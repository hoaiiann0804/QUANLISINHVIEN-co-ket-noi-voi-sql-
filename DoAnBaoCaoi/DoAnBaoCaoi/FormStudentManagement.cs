using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnBaoCaoi
{
    public partial class FormStudentManagement : Form
    {
        private List<SinhVien> studentList = new List<SinhVien>();
        private SqlConnection connection;

        public FormStudentManagement()
        {
            InitializeComponent();
            // Kết nối đến cơ sở dữ liệu
            connection = new SqlConnection("Data Source=HOAIAN\\SQLEXPRESS01;Initial Catalog=QuanLySinhVien;Integrated Security=True");
            LoadStudentData();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            tbId.ReadOnly = false; // Cho phép nhập mã sinh viên mới

            if (!ValidateInput()) return;

            // Tạo sinh viên mới
            SinhVien newStudent = new SinhVien
            {
                Mssv = tbId.Text,
                HoTen = tbName.Text,
                Tuoi = CalculateAge(dtpBirthDate.Value),
                GioiTinh = rbNam.Checked ? "Nam" : "Nữ",
                NgaySinh = dtpBirthDate.Value,
                Khoa = cbDepartment.SelectedItem.ToString(),
                DuongDanHinh = pbStudentImage.ImageLocation
            };

            // Thêm sinh viên vào cơ sở dữ liệu
            AddStudentToDatabase(newStudent);
            studentList.Add(newStudent);
            LoadStudentData();
            ClearInputFields();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0) return;

            if (!ValidateInput()) return;

            // Cập nhật thông tin sinh viên
            int index = dgvStudent.SelectedRows[0].Index;
            SinhVien studentToEdit = studentList[index];

            // Không cho sửa mã sinh viên
            studentToEdit.HoTen = tbName.Text;
            studentToEdit.Tuoi = CalculateAge(dtpBirthDate.Value);
            studentToEdit.GioiTinh = rbNam.Checked ? "Nam" : "Nữ";
            studentToEdit.NgaySinh = dtpBirthDate.Value;
            studentToEdit.Khoa = cbDepartment.SelectedItem.ToString();
            studentToEdit.DuongDanHinh = pbStudentImage.ImageLocation;

            // Cập nhật sinh viên trong cơ sở dữ liệu
            UpdateStudentInDatabase(studentToEdit);
            LoadStudentData();
            ClearInputFields();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvStudent.SelectedRows.Count == 0) return;

            // Lấy mã sinh viên từ dòng được chọn
            var selectedRow = dgvStudent.SelectedRows[0];
            string mssvToDelete = selectedRow.Cells["Mssv"].Value.ToString();

            // Tìm sinh viên trong danh sách bằng mã số sinh viên
            SinhVien studentToDelete = studentList.FirstOrDefault(s => s.Mssv == mssvToDelete);

            if (studentToDelete != null)
            {
                // Xóa sinh viên khỏi danh sách hiển thị
                studentList.Remove(studentToDelete);

                // Xóa sinh viên khỏi cơ sở dữ liệu
                DeleteStudentFromDatabase(mssvToDelete);

                // Tải lại dữ liệu để cập nhật DataGridView
                LoadStudentData();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Sinh viên không tồn tại!");
            }
        }


        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = tbSearch.Text.ToLower();

            // Filter the list based on whether the search term appears in either Id or HoTen
            var filteredList = studentList.FindAll(s =>
                s.Mssv.ToLower().Contains(searchTerm) || s.HoTen.ToLower().Contains(searchTerm)
            );

            dgvStudent.DataSource = filteredList;
        }


        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedStudent = studentList[e.RowIndex];
                tbId.Text = selectedStudent.Mssv;
                tbId.ReadOnly = true; // Đặt mã sinh viên thành chỉ đọc
                tbName.Text = selectedStudent.HoTen;
                tbAge.Text = selectedStudent.Tuoi.ToString();
                dtpBirthDate.Value = selectedStudent.NgaySinh;
                rbNam.Checked = selectedStudent.GioiTinh == "Nam";
                rbNu.Checked = selectedStudent.GioiTinh == "Nữ"; // Đảm bảo rbNu tồn tại
                cbDepartment.SelectedItem = selectedStudent.Khoa;

                // Hiển thị hình ảnh
                if (!string.IsNullOrEmpty(selectedStudent.DuongDanHinh))
                {
                    pbStudentImage.ImageLocation = selectedStudent.DuongDanHinh;
                }
                else
                {
                    pbStudentImage.Image = null; // Nếu không có hình ảnh, đặt về null
                }
            }
        }

        private void btUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbStudentImage.ImageLocation = ofd.FileName;

                    // Đặt chế độ hiển thị hình ảnh để vừa khung
                    pbStudentImage.SizeMode = PictureBoxSizeMode.StretchImage; // Hoặc PictureBoxSizeMode.Zoom để giữ tỷ lệ
                }
            }
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            tbAge.Text = CalculateAge(dtpBirthDate.Value).ToString();
        }

        private void LoadStudentData()
        {
            studentList.Clear();
            string query = "SELECT * FROM SinhVien";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SinhVien student = new SinhVien
                {
                    Mssv = reader["Mssv"].ToString(),
                    HoTen = reader["HoTen"].ToString(),
                    Tuoi = (int)reader["Tuoi"],
                    GioiTinh = reader["GioiTinh"].ToString(),
                    NgaySinh = (DateTime)reader["NgaySinh"],
                    Khoa = reader["Khoa"].ToString(),
                    DuongDanHinh = reader["DuongDanHinh"] as string
                };
                studentList.Add(student);
            }

            connection.Close();
            dgvStudent.DataSource = null;
            dgvStudent.DataSource = studentList;
            dgvStudent.ReadOnly = true;
            dgvStudent.AllowUserToAddRows = true;

            
            foreach (DataGridViewColumn column in dgvStudent.Columns)
            {
                column.ReadOnly = false; // Đảm bảo tất cả các cột có thể chỉnh sửa
            }

        }

        private void ClearInputFields()
        {
            tbId.Clear();
            tbName.Clear();
            tbAge.Clear();
            rbNam.Checked = false;
            rbNu.Checked = false; // Đặt lại rbNu
            dtpBirthDate.Value = DateTime.Now;
            cbDepartment.SelectedIndex = -1; // Đặt lại ComboBox
            pbStudentImage.Image = null; // Đặt hình ảnh về null
            tbId.ReadOnly = false; // Đặt lại trạng thái để có thể nhập mã sinh viên mới
        }

        private bool ValidateInput()
        {
            // Kiểm tra thông tin Id, HoTen, Khoa
            if (string.IsNullOrWhiteSpace(tbId.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text) ||
                cbDepartment.SelectedIndex == -1 || // Kiểm tra chọn Khoa
                !(rbNam.Checked || rbNu.Checked)) // Ràng buộc giới tính
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin, bao gồm chọn giới tính!");
                return false;
            }

            // Kiểm tra ngày sinh
            if (!DateTime.TryParse(dtpBirthDate.Value.ToString(), out DateTime birthDate) ||
                birthDate > DateTime.Now.AddYears(-18)) // Kiểm tra tuổi
            {
                MessageBox.Show("Ngày sinh không hợp lệ hoặc sinh viên chưa đủ 18 tuổi!");
                return false;
            }

            // Kiểm tra độ dài Id
            if (tbId.Text.Length != 10)
            {
                MessageBox.Show("Id phải có độ dài 10 ký tự!");
                return false;
            }

            // Kiểm tra hình ảnh
            if (pbStudentImage.Image == null)
            {
                MessageBox.Show("Vui lòng tải lên hình ảnh cho sinh viên!");
                return false;
            }

            return true;
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age)) age--;
            return age;
        }

        private void AddStudentToDatabase(SinhVien student)
        {
            string query = "INSERT INTO SinhVien (Mssv, HoTen, Tuoi, GioiTinh, NgaySinh, Khoa, DuongDanHinh) VALUES (@Mssv, @HoTen, @Tuoi, @GioiTinh, @NgaySinh, @Khoa, @DuongDanHinh)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Mssv", student.Mssv);
            command.Parameters.AddWithValue("@HoTen", student.HoTen);
            command.Parameters.AddWithValue("@Tuoi", student.Tuoi);
            command.Parameters.AddWithValue("@GioiTinh", student.GioiTinh);
            command.Parameters.AddWithValue("@NgaySinh", student.NgaySinh);
            command.Parameters.AddWithValue("@Khoa", student.Khoa);
            command.Parameters.AddWithValue("@DuongDanHinh", (object)student.DuongDanHinh ?? DBNull.Value);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UpdateStudentInDatabase(SinhVien student)
        {
            string query = "UPDATE SinhVien SET HoTen = @HoTen, Tuoi = @Tuoi, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, Khoa = @Khoa, DuongDanHinh = @DuongDanHinh WHERE Mssv = @Mssv";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Mssv", student.Mssv);
            command.Parameters.AddWithValue("@HoTen", student.HoTen);
            command.Parameters.AddWithValue("@Tuoi", student.Tuoi);
            command.Parameters.AddWithValue("@GioiTinh", student.GioiTinh);
            command.Parameters.AddWithValue("@NgaySinh", student.NgaySinh);
            command.Parameters.AddWithValue("@Khoa", student.Khoa);
            command.Parameters.AddWithValue("@DuongDanHinh", (object)student.DuongDanHinh ?? DBNull.Value);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void DeleteStudentFromDatabase(string id)
        {
            string query = "DELETE FROM SinhVien WHERE Mssv = @Mssv";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Mssv", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class SinhVien
    {
        public string Mssv { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Khoa { get; set; }
        public string DuongDanHinh { get; set; }
    }
}

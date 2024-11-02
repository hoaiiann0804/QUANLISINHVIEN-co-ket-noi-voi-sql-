using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DoAnBaoCaoi
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường đã được nhập
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!");
                return;
            }

            // Chuỗi kết nối
            string connectionString = "Data Source=HOAIAN\\SQLEXPRESS01;Initial Catalog=UserRegistrationDB;User ID=sa;Password=12345678";

            // Hash mật khẩu
            string passwordHash = HashPassword(txtPassword.Text);

            // Câu truy vấn SQL để kiểm tra thông tin đăng nhập
            string query = "SELECT COUNT(1) FROM Customer WHERE Username = @Username AND PasswordHash = @PasswordHash";

            // Kết nối đến cơ sở dữ liệu và kiểm tra thông tin người dùng
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", txtUsername.Text);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                try
                {
                    connection.Open();
                    int result = (int)command.ExecuteScalar();

                    if (result == 1)
                    {
                        FormStudentManagement formStudentManagement = new FormStudentManagement();
                        formStudentManagement.Show();
                        this.Hide(); // Ẩn form đăng nhập
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        // Hàm để hash mật khẩu với SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}

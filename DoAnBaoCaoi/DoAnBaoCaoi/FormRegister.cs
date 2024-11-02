using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DoAnBaoCaoi
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        // Click event handler for the Register button
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            // Check if passwords match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
                return;
            }

            // Check for minimum password length
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 6 ký tự!");
                return;
            }

            // Hash the password
            string passwordHash = HashPassword(txtPassword.Text);

            // Database connection string
            string connectionString = "Data Source=HOAIAN\\SQLEXPRESS01;Initial Catalog=UserRegistrationDB;User ID=sa;Password=12345678";

            // SQL query to insert data
            string query = "INSERT INTO Customer (Username, PasswordHash) VALUES (@Username, @PasswordHash)";

            // Connect to the database and insert data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", txtUsername.Text);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công!");

                    // Redirect to the login form
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Hide();
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show("Tên người dùng đã tồn tại. Vui lòng chọn tên khác.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        // Method to hash passwords using SHA256
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

        // Click event handler for the Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}

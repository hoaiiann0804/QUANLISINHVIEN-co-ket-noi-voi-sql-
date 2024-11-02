namespace DoAnBaoCaoi
{
    partial class FormStudentManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblId;
        private Label lblName;
        private Label lblAge;
        private Label lblGender;
        private Label lblBirthDate;
        private Label lblSearch;
        private TextBox tbId;
        private TextBox tbName;
        private TextBox tbAge;
        private DateTimePicker dtpBirthDate;
        private RadioButton rbNam;
        private RadioButton rbNu;
        private PictureBox pbStudentImage;
        private Button btUploadImage;
        private Button btNew;
        private Button btDelete;
        private Button btEdit;
        private Button btExit;
        private DataGridView dgvStudent;
        private TextBox tbSearch;
        private Button btSearch;
        private Label lblDepartment; // Thêm label cho Khoa
        private ComboBox cbDepartment; // Thêm ComboBox cho Khoa
        private GroupBox gbGender; // Thêm GroupBox cho giới tính

        private void InitializeComponent()
        {
            lblId = new Label();
            lblName = new Label();
            lblAge = new Label();
            lblGender = new Label();
            lblBirthDate = new Label();
            lblSearch = new Label();
            tbId = new TextBox();
            tbName = new TextBox();
            tbAge = new TextBox();
            dtpBirthDate = new DateTimePicker();
            rbNam = new RadioButton();
            rbNu = new RadioButton();
            pbStudentImage = new PictureBox();
            btUploadImage = new Button();
            btNew = new Button();
            btDelete = new Button();
            btEdit = new Button();
            btExit = new Button();
            dgvStudent = new DataGridView();
            tbSearch = new TextBox();
            btSearch = new Button();
            lblDepartment = new Label();
            cbDepartment = new ComboBox();
            gbGender = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pbStudentImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).BeginInit();
            gbGender.SuspendLayout();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.Location = new Point(20, 20);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 23);
            lblId.TabIndex = 0;
            lblId.Text = "Mã sinh viên";
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 60);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Họ tên";
            // 
            // lblAge
            // 
            lblAge.Location = new Point(20, 100);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(100, 23);
            lblAge.TabIndex = 4;
            lblAge.Text = "Tuổi";
            // 
            // lblGender
            // 
            lblGender.Location = new Point(20, 180);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(100, 23);
            lblGender.TabIndex = 8;
            lblGender.Text = "Giới tính";
            // 
            // lblBirthDate
            // 
            lblBirthDate.Location = new Point(20, 140);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(100, 23);
            lblBirthDate.TabIndex = 6;
            lblBirthDate.Text = "Ngày sinh";
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(20, 370);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(100, 23);
            lblSearch.TabIndex = 18;
            lblSearch.Text = "Tìm kiếm";
            // 
            // tbId
            // 
            tbId.Location = new Point(120, 20);
            tbId.Name = "tbId";
            tbId.Size = new Size(200, 27);
            tbId.TabIndex = 1;
            // 
            // tbName
            // 
            tbName.Location = new Point(120, 60);
            tbName.Name = "tbName";
            tbName.Size = new Size(200, 27);
            tbName.TabIndex = 3;
            // 
            // tbAge
            // 
            tbAge.Location = new Point(120, 100);
            tbAge.Name = "tbAge";
            tbAge.ReadOnly = true;
            tbAge.Size = new Size(200, 27);
            tbAge.TabIndex = 5;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(120, 140);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 27);
            dtpBirthDate.TabIndex = 7;
            dtpBirthDate.ValueChanged += dtpBirthDate_ValueChanged;
            // 
            // rbNam
            // 
            rbNam.Location = new Point(10, 20);
            rbNam.Name = "rbNam";
            rbNam.Size = new Size(104, 24);
            rbNam.TabIndex = 0;
            rbNam.Text = "Nam";
            // 
            // rbNu
            // 
            rbNu.Location = new Point(10, 50);
            rbNu.Name = "rbNu";
            rbNu.Size = new Size(104, 24);
            rbNu.TabIndex = 1;
            rbNu.Text = "Nữ";
            // 
            // pbStudentImage
            // 
            pbStudentImage.BorderStyle = BorderStyle.FixedSingle;
            pbStudentImage.Location = new Point(505, 12);
            pbStudentImage.Name = "pbStudentImage";
            pbStudentImage.Size = new Size(150, 150);
            pbStudentImage.TabIndex = 12;
            pbStudentImage.TabStop = false;
            // 
            // btUploadImage
            // 
            btUploadImage.BackColor = Color.LightGray;
            btUploadImage.Location = new Point(534, 180);
            btUploadImage.Name = "btUploadImage";
            btUploadImage.Size = new Size(75, 23);
            btUploadImage.TabIndex = 13;
            btUploadImage.Text = "Tải ảnh lên";
            btUploadImage.UseVisualStyleBackColor = false;
            btUploadImage.Click += btUploadImage_Click;
            // 
            // btNew
            // 
            btNew.BackColor = Color.LightGreen;
            btNew.Location = new Point(20, 330);
            btNew.Name = "btNew";
            btNew.Size = new Size(75, 23);
            btNew.TabIndex = 14;
            btNew.Text = "Thêm mới";
            btNew.UseVisualStyleBackColor = false;
            btNew.Click += btNew_Click;
            // 
            // btDelete
            // 
            btDelete.BackColor = Color.LightCoral;
            btDelete.Location = new Point(120, 330);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(75, 23);
            btDelete.TabIndex = 15;
            btDelete.Text = "Xóa";
            btDelete.UseVisualStyleBackColor = false;
            btDelete.Click += btDelete_Click;
            // 
            // btEdit
            // 
            btEdit.BackColor = Color.LightYellow;
            btEdit.Location = new Point(220, 330);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(75, 23);
            btEdit.TabIndex = 16;
            btEdit.Text = "Sửa";
            btEdit.UseVisualStyleBackColor = false;
            btEdit.Click += btEdit_Click;
            // 
            // btExit
            // 
            btExit.BackColor = Color.LightPink;
            btExit.Location = new Point(320, 330);
            btExit.Name = "btExit";
            btExit.Size = new Size(75, 23);
            btExit.TabIndex = 17;
            btExit.Text = "Thoát";
            btExit.UseVisualStyleBackColor = false;
            btExit.Click += btExit_Click;
            // 
            // dgvStudent
            // 
            dgvStudent.ColumnHeadersHeight = 29;
            dgvStudent.Location = new Point(20, 410);
            dgvStudent.Name = "dgvStudent";
            dgvStudent.RowHeadersWidth = 51;
            dgvStudent.Size = new Size(700, 150);
            dgvStudent.TabIndex = 21;
            dgvStudent.CellClick += dgvStudent_CellClick;
            dgvStudent.CellContentClick += dgvStudent_CellContentClick;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(120, 370);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(200, 27);
            tbSearch.TabIndex = 19;
            // 
            // btSearch
            // 
            btSearch.BackColor = Color.LightGoldenrodYellow;
            btSearch.Location = new Point(350, 370);
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(75, 23);
            btSearch.TabIndex = 20;
            btSearch.Text = "Tìm";
            btSearch.UseVisualStyleBackColor = false;
            btSearch.Click += btSearch_Click;
            // 
            // lblDepartment
            // 
            lblDepartment.Location = new Point(20, 290);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(100, 23);
            lblDepartment.TabIndex = 10;
            lblDepartment.Text = "Khoa";
            // 
            // cbDepartment
            // 
            cbDepartment.Items.AddRange(new object[] { "Khoa Công Nghệ Thông Tin", "Khoa Khoa học máy tính", "Khoa Kinh Tế", "Khoa Ngoại Ngữ", "Khoa Quản Trị Kinh Doanh", "Khoa Cơ khí" });
            cbDepartment.Location = new Point(120, 290);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(200, 28);
            cbDepartment.TabIndex = 11;
            // 
            // gbGender
            // 
            gbGender.BackColor = Color.LightCyan;
            gbGender.Controls.Add(rbNam);
            gbGender.Controls.Add(rbNu);
            gbGender.Location = new Point(120, 200);
            gbGender.Name = "gbGender";
            gbGender.Size = new Size(200, 80);
            gbGender.TabIndex = 9;
            gbGender.TabStop = false;
            gbGender.Text = "Giới tính";
            // 
            // FormStudentManagement
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(782, 653);
            Controls.Add(lblId);
            Controls.Add(tbId);
            Controls.Add(lblName);
            Controls.Add(tbName);
            Controls.Add(lblAge);
            Controls.Add(tbAge);
            Controls.Add(lblBirthDate);
            Controls.Add(dtpBirthDate);
            Controls.Add(lblGender);
            Controls.Add(gbGender);
            Controls.Add(lblDepartment);
            Controls.Add(cbDepartment);
            Controls.Add(pbStudentImage);
            Controls.Add(btUploadImage);
            Controls.Add(btNew);
            Controls.Add(btDelete);
            Controls.Add(btEdit);
            Controls.Add(btExit);
            Controls.Add(lblSearch);
            Controls.Add(tbSearch);
            Controls.Add(btSearch);
            Controls.Add(dgvStudent);
            Name = "FormStudentManagement";
            Text = "Quản lý sinh viên";
            ((System.ComponentModel.ISupportInitialize)pbStudentImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).EndInit();
            gbGender.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

namespace Builder
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxConnList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.btnAddConn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.table_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.txtModelUsing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModelNamespace = new System.Windows.Forms.TextBox();
            this.txtBLLUsing = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateBLL = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBLLNamespace = new System.Windows.Forms.TextBox();
            this.txtDALUsing = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreateDAL = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDALNamespace = new System.Windows.Forms.TextBox();
            this.txtModelSuffix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBLLSuffix = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDALSuffix = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDeleteConn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbnMSSQL = new System.Windows.Forms.RadioButton();
            this.rbnMySQL = new System.Windows.Forms.RadioButton();
            this.btnAllOutPut = new System.Windows.Forms.Button();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.txtServiceUsing = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCreateIService = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtServiceSuffix = new System.Windows.Forms.TextBox();
            this.txtServiceNamespace = new System.Windows.Forms.TextBox();
            this.txtRepositoryUsing = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCreateIRepository = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtRepositorySuffix = new System.Windows.Forms.TextBox();
            this.txtRepositoryNamespace = new System.Windows.Forms.TextBox();
            this.txtControllerUsing = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnCreateController = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtControllerSuffix = new System.Windows.Forms.TextBox();
            this.txtControllerNamespace = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxConnList
            // 
            this.cbxConnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConnList.FormattingEnabled = true;
            this.cbxConnList.Location = new System.Drawing.Point(104, 6);
            this.cbxConnList.Name = "cbxConnList";
            this.cbxConnList.Size = new System.Drawing.Size(726, 20);
            this.cbxConnList.TabIndex = 0;
            this.cbxConnList.SelectedIndexChanged += new System.EventHandler(this.cbxConnList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择数据库连接";
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(104, 32);
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(726, 21);
            this.txtConn.TabIndex = 2;
            // 
            // btnAddConn
            // 
            this.btnAddConn.Location = new System.Drawing.Point(836, 4);
            this.btnAddConn.Name = "btnAddConn";
            this.btnAddConn.Size = new System.Drawing.Size(75, 23);
            this.btnAddConn.TabIndex = 3;
            this.btnAddConn.Text = "新增";
            this.btnAddConn.UseVisualStyleBackColor = true;
            this.btnAddConn.Click += new System.EventHandler(this.btnAddConn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "输入数据库连接";
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(237, 59);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 6;
            this.btnConn.Text = "连接";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.table_name,
            this.table_comment});
            this.dataGridView1.Location = new System.Drawing.Point(100, 475);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(807, 323);
            this.dataGridView1.TabIndex = 7;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "#";
            this.Selected.Name = "Selected";
            this.Selected.Width = 40;
            // 
            // table_name
            // 
            this.table_name.DataPropertyName = "table_name";
            this.table_name.HeaderText = "表名";
            this.table_name.Name = "table_name";
            this.table_name.Width = 400;
            // 
            // table_comment
            // 
            this.table_comment.DataPropertyName = "table_comment";
            this.table_comment.HeaderText = "表描述";
            this.table_comment.Name = "table_comment";
            this.table_comment.Width = 305;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(638, 59);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // txtModelUsing
            // 
            this.txtModelUsing.Location = new System.Drawing.Point(104, 88);
            this.txtModelUsing.Multiline = true;
            this.txtModelUsing.Name = "txtModelUsing";
            this.txtModelUsing.Size = new System.Drawing.Size(228, 56);
            this.txtModelUsing.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "namespace";
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Location = new System.Drawing.Point(836, 102);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(75, 22);
            this.btnCreateModel.TabIndex = 9;
            this.btnCreateModel.Text = "生成Model";
            this.btnCreateModel.UseVisualStyleBackColor = true;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "using";
            // 
            // txtModelNamespace
            // 
            this.txtModelNamespace.Location = new System.Drawing.Point(425, 102);
            this.txtModelNamespace.Name = "txtModelNamespace";
            this.txtModelNamespace.Size = new System.Drawing.Size(172, 21);
            this.txtModelNamespace.TabIndex = 11;
            this.txtModelNamespace.Text = "Model";
            // 
            // txtBLLUsing
            // 
            this.txtBLLUsing.Location = new System.Drawing.Point(104, 150);
            this.txtBLLUsing.Multiline = true;
            this.txtBLLUsing.Name = "txtBLLUsing";
            this.txtBLLUsing.Size = new System.Drawing.Size(228, 56);
            this.txtBLLUsing.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "namespace";
            // 
            // btnCreateBLL
            // 
            this.btnCreateBLL.Location = new System.Drawing.Point(836, 164);
            this.btnCreateBLL.Name = "btnCreateBLL";
            this.btnCreateBLL.Size = new System.Drawing.Size(75, 24);
            this.btnCreateBLL.TabIndex = 14;
            this.btnCreateBLL.Text = "生成BLL";
            this.btnCreateBLL.UseVisualStyleBackColor = true;
            this.btnCreateBLL.Click += new System.EventHandler(this.btnCreateBLL_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "using";
            // 
            // txtBLLNamespace
            // 
            this.txtBLLNamespace.Location = new System.Drawing.Point(425, 164);
            this.txtBLLNamespace.Name = "txtBLLNamespace";
            this.txtBLLNamespace.Size = new System.Drawing.Size(172, 21);
            this.txtBLLNamespace.TabIndex = 16;
            this.txtBLLNamespace.Text = "BLL";
            // 
            // txtDALUsing
            // 
            this.txtDALUsing.Location = new System.Drawing.Point(104, 212);
            this.txtDALUsing.Multiline = true;
            this.txtDALUsing.Name = "txtDALUsing";
            this.txtDALUsing.Size = new System.Drawing.Size(228, 56);
            this.txtDALUsing.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "namespace";
            // 
            // btnCreateDAL
            // 
            this.btnCreateDAL.Location = new System.Drawing.Point(836, 227);
            this.btnCreateDAL.Name = "btnCreateDAL";
            this.btnCreateDAL.Size = new System.Drawing.Size(75, 24);
            this.btnCreateDAL.TabIndex = 19;
            this.btnCreateDAL.Text = "生成DAL";
            this.btnCreateDAL.UseVisualStyleBackColor = true;
            this.btnCreateDAL.Click += new System.EventHandler(this.btnCreateDAL_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "using";
            // 
            // txtDALNamespace
            // 
            this.txtDALNamespace.Location = new System.Drawing.Point(425, 227);
            this.txtDALNamespace.Name = "txtDALNamespace";
            this.txtDALNamespace.Size = new System.Drawing.Size(172, 21);
            this.txtDALNamespace.TabIndex = 21;
            this.txtDALNamespace.Text = "DAL";
            // 
            // txtModelSuffix
            // 
            this.txtModelSuffix.Location = new System.Drawing.Point(658, 103);
            this.txtModelSuffix.Name = "txtModelSuffix";
            this.txtModelSuffix.Size = new System.Drawing.Size(172, 21);
            this.txtModelSuffix.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(623, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "后缀";
            // 
            // txtBLLSuffix
            // 
            this.txtBLLSuffix.Location = new System.Drawing.Point(658, 167);
            this.txtBLLSuffix.Name = "txtBLLSuffix";
            this.txtBLLSuffix.Size = new System.Drawing.Size(172, 21);
            this.txtBLLSuffix.TabIndex = 16;
            this.txtBLLSuffix.Text = "BLL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(623, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "后缀";
            // 
            // txtDALSuffix
            // 
            this.txtDALSuffix.Location = new System.Drawing.Point(658, 230);
            this.txtDALSuffix.Name = "txtDALSuffix";
            this.txtDALSuffix.Size = new System.Drawing.Size(172, 21);
            this.txtDALSuffix.TabIndex = 21;
            this.txtDALSuffix.Text = "DAL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(623, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "后缀";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(369, 61);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(171, 21);
            this.txtKeyword.TabIndex = 24;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(322, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "关键词";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(557, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDeleteConn
            // 
            this.btnDeleteConn.Location = new System.Drawing.Point(836, 32);
            this.btnDeleteConn.Name = "btnDeleteConn";
            this.btnDeleteConn.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteConn.TabIndex = 27;
            this.btnDeleteConn.Text = "删除";
            this.btnDeleteConn.UseVisualStyleBackColor = true;
            this.btnDeleteConn.Click += new System.EventHandler(this.btnDeleteConn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "数据库类型";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbnMSSQL);
            this.panel1.Controls.Add(this.rbnMySQL);
            this.panel1.Location = new System.Drawing.Point(104, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 24);
            this.panel1.TabIndex = 30;
            // 
            // rbnMSSQL
            // 
            this.rbnMSSQL.AutoSize = true;
            this.rbnMSSQL.Location = new System.Drawing.Point(62, 5);
            this.rbnMSSQL.Name = "rbnMSSQL";
            this.rbnMSSQL.Size = new System.Drawing.Size(53, 16);
            this.rbnMSSQL.TabIndex = 33;
            this.rbnMSSQL.Tag = "System.Data.SqlClient";
            this.rbnMSSQL.Text = "MSSQL";
            this.rbnMSSQL.UseVisualStyleBackColor = true;
            // 
            // rbnMySQL
            // 
            this.rbnMySQL.AutoSize = true;
            this.rbnMySQL.Checked = true;
            this.rbnMySQL.Location = new System.Drawing.Point(3, 5);
            this.rbnMySQL.Name = "rbnMySQL";
            this.rbnMySQL.Size = new System.Drawing.Size(53, 16);
            this.rbnMySQL.TabIndex = 32;
            this.rbnMySQL.TabStop = true;
            this.rbnMySQL.Tag = "MySql.Data.MySqlClient";
            this.rbnMySQL.Text = "MySQL";
            this.rbnMySQL.UseVisualStyleBackColor = true;
            // 
            // btnAllOutPut
            // 
            this.btnAllOutPut.Location = new System.Drawing.Point(719, 59);
            this.btnAllOutPut.Name = "btnAllOutPut";
            this.btnAllOutPut.Size = new System.Drawing.Size(75, 23);
            this.btnAllOutPut.TabIndex = 31;
            this.btnAllOutPut.Text = "全部生成";
            this.btnAllOutPut.UseVisualStyleBackColor = true;
            this.btnAllOutPut.Click += new System.EventHandler(this.btnAllOutPut_Click);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Location = new System.Drawing.Point(836, 57);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPath.TabIndex = 32;
            this.btnOpenPath.Text = "打開目錄";
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // txtServiceUsing
            // 
            this.txtServiceUsing.Location = new System.Drawing.Point(104, 274);
            this.txtServiceUsing.Multiline = true;
            this.txtServiceUsing.Name = "txtServiceUsing";
            this.txtServiceUsing.Size = new System.Drawing.Size(228, 56);
            this.txtServiceUsing.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(623, 297);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 38;
            this.label14.Text = "后缀";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(360, 292);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 39;
            this.label15.Text = "namespace";
            // 
            // btnCreateIService
            // 
            this.btnCreateIService.Location = new System.Drawing.Point(836, 289);
            this.btnCreateIService.Name = "btnCreateIService";
            this.btnCreateIService.Size = new System.Drawing.Size(75, 24);
            this.btnCreateIService.TabIndex = 33;
            this.btnCreateIService.Text = "生成IBLL";
            this.btnCreateIService.UseVisualStyleBackColor = true;
            this.btnCreateIService.Click += new System.EventHandler(this.btnCreateIService_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(63, 294);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "using";
            // 
            // txtServiceSuffix
            // 
            this.txtServiceSuffix.Location = new System.Drawing.Point(658, 292);
            this.txtServiceSuffix.Name = "txtServiceSuffix";
            this.txtServiceSuffix.Size = new System.Drawing.Size(172, 21);
            this.txtServiceSuffix.TabIndex = 35;
            this.txtServiceSuffix.Text = "Service";
            // 
            // txtServiceNamespace
            // 
            this.txtServiceNamespace.Location = new System.Drawing.Point(425, 289);
            this.txtServiceNamespace.Name = "txtServiceNamespace";
            this.txtServiceNamespace.Size = new System.Drawing.Size(172, 21);
            this.txtServiceNamespace.TabIndex = 36;
            this.txtServiceNamespace.Text = "IService";
            // 
            // txtRepositoryUsing
            // 
            this.txtRepositoryUsing.Location = new System.Drawing.Point(104, 336);
            this.txtRepositoryUsing.Multiline = true;
            this.txtRepositoryUsing.Name = "txtRepositoryUsing";
            this.txtRepositoryUsing.Size = new System.Drawing.Size(228, 56);
            this.txtRepositoryUsing.TabIndex = 41;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(623, 359);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 45;
            this.label17.Text = "后缀";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(360, 354);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 46;
            this.label18.Text = "namespace";
            // 
            // btnCreateIRepository
            // 
            this.btnCreateIRepository.Location = new System.Drawing.Point(836, 351);
            this.btnCreateIRepository.Name = "btnCreateIRepository";
            this.btnCreateIRepository.Size = new System.Drawing.Size(75, 24);
            this.btnCreateIRepository.TabIndex = 40;
            this.btnCreateIRepository.Text = "生成IDAL";
            this.btnCreateIRepository.UseVisualStyleBackColor = true;
            this.btnCreateIRepository.Click += new System.EventHandler(this.btnCreateIRepository_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(63, 356);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 44;
            this.label19.Text = "using";
            // 
            // txtRepositorySuffix
            // 
            this.txtRepositorySuffix.Location = new System.Drawing.Point(658, 354);
            this.txtRepositorySuffix.Name = "txtRepositorySuffix";
            this.txtRepositorySuffix.Size = new System.Drawing.Size(172, 21);
            this.txtRepositorySuffix.TabIndex = 42;
            this.txtRepositorySuffix.Text = "Repository";
            // 
            // txtRepositoryNamespace
            // 
            this.txtRepositoryNamespace.Location = new System.Drawing.Point(425, 351);
            this.txtRepositoryNamespace.Name = "txtRepositoryNamespace";
            this.txtRepositoryNamespace.Size = new System.Drawing.Size(172, 21);
            this.txtRepositoryNamespace.TabIndex = 43;
            this.txtRepositoryNamespace.Text = "IRepository";
            // 
            // txtControllerUsing
            // 
            this.txtControllerUsing.Location = new System.Drawing.Point(107, 398);
            this.txtControllerUsing.Multiline = true;
            this.txtControllerUsing.Name = "txtControllerUsing";
            this.txtControllerUsing.Size = new System.Drawing.Size(228, 56);
            this.txtControllerUsing.TabIndex = 48;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(626, 421);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 52;
            this.label20.Text = "后缀";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(363, 416);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 12);
            this.label21.TabIndex = 53;
            this.label21.Text = "namespace";
            // 
            // btnCreateController
            // 
            this.btnCreateController.Location = new System.Drawing.Point(839, 413);
            this.btnCreateController.Name = "btnCreateController";
            this.btnCreateController.Size = new System.Drawing.Size(75, 24);
            this.btnCreateController.TabIndex = 47;
            this.btnCreateController.Text = "生成控制器";
            this.btnCreateController.UseVisualStyleBackColor = true;
            this.btnCreateController.Click += new System.EventHandler(this.btnCreateController_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(66, 418);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 12);
            this.label22.TabIndex = 51;
            this.label22.Text = "using";
            // 
            // txtControllerSuffix
            // 
            this.txtControllerSuffix.Location = new System.Drawing.Point(661, 416);
            this.txtControllerSuffix.Name = "txtControllerSuffix";
            this.txtControllerSuffix.Size = new System.Drawing.Size(172, 21);
            this.txtControllerSuffix.TabIndex = 49;
            this.txtControllerSuffix.Text = "Repository";
            // 
            // txtControllerNamespace
            // 
            this.txtControllerNamespace.Location = new System.Drawing.Point(428, 413);
            this.txtControllerNamespace.Name = "txtControllerNamespace";
            this.txtControllerNamespace.Size = new System.Drawing.Size(172, 21);
            this.txtControllerNamespace.TabIndex = 50;
            this.txtControllerNamespace.Text = "IRepository";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 905);
            this.Controls.Add(this.txtControllerUsing);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnCreateController);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtControllerSuffix);
            this.Controls.Add(this.txtControllerNamespace);
            this.Controls.Add(this.txtRepositoryUsing);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnCreateIRepository);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtRepositorySuffix);
            this.Controls.Add(this.txtRepositoryNamespace);
            this.Controls.Add(this.txtServiceUsing);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnCreateIService);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtServiceSuffix);
            this.Controls.Add(this.txtServiceNamespace);
            this.Controls.Add(this.btnOpenPath);
            this.Controls.Add(this.btnAllOutPut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnDeleteConn);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.txtDALUsing);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCreateDAL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDALSuffix);
            this.Controls.Add(this.txtDALNamespace);
            this.Controls.Add(this.txtBLLUsing);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateBLL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBLLSuffix);
            this.Controls.Add(this.txtBLLNamespace);
            this.Controls.Add(this.txtModelUsing);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreateModel);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtModelSuffix);
            this.Controls.Add(this.txtModelNamespace);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddConn);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxConnList);
            this.Name = "Form1";
            this.Text = "PetaPoco MsSQL&MySQL CodeGenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxConnList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.Button btnAddConn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.TextBox txtModelUsing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModelNamespace;
        private System.Windows.Forms.TextBox txtBLLUsing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateBLL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBLLNamespace;
        private System.Windows.Forms.TextBox txtDALUsing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateDAL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDALNamespace;
        private System.Windows.Forms.TextBox txtModelSuffix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBLLSuffix;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDALSuffix;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_comment;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDeleteConn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbnMSSQL;
        private System.Windows.Forms.RadioButton rbnMySQL;
        private System.Windows.Forms.Button btnAllOutPut;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.TextBox txtServiceUsing;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCreateIService;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtServiceSuffix;
        private System.Windows.Forms.TextBox txtServiceNamespace;
        private System.Windows.Forms.TextBox txtRepositoryUsing;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCreateIRepository;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtRepositorySuffix;
        private System.Windows.Forms.TextBox txtRepositoryNamespace;
        private System.Windows.Forms.TextBox txtControllerUsing;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnCreateController;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtControllerSuffix;
        private System.Windows.Forms.TextBox txtControllerNamespace;
    }
}


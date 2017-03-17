using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Common;

using PetaPoco;
using System.Globalization;
using System.Threading;

namespace Builder
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> pathDict;
        public void InitPath()
        {
            pathDict = new Dictionary<string, string>();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //生成目录位置
            pathDict.Add("bllOutPut", baseDirectory + @"\output\");
            pathDict.Add("controllerOutPut", baseDirectory + @"\output\");
            pathDict.Add("dalOutPut", baseDirectory + @"\output\");
            pathDict.Add("irepositoryOutPut", baseDirectory + @"\output\");
            pathDict.Add("iserviceOutPut", baseDirectory + @"\output\");
            pathDict.Add("modelOutPut", baseDirectory + @"\output\");

            //pathDict.Add("bllOutPut", baseDirectory + @"\bll\");
            //pathDict.Add("controllerOutPut", baseDirectory + @"\controller\");
            //pathDict.Add("dalOutPut", baseDirectory + @"\dal\");
            //pathDict.Add("irepositoryOutPut", baseDirectory + @"\irepository\");
            //pathDict.Add("iserviceOutPut", baseDirectory + @"\iservice\");
            //pathDict.Add("modelOutPut", baseDirectory + @"\model\");


            //模板位置
            pathDict.Add("bllTemplate", baseDirectory + @"\template\bll.txt");
            pathDict.Add("controllerTemplate", baseDirectory + @"\template\mvc\controller.txt");
            pathDict.Add("domainModelTemplate", baseDirectory + @"\template\mvc\domainmodel.txt");
            pathDict.Add("indexHtmlTemplate", baseDirectory + @"\template\cshtml\index.cshtml.txt");
            pathDict.Add("addHtmlTemplate", baseDirectory + @"\template\cshtml\add.cshtml.txt");
            pathDict.Add("dalTemplate", baseDirectory + @"\template\dal.txt");
            pathDict.Add("irepositoryTemplate", baseDirectory + @"\template\irepository.txt");
            pathDict.Add("iserviceTemplate", baseDirectory + @"\template\iservice.txt");
            pathDict.Add("modelTemplate", baseDirectory + @"\template\model.txt");

        }
        #region 临时类
        [Serializable]
        class ListItem
        {
            public string Text { get; set; }

            public ListItem(string text)
            {
                this.Text = text;
            }

            public override string ToString()
            {
                return this.Text.ToString();
            }
        }
        #endregion

        #region 首字母大写
        /// <summary>
        /// 首字母大寫
        /// </summary>
        private string FirstCharUpper(string str)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo ti = cultureInfo.TextInfo;

            if (string.IsNullOrEmpty(str)) return string.Empty;
            return ti.ToTitleCase(str);


            //var arr = str.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            //StringBuilder sb = new StringBuilder();
            //var list = arr.Select((s, index) => new { index, s });
            //foreach (var item in list)
            //{
            //    sb.Append(GetCharUpper(item.s));
            //    if (item.index != list.Count() - 1)
            //        sb.Append("_");
            //}
            //return sb.ToString();
        }

        //public string GetCharUpper(string str)
        //{
        //    if (string.IsNullOrEmpty(str)) return string.Empty;

        //    return string.Format("{0}{1}", str.ToCharArray().First().ToString().ToUpper(), str.Substring(1));
        //}
        #endregion

        #region 默认配置
        private void Init()
        {
            txtModelUsing.Text = "using DBUtility.PetaPoco;";
            txtBLLUsing.Text = "using DBUtility.PetaPoco;\r\nusing Common;\r\nusing IRepository;\r\nusing IService;\r\nusing Model;\r\nusing DomainModel;";
            txtDALUsing.Text = "using DBUtility.PetaPoco;\r\nusing DomainModel;\r\nusing IRepository;\r\nusing Model;";
            txtServiceUsing.Text = "using DomainModel;\r\nusing DBUtility.PetaPoco;\r\nusing Model;";
            txtRepositoryUsing.Text = "using DomainModel;\r\nusing DBUtility.PetaPoco;\r\nusing Model;";
            txtControllerUsing.Text = "using Common;\r\nusing CommonConfig;\r\nusing DomainModel;\r\nusing IService;\r\nusing Model;";

            txtModelNamespace.Text = "Model";
            txtBLLNamespace.Text = "BLL";
            txtDALNamespace.Text = "DAL";
            txtServiceNamespace.Text = "IService";
            txtRepositoryNamespace.Text = "IRepository";
            txtControllerNamespace.Text = "Web";

            txtModelSuffix.Text = "";
            txtBLLSuffix.Text = "BLL";
            txtDALSuffix.Text = "DAL";
            txtServiceSuffix.Text = "Service";
            txtRepositorySuffix.Text = "Repository";
            txtControllerSuffix.Text = "Controller";
        }
        #endregion

        #region 删除文件夹(包括非空文件夹)
        public static void DeleteFolder(string directoryPath)
        {
            List<string> list = new List<string>();
            try
            {
                list = Directory.GetFileSystemEntries(directoryPath).ToList();

                foreach (string d in list)
                {
                    if (File.Exists(d))
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);     //删除文件
                    }
                    else
                        DeleteFolder(d);    //删除文件夹
                }
                Directory.Delete(directoryPath);    //删除空文件夹
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 全部生成
        private void btnAllOutPut_Click(object sender, EventArgs e)
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var keys = pathDict.Keys.Where(s => s.EndsWith("OutPut", StringComparison.OrdinalIgnoreCase));
            foreach (string path in keys)//把之前的生成目录删除
            {
                DeleteFolder(pathDict[path]);
            }

            btnCreateModel.PerformClick();
            btnCreateBLL.PerformClick();
            btnCreateDAL.PerformClick();
            btnCreateIService.PerformClick();
            btnCreateIRepository.PerformClick();
            btnCreateController.PerformClick();
        }
        #endregion

        #region 生成Model
        /// <summary>
        /// 生成Model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }

            string strConn = this.txtConn.Text.Trim();
            if (string.IsNullOrEmpty(strConn))
            {
                return;
            }

            #region 获取数据库列
            DbProviderFactory dbProvider = null;
            DataTable colsDT = null;
            if (this.rbnMySQL.Checked)
            {
                #region MySql
                //MySql.Data.MySqlClient
                dbProvider = DbProviderFactories.GetFactory(this.rbnMySQL.Tag.ToString());
                //dbProvider = new MySql.Data.MySqlClient.MySqlClientFactory();
                Database db = new Database(strConn, dbProvider);

                //从information_schema中查询出了这张表的所有列,而不是根据某几个表来查,也可以吧,反正一般列也不多
                colsDT = db.GetDataTable("select table_name,column_name,data_type,column_type,character_maximum_length,column_default,is_nullable,column_key,extra,column_comment from INFORMATION_SCHEMA.COLUMNS where table_schema=@0;", GetDBName(strConn));
                #endregion
            }
            else
            {
                #region Sql Server
                //System.Data.SqlClient
                dbProvider = DbProviderFactories.GetFactory(this.rbnMSSQL.Tag.ToString());
                Database db = new Database(strConn, dbProvider);

                colsDT = db.GetDataTable("select o.name as table_name,c.name as column_name,t.name as data_type,'' as column_type,c.max_length as character_maximum_length," +
                    "s.text as column_default,c.is_nullable," +
                    "case " +
                    "    when exists" +
                    "    (" +
                    "        select 1 " +
                    "        from sys.objects x " +
                    "        join sys.indexes y on x.Type=N'PK' and x.Name=y.Name " +
                    "        join sysindexkeys z on z.ID=c.Object_id and z.indid=y.index_id and z.Colid=c.Column_id" +
                    "    ) then 'PRI' " +
                    "    else null " +
                    "end as column_key," +
                    "cast(is_identity as varchar) as extra," +
                    "e.[value] as column_comment " +
                    "from sys.columns c " +
                    "inner join sys.objects o on c.object_id=o.object_id " +
                    "left join sys.types t on c.user_type_id=t.user_type_id " +
                    "left join syscomments s on c.default_object_id=s.id " +
                    "left join sys.extended_properties e on e.major_id=o.object_id and e.minor_id=c.Column_id and e.class=1 " +
                    "where o.type='U' " +
                    "order by table_name,c.column_id;");
                #endregion
            }

            if (colsDT == null)
            {
                MessageBox.Show("获取数据库列失败，请重试。");
                return;
            }
            #endregion

            #region 垃圾变量
            DataRow[] drs = null;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string templateContent = File.ReadAllText(pathDict["modelTemplate"], Encoding.UTF8);
            string tempContent = null;

            DataGridViewCheckBoxCell checkBoxCell = null;
            bool isChecked;

            string tableName = null;
            string tableComment = null;
            string modelSuffix = this.txtModelSuffix.Text.Trim();

            string fieldName = null;//字段名
            string dataType = null;//数据类型
            string columnType = null;//列类型 类似int(10) unsigned这样
            object objDataLength = null;//数据长度
            long? dataLength = null;
            string strIsNullAble = null;//是否可为null YES=可不null NO=不可为null
            string keyType = null;//键类型 PRI=主键
            byte primaryKeyCount = 0;
            bool autoIncrement = false;

            string propertyName = null;//属性名
            string propertyComment = null;//属性描述

            string newLine = System.Environment.NewLine;
            char[] newLineArray = newLine.ToCharArray();
            string left = "{";
            string right = "}";
            string t = "\t";

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbPropertys = new StringBuilder();
            string path = pathDict["modelOutPut"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            #endregion

            #region 为每一个表生成一个文件
            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    primaryKeyCount = 0;
                    autoIncrement = false;

                    tableName = dgvr.Cells["table_name"].Value.ToString();
                    tableComment = dgvr.Cells["table_comment"].Value.ToString().Replace(newLine, string.Empty);

                    tempContent = templateContent;

                    tempContent = tempContent.Replace("[using]", this.txtModelUsing.Text.Trim());
                    tempContent = tempContent.Replace("[ModelNamespace]", this.txtModelNamespace.Text.Trim());

                    tempContent = tempContent.Replace("[表描述]", tableComment);
                    tempContent = tempContent.Replace("[TableName]", FirstCharUpper(tableName));
                    tempContent = tempContent.Replace("[ModelSuffix]", modelSuffix);

                    drs = colsDT.Select("table_name='" + tableName + "'");
                    foreach (DataRow dr in drs)
                    {
                        if (dr["column_key"].ToString() == "PRI")
                        {
                            if (dr["extra"].ToString() != string.Empty)
                            {
                                autoIncrement = true;
                            }
                            propertyName = dr["column_name"].ToString();
                            primaryKeyCount++;
                        }

                        if (primaryKeyCount > 1)
                        {
                            break;
                        }
                    }

                    if (primaryKeyCount == 1)
                    {
                        tempContent = tempContent.Replace("[PrimaryKeyName]", propertyName);
                    }
                    else if (primaryKeyCount > 1)
                    {
                        tempContent = tempContent.Replace("\"[PrimaryKeyName]\"", "null");
                    }

                    if (autoIncrement)//自动增长
                    {
                        tempContent = tempContent.Replace("[autoIncrement]", string.Empty);

                    }
                    else//非自动增长
                    {
                        tempContent = tempContent.Replace("[autoIncrement]", ", autoIncrement = false");
                    }

                    #region  替换string
                    foreach (DataRow dr in drs)
                    {
                        propertyName = dr["column_name"].ToString();

                        fieldName = propertyName.ToLower();
                        columnType = dr["column_type"].ToString();
                        dataType = DBDataTypeToCSharpDataType(dr["data_type"].ToString(), columnType.Contains("unsigned"));

                        objDataLength = dr["character_maximum_length"];
                        if (objDataLength != null && objDataLength != DBNull.Value)
                        {
                            dataLength = Convert.ToInt64(objDataLength);
                        }
                        else
                        {
                            dataLength = null;
                        }

                        strIsNullAble = dr["is_nullable"].ToString();
                        if (strIsNullAble == "YES" && (
                            dataType == "int" || dataType == "uint"
                            || dataType == "decimal"
                            || dataType == "DateTime"
                            || dataType == "bool"
                            || dataType == "long" || dataType == "ulong"
                            || dataType == "sbyte" || dataType == "byte"
                            || dataType == "short" || dataType == "ushort"
                            || dataType == "float"
                            || dataType == "double"
                            ))
                        {
                            strIsNullAble = "?";
                        }
                        else
                        {
                            strIsNullAble = string.Empty;
                        }

                        keyType = dr["column_key"].ToString();//是否是主键
                        if (keyType == string.Empty)
                        {
                            sbFields.Append(t + t);
                            sbPropertys.Append(t + t);
                        }

                        propertyComment = dr["column_comment"].ToString().Replace(newLine, string.Empty);//字段描述

                        sbFields.AppendFormat("private {0}{1} _{2}{3};{4}", dataType, strIsNullAble, fieldName, GetDefaultValue(dr["column_default"], dataType), newLine);

                        if (dataType != "string")
                        {
                            sbPropertys.AppendFormat("/// <summary>" + newLine +
                                t + t + "/// {0}" + newLine +
                                t + t + "/// </summary>" + newLine +
                                t + t + "public {1}{2} {3}" + newLine +
                                t + t + "{4}" + newLine +
                                t + t + "    set {4} _{5} = value; {6}" + newLine +
                                t + t + "    get {4} return _{5}; {6}" + newLine +
                                t + t + "{6}" + newLine, propertyComment, dataType, strIsNullAble, propertyName, left, fieldName, right);
                        }
                        else
                        {
                            sbPropertys.AppendFormat("/// <summary>" + newLine +
                                t + t + "/// {0}" + newLine +
                                t + t + "/// </summary>" + newLine +
                                t + t + "public {1}{2} {3}" + newLine +
                                t + t + "{4}" + newLine +
                                t + t + "    set {4} _{5} = (value == null ? \"\" : value.Length <= {6} ? value : value.Substring(0, {6})); {7}" + newLine +
                                t + t + "    get {4} return _{5}; {7}" + newLine +
                                t + t + "{7}" + newLine, propertyComment, dataType, strIsNullAble, propertyName, left, fieldName, dataLength.Value.ToString(), right);
                        }
                    }
                    #endregion

                    tempContent = tempContent.Replace("[Fields]", sbFields.ToString());
                    tempContent = tempContent.Replace("[Propertys]", sbPropertys.ToString().TrimEnd(newLineArray));

                    File.WriteAllText(path + FirstCharUpper(tableName) + modelSuffix + ".cs", tempContent, Encoding.UTF8);

                    sbFields.Remove(0, sbFields.Length);
                    sbPropertys.Remove(0, sbPropertys.Length);
                }
            }
            #endregion

        }
        #endregion

        #region 生成BLL
        /// <summary>
        /// 生成BLL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateBLL_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string templateContent = File.ReadAllText(pathDict["bllTemplate"], Encoding.UTF8);
            string tempContent = null;

            DataGridViewCheckBoxCell checkBoxCell = null;
            bool isChecked;

            string tableName = null;
            string tableComment = null;
            string modelSuffix = this.txtModelSuffix.Text.Trim();
            string bllSuffix = this.txtBLLSuffix.Text.Trim();
            string dalSuffix = this.txtDALSuffix.Text.Trim();

            string newLine = System.Environment.NewLine;
            char[] newLineArray = newLine.ToCharArray();

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbPropertys = new StringBuilder();
            string path = pathDict["bllOutPut"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    tableName = dgvr.Cells["table_name"].Value.ToString();
                    tableComment = dgvr.Cells["table_comment"].Value.ToString().Replace(newLine, string.Empty);

                    tempContent = templateContent;

                    tempContent = tempContent.Replace("[using]", this.txtBLLUsing.Text.Trim());
                    tempContent = tempContent.Replace("[BLLNamespace]", this.txtBLLNamespace.Text.Trim());
                    tempContent = tempContent.Replace("[ModelNamespace]", this.txtModelNamespace.Text.Trim());
                    tempContent = tempContent.Replace("[DALNamespace]", this.txtDALNamespace.Text.Trim());

                    tempContent = tempContent.Replace("[表描述]", tableComment);
                    tempContent = tempContent.Replace("[TableName]", FirstCharUpper(tableName));
                    tempContent = tempContent.Replace("[BLLSuffix]", bllSuffix);

                    tempContent = tempContent.Replace("[ModelSuffix]", modelSuffix);
                    tempContent = tempContent.Replace("[DALSuffix]", dalSuffix);

                    File.WriteAllText(path + FirstCharUpper(tableName) + bllSuffix + ".cs", tempContent, Encoding.UTF8);

                    sbFields.Remove(0, sbFields.Length);
                    sbPropertys.Remove(0, sbPropertys.Length);
                }
            }
        }
        #endregion

        #region 生成DAL
        /// <summary>
        /// 生成DAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateDAL_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string templateContent = File.ReadAllText(pathDict["dalTemplate"], Encoding.UTF8);
            string tempContent = null;

            DataGridViewCheckBoxCell checkBoxCell = null;
            bool isChecked;

            string newLine = System.Environment.NewLine;
            string dalSuffix = this.txtDALSuffix.Text.Trim();
            string modelSuffix = this.txtModelSuffix.Text.Trim();

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbPropertys = new StringBuilder();
            string path = pathDict["dalOutPut"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    string tableName = dgvr.Cells["table_name"].Value.ToString();
                    string TableName = FirstCharUpper(tableName);
                    string tableComment = dgvr.Cells["table_comment"].Value.ToString().Replace(newLine, string.Empty);

                    tempContent = templateContent;

                    tempContent = tempContent.Replace("[using]", this.txtDALUsing.Text.Trim());
                    tempContent = tempContent.Replace("[DALNamespace]", this.txtDALNamespace.Text.Trim());
                    tempContent = tempContent.Replace("[ModelNamespace]", this.txtModelNamespace.Text.Trim());

                    tempContent = tempContent.Replace("[表描述]", tableComment);
                    tempContent = tempContent.Replace("[TableName]", TableName);
                    tempContent = tempContent.Replace("[tableName]", tableName);
                    tempContent = tempContent.Replace("[DALSuffix]", dalSuffix);

                    tempContent = tempContent.Replace("[ModelSuffix]", modelSuffix);

                    File.WriteAllText(path + TableName + dalSuffix + ".cs", tempContent, Encoding.UTF8);

                    sbFields.Remove(0, sbFields.Length);
                    sbPropertys.Remove(0, sbPropertys.Length);
                }
            }
        }
        #endregion

        #region IService
        private void btnCreateIService_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string templateContent = File.ReadAllText(pathDict["iserviceTemplate"], Encoding.UTF8);

            string newLine = System.Environment.NewLine;
            string IServiceUsing = this.txtServiceUsing.Text.Trim();
            string IServiceNamespace = this.txtServiceNamespace.Text.Trim();
            string IServiceSuffix = this.txtServiceSuffix.Text.Trim();
            string modelSuffix = this.txtModelSuffix.Text.Trim();
            string modelNamespace = this.txtModelNamespace.Text.Trim();

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbPropertys = new StringBuilder();
            string path = pathDict["iserviceOutPut"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                var isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    string tableName = FirstCharUpper(dgvr.Cells["table_name"].Value.ToString());
                    string tableComment = dgvr.Cells["table_comment"].Value.ToString().Replace(newLine, string.Empty);

                    string tempContent = templateContent;

                    tempContent = tempContent.Replace("[using]", IServiceUsing);
                    tempContent = tempContent.Replace("[IServiceNamespace]", IServiceNamespace);
                    tempContent = tempContent.Replace("[ModelNamespace]", modelNamespace);

                    tempContent = tempContent.Replace("[表描述]", tableComment);
                    tempContent = tempContent.Replace("[TableName]", tableName);
                    tempContent = tempContent.Replace("[IServiceSuffix]", IServiceSuffix);

                    tempContent = tempContent.Replace("[ModelSuffix]", modelSuffix);

                    File.WriteAllText(path + "I" + tableName + IServiceSuffix + ".cs", tempContent, Encoding.UTF8);

                    sbFields.Remove(0, sbFields.Length);
                    sbPropertys.Remove(0, sbPropertys.Length);
                }
            }
        }
        #endregion

        #region IRepository
        private void btnCreateIRepository_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string templateContent = File.ReadAllText(pathDict["irepositoryTemplate"], Encoding.UTF8);


            DataGridViewCheckBoxCell checkBoxCell = null;
            bool isChecked;

            string newLine = System.Environment.NewLine;
            string IRepositoryUsing = this.txtRepositoryUsing.Text.Trim();
            string IRepositoryNamespace = this.txtRepositoryNamespace.Text.Trim();
            string IRepositorySuffix = this.txtRepositorySuffix.Text.Trim();
            string modelSuffix = this.txtModelSuffix.Text.Trim();
            string modelNamespace = this.txtModelNamespace.Text.Trim();

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbPropertys = new StringBuilder();
            string path = pathDict["irepositoryOutPut"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    string tableName = FirstCharUpper(dgvr.Cells["table_name"].Value.ToString());
                    string tableComment = dgvr.Cells["table_comment"].Value.ToString().Replace(newLine, string.Empty);

                    string tempContent = templateContent;

                    tempContent = tempContent.Replace("[using]", IRepositoryUsing);
                    tempContent = tempContent.Replace("[IRepositoryNamespace]", IRepositoryNamespace);
                    tempContent = tempContent.Replace("[ModelNamespace]", modelNamespace);

                    tempContent = tempContent.Replace("[表描述]", tableComment);
                    tempContent = tempContent.Replace("[TableName]", tableName);
                    tempContent = tempContent.Replace("[IRepositorySuffix]", IRepositorySuffix);

                    tempContent = tempContent.Replace("[ModelSuffix]", modelSuffix);

                    File.WriteAllText(path + "I" + tableName + IRepositorySuffix + ".cs", tempContent, Encoding.UTF8);

                    sbFields.Remove(0, sbFields.Length);
                    sbPropertys.Remove(0, sbPropertys.Length);
                }
            }
        }
        #endregion

        #region Controller
        private void btnCreateController_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string controllerContent = File.ReadAllText(pathDict["controllerTemplate"], Encoding.UTF8);
            string domainModelContent = File.ReadAllText(pathDict["domainModelTemplate"], Encoding.UTF8);
            string indexHtmlContent = File.ReadAllText(pathDict["indexHtmlTemplate"], Encoding.UTF8);
            string addHtmlContent = File.ReadAllText(pathDict["addHtmlTemplate"], Encoding.UTF8);

            DataGridViewCheckBoxCell checkBoxCell = null;
            bool isChecked;

            string newLine = System.Environment.NewLine;
            string controllerUsing = this.txtControllerUsing.Text.Trim();
            string controllerNamespace = this.txtControllerNamespace.Text.Trim();
            string controllerSuffix = this.txtControllerSuffix.Text.Trim();
            string modelSuffix = this.txtModelSuffix.Text.Trim();
            string modelNamespace = this.txtModelNamespace.Text.Trim();

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbPropertys = new StringBuilder();
            string path = pathDict["controllerOutPut"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    string tableName = dgvr.Cells["table_name"].Value.ToString();//小写
                    string TableName = FirstCharUpper(tableName);//转化大写
                    string TableName2 = FirstCharUpper(tableName).Replace("_", "");//转化大写并去除下划线

                    string tableComment = dgvr.Cells["table_comment"].Value.ToString().Replace(newLine, string.Empty);

                    string tempContent = controllerContent;

                    tempContent = tempContent.Replace("[using]", controllerUsing);
                    tempContent = tempContent.Replace("[ControllerNamespace]", controllerNamespace);
                    //tempContent = tempContent.Replace("[ModelNamespace]", modelNamespace);

                    //tempContent = tempContent.Replace("[表描述]", tableComment);
                    tempContent = tempContent.Replace("[TableName]", TableName);
                    tempContent = tempContent.Replace("[TableName2]", TableName2);
                    tempContent = tempContent.Replace("[tableName]", tableName);
                    tempContent = tempContent.Replace("[ControllerSuffix]", controllerSuffix);

                    tempContent = tempContent.Replace("[ModelSuffix]", modelSuffix);

                    #region 替换 DomainModel
                    domainModelContent = domainModelContent.Replace("[TableName]", TableName);
                    domainModelContent = domainModelContent.Replace("[ModelSuffix]", modelSuffix);
                    #endregion

                    #region 替换Index.cshtml

                    #endregion

                    #region 替换Add.cshtml
                    addHtmlContent = addHtmlContent.Replace("[TableName]", TableName);
                    addHtmlContent = addHtmlContent.Replace("[ModelSuffix]", modelSuffix);
                    #endregion

                    File.WriteAllText(path + TableName2 + controllerSuffix + ".cs", tempContent, Encoding.UTF8);
                    File.WriteAllText(path + TableName + "_Dm" + ".cs", domainModelContent, Encoding.UTF8);

                    Directory.CreateDirectory(path + TableName2);
                    File.WriteAllText(path + TableName2 + @"\" + "Index.cshtml", indexHtmlContent, Encoding.UTF8);
                    File.WriteAllText(path + TableName2 + @"\" + "Add.cshtml", addHtmlContent, Encoding.UTF8);

                    sbFields.Remove(0, sbFields.Length);
                    sbPropertys.Remove(0, sbPropertys.Length);
                }
            }
        }
        #endregion

        #region 其他
        public Form1()
        {
            InitializeComponent();
            Init();
            InitPath(); //实例化pathDict变量
            //注册 當前程序未處理異常事件
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(currAppdomain_UnhandledException);
        }

        #region 當前程序未處理異常事件 - static void currAppdomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        /// <summary>
        /// 當前程序未處理異常事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void currAppdomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("操作失败，原因是：" + e.ExceptionObject.ToString());
            Environment.Exit(0);
        }
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            var list = GetConnByFile();
            if (list != null)
            {
                foreach (var item in list)
                {
                    this.cbxConnList.Items.Add(item);
                }

                if (list.Count > 0)
                {
                    this.cbxConnList.SelectedIndex = 0;
                    this.txtConn.Text = list[0].Text;
                }
                btnConn.PerformClick();
                txtKeyword.Focus();
            }
            else
            {
                txtConn.Focus();
            }
        }
        #endregion

        #region 选择数据库连接
        private void cbxConnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxConnList.SelectedIndex != -1)
            {
                this.txtConn.Text = this.cbxConnList.SelectedItem.ToString();
            }
        }
        #endregion

        #region 新增数据库连接
        /// <summary>
        /// 新增数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddConn_Click(object sender, EventArgs e)
        {
            string strConn = this.txtConn.Text.Trim();
            if (!string.IsNullOrEmpty(strConn))
            {
                foreach (var item in this.cbxConnList.Items)
                {
                    if (item.ToString() == strConn)
                    {
                        MessageBox.Show("数据库连接已存在");
                        return;
                    }
                }

                this.cbxConnList.Items.Add(new ListItem(strConn));
                SaveConnToFile(0, strConn);

                if (this.cbxConnList.Items.Count == 1)
                {
                    this.cbxConnList.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region 删除数据库连接
        /// <summary>
        /// 删除数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteConn_Click(object sender, EventArgs e)
        {
            int index = this.cbxConnList.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("请先选择数据库连接");
                return;
            }

            string strConn = this.cbxConnList.SelectedItem.ToString();
            DeleteConnByFile(index, strConn);
            this.cbxConnList.Items.RemoveAt(index);
            if (this.txtConn.Text.Trim() == strConn)
            {
                this.txtConn.Text = string.Empty;
            }
        }
        #endregion

        #region 获取连接字符串从文件
        /// <summary>
        /// 保存连接字符串到文件
        /// </summary>
        /// <param name="strConn"></param>
        private List<ListItem> GetConnByFile()
        {
            if (!File.Exists("ConnList.bin"))
            {
                return null;
            }

            using (FileStream stream = new FileStream("ConnList.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (stream.Length > 0)
                {
                    List<ListItem> list = bf.Deserialize(stream) as List<ListItem>;
                    return list;
                }
                return null;
            }
        }
        #endregion

        #region 保存(添加或修改)连接字符串到文件
        /// <summary>
        /// 保存(添加或修改)连接字符串到文件
        /// </summary>
        /// <param name="index">索引(修改时用)</param>
        /// <param name="strConn">连接字符串</param>
        private void SaveConnToFile(int index, string strConn)
        {
            List<ListItem> list = null;

            if (File.Exists("ConnList.bin"))
            {
                using (FileStream stream = new FileStream("ConnList.bin", FileMode.Open))
                {
                    if (stream.Length > 0)
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        list = bf.Deserialize(stream) as List<ListItem>;
                    }
                }
            }

            using (FileStream stream = new FileStream("ConnList.bin", FileMode.OpenOrCreate))
            {
                if (list != null)
                {
                    if (index > 0)//修改
                    {
                        list[index].Text = strConn;
                    }
                    else
                    {
                        list.Add(new ListItem(strConn));
                    }
                }
                else
                {
                    list = new List<ListItem>();
                    list.Add(new ListItem(strConn));
                }

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, list);//将p所指向的对象序列化文件流中
            }
        }
        #endregion

        #region 删除连接字符串从文件
        /// <summary>
        /// 删除连接字符串从文件
        /// </summary>
        /// <param name="strConn"></param>
        private void DeleteConnByFile(int index, string strConn)
        {
            if (index < 0)
            {
                MessageBox.Show("索引必须大于0");
                return;
            }

            List<ListItem> list = null;

            if (!File.Exists("ConnList.bin"))
            {
                MessageBox.Show("文件不存在");
                return;
            }

            using (FileStream stream = new FileStream("ConnList.bin", FileMode.Open))
            {
                if (stream.Length <= 0)
                {
                    MessageBox.Show("文件错误");
                    return;
                }

                BinaryFormatter bf = new BinaryFormatter();
                list = bf.Deserialize(stream) as List<ListItem>;
            }

            if (list == null)
            {
                MessageBox.Show("文件错误");
                return;
            }

            if (list.Count == 0)
            {
                MessageBox.Show("文件错误");
                return;
            }

            using (FileStream stream = new FileStream("ConnList.bin", FileMode.Open))
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].Text == strConn)
                    {
                        list.RemoveAt(i);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(stream, list);//将p所指向的对象序列化文件流中
                        break;
                    }
                }
            }
        }
        #endregion

        #region 连接
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConn_Click(object sender, EventArgs e)
        {
            Search(null);
        }
        #endregion

        #region 获取数据库名称
        /// <summary>
        /// 获取数据库名称
        /// </summary>
        /// <param name="strConn"></param>
        /// <returns></returns>
        private string GetDBName(string strConn)
        {
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            builder.ConnectionString = strConn;

            object objDBName = null;
            if (builder.TryGetValue("database", out objDBName))
            {
                return objDBName.ToString();
            }

            return string.Empty;
        }
        #endregion

        #region 搜索方法
        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="keyword"></param>
        private void Search(string keyword)
        {
            string strConn = this.txtConn.Text.Trim();
            if (!string.IsNullOrEmpty(strConn))
            {
                DbProviderFactory dbProvider = null;
                Database db = null;
                DataTable dt = null;

                if (this.rbnMySQL.Checked)
                {
                    #region MySQL
                    //dbProvider = DbProviderFactories.GetFactory(this.rbnMySQL.Tag.ToString());
                    dbProvider = new MySql.Data.MySqlClient.MySqlClientFactory();
                    db = new Database(strConn, dbProvider);

                    if (string.IsNullOrEmpty(keyword))
                    {
                        dt = db.GetDataTable("select table_name,table_comment " +
                            "from INFORMATION_SCHEMA.tables " +
                            "where table_schema=@0;", GetDBName(strConn));
                    }
                    else
                    {
                        dt = db.GetDataTable("select table_name,table_comment " +
                            "from INFORMATION_SCHEMA.tables " +
                            "where table_schema=@0 and (table_name like @1 or table_comment like @1);", GetDBName(strConn), "%" + keyword + "%");
                    }
                    #endregion
                }
                else
                {
                    #region MSSQL
                    dbProvider = DbProviderFactories.GetFactory(this.rbnMSSQL.Tag.ToString());
                    db = new Database(strConn, dbProvider);

                    if (string.IsNullOrEmpty(keyword))
                    {
                        dt = db.GetDataTable("select o.name as table_name,cast(value as nvarchar(50)) as table_comment " +
                                    "from sys.extended_properties p " +
                                    "right join sysobjects o on p.major_id=o.id and p.class=1 and p.minor_id=0 " +
                                    "where o.xtype='U' " +
                                    "order by o.name ");
                    }
                    else
                    {
                        dt = db.GetDataTable("select o.name as table_name,cast(value as nvarchar(50)) as table_comment " +
                                    "from sys.extended_properties p " +
                                    "right join sysobjects o on p.major_id=o.id and p.class=1 and p.minor_id=0 " +
                                    "where o.xtype=@0 and (o.name like @1 or cast(value as nvarchar(50)) like @1)" +
                                    "order by o.name ", "U", "%" + keyword + "%");
                    }
                    #endregion
                }

                if (dt == null)
                {
                    MessageBox.Show("操作失败，请重试。");
                    return;
                }
                this.dataGridView1.DataSource = dt;
                //foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
                //{
                //    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                //    checkBoxCell.Value = true;
                //}
            }
        }
        #endregion

        #region 搜索
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(this.txtKeyword.Text.Trim());
        }
        #endregion

        #region 全选方法
        /// <summary>
        /// 全选方法
        /// </summary>
        private void SelectAll(bool isChecked)
        {
            DataGridViewCheckBoxCell checkBoxCell = null;
            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                checkBoxCell = (DataGridViewCheckBoxCell)dgvr.Cells["Selected"];
                checkBoxCell.Value = isChecked;
            }
        }
        #endregion

        #region 全选
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (this.btnSelectAll.Text == "全选")
            {
                SelectAll(true);
                this.btnSelectAll.Text = "取消";
            }
            else if (this.btnSelectAll.Text == "取消")
            {
                SelectAll(false);
                this.btnSelectAll.Text = "全选";
            }
        }
        #endregion

        #region DB数据类型转C#数据类型
        /// <summary>
        /// DB数据类型转C#数据类型
        /// </summary>
        /// <param name="dbDataType">DB数据类型</param>
        /// <param name="isUnsigned">是否是无符号类型</param>
        /// <returns></returns>
        private string DBDataTypeToCSharpDataType(string dbDataType, bool isUnsigned)
        {
            switch (dbDataType)
            {
                case "varchar":
                    return "string";

                case "varchar2":

                    return "string";

                case "nvarchar":
                    return "string";

                case "nvarchar2":
                    return "string";

                case "char":
                    return "string";

                case "nchar":
                    return "string";

                case "text":
                    return "string";

                case "mediumtext":
                    return "string";

                case "longtext":
                    return "string";

                case "ntext":
                    return "string";

                case "string":
                    return "string";

                case "date":
                    return "DateTime";

                case "datetime":
                    return "DateTime";

                case "smalldatetime":
                    return "DateTime";

                case "smallint":
                    return (!isUnsigned) ? "short" : "ushort";

                case "int":
                    return (!isUnsigned) ? "int" : "uint";

                case "number":
                    return "int";

                case "bigint":
                    return (!isUnsigned) ? "long" : "ulong";

                case "tinyint":
                    return (!isUnsigned) ? "sbyte" : "byte";

                case "float":
                    return "float";

                case "numeric":
                    return "decimal";

                case "decimal":
                    return "decimal";

                case "money":
                    return "decimal";

                case "smallmoney":
                    return "decimal";

                case "real":
                    return "decimal";

                case "bit":
                    return "bool";

                case "binary":
                    return "byte[]";

                case "varbinary":
                    return "byte[]";

                case "image":
                    return "byte[]";

                case "raw":
                    return "byte[]";

                case "long":
                    return "byte[]";

                case "long raw":
                    return "byte[]";

                case "blob":
                    return "byte[]";

                case "bfile":
                    return "byte[]";

                case "uniqueidentifier":
                    return "Guid";

                case "integer":
                    return (!isUnsigned) ? "int" : "uint";

                case "double":
                    return "double";

                case "enum":
                    return "Enum";

                case "timestamp":
                    return "DateTime";

                default:
                    return null;
            }
        }
        #endregion

        #region 获取默认值
        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <param name="objDefaultValue"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private string GetDefaultValue(object objDefaultValue, string dataType)
        {
            if (objDefaultValue != null && objDefaultValue != DBNull.Value)
            {
                string defaultValue = objDefaultValue.ToString();
                switch (dataType.ToLower())
                {
                    case "string":
                        return " = \"" + defaultValue + "\"";
                    case "int":
                        return " = " + defaultValue + "";
                    case "decimal":
                        return " = " + defaultValue + "";
                    case "bool":
                        defaultValue = defaultValue.Replace("b", "").Replace("'", "");
                        return defaultValue == "0" ? " = false" : " = true";
                    case "datetime":
                        if (defaultValue == "CURRENT_TIMESTAMP")
                        {
                            return " = DateTime.Now";
                        }
                        else
                        {
                            return string.Empty;
                        }
                }
            }

            return string.Empty;
        }
        #endregion

        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = baseDirectory;
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");

            psi.Arguments = path;
            //psi.Arguments = "/e,/select," + path;
            System.Diagnostics.Process.Start(psi);
        }
        #endregion

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
    }
}


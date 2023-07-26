using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANPR_General.Services;
using Infragistics.Win;

namespace ANPR_General
{
    public partial class frmDBsetting : Form
    {

        private string ConnStringWinMode;
        private string ConnStringUserMode;
        private string ConnString_masterdb;
        private string ConnString_livedb;

        public frmDBsetting()
        {
            InitializeComponent();
        }

        private void frmDBsetting_Load(object sender, EventArgs e)
        {
            FillDropDown();
            Set_controls();
        }

        private void GetConnectinString_CreateDatabase()
        {
            if(txtServerName.Text!="")
            {
                ConnStringWinMode = "Server= " + txtServerName.Text + "; Database= master; Integrated Security=True;";
            }
            else
            {
                MessageBox.Show("Please enter Server Name");
                return;
            }

            if (chkWindAuth.Checked)
            {
                ConnString_masterdb = ConnStringWinMode;
            }
            else
            {
                if (txtUserName.Text != "" || txtPassword.Text != "")
                {
                    ConnStringUserMode = "Data Source="+ txtServerName.Text + ";Initial Catalog=master;Persist Security Info=True;User ID="+ txtUserName.Text + ";Password="+ txtPassword.Text + ";";
                }
                else
                {
                    MessageBox.Show("Please enter User Name/Password");
                    return;
                }

                ConnString_masterdb = ConnStringUserMode;
            }

        }

        private string GetConnectinString_LiveDb()
        {

            string conString = "";
            string db = cmbDatabase.Text;
           
            if (chkWindAuth.Checked)
            {
                if (txtServerName.Text != "")
                {
                    conString = "Server= " + txtServerName.Text + "; Database= "+ db + "; Integrated Security=True;";
                }
            }
            else
            {
                if (txtUserName.Text != "" || txtPassword.Text != "")
                {
                    conString = "Data Source=" + txtServerName.Text + ";Initial Catalog=" + db + " ;Persist Security Info=True;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + ";";
                }
            }

            return conString;
        }

        private bool ValidConnection(string connectionString)
        {

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }


        }

        private void FillDropDown()
        {

            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void GetDataSources()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            string ServerName = Environment.MachineName;
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(ServerName + "\\" + row["InstanceName"].ToString());
            }
        }

        private void chkWindAuth_CheckedChanged(object sender, EventArgs e)
        {

            Set_controls();
        }

        private void Set_controls()
        {
            if (chkWindAuth.Checked)
            {
                grpMixMode.Enabled = false;
            }
            else
            {
                grpMixMode.Enabled = true;
            }
        }

        private void Init()
        {
            if (chkWindAuth.Checked)
            {
                grpMixMode.Enabled = false;
            }
            else
            {
                grpMixMode.Enabled = true;
            }

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            GetConnectinString_CreateDatabase();

            if(ValidConnection(ConnString_masterdb))
            {
                MessageBox.Show("Connection with master db is connected successfully.");
            }
            else
            {
                MessageBox.Show("Connection with master db is failed.");
            }

            //if (ConnString_livedb!="")
            //{
            //    if (ValidConnection(ConnString_livedb))
            //    {
            //        MessageBox.Show("Connection with Live db is connected successfully.");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Connection with Live db is failed.");
            //    }

            //}

        }

        private void btnSetConn_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        { 
            try
            {

                DialogResult dialogResult = MessageBox.Show("are you sure for create or reset the database ?", "Reset Database", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ExecuteScripts();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Get_DatabaseList()
        {
            try
            {
                GetConnectinString_CreateDatabase();

                DataSet ds = new DataSet();

                SqlConnection sqlconn = new SqlConnection(ConnString_masterdb);
                string qry = "";

                qry = "SELECT name";
                qry += " FROM sys.databases order by create_date desc";
             
                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);

                cmbDatabase.DataSource = ds.Tables[0];
                cmbDatabase.DisplayMember = "name";
                cmbDatabase.ValueMember = "name";
                cmbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Get_DatabaseList();
        }

        private void btnNewDB_Click(object sender, EventArgs e)
        {
            GetConnectinString_CreateDatabase();

            if (txtDBName.Text=="")
            {
                MessageBox.Show("Please enter the database name");
                return;
            }

            try
            {
                string qry = "";

                SqlConnection sqlconn = new SqlConnection(ConnString_masterdb);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                
               qry = " CREATE DATABASE " + txtDBName.Text ;
                  

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

                txtDBName.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            Get_DatabaseList();
        }

        private void txtServerName_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void SetAccessRights(string file)
        {
            FileSecurity fileSecurity = File.GetAccessControl(file);
            AuthorizationRuleCollection rules = fileSecurity.GetAccessRules(true, true, typeof(NTAccount));
            foreach (FileSystemAccessRule rule in rules)
            {
                string name = rule.IdentityReference.Value;
                if (rule.FileSystemRights != FileSystemRights.FullControl)
                {
                    FileSecurity newFileSecurity = File.GetAccessControl(file);
                    FileSystemAccessRule newRule = new FileSystemAccessRule(name, FileSystemRights.FullControl, AccessControlType.Allow);
                    newFileSecurity.AddAccessRule(newRule);
                    File.SetAccessControl(file, newFileSecurity);
                }
            }
        }

        private void ExecuteScripts()
        {
            try
            {
                string connString = "";
                connString=GetConnectinString_LiveDb();

                if (cmbDatabase.Text!="")
                {

                    string qry = "";

                    SqlConnection sqlconn = new SqlConnection(connString);
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.CommandType = CommandType.Text;
                    DateTime dt = DateTime.Now;
                    Communication c = new Communication();

                    qry = c.Get_QueryScripts("Table.sql");


                    sqlcmd.CommandText = qry;
                    sqlcmd.Connection = sqlconn;

                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();

                    //********** For Run Datbase

                    qry = c.Get_QueryScripts("Data.sql");


                    sqlcmd.CommandText = qry;
                    sqlcmd.Connection = sqlconn;

                    sqlcmd.ExecuteNonQuery();


                    sqlconn.Close();

                    MessageBox.Show("Database tables have been created.");

                    Set_ConnectionString(connString);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Set_ConnectionString(string connStr)
        {

            try
            {

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                string key;
                string value;

                key = "ConnString";
                value = connStr;

                settings.Add(key, value);

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }


                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                MessageBox.Show("Connection has been updated.", "System Info");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void txtServerName_Leave(object sender, EventArgs e)
        {
            Get_DatabaseList();
        }
    }
}

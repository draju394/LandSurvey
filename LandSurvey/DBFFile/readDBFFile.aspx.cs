using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace LandSurvey.DBFFile
{
    public partial class readDBFFile : System.Web.UI.Page
    {
        string thousandSeparator = "#" + "" + "###"; // or ","
      //  dsCreateTable.Tables[0].Rows[row][col] = Convert.ToString(Convert.ToDouble(dsExport.Tables[0].Rows[row][col].ToString().Trim()).ToString(thousandSeparator));
        protected void Page_Load(object sender, EventArgs e)
        {
            //F:\DatarSirWork\LandSurvey\LandSurvey\LandSurvey\DBFFile\A5313760301001.dbf
            //string FileExist = Server.MapPath(@"~/DBFFile/" + "A5313760301001.dbf");
            //if (File.Exists(FileExist))
            //{
            //    ImportDBF(Server.MapPath(@"~/DBFFile/" + "A5313760301001.dbf"));
            //}
            ReadDBFUsingOleDB();
          //  ImportDBF(Server.MapPath(@"~/DBFFile"));
        }

        public DataSet ImportDBF(string filePath)
        {
           
            string ImportDirPath = string.Empty;
            string tableName = string.Empty;
            // This function give the Folder name and table name to use in
            // the connection string and create table statement.
            GetFileNameAndPath(filePath, ref tableName, ref ImportDirPath);
            DataSet dsImport = new DataSet();
            string thousandSep = thousandSeparator;
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ImportDirPath + "; Extended Properties=DBASE IV;";
            OleDbConnection conn = new OleDbConnection(connString);
            DataSet dsGetData = new DataSet();
            OleDbDataAdapter daGetTableData = new OleDbDataAdapter("Select * from " + tableName, conn);
            // fill all the data in to dataset
            daGetTableData.Fill(dsGetData);
            DataTable dt = new DataTable(dsGetData.Tables[0].TableName.ToString());
            dsImport.Tables.Add(dt);
            // here I am copying get Dataset into another dataset because //before return the dataset I want to format the data like change //"datesymbol","thousand symbol" and date format as did while
            // exporting. If you do not want to format the data then you can // directly return the dsGetData
            for (int row = 0; row < dsGetData.Tables[0].Rows.Count; row++)
            {
                DataRow dr = dsImport.Tables[0].NewRow();
                dsImport.Tables[0].Rows.Add(dr);
                for (int col = 0; col < dsGetData.Tables[0].Columns.Count; col++)
                {
                    if (row == 0)
                    {
                        DataColumn dc = new DataColumn(dsGetData.Tables[0].Columns[col].ColumnName.ToString());
                        dsImport.Tables[0].Columns.Add(dc);
                    }
                    if (!String.IsNullOrEmpty(dsGetData.Tables[0].Rows[row][col].
                    ToString()))
                    {
                        dsImport.Tables[0].Rows[row][col] = Convert.ToString(dsGetData.Tables[0].Rows[row][col].ToString().Trim());
                    }
                } // close inner for loop
            }// close ouer for loop
          //  MessageBox.Show("Import done Successfully to DBF File.");
            return dsImport;
        } // close function

        private void GetFileNameAndPath(string completePath, ref string fileName, ref string folderPath)
        {
            string[] fileSep = completePath.Split('\\');
            for (int iCount = 0; iCount < fileSep.Length; iCount++)
            {
                if (iCount == fileSep.Length - 2)
                {
                    if (fileSep.Length == 2)
                    {
                        folderPath += fileSep[iCount] + "\\";
                    }
                    else
                    {
                        folderPath += fileSep[iCount];
                    }
                }
                else
                {
                    if (fileSep[iCount].IndexOf(".") > 0)
                    {
                        fileName = fileSep[iCount];
                        fileName = fileName.Substring(0, fileName.IndexOf("."));
                    }
                    else
                    {
                        folderPath += fileSep[iCount] + "\\";
                    }
                }
            }
        }

        public void ReadDBFUsingOleDB()
        {
            DataTable data = new DataTable();

            //string FilePath = "C:\\Users\\Administrator\\Desktop\\";
            string FilePath = "C:\\Users\\hp\\Desktop\\";

            //string DBF_FileName = "SCTFIN.dbf";
            string DBF_FileName = "A5313760301001.dbf";

            //OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.GetDirectoryName(DBF_FileName) + ";Extended Properties=DBASE III");
            //connection.Open();
            //OleDbDataAdapter adapter = new OleDbDataAdapter("select * from " + Path.GetFileName(DBF_FileName), connection);
            //DataSet dataSet = new DataSet(); ;
            //adapter.Fill(dataSet);
            //if (dataSet.Tables.Count > 0)
            //{
            //    GridView1.DataSource = dataSet;
            //    GridView1.DataBind();
            //    //data = dataSet.Tables[0];
            //}



            ////string FilePath = "C:\\Users\\Administrator\\Desktop\\";
            //string FilePath = "C:\\Users\\hp\\Desktop\\";
          
            ////string DBF_FileName = "SCTFIN.dbf";
            //string DBF_FileName = "A5313760601001.dbf";
            //define the connections to the .dbf file
           OleDbConnection conn = new OleDbConnection(@"Provider=vfpoledb;Data Source=" + FilePath+ ";Collating Sequence=machine;");
            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=dBASE IV;");

            OleDbCommand command = new OleDbCommand("select * from " + DBF_FileName, conn);
            conn.Open();


            //open the connection and read in all the data from .dbf file into a datatable
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();  //close connection to the .dbf file


           // lblResult.Text = "Congratulations, your .dbf file has been transferred to Grid.";
        }
        //
    }
}
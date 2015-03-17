using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraTab;

namespace BSKChartMonitor
{
    public partial class Form1 : Form
    {
        private string connStr = "Data Source=192.168.10.207;Initial Catalog=ErrLog;User ID=sa;Password=7319";
        private string lastSn = "";
        private string customSearchtext = "SELECT * FROM [ErrLog].[dbo].[ErrLog] where [LogTime]>='{0}' and [LogTime]<'{1}' order by [LogTime] DESC";
        //string.Format("SELECT Top 1000 * FROM [ErrLog].[dbo].[ErrLog] where [LogTime]>='{0}' and [LogTime]<'{1}' order by [LogTime] DESC",dateTimePicker1.Value.ToString("yyyy-MM-dd"),dateTimePicker2.Value.ToString("yyyy-MM-dd"))
        public Form1()
        {
            InitializeComponent();
        }

        public DataTable GetCustomSearch(string text)
        {
            DataTable dtLog = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(text, conn))
                {
                    conn.Open();                
                    dtLog.Load(cmd.ExecuteReader());
                }
            }
            return dtLog;
        }

        public void GetTop1000Lag()
        {
            DataTable dtLog = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM [ErrLog].[dbo].[ErrLog] where [LogTime]>='{0}' and [LogTime]<'{1}' order by [LogTime] DESC"
                    ,dateTimePicker1.Value.ToString("yyyy-MM-dd")
                    ,dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd")), conn))
                {
                    conn.Open();
                    
                    dtLog.Load(cmd.ExecuteReader());
                    label7.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    if (lastSn != dtLog.Rows[0]["Sn"].ToString())
                    {
                        label10.Text = lastSn;
                        label8.Visible = true;
                        lastSn = dtLog.Rows[0]["Sn"].ToString();
                    }
                    else
                        label8.Visible = false;

                    label13.Text = dtLog.Rows.Count.ToString();
                }
            }
            if (dtLog != null)
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = dtLog;
                gridView1.RefreshData();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Interval = int.Parse(textBox3.Text);
                timer1.Enabled = true;
            }
            else timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            GetTop1000Lag();
            if (checkBox1.Checked)
            {
                timer1.Interval = int.Parse(textBox3.Text);
                timer1.Enabled = true;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage page = new DevExpress.XtraTab.XtraTabPage();
            page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            page.Text = "自訂查詢" + (xtraTabControl1.TabPages.Count - 1).ToString();
            xtraTabControl1.TabPages.Add(page);
            ucLogGrid ucGD = new ucLogGrid();
            ucGD.Parent = page;
            ucGD.Dock = DockStyle.Fill;
            ucGD.Show();

            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;

            SetCustomSearchText();

            switch (imageComboBoxEdit1.EditValue.ToString())
            {
                case "1":
                    customSearchtext = string.Format(customSearchtext , dateTimePicker3.Value.ToString("yyyy-MM-dd") , dateTimePicker4.Value.AddDays(1).ToString("yyyy-MM-dd"));
                    break;
                case "2":
                    customSearchtext = string.Format(customSearchtext , textBox1.Text , dateTimePicker3.Value.ToString("yyyy-MM-dd") , dateTimePicker4.Value.AddDays(1).ToString("yyyy-MM-dd"));
                    break;
                case "4":
                    customSearchtext = string.Format(customSearchtext ,textBox2.Text);
                    break;
                case "5":
                    customSearchtext = string.Format(customSearchtext , dateTimePicker3.Value.ToString("yyyy-MM-dd") , dateTimePicker4.Value.AddDays(1).ToString("yyyy-MM-dd"));
                    break;
                case "6":
                    customSearchtext = string.Format(customSearchtext, dateTimePicker3.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.AddDays(1).ToString("yyyy-MM-dd"),imageComboBoxEdit2.EditValue.ToString());
                    break;
            }

            ucGD.gcGrid.DataSource = null;
            ucGD.gcGrid.DataSource = GetCustomSearch(customSearchtext);
            if (ucGD.gvGrid.Columns.ColumnByFieldName("LogTime") != null)
            {
                ucGD.gvGrid.Columns["LogTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                ucGD.gvGrid.Columns["LogTime"].DisplayFormat.FormatString = "g";
            }
            ucGD.gvGrid.RefreshData();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            XtraTabPage tp = (XtraTabPage)((DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e).Page;
            if (tp != null)
            {
                xtraTabControl1.TabPages.Remove(tp);
                tp.Dispose();
                tp = null;
            }
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }

        private void imageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panCus.Visible = false;
            panDate.Visible = false;
            panErr.Visible = false;
            panType.Visible = false;

            SetCustomSearchText();
        }

        private void SetCustomSearchText()
        {
            switch (imageComboBoxEdit1.EditValue.ToString())
            {
                case "1":
                    panDate.Visible = true;
                    customSearchtext = "SELECT * FROM [ErrLog].[dbo].[ErrLog] " +
                    "where [LogTime]>='{0}' and [LogTime]<'{1}' order by [LogTime] DESC";
                    break;
                case "2":
                    panDate.Visible = true;
                    panCus.Visible = true;
                    customSearchtext = "SELECT * FROM [ErrLog].[dbo].[ErrLog] " +
                    "where [Account] = '{0}' and [LogTime]>='{1}' and [LogTime]<'{2}' order by [LogTime] DESC";
                    break;
                case "3":
                    customSearchtext = "select CAST([LogTime] AS DATE) as 日期,count(*) as 數量 from [ErrLog].[dbo].[ErrLog] GROUP BY CAST([LogTime] AS DATE) order by 日期 DESC";
                    break;
                case "4":
                    customSearchtext = "select CAST([LogTime] AS DATE) as 日期,count(*) as 數量 from [ErrLog].[dbo].[ErrLog]  where ErrContent like '%{0}%' GROUP BY CAST([LogTime] AS DATE) order by 日期 DESC";
                    panErr.Visible = true;
                    break;
                case "5":
                    customSearchtext = "SELECT [Account],count(*) as 數量  FROM [ErrLog].[dbo].[ErrLog] " +
                                    "where [LogTime]>='{0}' and [LogTime]<'{1}' Group by [Account] order by 數量 DESC";
                    panDate.Visible = true;
                    break;
                case "6":
                    customSearchtext = "select 日期,sum([Count]) as 發生次數 from (" +
                    "SELECT CAST([LogTime] AS DATE) as 日期,Account,count(*) as Count FROM [ErrLog].[dbo].[ErrLog] " +
                    "where [LogTime]>='{0}' and [LogTime]<'{1}' and ErrType = {2} Group by Account ,CAST([LogTime] AS DATE)) A Group by 日期 " +
                    "order by 日期 DESC";
                    panDate.Visible = true;
                    panType.Visible = true;
                    break;
            }
        }
    }
}

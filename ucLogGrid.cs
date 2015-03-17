using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BSKChartMonitor
{
    public partial class ucLogGrid : UserControl
    {
        public ucLogGrid()
        {
            InitializeComponent();
        }

        private void 匯出EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "";
            saveFileDialog1.Filter = "Excel|*.xlsx|Excel 2003|*.xls";
            saveFileDialog1.Title = "匯出資料";
            saveFileDialog1.FileName = "籌碼K線Log紀錄.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                string file1 = saveFileDialog1.FileName;
                string fileExtenstion = new FileInfo(file1).Extension;
                try
                {
                    if (System.IO.File.Exists(file1))
                    {
                        System.IO.File.Delete(file1);
                        if (gvGrid.RowCount > 0)
                        {
                            if (fileExtenstion == ".xls") gvGrid.ExportToXls(file1);
                            else gvGrid.ExportToXlsx(file1);
                            System.Diagnostics.Process.Start(file1);
                        }
                    }
                    else
                    {
                        if (gvGrid.RowCount > 0)
                        {
                            if (fileExtenstion == ".xls") gvGrid.ExportToXls(file1);
                            else gvGrid.ExportToXlsx(file1);
                            System.Diagnostics.Process.Start(file1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

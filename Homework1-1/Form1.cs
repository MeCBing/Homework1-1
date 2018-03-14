using LinqToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1_1
{
    public partial class Form1 : Form
    {
        List<Class1.Exl> result = new List<Class1.Exl>();
        List<Class1.Exl1> result1 = new List<Class1.Exl1>();
        public Form1()
        {
            InitializeComponent();
            CreateDataSo();
            CreateData();
        }
        
        private void CreateData()
        {
            var restaurant1 = new Class1.Exl1
            {
                級別 = "0",
                級距1 = "0",
                級距2 = "0",
                稅率 = "0",
                累積差額 = "0"
            };
            foreach (var items in result)
            {
                string[] s = items.級距.Split('~');
                var restaurant = new Class1.Exl1
                {
                    級別 = items.級別,
                    級距1 = s[0],
                    級距2 = s[1],
                    稅率 = items.稅率,
                    累積差額 = ((double.Parse(restaurant1.級距2)
                    * ((double.Parse(items.稅率) - double.Parse(restaurant1.稅率)) / 100))
                    + (double.Parse(restaurant1.累積差額))).ToString()
                };
                result1.Add(restaurant);
                restaurant1 = restaurant;
            }
            dataGridView1.DataSource = result1;
        }
        private void CreateDataSo()
        {
            var excelFile = new ExcelQueryFactory(@"C:\Build school\Homework1-1\Homework1-1\bin\Debug\1.xlsx");
            var excel = excelFile.Worksheet<Class1.Exl>("工作表1");
            foreach(var items in excel)
            {
                var restaurant = new Class1.Exl
                {
                    級別 = items.級別,
                    級距 = items.級距,
                    稅率 = items.稅率,
                    累積差額 = "0"
                };
                result.Add(restaurant);
            }
            //dataGridView1.DataSource = result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CreateData c = new  CreateData(ref result1, textBox1.Text);
            MessageBox.Show(c.S);
            label1.Text = c.S;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char) Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
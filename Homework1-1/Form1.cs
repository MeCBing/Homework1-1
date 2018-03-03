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
        public Form1()
        {
            InitializeComponent();
            CreateDataSo();
            CreateData();
        }
        List<Class1.Exl> result = new List<Class1.Exl>();
        List<Class1.Exl1> result1 = new List<Class1.Exl1>();
        private void CreateData()
        {
            foreach (var items in result)
            {
                int max = 999999999;
                string[] s = items.級距.Split('~');
                int.TryParse(s[1], out max);
                var restaurant = new Class1.Exl1
                {
                    級別 = items.級別,
                    級距1 = s[0],
                    級距2 = max.ToString(),
                    稅率 = items.稅率,
                    累積差額 = items.累積差額
                };
                result1.Add(restaurant);
            }
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
                    累積差額 = items.累積差額
                };
                result.Add(restaurant);
            }
            dataGridView1.DataSource = result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double money = 0;
            double.TryParse(textBox1.Text, out money);
            var res = result1.Where((x) => double.Parse(x.級距1) < money && money < double.Parse(x.級距2));
            foreach(var sd in res)
            {
                string s = $"現在級別 : {sd.級別} \n現金 : {money} \n稅率 : {sd.稅率} \n需繳納稅金為 {(money * (double.Parse(sd.稅率) / 100.00) - double.Parse(sd.累積差額)).ToString("C")}";
                MessageBox.Show(s);
                label1.Text = s;
            }
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
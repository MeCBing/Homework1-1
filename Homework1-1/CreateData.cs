using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_1
{
    class CreateData
    {
        public string S { get; set; }
        public CreateData(ref List<Class1.Exl1> list,string text)
        {
            double money = 0;
            double.TryParse(text, out money);
            var res = list.Where((x) => double.Parse(x.級距1) < money && money < double.Parse(x.級距2));
            foreach (var sd in res)
            {
                S = $"現在級別 : {sd.級別} \n現金 : {money} \n稅率 : {sd.稅率} \n需繳納稅金為 {(money * (double.Parse(sd.稅率) / 100.00) - double.Parse(sd.累積差額)).ToString("C")}";
            }
        }
    }
}

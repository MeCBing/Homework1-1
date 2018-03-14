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
            double max = list.Max((y) => double.Parse(y.級距1));
            var list1 = list.Where((x) => double.Parse(x.級距1) < max);
            List<Class1.Exl1> res = new List<Class1.Exl1>();
            if(money>max)
            {
                var res1 = list.Where((x) => double.Parse(x.級距1) == max);
                foreach (var index in res1)
                {
                    res.Add(index);
                }
            }
            else
            {
                var res1 = list1.Where((x) => double.Parse(x.級距1) <= money && money <= double.Parse(x.級距2));
                foreach(var index in res1)
                {
                    res.Add(index);
                }
            }
            foreach(var index in res)
            {
                S = $"現在級別 : {index.級別} \n現金 : {money} \n稅率 : {index.稅率} \n需繳納稅金為 {(money * (double.Parse(index.稅率) / 100.00) - double.Parse(index.累積差額)).ToString("C")}";
            }
        }
    }
}

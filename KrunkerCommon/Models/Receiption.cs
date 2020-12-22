using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerCommon.Models
{
    public class Receiption
    {
        private static int _id;
        public List<AbstractItem> ItemsList { get; set; }
        public int ID { get; set; }
        public string Date { get; set; }
        public double Bill { get; set; }
        public Receiption(List<AbstractItem> items, string date)
        {
            _id++;
            ID = _id;
            Date = date;
            ItemsList = items;
            for (int i = 0; i < items.Count; i++)
            {
                Bill += items[i].ActualPrice;
            }
        }
        [JsonConstructor]
        public Receiption()
        {
            _id++;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Receiption No. #{ID}");
            for (int i = 0; i < ItemsList.Count; i++)
            {
                str.AppendLine($"{i+1}. {ItemsList[i].Name}\t{ItemsList[i].ActualPrice}$");
            }
            str.AppendLine($"Total bill: {Bill}$");
            return str.ToString();
        }
    }
}

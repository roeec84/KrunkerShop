using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerCommon.Models
{
    public class AbstractItem : IComparer
    {
        //private string _type;
        public int ID { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int AvailableAmount { set; get; }
        public string UriPath;
        //public string ItemType { get { return _type; } }
        public double ActualPrice
        {
            get
            {
                return Price - Price*(Discount / 100);
            }
        }
        private static int _lastID;
        public AbstractItem(string name, double price, int amount, string imgpath, double discount = 0)
        {
            _lastID++;
            ID = _lastID;
            Name = name;
            Price = price;
            Discount = discount;
            AvailableAmount = amount;
            UriPath = imgpath;
            //_type = this.GetType().Name;
        }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }
}

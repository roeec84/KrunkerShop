using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerCommon.Models
{
    public class Clothing : AbstractItem
    {
        public enum ClothSize
        {
            Small,
            Medium,
            Large
        }
        private ClothSize _size;
        public ClothSize Size { get => _size; }
        public Clothing(string name, double price, ClothSize size, int amount, string imgpath, double discount = 0) : base(name, price, amount, imgpath, discount)
        {
            _size = size;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Name: {Name}");
            str.AppendLine($"Price: {ActualPrice}$");
            str.AppendLine($"Discount: {Discount}%");
            str.AppendLine($"Size: {_size}");
            str.AppendLine($"In stock: {AvailableAmount}");
            return str.ToString();
        }
    }
}

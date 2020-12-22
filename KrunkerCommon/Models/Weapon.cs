using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerCommon.Models
{
    public class Weapon : AbstractItem
    {
        public int MagazineSize { get; set; }
        public Weapon(string name, double price, int amount, string imgpath, double discount = 0, int magazine = 30) : base(name, price, amount, imgpath, discount)
        {
            MagazineSize = magazine;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Name: {Name}");
            str.AppendLine($"Price: {ActualPrice}$");
            str.AppendLine($"Discount: {Discount}%");
            if(MagazineSize > 1)
                str.AppendLine($"Magazine Size: {MagazineSize}");
            str.AppendLine($"In stock: {AvailableAmount}");
            return str.ToString();
        }
    }
}

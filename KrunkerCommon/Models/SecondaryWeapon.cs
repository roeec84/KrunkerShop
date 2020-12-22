using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerCommon.Models
{
    public class SecondaryWeapon : Weapon
    {
        public SecondaryWeapon(string name, double price, int amount, string imgpath, double discount = 0, int magazine = 10) : base(name, price, amount, imgpath, discount, magazine)
        {
        }
    }
}

using KrunkerCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerBL.Service
{
    public interface IService
    {
        List<AbstractItem> GetItems(bool isUser = true);
        AbstractItem GetItemByID(int itemID, bool isUser = true);
        AbstractItem GetItemByName(string name, bool isUser = true);
        bool CreateItem(AbstractItem item, bool isUser = true);
        void DeleteItem(AbstractItem item, bool isUser = true);
    }
}

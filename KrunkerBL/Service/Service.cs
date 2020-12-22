using KrunkerDAL.Manager;
using KrunkerCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerBL.Service
{
    public class Service : IService //The connection with the DAL
    {
        Manager manager;
        public Service()
        {
            manager = new Manager();
        }
        public bool CreateItem(AbstractItem item, bool isUser = true)
        {
            return manager.CreateItem(item, isUser);
        }

        public void DeleteItem(AbstractItem item, bool isUser = true)
        {
            manager.DeleteItem(item, isUser);
        }

        public AbstractItem GetItemByID(int itemID, bool isUser = true)
        {
            return manager.GetItemByID(itemID, isUser);
        }
        public AbstractItem GetItemByName(string name, bool isUser = true)
        {
            return manager.GetItemByName(name, isUser);
        }
        public List<AbstractItem> GetItems(bool isUser = true)
        {
            return manager.GetItems(isUser);
        }
        public AbstractItem GetStorageItemByName(string name)
        {
            return manager.GetStorageItemByName(name);
        }
        public List<AbstractItem> GetAvailableItems()
        {
            return manager.GetAvailableItems();
        }
        public List<string> GetAvailableTypes()
        {
            return manager.GetAvailableTypes();
        }
        public List<Receiption> GetReceiptions()
        {
            return manager.GetReceiptions();
        }
        public void UpdateAmounts(List<AbstractItem> itemsList)
        {
            manager.UpdateAmounts(itemsList);
        }
        public void Clear(bool isUser)
        {
            manager.Clear(isUser);
        }
        public void AddReceiption(Receiption recep)
        {
            manager.AddReceiption(recep);
        }
    }
}

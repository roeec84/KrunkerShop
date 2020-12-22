using KrunkerCommon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KrunkerDAL.Manager
{
    public class Manager : IManager //The connection with the user file
    {
        List<AbstractItem> userItemsList; //User File
        List<AbstractItem> storeItemsList; //Store File
        List<AbstractItem> jsonFileItems; //Json file
        List<string> typesList; //Available types list
        List<Receiption> receiptionsList; //Receiptions List
        public Manager()
        {
            userItemsList = new List<AbstractItem>();
            storeItemsList = new List<AbstractItem>();
            typesList = new List<string>();
            jsonFileItems = new List<AbstractItem>();
            receiptionsList = new List<Receiption>();
            #region Storage Instances
            //PrimaryWeapon M4 = new PrimaryWeapon("M4", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Rqua.png", 0, 30);
            //PrimaryWeapon AK47 = new PrimaryWeapon("AK-47", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Puma RR.png", 0, 30);
            //PrimaryWeapon Sniper = new PrimaryWeapon("AWP Cherry Blossom", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Cherry Blossom.png", 0, 5);
            //PrimaryWeapon UMP = new PrimaryWeapon("UMP", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Commo.png", 0, 30);
            //PrimaryWeapon RPG = new PrimaryWeapon("RPG", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Dijon.png", 0, 2);
            //PrimaryWeapon Sniper2 = new PrimaryWeapon("Dragonov", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Interuention Ul.png", 0, 5);
            //PrimaryWeapon MAG = new PrimaryWeapon("M.A.G", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\LMG Wanderer.png", 0, 60);
            //PrimaryWeapon Shotgun = new PrimaryWeapon("Shotgun", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Spectrum.png", 0, 2);
            //PrimaryWeapon Sniper3 = new PrimaryWeapon("AWP Theta", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Primary\Theta.png", 0, 5);
            //SecondaryWeapon Knife = new SecondaryWeapon("Knife Flame Fang", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Secondary\FlameFang.png", 0, 1);
            //SecondaryWeapon Knife2 = new SecondaryWeapon("Knife Soul Fang", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Secondary\Soul Fang.png", 0, 1);
            //SecondaryWeapon Knife3 = new SecondaryWeapon("Knife Uolt Fang", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Secondary\Uolt Fang.png", 0, 1);
            //SecondaryWeapon Revolver = new SecondaryWeapon("Revolver Raynbow", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Secondary\Raynbow.png", 0, 6);
            //SecondaryWeapon Revolver2 = new SecondaryWeapon("Revolver Raynbow", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Secondary\Rutumn Puthon.png", 0, 6);
            //SecondaryWeapon Revolver3 = new SecondaryWeapon("Revolver Tiger", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Secondary\Tiger Puthon.png", 0, 6);
            //SecondaryWeapon Revolver4 = new SecondaryWeapon("Revolver Uenomous", 1000, 10, @"ms-appx:///Assets\Pictures\Weapons\Secondary\Uenomous.png", 0, 6);
            //Hat hat1 = new Hat("Bandit Hat", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Bandit.png");
            //Hat hat2 = new Hat("Clown Hat", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Clown.png");
            //Hat hat3 = new Hat("Diuer Goggles", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Diuer Goggles.png");
            //Hat hat4 = new Hat("Jack o' Lantern", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Jack o' Lantern.png");
            //Hat hat5 = new Hat("Mad Cap", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Mad Cap.png");
            //Hat hat6 = new Hat("Mad Man", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Madman.png");
            //Hat hat7 = new Hat("Pig Head", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Pig Head.png");
            //Hat hat8 = new Hat("Afro Head", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Rfro.png");
            //Hat hat9 = new Hat("Sun Glasses", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Sun Glasses.png");
            //Hat hat10 = new Hat("Zombie Head", 100, Clothing.ClothSize.Medium, 10, @"ms-appx:///Assets\Pictures\Hats\Zombie Head.png");
            //Bag bag1 = new Bag("Diablo Wings", 100, Clothing.ClothSize.Large, 10, @"ms-appx:///Assets\Pictures\Bags\Diablo Wings.png");
            //Bag bag2 = new Bag("Panda Body", 100, Clothing.ClothSize.Large, 10, @"ms-appx:///Assets\Pictures\Bags\Panda Body.png");
            //Bag bag3 = new Bag("Angelic Wings", 100, Clothing.ClothSize.Large, 10, @"ms-appx:///Assets\Pictures\Bags\Rngeilc Wings.png");
            //Bag bag4 = new Bag("Samurai Blades", 100, Clothing.ClothSize.Large, 10, @"ms-appx:///Assets\Pictures\Bags\Samurai Blades.png");
            //Uniforms uniform1 = new Uniforms("WW2 Uniforms", 100, Clothing.ClothSize.Large, 10, @"ms-appx:///Assets\Pictures\Uniforms\WW2 Uniforms.png");
            //Uniforms uniform2 = new Uniforms("School Uniforms", 100, Clothing.ClothSize.Large, 10, @"ms-appx:///Assets\Pictures\Uniforms\School.png");
            //jsonFileItems.Add(M4);
            //jsonFileItems.Add(AK47);
            //jsonFileItems.Add(Sniper);
            //jsonFileItems.Add(UMP);
            //jsonFileItems.Add(RPG);
            //jsonFileItems.Add(Sniper2);
            //jsonFileItems.Add(MAG);
            //jsonFileItems.Add(Shotgun);
            //jsonFileItems.Add(Sniper3);
            //jsonFileItems.Add(Knife);
            //jsonFileItems.Add(Knife2);
            //jsonFileItems.Add(Knife3);
            //jsonFileItems.Add(Revolver);
            //jsonFileItems.Add(Revolver2);
            //jsonFileItems.Add(Revolver3);
            //jsonFileItems.Add(Revolver4);
            //jsonFileItems.Add(hat1);
            //jsonFileItems.Add(hat2);
            //jsonFileItems.Add(hat3);
            //jsonFileItems.Add(hat4);
            //jsonFileItems.Add(hat5);
            //jsonFileItems.Add(hat6);
            //jsonFileItems.Add(hat7);
            //jsonFileItems.Add(hat8);
            //jsonFileItems.Add(hat9);
            //jsonFileItems.Add(hat10);
            //jsonFileItems.Add(bag1);
            //jsonFileItems.Add(bag2);
            //jsonFileItems.Add(bag3);
            //jsonFileItems.Add(bag4);
            //jsonFileItems.Add(uniform1);
            //jsonFileItems.Add(uniform2);
            #endregion
            //Go to SerializeJsonFile method and change GetFileAsync to CreateFileAsync
            //Serialize the lists first to create the files.
            //After that close the program, delete the Storage Instances region and this code and uncomment the Deserialize lines
            //Change back the SerializeJsonFile method from CreateFileAsync to GetFileAsync
            /*SerializeJsonFile(userItemsList, "StorageFile.json");
            SerializeJsonFile(userItemsList, "StoreItems.json");
            SerializeJsonFile(userItemsList, "UserItems.json");
            SerializeJsonFile(userItemsList, "Receiptions.json");
            */
            DeserializeFile(jsonFileItems, "StorageFile.json"); //Update the list from the json file
            DeserializeFile(storeItemsList, "StoreItems.json"); //Update the list from the store json file
            DeserializeFile(userItemsList, "UserItems.json"); //Update the list from the user json file
            DeserializeFile(receiptionsList, "Receiptions.json"); //Update the list from the receiptions json file
            
        }
        public bool CreateItem(AbstractItem item, bool isUser = true) //Create new item to its proper list
        {
            if (isUser == true)
            {
                if (!IsItemAlreadyAdded(item))
                {
                    userItemsList.Add(item);
                    SerializeJsonFile(userItemsList, "UserItems.json");
                    return true;
                }
            }
            else
            {
                if (!IsItemAlreadyAdded(item, false))
                {
                    storeItemsList.Add(item);
                    SerializeJsonFile(storeItemsList, "StoreItems.json");
                    return true;
                }
            }
            return false;
        }

        public void DeleteItem(AbstractItem item, bool isUser = true) //Delete an item from its proper list
        {
            if(isUser == true)
            {
                AbstractItem removedItem = userItemsList.Find(i => i.Name.Equals(item.Name));
                userItemsList.Remove(removedItem);
                SerializeJsonFile(userItemsList, "UserItems.json");
            }else
            {
                AbstractItem removedItem = storeItemsList.Find(i => i.Name.Equals(item.Name));
                storeItemsList.Remove(removedItem);
                SerializeJsonFile(storeItemsList, "StoreItems.json");
            }
        }

        public AbstractItem GetItemByID(int itemID, bool isUser = true) //Get and item by id from its proper list
        {
            if(isUser == true)
                return userItemsList.Find(i => i.ID == itemID);
            return storeItemsList.Find(i => i.ID == itemID);
        }
        public AbstractItem GetItemByName(string name, bool isUser = true) //Get and item by name from its proper list
        {
            if (isUser)
            {
                AbstractItem tempitem = userItemsList.Find(i => i.Name.Equals(name));
                return userItemsList.Find(i => i.Name.Equals(name));
            }
            return storeItemsList.Find(i => i.Name.Equals(name));
        }
        public List<AbstractItem> GetItems(bool isUser = true) //Get the items from the proper list
        {
            if(isUser == true)
                return userItemsList;
            return storeItemsList;
        }
        public AbstractItem GetStorageItemByName(string name) //Get item name from the storage list
        {
            return jsonFileItems.Find(n => n.Name.Equals(name));
        }
        public List<AbstractItem> GetAvailableItems() //Get all the items from the storage list
        {
            return jsonFileItems;
        }
        private bool IsTypeExist(string type) //Check if type is already exists
        {
            if (typesList.Exists(t => t.Equals(type)))
                return true;
            return false;
        }
        private bool IsItemAlreadyAdded(AbstractItem item, bool isUser = true) //Check if user/store already have that item
        {
            if(isUser)
            {
                if (userItemsList.Exists(i => i.Name.Equals(item.Name)))
                    return true;
            }else
            {
                if (storeItemsList.Exists(i => i.Name.Equals(item.Name)))
                    return true;
            }
            return false;
        }
        public List<string> GetAvailableTypes() //Get the available types of the store
        {
            for (int i = 0; i < jsonFileItems.Count; i++)
            {
                if (!IsTypeExist(jsonFileItems[i].GetType().Name))
                    typesList.Add(jsonFileItems[i].GetType().Name);
            }
            return typesList;
        }
        public List<Receiption> GetReceiptions() //Get the receiptions list
        {
            return receiptionsList;
        }
        public void UpdateAmounts(List<AbstractItem> itemsList) //Update the amount of a specific item
        {
            for (int i = 0; i < storeItemsList.Count; i++)
            {
                if(itemsList.Exists(n => storeItemsList[i].Name.Equals(n.Name)))
                {
                    storeItemsList[i].AvailableAmount--;
                    if (storeItemsList[i].AvailableAmount == 0)
                        storeItemsList.RemoveAt(i);
                }
            }
            SerializeJsonFile(storeItemsList, "StoreItems.json");
        }
        public void Clear(bool isUser) //Clear the entire proper list
        {
            if(isUser)
            {
                while(userItemsList.Count != 0)
                {
                    DeleteItem(userItemsList[0], true);
                }
            }
            else
            {
                while (storeItemsList.Count != 0)
                {
                    DeleteItem(storeItemsList[0], true);
                }
            }
        }
        public void AddReceiption(Receiption recep) //Add receipt
        {
            receiptionsList.Add(recep);
            SerializeJsonFile(receiptionsList, "Receiptions.json");
        }
        private async void SerializeJsonFile<T>(List<T> tempList, string filename) //Serialize specific list to a file
        {
            if (tempList.Count == 0)
            {
                var nullFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                await FileIO.WriteTextAsync(nullFile, "");
                return;
            }
            string filecontent = JsonConvert.SerializeObject(tempList, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            var json = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            await FileIO.WriteTextAsync(json, filecontent);
        }
        private async void DeserializeFile<T>(List<T> tempList, string filename) //Deserialize specific list from a file
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            var filecontent = await FileIO.ReadTextAsync(file);
            if (filecontent != "")
            {
                List<T> tempItems = JsonConvert.DeserializeObject<List<T>>(filecontent, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }); 
                foreach (T item in tempItems)
                {
                    tempList.Add(item);
                }
            }
        }
    }
}

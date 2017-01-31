using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace App1
{
    class SaveArmy
    {
        Army army;
        List<Squad> armyList;
        string fullArmyList = " ";
        List<string> finalList = new List<string>();


        public SaveArmy()
        { }

        public async void SaveTheArmy(Army _army)
        {
            army = _army;
            string armyName = army.GetArmyName();
            armyList = army.GetArmyList();
            var localFolder = ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync(
                    "LastArmy.txt", CreationCollisionOption.OpenIfExists);

            // loop through an arry to create a big string with a delimiter

            fullArmyList += army.armyPoints.ToString() + ';';

            for (int i = 0; i < armyList.Count; i++)
            {
                fullArmyList += armyList[i].squadDesc + ';';
            }


            file = await localFolder.CreateFileAsync(
                   "LastArmy.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, fullArmyList);
        }


        public async void SetLastArmy()
        {
            var localFolder = ApplicationData.Current.LocalFolder;

            // attempt to open file
            var file = await localFolder.CreateFileAsync(
                "LastArmy.txt", CreationCollisionOption.OpenIfExists);

            string thing = await FileIO.ReadTextAsync(file);
            string[] savedArmy = thing.Split(';');

            for(int i = 0; i < savedArmy.Length; i++)
            {
                finalList.Add(savedArmy[i]);
            }
             
        }


        public List<string> GetLastArmy()
        {
            return finalList;
        }



    }
}


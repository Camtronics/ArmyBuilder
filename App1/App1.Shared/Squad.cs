using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class Squad
    {
        public static List<Unit> aSquad = new List<Unit>();
        public string squadType { get; set; }
        public int squadPointValue { get; set; }
        public int squadSize;
        public string squadDesc { get; set; }
        public string squadName { get; set; }
        private static List<string> squadTypes = new List<string> { "HQ", "Troop", "Elite", "Fast Attack", "Vehicles", "Heavy Support"};
        private static List<string> hqTypes = new List<string> { "Asmodai", "Belial", "Chaplain", "Company Master", "Ezekiel"};
        private static List<string> troopTypes = new List<string> { "Tactical Squad", "Scout Squad"};
        public string squadSpecialRules;
        public string squadEquipment;

        public Squad()
        { }






        public List<string> GetTypes()
        {
            return squadTypes;
        }

        public List<string> GetHQs()
        {
            return hqTypes;
        }

        public List<string> GetTroops()
        {
            return troopTypes;
        }





    }
}

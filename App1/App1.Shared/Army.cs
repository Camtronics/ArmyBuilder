using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class Army
    {
        List<Squad> army = new List<Squad>();
        public string armyName;
        public int armyPoints { get; set; }
        public string newUnitType { get; set; }
        public int editUnitAtPosition { get; set; }

        public void SetArmyName(string name)
        {
            this.armyName = name;
        }
        public string GetArmyName()
        {
            return armyName;
        }

        public List<Squad> GetArmyList()
        {
            return army;
        }

        public int countTacSquads()
        {
            int numberOfTacSquads = 0;

            foreach (Squad arm in army)
            {
                if (arm.squadType == "TacSquad")
                {
                    numberOfTacSquads++;
                }
                else
                {

                }
            }
            return numberOfTacSquads;
        }
    }
}

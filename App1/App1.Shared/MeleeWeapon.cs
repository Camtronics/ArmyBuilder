using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class MeleeWeapon: Weapon
    {
        
        

        public static List<string> meleeList = new List<string> { "Chainsword 0pts", "Ligtning Claw 15pts", "Power Sword 15pts",
                                                                   "Power Fist 25pts", "Thunder Hammer 30pts"};

        public MeleeWeapon(string wepName)
        {
            switch (wepName)
            {
                case ("Chainsword"):
                    {
                        priWepName = "Chainsword";
                        priWepStrng = "User";
                        priWepAP = "-";
                        priWepType = "Melee";
                        wepPointsValue = 0;
                        isCombi = false;
                        break;
                    }
                case ("Ligtning Claw"):
                    {
                        priWepName = "Lightning Claw";
                        priWepStrng = "User";
                        priWepAP = "3";
                        priWepType = "Melee, Shred, Specialist Weapon";
                        wepPointsValue = 15;
                        isCombi = false;
                        break;
                    }
                case ("Power Sword"):
                    {
                        priWepName = "Power Sword";
                        priWepStrng = "User";
                        priWepAP = "3";
                        priWepType = "Melee";
                        wepPointsValue = 15;
                        isCombi = false;
                        break;
                    }
                case ("Power Fist"):
                    {
                        priWepName = "Power Fist";
                        priWepStrng = "x2";
                        priWepAP = "2";
                        priWepType = "Melee, Specialist Wepaon, Unwieldy";
                        wepPointsValue = 25;
                        isCombi = false;
                        break;
                    }
                case ("Thunder Hammer"):
                    {
                        priWepName = "Thunder Hammer";
                        priWepStrng = "x2";
                        priWepAP = "2";
                        priWepType = "Melee, Concusive, Specialist Weapon, Unwieldy";
                        wepPointsValue = 30;
                        isCombi = false;
                        break;
                    }
            }
        }


        public static List<string> GetMeleeList()
        {
            return meleeList;

        }




    }
}

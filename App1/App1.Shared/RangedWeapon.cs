using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class RangedWeapon: Weapon
    {
        public static List<string> fullRanged = new List<string> { "Bolt Pistol 0pts", "Boltgun 0pts", "Storm Bolter 5pts", "Combi-Flamer 10pts",
                                    "Combi-grav 10pts", "Combi-Melta 10pts", "Combi-Plasma 10pts", "Plasma Pistol 15pts", "Grav Pistol 15pts"  };

        public static List<string> nonPistolRanged = new List<string> { "Boltgun 0pts", "Storm Bolter 5pts", "Combi-Flamer 10pts",
                                                                        "Combi-grav 10pts", "Combi-Melta 10pts", "Combi-Plasma 10pts", };

        public static List<string> pistolRanged = new List<string> { "Bolt Pistol 0pts", "Plasma Pistol 15pts",
                                                                      "Grav Pistol 15pts" };

        public RangedWeapon(string wepName)
                 : base()
        {
           switch (wepName)
           {
               
                case "Bolt Pistol":
                    {
                        this.wepPointsValue = 0;
                        this.wepName = "Bolt Pistol";
                        this.priWepName = "Bolt Pistol";
                        this.priWepRange = "12";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Pistol";
                        isCombi = false;
                        break;
                    }
                case "Boltgun":
                    {
                        this.wepPointsValue = 0;
                        this.wepName = "Boltgun";
                        this.priWepName = "Boltgun";
                        this.priWepRange = "24";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Rapid Fire";
                        isCombi = false;
                        break;
                    }
                case "Storm Bolter":
                    {
                        this.wepPointsValue = 5;
                        this.wepName = "Storm Bolter";
                        this.priWepName = "Storm Bolter";
                        this.priWepRange = "24";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Assault 2";
                        isCombi = false;
                        break;
                    }
                case "Combi-Flamer":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Combi-Flamer";
                        this.priWepName = "Boltgun";
                        this.priWepRange = "24";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Rapid Fire";
                        this.secWepName = "Flamer";
                        this.secWepRange = "Template";
                        this.secWepStrng = "4";
                        this.secWepAP = "5";
                        this.secWepType = "Assault 1, One Use Only";
                        break;
                    }
                case "Combi-grav":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Combi-Grav";
                        this.priWepName = "Boltgun";
                        this.priWepRange = "24";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Rapid Fire";
                        this.secWepName = "Grav-Gun";
                        this.secWepRange = "18";
                        this.secWepStrng = "*";
                        this.secWepAP = "2";
                        this.secWepType = "Salvo 2/3, Concusion, Graviton, One Use Only";
                        break;
                    }
                case "Combi-Melta":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Combi-Melta";
                        this.priWepName = "Boltgun";
                        this.priWepRange = "24";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Rapid Fire";
                        this.secWepName = "Meltagun";
                        this.secWepRange = "12";
                        this.secWepStrng = "8";
                        this.secWepAP = "1";
                        this.secWepType = "Assault 1, Melta, One Use Only";
                        break;
                    }
                case "Combi-Plasma":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Combi-Plasma";
                        this.priWepName = "Boltgun";
                        this.priWepRange = "24";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Rapid Fire";
                        this.secWepName = "Plasma Gun";
                        this.secWepRange = "24";
                        this.secWepStrng = "7";
                        this.secWepAP = "2";
                        this.secWepType = "Rapid Fire, Gets Hot, One Use Only";
                        break;
                    }
                case "Plasma Pistol":
                    {
                        this.wepPointsValue = 15;
                        this.wepName = "Plasma Pistol";
                        this.priWepName = "Plasma Pistol";
                        this.priWepRange = "12";
                        this.priWepStrng = "7";
                        this.priWepAP = "2";
                        this.priWepType = "Pistol, Get Hot";
                        isCombi = false;
                        break;
                    }
                case "Grav Pistol":
                    {
                        this.wepPointsValue = 15;
                        this.wepName = "Grav Pistol";
                        this.priWepName = "Grav Pistol";
                        this.priWepRange = "12";
                        this.priWepStrng = "*";
                        this.priWepAP = "2";
                        this.priWepType = "Pistol, Concussive, Graviton";
                        isCombi = false;
                        break;
                    }

            }//end wep switch

        }//end constructor

        public static List<string> GetFullRanged()
        {
            return fullRanged;
        }

        public static List<string> GetNonPistol()
        {
            return nonPistolRanged;
        }

        public static List<string> GetPistols()
        {
            return pistolRanged;
        }




    }
}

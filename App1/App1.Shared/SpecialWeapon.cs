using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class SpecialWeapon : Weapon
    {
        

        public static List<string> specWeaps = new List<string> { "Flamer 5pts", "Meltagun 10pts", "Grav-gun 15pts", "Plasma Gun 15pts" };
        

        public SpecialWeapon(string wepName)
        {
            switch (wepName)
            {

                case ("Flamer"):
                    {
                        this.wepPointsValue = 5;
                        this.wepName = "Flamer";
                        this.priWepName = "Flamer";
                        this.priWepRange = "Template";
                        this.priWepStrng = "4";
                        this.priWepAP = "5";
                        this.priWepType = "Asault 1";
                        isCombi = false;
                        break;
                    }
                case "Meltagun":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Meltagun";
                        this.priWepName = "Meltagun";
                        this.priWepRange = "12";
                        this.priWepStrng = "8";
                        this.priWepAP = "1";
                        this.priWepType = "Asault 1, Melta";
                        isCombi = false;
                        break;
                    }
                case "Grav-gun":
                    {
                        this.wepPointsValue = 15;
                        this.wepName = "Grav-gun";
                        this.priWepName = "Grav-gun";
                        this.priWepRange = "18";
                        this.priWepStrng = "*";
                        this.priWepAP = "2";
                        this.priWepType = "Salvo 2/3, Concusive, Graviton";
                        isCombi = false;
                        break;
                    }
                case "Plasma Gun":
                    {
                        this.wepPointsValue = 15;
                        this.wepName = "Plasma Gun";
                        this.priWepName = "Plasma Gun";
                        this.priWepRange = "24";
                        this.priWepStrng = "7";
                        this.priWepAP = "2";
                        this.priWepType = "Rapid Fire, Gets Hot";
                        isCombi = false;
                        break;
                    }


            }//end wep switch

        }//end constructor

        public static List<string> GetSpecials()
        {
            return specWeaps;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class HeavyWeapons: Weapon

    {
        public static List<string> heavWeaps = new List<string>
        { "Heavy Bolter 10pts", "Multi-Melta 10pts", "Missle Launcher (frag/krak) 15pts",
            "Missle Launcher (frag/krak/flakk) 25pts", "Plasma Cannon 15pts", "Lascannon 20pts",
            "Grav-cannon w/ grav-amp 35pts" };


        public HeavyWeapons(string wepName)
        {
            switch (wepName)
            {

                case "Heavy Bolter":
                    {
                        this.wepPointsValue = 5;
                        this.wepName = "Heavy Bolter";
                        this.priWepName = "Heavy Bolter";
                        this.priWepRange = "36";
                        this.priWepStrng = "5";
                        this.priWepAP = "4";
                        this.priWepType = "Heavy 4";
                        isCombi = false;
                        break;
                    }
                case "Multi-Melta":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Multi-Melta";
                        this.priWepName = "Multi-Melta";
                        this.priWepRange = "24";
                        this.priWepStrng = "8";
                        this.priWepAP = "1";
                        this.priWepType = "Heavy 1, Melta";
                        isCombi = false;
                        break;
                    }
                case "Missle Launcher (frag/krak)":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Missle Launcher (frag/krak)";
                        this.priWepName = "Missle Launcher (frag/krak)";
                        this.priWepRange = "48";
                        this.priWepStrng = "See Book for Missle Types";
                        this.priWepAP = "See Book for Missle Types";
                        this.priWepType = "See Book for Missle Types";
                        isCombi = false;
                        break;
                    }
                case "Missle Launcher (frag/krak/flakk)":
                    {
                        this.wepPointsValue = 10;
                        this.wepName = "Missle Launcher (frag/krak/flakk)";
                        this.priWepName = "Missle Launcher (frag/krak/flakk)";
                        this.priWepRange = "48";
                        this.priWepStrng = "See Book for Missle Types";
                        this.priWepAP = "See Book for Missle Types";
                        this.priWepType = "See Book for Missle Types";
                        isCombi = false;
                        break;
                    }
                case "Plasma Cannon":
                    {
                        this.wepPointsValue = 15;
                        this.wepName = "Plasma Cannon";
                        this.priWepName = "Plasma Cannon";
                        this.priWepRange = "36";
                        this.priWepStrng = "7";
                        this.priWepAP = "2";
                        this.priWepType = "Heavy 1, Blast, Gets Hot";
                        isCombi = false;
                        break;
                    }
                case "Lascannon":
                    {
                        this.wepPointsValue = 20;
                        this.wepName = "Lascannon";
                        this.priWepName = "Lascannon";
                        this.priWepRange = "48";
                        this.priWepStrng = "9";
                        this.priWepAP = "2";
                        this.priWepType = "Heavy 1";
                        isCombi = false;
                        break;
                    }
                case "Grav-cannon w/ grav-amp":
                    {
                        this.wepPointsValue = 35;
                        this.wepName = "Grav-cannon w/ grav-amp";
                        this.priWepName = "Grav-cannon w/ grav-amp";
                        this.priWepRange = "24";
                        this.priWepStrng = "*";
                        this.priWepAP = "2";
                        this.priWepType = "Salvo 3/5, Concusive, Graviton";
                        isCombi = false;
                        break;
                    }
               


            }//end wep switch

        }//end constructor

        public static List<string> GetHeavy()
        {
            return heavWeaps;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class TacSquad : Squad
    {
        public int spaceMarineCount { get; set; }

        public TacSquad()
        {
            squadPointValue += 70;
            SpaceMarineSgt Sgt = new SpaceMarineSgt();
            aSquad.Add(Sgt);
            for (int i = 0; i < 4; i++)
            {
                spaceMarineCount++;
                SpaceMarine marine = new SpaceMarine();
                aSquad.Add(marine);
            }
            squadSize = 5;
            squadType = "TacSquad";
            squadSpecialRules = "Special Rules:\nAnd They Shall Know No Fear, Combat Squads, Grim Resolve\n";
            squadEquipment = "Wargear:\nFragg Grenades, Crack Grenades";

        }
//add marine
        public void AddSpaceMarine()
        {
            if (spaceMarineCount == 9)//if there 9 SM do nothing
            { }
            else//if less than 9
            {
                squadPointValue += 14;
                spaceMarineCount++;
                squadSize++;
                SpaceMarine marine = new SpaceMarine();
                aSquad.Add(marine);
                
            }
        }//emd add marine

//remove marine

        public void RemoveSpaceMarine()
        {
            if (spaceMarineCount > 4)//remove marine if there are more than 4
            {
                aSquad.RemoveAt(spaceMarineCount);
                squadPointValue -= 14;
                spaceMarineCount--;
                squadSize--;
            }
            else//if 4 do nothing
            {
            }
        }//end remove marine

        //Set Sgt Type


        public void MakeSgt()
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            sgt.MakeSgt();
            aSquad.RemoveAt(0);
            aSquad.Insert(0, sgt);
        }

        public void MakeVetSgt()
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            sgt.MakeVetSgt();
            aSquad.RemoveAt(0);
            aSquad.Insert(0, sgt);
        }

        public string GetSgtType()
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            string name = sgt.unitType;
            return name;
        }




        //Set Heavy and Special for SM 4

        public void ChangeWepSpecial4(string weapon)
        {
            SpaceMarine marine = new SpaceMarine();
            marine.ChangeWeaponToSpecial(weapon);
            marine.isSpecial = true;
            aSquad.RemoveAt(4);
            aSquad.Insert(4, marine);
        }

        public void ChangeWepHeavy4(string weapon)
        {
            SpaceMarine marine = new SpaceMarine();
            marine.ChangeWeaponToHeavy(weapon);
            marine.isHeavy = true;
            aSquad.RemoveAt(4);
            aSquad.Insert(4, marine);
        }


//Set Heavy and Special for SM 9

        public void ChangeWepSpecial9(string weapon)
        {
            SpaceMarine marine = new SpaceMarine();
            marine.ChangeWeaponToSpecial(weapon);
            marine.isSpecial = true;
            aSquad.RemoveAt(9);
            aSquad.Insert(9, marine);
        }

        public void ChangeWepHeavy9(string weapon)
        {
            SpaceMarine marine = new SpaceMarine();
            marine.ChangeWeaponToHeavy(weapon);
            marine.isHeavy = true;
            aSquad.RemoveAt(9);
            aSquad.Insert(9, marine);
        }


//Set Sgt Weapons

        public void ChangeSgtRanged(string weapon)
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            sgt.ChangeRangedWeapon(weapon);
            aSquad.RemoveAt(0);
            aSquad.Insert(0, sgt);
        }

        public void ChangeSgtPistol(string weapon)
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            sgt.ChangePistolWeapon(weapon);
            aSquad.RemoveAt(0);
            aSquad.Insert(0, sgt);
        }

        public void ChangeSgtMelee(string weapon)
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            sgt.ChangeMeleeWeapon(weapon);
            aSquad.RemoveAt(0);
            aSquad.Insert(0, sgt);
        }


//Get Weapons for Positions 4 and 9 Sgt

        public Weapon GetMarine4Wepaon()
        {
            SpaceMarine marine = aSquad[4] as SpaceMarine;
            Weapon weapon = marine.GetWeapon();
            return weapon;
        }

        public Weapon GetMarine9Wepaon()
        {
            SpaceMarine marine = aSquad[9] as SpaceMarine;
            Weapon weapon = marine.GetWeapon();
            return weapon;
        }

        
///get Sgt Weapons 

        public Weapon GetSgtRangedWepaon()
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            Weapon weapon = sgt.GetWeapon();
            return weapon;
        }

        public Weapon GetSgtPistolWepaon()
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            Weapon weapon = sgt.GetPistolWeapon();
            return weapon;
        }

        public Weapon GetSgtMeleeWepaon()
        {
            SpaceMarineSgt sgt = aSquad[0] as SpaceMarineSgt;
            Weapon weapon = sgt.GetMeleeWeapon();
            return weapon;
        }


//Reset the weapons of position 4 and 9

        public void ResetBolter4()
        {
            SpaceMarine marine = new SpaceMarine();
            marine.isSpecial = false;
            marine.isHeavy = false;
            aSquad.RemoveAt(4);
            aSquad.Insert(4, marine);
        }

        public void ResetBolter9()
        {
            SpaceMarine marine = new SpaceMarine();
            marine.isSpecial = false;
            marine.isHeavy = false;
            aSquad.RemoveAt(9);
            aSquad.Insert(9, marine);
        }

        public bool IsMarine4Special()
        {
            SpaceMarine marine = aSquad[4] as SpaceMarine;
            bool isSpecial = marine.isSpecial;
            return isSpecial;
        }

        public bool IsMarine4Heavy()
        {
            SpaceMarine marine = aSquad[4] as SpaceMarine;
            bool isHeavy = marine.isHeavy;
            return isHeavy;
        }

        public int CountBolters()
        {
            int bolterCount = 0;

            for (int i = 1; i < squadSize;  i++)
            {
                SpaceMarine marine = aSquad[i] as SpaceMarine;
                if (marine.GetWeapon().priWepName == "Boltgun")
                {
                    bolterCount++;
                }
            }
         return bolterCount;
        }

        public void ClearMarines()
        {
            aSquad.Clear();
        }

    }
}

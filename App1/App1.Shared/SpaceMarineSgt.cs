using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class SpaceMarineSgt: Unit
    {
        Weapon spaceMarineWeapon;
        Weapon spaceMarineMelee;
        Weapon spaceMarineSideArm;

        public SpaceMarineSgt()
            : base()
        {
            this.unitType = "Space Marine Sgt";
            spaceMarineWeapon = new RangedWeapon("Bloter");
            spaceMarineMelee = new MeleeWeapon("Chainsword");
            spaceMarineSideArm = new RangedWeapon("Bolt Pistol");
            this.wepSkill = 4;
            this.balSkill = 4;
            this.strength = 4;
            this.toughness = 4;
            this.wounds = 1;
            this.initiative = 4;
            this.attacks = 1;
            this.leadership = 8;
            this.save = 3;
        }

        public void MakeVetSgt()
        {
            this.unitType = "Veteran Sergeant";
            this.attacks = 2;
            this.leadership = 9;
        }

        public void MakeSgt()
        {
            this.unitType = "Space Marine Sgt";
            this.attacks = 1;
            this.leadership = 8;
        }


        //get weapons
        public Weapon GetWeapon()
        {
            return spaceMarineWeapon;
        }

        public Weapon GetPistolWeapon()
        {
            return spaceMarineSideArm;
        }

        public Weapon GetMeleeWeapon()
        {
            return spaceMarineMelee;
        }
        


        //Change weapons
        public void ChangeRangedWeapon(string weapon)
        {
            spaceMarineWeapon = new RangedWeapon(weapon);
        }

        public void ChangePistolWeapon(string weapon)
        {
            spaceMarineSideArm = new RangedWeapon(weapon);
        }

        public void ChangeMeleeWeapon(string weapon)
        {
            spaceMarineMelee = new MeleeWeapon(weapon);
        }





    }
}

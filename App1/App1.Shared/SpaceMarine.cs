using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class SpaceMarine: Unit
    {
        Weapon spaceMarineWeapon;
        Weapon spaceMarineSideArm;
        public bool isHeavy;
        public bool isSpecial;

        public SpaceMarine()
            : base()
        {
            spaceMarineSideArm = new RangedWeapon("Bolt Pistol");
            spaceMarineWeapon = new RangedWeapon("Boltgun");
            this.wepSkill = 4;
            this.balSkill = 4;
            this.strength = 4;
            this.toughness = 4;
            this.wounds = 1;
            this.initiative = 4;
            this.attacks = 1;
            this.leadership = 8;
            this.save = 3;
            isHeavy = false;
            isSpecial = false;
        }

        public void ChangeWeaponToSpecial(string weapon)
        {
            spaceMarineWeapon = new SpecialWeapon(weapon);
            isSpecial = true;
        }

        public void ChangeWeaponToHeavy(string weapon)
        {
            spaceMarineWeapon = new HeavyWeapons(weapon);
            isHeavy = true;
        }

        public void ChangeWeaponBolter()
        {
            spaceMarineWeapon = new RangedWeapon("Bolter");
            isHeavy = false;
            isSpecial = false;
        }
        
        public Weapon GetWeapon()
        {
            return spaceMarineWeapon;
        }


    }
}

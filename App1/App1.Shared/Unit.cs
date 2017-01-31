using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class Unit
    {
        public string unitType { get; set; }
        protected string unitName { get; set; }
        protected int wepSkill { get; set; }
        protected int balSkill { get; set; }
        protected int strength { get; set; }
        protected int toughness { get; set; }
        protected int wounds { get; set; }
        protected int initiative { get; set; }
        protected int attacks { get; set; }
        protected int leadership { get; set; }
        protected int save { get; set; }

        public Unit()
        { }
   
    }
}

using System;
using System.Collections.Generic;

namespace BlockKing.Detail
{
    public partial class People
    {
        public int PersonId { get; set; }
        public int BuildingId { get; set; }
        public int WeaponId { get; set; }
        public int WorkId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual Weapons Weapon { get; set; }
        public virtual Occupations Work { get; set; }
    }
}

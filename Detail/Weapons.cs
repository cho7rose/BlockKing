using System;
using System.Collections.Generic;

namespace BlockKing.Detail
{
    public partial class Weapons
    {
        public Weapons()
        {
            People = new HashSet<People>();
        }

        public int WeaponId { get; set; }
        public string Name { get; set; }
        public float? AttackFactor { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<People> People { get; set; }
    }
}

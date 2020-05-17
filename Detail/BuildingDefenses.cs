using System;
using System.Collections.Generic;

namespace BlockKing.Detail
{
    public partial class BuildingDefenses
    {
        public BuildingDefenses()
        {
            Buildings = new HashSet<Buildings>();
        }

        public int DefenseId { get; set; }
        public string Name { get; set; }
        public float? DefenseFactor { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Buildings> Buildings { get; set; }
    }
}

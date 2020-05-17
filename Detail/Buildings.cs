using System;
using System.Collections.Generic;

namespace BlockKing.Detail
{
    public partial class Buildings
    {
        public Buildings()
        {
            People = new HashSet<People>();
        }

        public int BuildingId { get; set; }
        public int? XLocation { get; set; }
        public int? YLocation { get; set; }
        public string Name { get; set; }
        public int DefenseId { get; set; }
        public string Icon { get; set; }

        public virtual BuildingDefenses Defense { get; set; }
        public virtual ICollection<People> People { get; set; }
    }
}

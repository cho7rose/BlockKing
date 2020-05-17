using System;
using System.Collections.Generic;

namespace BlockKing.Detail
{
    public partial class Occupations
    {
        public Occupations()
        {
            People = new HashSet<People>();
        }

        public int WorkId { get; set; }
        public string Name { get; set; }
        public int? Income { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<People> People { get; set; }
    }
}

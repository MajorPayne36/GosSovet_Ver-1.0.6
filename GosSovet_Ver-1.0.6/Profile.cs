using System;
using System.Collections.Generic;

namespace GosSovet_Ver_1._0._6
{
    public partial class Profile
    {
        public Profile()
        {
            Comission = new HashSet<Comission>();
        }

        public int IdProfile { get; set; }
        public string ProfileName { get; set; }

        public virtual ICollection<Comission> Comission { get; set; }
    }
}

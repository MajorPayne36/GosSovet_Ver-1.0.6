using System;
using System.Collections.Generic;

namespace GosSovet_Ver_1._0._6
{
    public partial class Comission
    {
        public Comission()
        {
            DepAndCom = new HashSet<DepAndCom>();
        }

        public int IdComission { get; set; }
        public string ComissionName { get; set; }
        public int IdProfile { get; set; }

        public virtual Profile IdProfileNavigation { get; set; }
        public virtual ICollection<DepAndCom> DepAndCom { get; set; }
    }
}

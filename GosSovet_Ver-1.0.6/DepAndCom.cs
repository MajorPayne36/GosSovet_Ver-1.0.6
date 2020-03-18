using System;
using System.Collections.Generic;

namespace GosSovet_Ver_1._0._6
{
    public partial class DepAndCom
    {
        public int IdDepCom { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int IdPost { get; set; }
        public int IdComission { get; set; }
        public int IdDeputy { get; set; }

        public virtual Comission IdComissionNavigation { get; set; }
        public virtual Deputy IdDeputyNavigation { get; set; }
        public virtual Post IdPostNavigation { get; set; }
    }
}

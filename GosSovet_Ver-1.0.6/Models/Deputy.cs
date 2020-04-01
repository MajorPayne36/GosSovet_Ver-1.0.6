using System;
using System.Collections.Generic;

namespace GosSovet_Ver_1._0._6
{
    public partial class Deputy
    {
        public Deputy()
        {
            DepAndCom = new HashSet<DepAndCom>();
        }

        public int IdDeputy { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public DateTime? Birthday { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Dostup { get; set; }

        public virtual ICollection<DepAndCom> DepAndCom { get; set; }
    }
}

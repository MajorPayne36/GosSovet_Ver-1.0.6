using System;
using System.Collections.Generic;

namespace GosSovet_Ver_1._0._6
{
    public partial class Post
    {
        public Post()
        {
            DepAndCom = new HashSet<DepAndCom>();
        }

        public int IdPost { get; set; }
        public string PostName { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<DepAndCom> DepAndCom { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odevproject.Models
{
    public partial class Il
    {
        public Il()
        {
            ÖdevTables = new HashSet<ÖdevTable>();
            Ilceler = new HashSet<Ilce>();
        }

        public int IlId { get; set; }
        public string IlAd { get; set; }

        public virtual ICollection<ÖdevTable> ÖdevTables { get; set; }
        public virtual ICollection<Ilce> Ilceler { get; set; }
    }
}   

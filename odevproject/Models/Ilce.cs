using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odevproject.Models
{
    public partial class Ilce
    {
        public Ilce()
        {
            ÖdevTables = new HashSet<ÖdevTable>();
        }

        public int IlceId { get; set; }
        public string IlceAd { get; set; }
        public int IlId { get; set; }

        public virtual Il Il { get; set; }
        public virtual ICollection<ÖdevTable> ÖdevTables { get; set; }
    }
}

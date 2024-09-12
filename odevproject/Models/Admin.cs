using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odevproject.Models
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }
		public string Kullanici { get; set; }
		public string Sifre { get; set; }
    }
}

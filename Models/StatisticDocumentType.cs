using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerpaAnalisisApp.Models
{
	public class StatisticDocumentType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StatisticDocumentTypeID { get; set; }
		public string UserID { get; set; }
		public int DocumentTypeId { get; set; }
		public int TotalCorrect { get; set; }
	}
}

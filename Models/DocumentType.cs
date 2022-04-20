using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerpaAnalisisApp.Models
{
    public class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentTypeId { get; set; }
        public string Title { get; set; }

        public ICollection<Question> Question { get; set; }
    }
}

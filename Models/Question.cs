using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerpaAnalisisApp.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        [Required]
        public string QuestionDescription { get; set; }
        [Required]
        public string Answers { get; set; }
        public int CorrectAnswerNumber { get; set; }
        public int DocumentTypeId { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}

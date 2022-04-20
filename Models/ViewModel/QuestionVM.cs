using System.Collections.Generic;

namespace FerpaAnalisisApp.Models.ViewModel
{
    public class QuestionVM
    {
        public int QuestionID { get; set; }
        public string QuestionDescription { get; set; }
        public List<AnswerVM> Answers { get; set; }
        public int DocumentTypeId { get; set; }
        public int CorrectAnswerNumber { get; set; }
    }
    public class AnswerVM
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}

using FerpaAnalisisApp.Data;
using FerpaAnalisisApp.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FerpaAnalisisApp.Controllers
{
    public class PII : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PII(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        public void UpdateMenu()
        {
            //MENU
            bool AllFERPACompleted = false;
            bool AllPIICompleted = false;
            bool AllHIPAACompleted = false;
            if (User.Identity.IsAuthenticated)
            {
                var docTypeFERPA = _context.DocumentType.FirstOrDefault(x => x.Title == "FERPA").DocumentTypeId;
                var docTypePII = _context.DocumentType.FirstOrDefault(x => x.Title == "PII").DocumentTypeId;
                var docTypeHIPAA = _context.DocumentType.FirstOrDefault(x => x.Title == "HIPAA").DocumentTypeId;

                var userID = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).Id;

                var totalQuestionFERPA = _context.Question.Where(x => x.DocumentTypeId == docTypeFERPA).Count();
                var totalQuestionPII = _context.Question.Where(x => x.DocumentTypeId == docTypePII).Count();
                var totalQuestionHIPAA = _context.Question.Where(x => x.DocumentTypeId == docTypeHIPAA).Count();

                if (_context.StatisticDocumentType.Any(x => x.UserID == userID && x.DocumentTypeId == docTypeFERPA))
                    AllFERPACompleted = _context.StatisticDocumentType.FirstOrDefault(x => x.UserID == userID && x.DocumentTypeId == docTypeFERPA).TotalCorrect == totalQuestionFERPA;
                if (_context.StatisticDocumentType.Any(x => x.UserID == userID && x.DocumentTypeId == docTypePII))
                    AllPIICompleted = _context.StatisticDocumentType.FirstOrDefault(x => x.UserID == userID && x.DocumentTypeId == docTypePII).TotalCorrect == totalQuestionPII;
                if (_context.StatisticDocumentType.Any(x => x.UserID == userID && x.DocumentTypeId == docTypeHIPAA))
                    AllHIPAACompleted = _context.StatisticDocumentType.FirstOrDefault(x => x.UserID == userID && x.DocumentTypeId == docTypeHIPAA).TotalCorrect == totalQuestionHIPAA;
            }
            ViewBag.AllFERPACompleted = AllFERPACompleted;
            ViewBag.AllPIICompleted = AllPIICompleted;
            ViewBag.AllHIPAACompleted = AllHIPAACompleted;
        }
        public IActionResult Index()
        {
            var ferpaID = _context.DocumentType.FirstOrDefault(x => x.Title == "PII").DocumentTypeId;
            var listaVM = new List<QuestionVM>();
            var lista = _context.Question.Where(x => x.DocumentTypeId == ferpaID).ToList();
            foreach (var item in lista)
            {
                var tmp = new QuestionVM();
                tmp.DocumentTypeId = item.DocumentTypeId;
                tmp.QuestionDescription = item.QuestionDescription;
                tmp.QuestionID = item.QuestionID;
                tmp.CorrectAnswerNumber = item.CorrectAnswerNumber;
                var answerlist = item.Answers.Split(',').ToList();
                var count = 1;
                var tmpAnswerList = new List<AnswerVM>();
                foreach (var answer in answerlist)
                {
                    var tmp2 = new AnswerVM
                    {
                        Answer = answer,
                        Id = count,
                        IsCorrect = count == tmp.CorrectAnswerNumber
                    };
                    tmpAnswerList.Add(tmp2);
                    count++;
                }
                tmp.Answers = tmpAnswerList;
                listaVM.Add(tmp);
            }

            UpdateMenu();
            return View(listaVM);
        }
    }
}

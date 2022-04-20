using FerpaAnalisisApp.Data;
using FerpaAnalisisApp.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FerpaAnalisisApp.Controllers
{
	public class FERPA : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public FERPA(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var ferpaID = _context.DocumentType.FirstOrDefault(x => x.Title == "FERPA").DocumentTypeId;
            var listaVM = new List<QuestionVM>();
            var lista = _context.Question.Where(x => x.DocumentTypeId == ferpaID).ToList();
            foreach (var item in lista)
            {
                var tmp = new QuestionVM();
                tmp.DocumentTypeId = item.DocumentTypeId;
                tmp.QuestionDescription = item.QuestionDescription;
                tmp.QuestionID = item.QuestionID;
                tmp.CorrectAnswerNumber = item.CorrectAnswerNumber;
                var answerlist =item.Answers.Split(',').ToList();
                var count = 1;
                var tmpAnswerList = new List<AnswerVM>(); 
                foreach(var answer in answerlist)
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
            return View(listaVM);
        }

    }
}

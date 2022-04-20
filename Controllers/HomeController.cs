using FerpaAnalisisApp.Data;
using FerpaAnalisisApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FerpaAnalisisApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var labelsBarChart = new List<string>();
            var labelsBarChartData = new List<int>();
            var listDocumentType = _context.DocumentType.ToList();
            foreach (var item in listDocumentType)
            {
                labelsBarChart.Add(item.Title);
                var listStatistic = _context.StatisticDocumentType.Where(x => x.DocumentTypeId == item.DocumentTypeId).ToList();
                var total = 0;
				if (listStatistic.Any())
				{
                    total = listStatistic.Select(x => x.TotalCorrect).DefaultIfEmpty(0).Sum();
                }
                labelsBarChartData.Add(total);
            }
            ViewBag.labelsBarChart = labelsBarChart.ToArray();
            ViewBag.labelsBarChartData = labelsBarChartData.ToArray();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> SaveData(int DocumentTypeID, int TotalCorrect)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    throw new ArgumentException("You must register or login first");
                }
                if (!_context.DocumentType.Any(x => x.DocumentTypeId == DocumentTypeID))
                {
                    throw new ArgumentException("Didn't find the document type");
                }
                var username = User.Identity.Name;
                var userID = _context.Users.FirstOrDefault(x => x.Email == username).Id;
                //IF EXIST
                if (_context.StatisticDocumentType.Any(x => x.UserID == userID && x.DocumentTypeId == DocumentTypeID))
                {
                    var item = _context.StatisticDocumentType.FirstOrDefault(x => x.UserID == userID && x.DocumentTypeId == DocumentTypeID);
                    item.TotalCorrect = TotalCorrect;
                }
                else
                {
                    _context.StatisticDocumentType.Add(new StatisticDocumentType
                    {
                        DocumentTypeId = DocumentTypeID,
                        TotalCorrect = TotalCorrect,
                        UserID = userID
                    });
                }
                await _context.SaveChangesAsync();
                return Json("success");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assessment_SlipStream.Web.Models;
using Assessment_SlipStream.BAL.Services;
using Assessment_SlipStream.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assessment_SlipStream.Common.DTO;
using Assessment_SlipStream.Common.Enums;
using Assessment_SlipStream.Common.Extensions;
using System.Text;
using Assessment_SlipStream.Common.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Assessment_SlipStream.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientsService clientsService;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, ClientsService clientsService, IWebHostEnvironment _env, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            this.clientsService = clientsService;
            this._env = _env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View(clientsService.GetAll());
        }

        public IActionResult Edit(Guid id)
        {
            var client = clientsService.GetByID(id);
            ViewBag.Gender = GetGenders(client.Gender.ToString());
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Clients clients)
        {

            if (!clientsService.Update(clients))
            {
                ViewBag.Gender = GetGenders(clients.Gender.ToString());
                return View(clientsService.GetAll());
            }
            else {
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Gender = GetGenders();
            return View(new Clients() { ID = Guid.NewGuid() });
        }

        public SelectList GetGenders(string SelectedValue = "")
        {
            var res = (new EnumDetails()).GetEnumDetails<Gender>();
            return new SelectList(res, "Value", "DefualtText", SelectedValue);
        }

        [HttpPost]
        public IActionResult Add(Clients clients)
        {

            if (!clientsService.Add(clients))
            {
                ViewBag.Gender = GetGenders(clients.Gender.ToString());
                return View(clientsService.GetAll());
            }
            else {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpGet("/Home/ExportData")]
        public async Task<IActionResult> ExportData()
        {

            var csv = clientsService.GetAll().ToCSVString(new List<string>() { "ID", "CellNumber", "GenderName" });

            string filename = string.Format("Export-{0}.csv", DateTime.Now.ToString("yyyyMMdd-HHmmss"));

            var filePath = GetPathAndFilename(filename).FilePath;

            System.IO.File.WriteAllText(filePath, csv);
            string host = httpContextAccessor.HttpContext.Request.Host.Value;

            return Ok($"{httpContextAccessor.HttpContext.Request.Scheme}://{host}/Files/{filename}");
        }

        private (string FilePath, string url) GetPathAndFilename(string filename)
        {
            return (FileSys.CreateFolder(this._env.ContentRootPath + "\\Files\\").Result + filename, FileSys.CreateFolder(this._env.WebRootPath + "\\Files\\").Result + filename);
        }
    }
}

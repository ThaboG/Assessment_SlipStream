using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment_SlipStream.BAL.Services;
using Assessment_SlipStream.Common.Extensions;
using Assessment_SlipStream.Common.Helper;
using Assessment_SlipStream.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_SlipStream.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsService clientsService;
        private readonly IWebHostEnvironment _env;
        public ClientsController(IWebHostEnvironment _env, ClientsService clientsService)
        {
            this.clientsService = clientsService;
            this._env = _env;
        }

        [HttpGet]
        public IActionResult GetAll() {

            try
            {
                return Ok(clientsService.GetAll());
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
        }

        [HttpPost("/New")]
        public IActionResult Add(Clients clients) {

            try
            {
                return Ok(clientsService.Add(clients));
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
        }

        [HttpPost("/Update")]
        public IActionResult Edit(Clients clients)
        {

            if (!clientsService.Update(clients))
            {
                return Ok(clientsService.GetAll());
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("/ExportData")]
        public IActionResult ExportData()
        {

            var csv = clientsService.GetAll().ToCSVString(new List<string>() { "ID", "CellNumber", "GenderName" });

            string filename = string.Format("Export-{0}.csv", DateTime.Now.ToString("yyyyMMdd-HHmmss"));

            var filePath = GetPathAndFilename(filename);

            System.IO.File.WriteAllText(filePath, csv.ToString());

            return PhysicalFile(filePath, "text/csv", filename);
        }

        private string GetPathAndFilename(string filename)
        {
            return FileSys.CreateFolder(this._env.ContentRootPath + "\\Files\\").Result + filename;
        }

    }
}

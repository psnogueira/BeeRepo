using Microsoft.AspNetCore.Mvc;

namespace Bee.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // <iframe title="teste1db" width="600" height="373.5" src="https://app.powerbi.com/view?r=eyJrIjoiNjVjNjliMWItOGM3Mi00OGVmLThiOTctZTAyNTgwM2MxY2NkIiwidCI6IjExZGJiZmUyLTg5YjgtNDU0OS1iZTEwLWNlYzM2NGU1OTU1MSIsImMiOjR9" frameborder="0" allowFullScreen="true"></iframe>

        public IActionResult PowerBIReport()
        {
            return View();
        }
    }
}

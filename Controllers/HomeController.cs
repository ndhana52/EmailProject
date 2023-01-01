using EmailProject.Models;
using EmailProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmailProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailServices        eg ;
        public HomeController(ILogger<HomeController> logger , IEmailServices _eg)
        {
            _logger = logger;
            eg = _eg;
            
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public async Task<string> Index()
        {
            UserEmailOptions o = new UserEmailOptions
            {
                ToEmails = new List<string>() { "syamreddy52@gmail.com"}
            };

            await eg.SendTestEmail(o);


            return "view";

          
        }
        
    }
}

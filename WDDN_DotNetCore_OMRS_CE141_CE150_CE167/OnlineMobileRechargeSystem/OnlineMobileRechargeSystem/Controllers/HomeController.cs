using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMobileRechargeSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProviderRepository _provider;

        private readonly IActivePlanRepository _activePlan;
        public HomeController(ILogger<HomeController> logger, IProviderRepository provider,IActivePlanRepository activePlan)
        {
            this._provider = provider;
            _logger = logger;
            _activePlan = activePlan;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult HomePage()
        {
            var model = _provider.GetAllProvider();
            return View(model);
        }

        //[HttpPost]
        //public IActionResult HomePage()
        //{
        //    var model = _provider.GetAllProvider();
        //    return View(model);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult History()
        {
            var model = _activePlan.GetAllActivePlan(User.Identity.Name);
            return View(model);
        }
}
}

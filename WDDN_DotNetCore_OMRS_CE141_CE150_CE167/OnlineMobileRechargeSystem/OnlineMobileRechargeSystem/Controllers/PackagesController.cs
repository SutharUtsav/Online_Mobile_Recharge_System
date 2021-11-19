using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMobileRechargeSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace OnlineMobileRechargeSystem.Controllers
{
    [Authorize]
    public class PackagesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IRechargeListRepository _list;
        private readonly IProviderRepository _provider;
        private readonly ITypeofRechargeRepository _type;
        private readonly IActivePlanRepository _activeplan;
        public PackagesController(IRechargeListRepository recharge, IProviderRepository provider, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITypeofRechargeRepository type, IActivePlanRepository activePlan)
        {
            this._list = recharge;
            this._provider = provider;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _activeplan = activePlan;
            this._type = type;
        }
        [HttpPost]
        public IActionResult Index(string ph_number,string pid,string tid)
        {
            int PId = Int32.Parse(pid), TId;
            ViewBag.number = ph_number;
            ViewBag.pid = PId;
            ViewBag.type = _type.GetTypeswithId(PId);
            if (tid == null)
            {
                TId = (PId-1) * 6 + 1;
            }
            else
            {
                TId = Int32.Parse(tid);
            }
            var model = _list.GetRechargeListFilter(PId, TId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Summary(string id, string ph_number, string pid)
        {
            var model = _list.GetRecharge(Int32.Parse(id));
            int PId = Int32.Parse(pid);
            ViewBag.number = ph_number;
            ViewBag.pid = PId;
            return View(model);
        }

        [HttpPost]
        public IActionResult Summary(string id,string ph_number)
        {
            var recharge = _list.GetRecharge(Int32.Parse(id));
            var start = DateTime.Now;
            ActivePlan activePlan = new ActivePlan();
            activePlan.Phonenumber = ph_number;
            activePlan.Recharge = _list.GetRecharge(Int32.Parse(id));
            activePlan.Uid = User.Identity.Name;
            activePlan.startdate = DateTime.Now;
            var val=0;
            if (recharge.validity.HasValue)
            {
                val = (int)recharge.validity;
            }
            TimeSpan time = new TimeSpan(val, 0, 0, 0);
            activePlan.enddate = start.Add(time);
            _activeplan.Add(activePlan);
            return RedirectToAction("HomePage", "Home");
        }
    }
}

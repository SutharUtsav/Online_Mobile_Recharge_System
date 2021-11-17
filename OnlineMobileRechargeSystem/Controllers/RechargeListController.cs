using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMobileRechargeSystem.Models;
using Microsoft.AspNetCore.Http;

namespace OnlineMobileRechargeSystem.Controllers
{
    [Authorize]
    public class RechargeListController : Controller
    {
        private readonly IRechargeListRepository _list;
        private readonly IProviderRepository _provider;
        private readonly ITypeofRechargeRepository _type;
        Provider selectedprovider;
        TypeofRecharge selectedtype;
        public RechargeListController(IRechargeListRepository recharge,IProviderRepository provider, ITypeofRechargeRepository type)
        {
            this._list = recharge;
            this._provider = provider;
            this._type = type;
        }
        public IActionResult Index()
        {
            var model = _list.GetRechargeList();
            return View(model);
        }
        public ViewResult Details(int Id)
        {
            RechargeList recharge = _list.GetRecharge(Id);
            if (recharge == null)
            {
                Response.StatusCode = 404;
                return View("studentNotFount", 404);
            }
            return View(recharge);
        }
        [HttpGet]
        public IActionResult FilterProvider()
        {
            var p = _provider.GetAllProvider();
            ViewBag.Provider = new SelectList(p, "Id", "ProviderName");
            return View("~/Views/RechargeList/FilterProvider.cshtml");
        }
        [HttpPost]
        public IActionResult FilterType(string provider)
        {
            HttpContext.Session.SetString("Provider", provider);
            selectedprovider = _provider.GetProvider(Int32.Parse(provider));
            ViewBag.Provider = selectedprovider.ProviderName;
            var type = _type.GetTypeswithId(selectedprovider.Id);
            ViewBag.Type = new SelectList(type, "Id", "RechargeType");
            return View("~/Views/RechargeList/FilterType.cshtml");
        }
        [HttpGet]
        public IActionResult Filter(string type)
        {
            //HttpContext.Session.SetString("Type", type);
            //ViewBag.Provider = _provider.GetProvider().ProviderName;
            //selectedtype = _type.GetType(Int32.Parse(type));
            //ViewBag.Type = selectedtype.RechargeType;
            var model = _list.GetRechargeListFilter(Int32.Parse(HttpContext.Session.GetString("Provider")),Int32.Parse(type));

            return View(model);
        }
        [HttpGet]
        public IActionResult SelectProvider()
        {
            var p = _provider.GetAllProvider();
            ViewBag.Provider = new SelectList(p, "Id", "ProviderName");
            return View("~/Views/RechargeList/SelectProvider.cshtml");
        }
        [HttpPost]
        public IActionResult SelectType(string provider)
        {
            HttpContext.Session.SetString("Provider", provider);
            selectedprovider = _provider.GetProvider(Int32.Parse( provider));
            ViewBag.Provider = selectedprovider.ProviderName;
            var type = _type.GetTypeswithId(selectedprovider.Id);
            ViewBag.Type = new SelectList(type, "Id", "RechargeType");
            return View("~/Views/RechargeList/SelectType.cshtml");
        }
        [HttpGet]
        public IActionResult Create(string type)
        {
            HttpContext.Session.SetString("Type", type);
            ViewBag.Provider =  _provider.GetProvider(Int32.Parse( HttpContext.Session.GetString("Provider"))).ProviderName;
            selectedtype = _type.GetType(Int32.Parse(type));
            ViewBag.Type = selectedtype.RechargeType;
                
            return View();
        }
        [HttpPost]
        public IActionResult Create(RechargeList recharge)
        {
            if (ModelState.IsValid)
            {
                recharge.Provider = _provider.GetProvider(Int32.Parse(HttpContext.Session.GetString("Provider")));
                recharge.Type = _type.GetType(Int32.Parse(HttpContext.Session.GetString("Type")));
                RechargeList newrecharge = _list.Add(recharge);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var recharge = _list.GetRecharge(Id);
            //ViewData["DepartmentId"] = new SelectList(_providerRepo.GetDepartments(), "Id", "Name", provider.DepartmentId);
            return View(recharge);
        }
        [HttpPost]
        public IActionResult Edit(RechargeList model)
        {
            if (ModelState.IsValid)
            {
                RechargeList recharge = _list.GetRecharge(model.Id);
                recharge.Amount = model.Amount;
                recharge.Datapack = model.Datapack;
                recharge.SMSLimit = model.SMSLimit;
                recharge.Type = model.Type;
                recharge.Provider = model.Provider;
                recharge.validity = model.validity;
                recharge.Voice = model.Voice;

                RechargeList updaterecharge = _list.Update(recharge);
                return RedirectToAction("index");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            RechargeList recharge = _list.GetRecharge(Id);
            if (recharge == null)
            {
                return NotFound();
            }
            return View(recharge);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            var recharge = _list.GetRecharge(Id);
            _list.Delete(recharge.Id);
            return RedirectToAction("index");
        }
    }
}

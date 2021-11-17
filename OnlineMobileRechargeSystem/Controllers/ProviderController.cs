using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMobileRechargeSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnlineMobileRechargeSystem.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        private readonly IProviderRepository _provider;
        private readonly ITypeofRechargeRepository _type;
        public ProviderController(IProviderRepository provider,ITypeofRechargeRepository type)
        {
            this._provider = provider;
            this._type = type;
        }
        public IActionResult Index()
        {
            var model = _provider.GetAllProvider();
            return View(model);
        }
        public ViewResult Details(int Id)
        {
            Provider provider = _provider.GetProvider(Id);
            if (provider == null)
            {
                Response.StatusCode = 404;
                return View("studentNotFount", 404);
            }
            return View(provider);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                Provider newprovider =  _provider.Add(provider);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var provider = _provider.GetProvider(Id);
            //ViewData["DepartmentId"] = new SelectList(_providerRepo.GetDepartments(), "Id", "Name", provider.DepartmentId);
            return View(provider);
        }
        [HttpPost]
        public IActionResult Edit(Provider model)
        {
            if (ModelState.IsValid)
            {
                Provider provider = _provider.GetProvider(model.Id);
                provider.ProviderName = model.ProviderName;
                Provider updatedprovider = _provider.Update(provider);
                return RedirectToAction("index");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Provider provider = _provider.GetProvider(Id);
            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            var provider = _provider.GetProvider(Id);
            _provider.Delete(provider.Id);
            return RedirectToAction("index");
        }
    }
}

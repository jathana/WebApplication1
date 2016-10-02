using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.eBay;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class eBayFindController : Controller
    {
        // GET: eBayFind
        public ActionResult Index()
        {
            return View();
        }

      // GET: /Account/Login
      [AllowAnonymous]
      public ActionResult eBayFindByKeywords()
      {
         ///ViewBag.ReturnUrl = returnUrl;
         return View();
      }

      //
      // POST: /Account/Login
      [HttpPost]
      [AllowAnonymous]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> eBayFindByKeywords(FreeTextKeywordQueryViewModel model)
      {
         if (!ModelState.IsValid)
         {
            return View(model);
         }

         // This doesn't count login failures towards account lockout
         // To enable password failures to trigger account lockout, change to shouldLockout: true
         aBayFindAPI api = new aBayFindAPI();
         List<eBayItemViewModel> res= api.FindItemsByKeywords(model.Query);
         
         return View("eBayItems",res);
      }


   }
}
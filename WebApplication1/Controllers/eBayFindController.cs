using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.com.ebay.developer.findingAPI;
using WebApplication1.eBay;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class eBayFindController : AsyncController
    {
        // GET: eBayFind
        public ActionResult Index()
        {
            return View();
        }


      #region eBayFindByKeywords
      // GET: /Account/Login
      [AllowAnonymous]
      public ActionResult eBayFindByKeywords()
      {
         ///ViewBag.ReturnUrl = returnUrl;
         return View();
      }

      //
      // POST: /Account/Login
      //[HttpPost]
      //[AllowAnonymous]
      //[ValidateAntiForgeryToken]
      //public async Task<ActionResult> eBayFindByKeywords(FreeTextKeywordQueryViewModel model)
      //{
      //   if (!ModelState.IsValid)
      //   {
      //      return View(model);
      //   }

      //   // This doesn't count login failures towards account lockout
      //   // To enable password failures to trigger account lockout, change to shouldLockout: true
      //   aBayFindAPI api = new aBayFindAPI();
      //   List<eBayItemViewModel> res= api.FindItemsByKeywords(model.Query);
         
      //   return View("eBayItems",res);
      //}

      [HttpPost]
      [AllowAnonymous]
      [ValidateAntiForgeryToken]
      public void eBayFindByKeywordsAsync(FreeTextKeywordQueryViewModel model)
      {
         AsyncManager.OutstandingOperations.Increment();
         try
         {
            CustomFindingService service = new CustomFindingService();
            service.Url = "http://svcs.ebay.com/services/search/FindingService/v1";
            FindItemsByKeywordsRequest request = new FindItemsByKeywordsRequest();

            // Setting the required proterty value
            request.keywords = model.Query.Trim();


            // Setting the pagination 
            PaginationInput pagination = new PaginationInput();
            pagination.entriesPerPageSpecified = true;
            pagination.entriesPerPage = 25;
            pagination.pageNumberSpecified = true;
            pagination.pageNumber = model.PageNumber;
            request.paginationInput = pagination;

            // Sorting the result
            request.sortOrderSpecified = true;
            request.sortOrder = SortOrderType.CurrentPriceHighest;
            service.findItemsByKeywordsCompleted += (sender, e) =>
            {
               AsyncManager.Parameters["response"] = e.Result;
               AsyncManager.Parameters["request"] = model;
               AsyncManager.OutstandingOperations.Decrement();
            };
            service.findItemsByKeywordsAsync(request);

         }
         catch (Exception ex)
         {

         }
      }

      public ActionResult eBayFindByKeywordsCompleted(FreeTextKeywordQueryViewModel request, FindItemsByKeywordsResponse response)
      {
         eBayFindResultsViewModel viewModel = new eBayFindResultsViewModel();
         if (response.searchResult.count > 0)
         {
            
            foreach (SearchItem searchItem in response.searchResult.item)
            {
               eBayItemViewModel item = new eBayItemViewModel();
               item.ItemId = searchItem.itemId;
               item.PaymentMethod = searchItem.paymentMethod !=null ? searchItem.paymentMethod[0]:"";
               item.GalleryURL = searchItem.galleryURL != null ? searchItem.galleryURL : "http://192.168.0.0/empty.png";
               item.Title = searchItem.title;
               item.ViewItemURL = searchItem.viewItemURL!=null?searchItem.viewItemURL:"";
               item.PrimaryCategoryId = searchItem.primaryCategory != null ? searchItem.primaryCategory.categoryId : "";
               item.PrimaryCategoryName = searchItem.primaryCategory != null ? searchItem.primaryCategory.categoryName:"";

               viewModel.Items.Add(item);
            }
            viewModel.Query = request.Query;
            viewModel.PageNumber = request.PageNumber;
            viewModel.PaginationInfo.TotalPages = response.paginationOutput.totalPages;
         }
         return View("eBayItems", viewModel);
      }

      #endregion

   }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.com.ebay.developer;
using WebApplication1.com.ebay.developer.findingAPI;
using WebApplication1.Models;

namespace WebApplication1.eBay
{
   public class aBayFindAPI
   {
      public List<eBayItemViewModel> FindItemsByKeywords(string keywords)
      {

         List<eBayItemViewModel> retval = new List<eBayItemViewModel>();
         StringBuilder strResult = new StringBuilder();
         try
         {
            CustomFindingService service = new CustomFindingService();
            service.Url = "http://svcs.ebay.com/services/search/FindingService/v1";
            FindItemsByKeywordsRequest request = new FindItemsByKeywordsRequest();

            // Setting the required proterty value
            request.keywords = keywords.Trim();
            

            // Setting the pagination 
            PaginationInput pagination = new PaginationInput();
            pagination.entriesPerPageSpecified = true;
            pagination.entriesPerPage = 250;
            pagination.pageNumberSpecified = true;
            pagination.pageNumber = 1;
            request.paginationInput = pagination;

            // Sorting the result
            request.sortOrderSpecified = true;
            request.sortOrder = SortOrderType.CurrentPriceHighest;

            FindItemsByKeywordsResponse response = service.findItemsByKeywords(request);
            if (response.searchResult.count > 0)
            {
               foreach (SearchItem searchItem in response.searchResult.item)
               {
                  eBayItemViewModel item = new eBayItemViewModel();
                  item.ItemId = searchItem.itemId;
                  item.PaymentMethod = searchItem.paymentMethod[0];
                  item.GalleryURL = searchItem.galleryURL;
                  item.Title = searchItem.title;
                  item.ViewItemURL = searchItem.viewItemURL;
                  item.PrimaryCategoryId = searchItem.primaryCategory.categoryId;
                  item.PrimaryCategoryName = searchItem.primaryCategory.categoryName;

                  retval.Add(item);
               }
            }
            
         }
         catch (Exception ex)
         {
            
         }
         return retval;
      }

      public List<eBayItemViewModel> FindItemsByKeywordsAsync(string keywords)
      {

         List<eBayItemViewModel> retval = new List<eBayItemViewModel>();
         StringBuilder strResult = new StringBuilder();
         try
         {
            CustomFindingService service = new CustomFindingService();
            service.Url = "http://svcs.ebay.com/services/search/FindingService/v1";
            FindItemsByKeywordsRequest request = new FindItemsByKeywordsRequest();

            // Setting the required proterty value
            request.keywords = keywords.Trim();


            // Setting the pagination 
            PaginationInput pagination = new PaginationInput();
            pagination.entriesPerPageSpecified = true;
            pagination.entriesPerPage = 250;
            pagination.pageNumberSpecified = true;
            pagination.pageNumber = 1;
            request.paginationInput = pagination;

            // Sorting the result
            request.sortOrderSpecified = true;
            request.sortOrder = SortOrderType.CurrentPriceHighest;

            FindItemsByKeywordsResponse response = service.findItemsByKeywords(request);
            if (response.searchResult.count > 0)
            {
               foreach (SearchItem searchItem in response.searchResult.item)
               {
                  eBayItemViewModel item = new eBayItemViewModel();
                  item.ItemId = searchItem.itemId;
                  item.PaymentMethod = searchItem.paymentMethod[0];
                  item.GalleryURL = searchItem.galleryURL;
                  item.Title = searchItem.title;
                  item.ViewItemURL = searchItem.viewItemURL;
                  item.PrimaryCategoryId = searchItem.primaryCategory.categoryId;
                  item.PrimaryCategoryName = searchItem.primaryCategory.categoryName;

                  retval.Add(item);
               }
            }

         }
         catch (Exception ex)
         {

         }
         return retval;
      }
   }
}
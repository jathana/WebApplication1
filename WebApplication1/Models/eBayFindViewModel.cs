﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
   public class FreeTextKeywordQueryViewModel
   {
      [Required]
      [Display(Name = "Search")]
      public string Query { get; set; }
      public int PageNumber { get; set; }
   }

   public class eBayItemViewModel
   {
      public string ItemId { get; set; }
      public string Title { get; set; }
      public string PrimaryCategoryId { get; set; }
      public string PrimaryCategoryName { get; set; }
      public string GalleryURL { get; set; }
      public string ViewItemURL { get; set; }
      public string PaymentMethod { get; set; }

   }

   public class Pagination
   {
      public int TotalPages { get; set; }
      public int ItemsPerPage { get; set; }
   }

   public class eBayFindResultsViewModel
   {
      public List<eBayItemViewModel> Items { get; set; }
      public Pagination PaginationInfo { get; set; }
      public int PageNumber { get; set; }
      public string Query { get; set; }

      public eBayFindResultsViewModel()
      {
         Items = new List<eBayItemViewModel>();
         PaginationInfo = new Pagination();
      }
   }


}
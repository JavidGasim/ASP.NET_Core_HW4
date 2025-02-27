﻿using ASP.NET_Core_HW4.Data;
using ASP.NET_Core_HW4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ASP.NET_Core_HW4.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ProductDBContext _context;

        public CategoryListViewComponent(ProductDBContext context)
        {
            _context = context;
        }

        public ViewViewComponentResult Invoke()
        {
            var categories = _context.Categories.Select(c => new CategoryViewModel { Title = c.Title });

            return View(
                new CategoryListViewModel
                {
                    Categories = categories,
                });
        }

    }
}

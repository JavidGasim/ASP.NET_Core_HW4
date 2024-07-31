using ASP.NET_Core_HW4.Data;
using ASP.NET_Core_HW4.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_HW4.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductDBContext _context;

        public IndexModel(ProductDBContext context)
        {
            _context = context;
        }

        public List<Entities.Product> Products { get; set; }

        public void OnGet(string info = "")
        {
            Products = _context.Products.ToList();
            Info = info;
        }

        public string Info { get; set; }

        [BindProperty]
        public Entities.Product Product { get; set; }

        public IActionResult OnPostAdd()
        {
            if (Product != null)
            {
                _context.Products.Add(Product);
                _context.SaveChanges();
                Info = $"{Product.Name} added succesfully";
                return RedirectToPage("Index", new { info = Info });
            }
            return RedirectToPage("Index", new { info = "Data is null" });
        }

        public IActionResult OnPostDelete()
        {
            var id = Request.Form["id"];
            if (Product != null)
            {
                if (int.TryParse(id, out int productId))
                {
                    var result = _context.Products.SingleOrDefault(p => p.Id == productId);
                    _context.Products.Remove(result);
                    _context.SaveChanges();
                    Info = $"{Product.Name} delete succesfully";
                    return RedirectToPage("Index", new { info = Info });
                }
            }
            return RedirectToPage("Index");
        }

        [BindProperty]
        public Entities.Product EditProduct { get; set; }

        public IActionResult OnPostEdit(int id)
        {
            EditProduct = _context.Products.SingleOrDefault(p => (p.Id == id));
            Products = _context.Products.ToList();
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            _context.Products.Update(EditProduct);
            _context.SaveChanges();
            Products = _context.Products.ToList();

            return RedirectToPage("Index");
        }
    }
}

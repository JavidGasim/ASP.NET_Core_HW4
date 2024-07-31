namespace ASP.NET_Core_HW4.Models
{
    public class CategoryListViewModel
    {
        public IQueryable<CategoryViewModel> Categories { get; set; }
    }
}

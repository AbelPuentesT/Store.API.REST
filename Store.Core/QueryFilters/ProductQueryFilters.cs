using Store.Core.Enumerations;

namespace Store.Core.QueryFilters
{
    public class ProductQueryFilters
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public Category? ProductCategory { get; set; }
        public OrderBy? OrderByName { get; set; }
        public OrderBy? OrderByCategory { get; set; }
    }

}

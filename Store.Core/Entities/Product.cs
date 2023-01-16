using Store.Core.Enumerations;

namespace Store.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }=null!;
        public Category Category { get; set; } 
        public string Image { get; set; } = null!;
    }
}

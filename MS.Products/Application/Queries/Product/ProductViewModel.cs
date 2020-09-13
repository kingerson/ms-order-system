namespace MS.Products.Application
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string producer { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public bool is_active { get; set; }
        public string register_date { get; set; }
    }

    public class ProductPaginationViewModel : Pagination<ProductViewModel>
    {
    }

    public class ProductFilter : BasePagination
    {
    }
}

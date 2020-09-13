namespace MS.Suppliers.Application.Queries
{
    public class SupplierViewModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string contact_person { get; set; }
        public bool is_active { get; set; }
        public string register_date { get; set; }
    }

    public class SupplierPaginationViewModel : Pagination<SupplierViewModel>
    {
    }

    public class SupplierFilter : BasePagination
    {
    }
}

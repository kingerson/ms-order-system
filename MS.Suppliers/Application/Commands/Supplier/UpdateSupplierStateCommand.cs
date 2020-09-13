namespace MS.Suppliers.Application.Commands
{
    public class UpdateSupplierStateCommand
    {
        public int id { get; set; }
        public bool is_active { get; set; }
    }
}

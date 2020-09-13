using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Suppliers.Application.Commands
{
    public class UpdateSupplierCommand
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string contact_person { get; set; }
    }
}

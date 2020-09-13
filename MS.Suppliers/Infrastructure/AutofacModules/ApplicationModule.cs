using Autofac;
using MS.Suppliers.Application.Queries;

namespace MS.Suppliers.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        private readonly string _connectionString;
        public ApplicationModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SupplierQuery(_connectionString)).As<ISupplierQuery>().InstancePerLifetimeScope();

        }
    }
}

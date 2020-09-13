using Autofac;
using MS.Products.Application;
using MS.Products.Services;
using System.Diagnostics.CodeAnalysis;

namespace MS.Products.Infrastructure.AutofacModules
{
    [ExcludeFromCodeCoverage]
    public class ApplicationModule : Autofac.Module
    {
        private readonly string _connectionString;
        private readonly string _formatDateTime;
        public ApplicationModule(string connectionString,string formatDateTime)
        {
            _connectionString = connectionString;
            _formatDateTime = formatDateTime;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProductQuery(_connectionString)).As<IProductQuery>().InstancePerLifetimeScope();
            builder.Register(c => new ProductRepository(_connectionString, _formatDateTime)).As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DateService>().As<IDateService>().InstancePerLifetimeScope();
        }
    }
}

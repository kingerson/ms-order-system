using Autofac;
using MS.Login.Application;
using System.Diagnostics.CodeAnalysis;

namespace MS.Login.Infraestructure.AutofacModules
{
    [ExcludeFromCodeCoverage]
    public class ApplicationModule : Autofac.Module
    {
        private readonly string _connectionString;
        public ApplicationModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserQuery(_connectionString)).As<IUserQuery>().InstancePerLifetimeScope();
        }
    }
}

using Autofac;
using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Infrastructure;
using DBHuan.Shopping.Infrastructure.Helper;

namespace DBHuan.Shopping.HttpApi
{
    /// <summary>
    /// DI của ứng dụng
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    public class DBHuanShoppingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // di db
            builder.RegisterType<DBHuanShoppingDbContext>();

            // common helper
            builder.RegisterInstance(new CommonHelper())
                .As<ICommonHelper>();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("DBHuan.Shopping.Infrastructure"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // tự động tiêm các object service kết thức bằng "Service"
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("DBHuan.Shopping.Application"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
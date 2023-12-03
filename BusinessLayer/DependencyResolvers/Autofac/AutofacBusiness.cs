using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Castle.DynamicProxy;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entitiess.Concrete.DBcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace BusinessLayer.DependencyResolvers.Autofac
{
    public class AutofacBusiness : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CartItemManager>().As<ICartItemService>().SingleInstance();
            builder.RegisterType<EfCartItemDal>().As<ICartItemDal>().SingleInstance();

            builder.RegisterType<CartManager>().As<ICartService>().SingleInstance();
            builder.RegisterType<EfCartDal>().As<ICartDal>().SingleInstance();


            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<IngredientManager>().As<IIngredientService>().SingleInstance();
            builder.RegisterType<EfIngredientDal>().As<IIngredientDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            builder.RegisterType<SizeManager>().As<ISizeService>().SingleInstance();
            builder.RegisterType<EfSizeDal>().As<ISizeDal>().SingleInstance();


            var assembly = Assembly.GetExecutingAssembly();
            var repo = Assembly.GetAssembly(typeof(AppDbContext));

            builder.RegisterAssemblyTypes(assembly, repo);

		}

	}
}

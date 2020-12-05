using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Solid;
using CourseProjectWPF.ViewModels;
using CourseProjectWPF.Windows;
using DAL.Concrete;
using DAL.Interfaces;
using System.Configuration;
using System.Windows;
using Unity;
using AutoMapper;
using DTO;
//using Unity.Injection;

namespace CourseProjectWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IUnityContainer Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);
            //RegisterUnity();

            //UnityContainer newContainer = new UnityContainer();
            // newContainer.RegisterType<User>();
            //    new InjectionConstructor("LoginShipperModel"));


            Container = new UnityContainer();

            Container.RegisterType<IItemDAL, ItemDAL>()
                     .RegisterType<IOrderDAL, OrderDAL>()
                     .RegisterType<IAddToOrderDAL, AddToOrderDAL>()
                     .RegisterType<IShipperDAL, ShipperDAL>()
                     .RegisterType<IUser, User>()
                    ;
            //.RegisterType<IAuthManager, AuthManager>();

            //RegisterAutoMapper();

            MapperConfiguration config = new MapperConfiguration(
              cfg =>
              {
                  cfg.AddMaps(typeof(User).Assembly);
              });

            Container.RegisterInstance(config.CreateMapper());



            IShipperDAL _shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            IItemDAL _itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            ICustomerDAL _customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            IOrderDAL _orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            IAddToOrderDAL _addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

           
            ICustomer user2 = new Customer(_customerDAL, _addtoorderDAL, _itemDAL, _orderDAL);
            IUser user1 = new User(_shipperDAL, _itemDAL, _customerDAL, _orderDAL, _addtoorderDAL);
           // ItemDTO item = user1.GetItem(1);
           //ItemDetailsModel l = new ItemDetailsModel(user1, item);
            //ItemDetails j = new ItemDetails(l);
          //  j.ShowDialog();
            LoginShipperModel lm = new LoginShipperModel(user1);
            ItemsListModel lm1 = new ItemsListModel(user1);
            //var key = typeof(MainWindow).ToString();
           // LoginShipper lf = Container.Resolve<LoginShipper>();
           LoginShipper lf = new LoginShipper(lm);
            bool result = lf.ShowDialog() ?? false;
           // Window1 w = Container.Resolve<Window1>();
           // bool result = w.ShowDialog() ?? false;
           // if (result)
            {
                MessageBox.Show("YEP");
                //ItemsList ml = Container.Resolve<ItemsList>();
                ItemsList ml = new ItemsList(lm1);
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = ml;
                ml.Show();
            }
            //else
            //{
            //    Current.Shutdown();
            //}
        }

        private void RegisterAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(User).Assembly);
                });

            Container.RegisterInstance(config.CreateMapper());
        }

        private void RegisterUnity()
        {
            Container = new UnityContainer();

            Container.RegisterType<IItemDAL, ItemDAL>()
                     .RegisterType<IOrderDAL, OrderDAL>()
                     .RegisterType<IAddToOrderDAL, AddToOrderDAL>()
                     .RegisterType<IShipperDAL, ShipperDAL>()
                     .RegisterType<IUser, User>();
                     //.RegisterType<IAuthManager, AuthManager>();
        }
    }
}


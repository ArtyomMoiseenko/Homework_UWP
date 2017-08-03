using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Homework_UWP.ViewModels;
using Homework_UWP.Views;
using Microsoft.Practices.ServiceLocation;

namespace Homework_UWP
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(WeatherViewModel), typeof(WeatherView));
            navigationService.Configure(nameof(LogsViewModel), typeof(LogsView));
            navigationService.Configure(nameof(CitiesViewModel), typeof(CitiesView));

            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

            }

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<WeatherViewModel>();
            SimpleIoc.Default.Register<LogsViewModel>();
            SimpleIoc.Default.Register<CitiesViewModel>();

            ServiceLocator.Current.GetInstance<WeatherViewModel>();
        }

        public WeatherViewModel WeatherVMInstance
        {
            get { return ServiceLocator.Current.GetInstance<WeatherViewModel>(); }
        }

        public LogsViewModel LogsVMInstance
        {
            get { return ServiceLocator.Current.GetInstance<LogsViewModel>(); }
        }

        public CitiesViewModel CitiesVMInstance
{
            get { return ServiceLocator.Current.GetInstance<CitiesViewModel>(); }
        }

        public static void Cleanup()
        {

        }
    }
}

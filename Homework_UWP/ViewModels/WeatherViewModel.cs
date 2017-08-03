using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Homework_UWP.Models;
using Homework_UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_UWP.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly WeatherService _weatherService;

        public WeatherViewModel(INavigationService navigationService)
        {
            Title = "Weather";
            _navigationService = navigationService;
            _weatherService = new WeatherService();
            SearchCommand = new RelayCommand<string>(item => Search(item));
        }

        public WeatherModel Forecast { get; private set; }
        public List<List> Lists
        {
            get
            {

                return Forecast != null ? Forecast.List : null;
            }
        }
        public ICommand SearchCommand { get; set; }

        public async void Search(string name)
        {
            const string day = "1";
            Forecast = null;
            var response = await _weatherService.GetWeatherCity(name, day);
        }
    }
}

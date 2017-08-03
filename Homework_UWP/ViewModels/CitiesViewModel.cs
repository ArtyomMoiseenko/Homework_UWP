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
    public class CitiesViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly CityService _cityService;

        public CitiesViewModel(INavigationService navigationService)
        {
            Title = "City";
            _navigationService = navigationService;
            _cityService = new CityService();
            Cities = new ObservableCollection<CityModel>();
            AddCommand = new RelayCommand<string>(item => Add(item));
            EditCommand = new RelayCommand<string>(item => Edit(item));
            DeleteCommand = new RelayCommand<string>(item => Delete(item));
            GetAll();
        }

        public ObservableCollection<CityModel> Cities { get; private set; }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public async void GetAll()
        {
            Cities.Clear();
            var response = await _cityService.GetCities();
            foreach (var item in response)
            {
                Cities.Add(item);
            }
        }

        public async void Add(string name)
        {
            var response = await _cityService.CreateCity(new CityModel { Id = 0, Name = name });
            GetAll();
        }

        public async void Edit(string name)
        {
            var city = Cities.FirstOrDefault(item => item.Name == name);
            var response = await _cityService.EditCity(city.Id, city);
            GetAll();
        }

        public async void Delete(string name)
        {
            var city = Cities.FirstOrDefault(item => item.Name == name);
            var response = await _cityService.DeleteCity(city.Id);
            GetAll();
        }
    }
}

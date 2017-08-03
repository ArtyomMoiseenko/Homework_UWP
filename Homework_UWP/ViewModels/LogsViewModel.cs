using GalaSoft.MvvmLight.Views;
using Homework_UWP.Models;
using Homework_UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_UWP.ViewModels
{
    public class LogsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly LogService _logService;

        public LogsViewModel(INavigationService navigationService)
        {
            Title = "Weather";
            _navigationService = navigationService;
            _logService = new LogService();
            Logs = new ObservableCollection<LogModel>();
            Search();
        }

        public ObservableCollection<LogModel> Logs { get; private set; }

        public async void Search()
        {
            Logs.Clear();
            var response = await _logService.GetLogs();
            foreach (var item in response)
            {
                Logs.Add(item);
            }

        }
    }
}

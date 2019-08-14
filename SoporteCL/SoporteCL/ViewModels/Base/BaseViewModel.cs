using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SoporteCL.Models;
using SoporteCL.Services;
using SoporteCL.Helpers;
using System.Threading.Tasks;
using SoporteCL.Services.Navigation;

/*
 * Clase ViewModel de la que heredan las demas. Contiene las bases de datos del programa y mediante INotifyPropertyChanged, respondera a cambios en los datos.
 */
namespace SoporteCL.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Base de datos simulada de Notificaciones
        public INotificationStore<Notificacion> NotifStore => DependencyService.Get<INotificationStore<Notificacion>>();

        protected readonly INavigationService NavigationService;
        public object Parameter { get; internal set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; RaisePropertyChanged(); }
        }

        //Titulo de la vista, mostrado en la barra de herramientas
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { title=value; RaisePropertyChanged(); }
        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

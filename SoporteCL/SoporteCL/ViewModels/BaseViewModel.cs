using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SoporteCL.Models;
using SoporteCL.Services;
using SoporteCL.Helpers;

/*
 * Clase ViewModel de la que heredan las demas. Contiene las bases de datos del programa y mediante INotifyPropertyChanged, respondera a cambios en los datos.
 */
namespace SoporteCL.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        //Base de datos simulada de Notificaciones
        //TODO: reemplazar base de datos simulada por conexion a base de datos (eliminar este parametro)
        public INotificationStore<Notificacion> NotifStore => DependencyService.Get<INotificationStore<Notificacion>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        //Titulo de la vista, mostrado en la barra de herramientas
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

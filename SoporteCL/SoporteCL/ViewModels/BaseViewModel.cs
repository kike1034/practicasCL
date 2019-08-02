using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SoporteCL.Models;
using SoporteCL.Services;

/*
 * Clase ViewModel de la que heredan las demas. Contiene las bases de datos del programa y mediante INotifyPropertyChanged, respondera a cambios en los datos.
 */
namespace SoporteCL.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Base de datos simulada de Notificaciones
        //TODO: reemplazar base de datos simulada por conexion a base de datos (eliminar este parametro)
        public INotificationStore<Notificacion> NotifStore => DependencyService.Get<INotificationStore<Notificacion>>() ?? new MockNotificationStore();

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

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

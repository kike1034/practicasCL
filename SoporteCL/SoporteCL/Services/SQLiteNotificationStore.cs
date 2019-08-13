using SoporteCL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoporteCL.Services.SQLiteNotificationStore))]
namespace SoporteCL.Services
{
    public class SQLiteNotificationStore : INotificationStore<Notificacion>
    {
        private readonly ISQLitePlatform _platform;
        public SQLiteNotificationStore (ISQLitePlatform platform)
        {
            _platform = platform;
            var con = _platform.GetConnection();
            con.CreateTable<Notificacion>();
            con.Close();
        }
        public SQLiteNotificationStore()
        {
            _platform = DependencyService.Get<ISQLitePlatform>();
            var con = _platform.GetConnection();
            con.CreateTable<Notificacion>();
            con.Close();
        }
        public async Task<bool> AddNotificacionAsync(Notificacion notificacion)
        {
            return (await _platform.GetConnectionAsync().InsertAsync(notificacion)) > 0;
        }

        public async Task<bool> DeleteNotificacionAsync(string id)
        {
            var oldnotif = GetNotificacionAsync(id);
            return (await _platform.GetConnectionAsync().DeleteAsync(oldnotif)) > 0;
        }

        public async Task<bool> DeleteNotificacionAsync(Notificacion notificacion)
        {
            return (await _platform.GetConnectionAsync().DeleteAsync(notificacion)) > 0;
        }

        public async Task<IEnumerable<Notificacion>> GetAllNotificacionesAsync()
        {
            return await _platform.GetConnectionAsync().Table<Notificacion>().ToListAsync();
        }

        public async Task<IEnumerable<Notificacion>> GetAllUnreadNotificacionesAsync()
        {
            return await _platform.GetConnectionAsync()
                .Table<Notificacion>().Where(x => x.Leido == 0)
                .ToListAsync();
        }

        public async Task<Notificacion> GetNotificacionAsync(string id)
        {
            return await _platform.GetConnectionAsync()
                .Table<Notificacion>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Notificacion> GetNotificacionAsync(Notificacion notif)
        {
            return await _platform.GetConnectionAsync().GetAsync<Notificacion>(notif);
        }

        public async Task<bool> UpdateNotificacionAsync(Notificacion notificacion)
        {
            return (await _platform.GetConnectionAsync().UpdateAsync(notificacion)) > 0;
        }

        public async Task<IEnumerable<Notificacion>> GetAllUnreadNotificacionesProfileAsync(string nombreperfil)
        {
            return await _platform.GetConnectionAsync()
                .Table<Notificacion>().Where(x => x.Destino == nombreperfil && x.TipoTarget == "RedNegocio" && x.Leido == 0).ToListAsync();
        }

        public async Task<IEnumerable<Notificacion>> GetAllNotificacionesProfileAsync(string nombreperfil)
        {
            return await _platform.GetConnectionAsync()
                .Table<Notificacion>().Where(x => x.Destino == nombreperfil && x.TipoTarget == "RedNegocio").ToListAsync();
        }

        public async Task<IEnumerable<Notificacion>> GetAllUnreadNotificacionesUserAsync(string user)
        {
            return await _platform.GetConnectionAsync()
                 .Table<Notificacion>().Where(x => x.Destino == user && x.TipoTarget == "Usuario" && x.Leido == 0).ToListAsync();
        }

        public async Task<IEnumerable<Notificacion>> GetAllNotificacionesUserAsync(string user)
        {
            return await _platform.GetConnectionAsync()
                .Table<Notificacion>().Where(x => x.Destino == user && x.TipoTarget == "Usuario").ToListAsync();
        }
    }
}

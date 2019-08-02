using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

/*
 * Interfaz para conectar con una base de datos SQLite (utilizada para implementar conexion en cada plataforma)
 */
namespace SoporteCL.Services
{
    public interface INotificacionesSQLite
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
    }
}

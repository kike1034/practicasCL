using SoporteCL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoporteCL.Services.SQLiteProfileStore))]
namespace SoporteCL.Services
{
    class SQLiteProfileStore : IProfileStore<Profile>
    {
        private readonly ISQLitePlatform _platform;
        public SQLiteProfileStore(ISQLitePlatform platform)
        {
            _platform = platform;
            var con = _platform.GetConnection();
            con.CreateTable<Profile>();
            if (con.Table<Profile>().Count() == 0)
            {
                Profile clay = new Profile
                {
                    Nombre = "CristianLay",
                    Jerarquia = 7
                };
                con.Insert(clay);
                Profile DN = new Profile
                {
                    Nombre = "DN",
                    Jerarquia = 6
                };
                con.Insert(DN);
                Profile DR = new Profile
                {
                    Nombre = "DR",
                    Jerarquia = 5
                };
                con.Insert(DR);
                Profile DA = new Profile
                {
                    Nombre = "DA",
                    Jerarquia = 4
                };
                con.Insert(DA);
                Profile SU = new Profile
                {
                    Nombre = "SU",
                    Jerarquia = 3
                };
                con.Insert(SU);
                Profile JG = new Profile
                {
                    Nombre = "JG",
                    Jerarquia = 2
                };
                con.Insert(JG);
                Profile DI = new Profile
                {
                    Nombre = "DI",
                    Jerarquia = 1
                };
                con.Insert(DI);
            }
            con.Close();
        }
        public SQLiteProfileStore()
        {
            _platform = DependencyService.Get<ISQLitePlatform>();
            var con = _platform.GetConnection();
            con.CreateTable<Profile>();
            con.Close();
        }
        public async Task<bool> AddProfileAsync(Profile profile)
        {
            return (await _platform.GetConnectionAsync().InsertAsync(profile)) > 0;
        }

        public async Task<bool> DeleteProfileAsync(string id)
        {
            var oldnotif = GetProfileAsync(id);
            return (await _platform.GetConnectionAsync().DeleteAsync(oldnotif)) > 0;
        }

        public async Task<bool> DeleteProfileAsync(Profile profile)
        {
            return (await _platform.GetConnectionAsync().DeleteAsync(profile)) > 0;
        }

        public async Task<IEnumerable<Profile>> GetAllProfileAsync()
        {
            return await _platform.GetConnectionAsync().Table<Profile>().ToListAsync();
        }

        public async Task<Profile> GetProfileAsync(string id)
        {
            return await _platform.GetConnectionAsync()
                .Table<Profile>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Profile> GetProfileAsync(Profile profile)
        {
            return await _platform.GetConnectionAsync().GetAsync<Profile>(profile);
        }

        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            return (await _platform.GetConnectionAsync().UpdateAsync(profile)) > 0;
        }
    }
}

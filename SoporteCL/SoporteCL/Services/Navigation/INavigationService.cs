using SoporteCL.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace SoporteCL.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateBackAsync();
    }
}

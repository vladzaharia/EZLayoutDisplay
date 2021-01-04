using InvvardDev.EZLayoutDisplay.Core.Services.Implementation;
using InvvardDev.EZLayoutDisplay.Core.ViewModels;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace InvvardDev.EZLayoutDisplay.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IMvxNavigationCache, MvxNavigationCache>();
            Mvx.IoCProvider.RegisterType<IMvxViewModelLoader, MvxViewModelLoader>();
            Mvx.IoCProvider.RegisterSingleton<IMvxNavigationService>(() => {
                                                                         var navigationCache = Mvx.IoCProvider.Resolve<IMvxNavigationCache>();
                                                                         var viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();

                                                                         return new WindowService(navigationCache, viewModelLoader);
                                                                     });
            RegisterAppStart<NotifyIconViewModel>();
        }
    }
}

using System;
using Xamarin.Forms;

namespace SoporteCL.Helpers
{
    public class BoolResources
    {
        public static readonly bool ShouldShowBoxView = Elegirplataforma(); //Device.OnPlatform(true, false, true)
        private static bool Elegirplataforma()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    return false;
                default:
                    return true;
            }
        }
    }
}

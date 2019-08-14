using System;
using Xamarin.Forms;

namespace SoporteCL.Helpers
{
    class DoubleResources
    {
        public static readonly Thickness ButtonGroupPadding = new Thickness(0, Buttongrouppaddingswitch(), 0, 0);
        public static readonly double SignUpButtonHeight = Signupbuttonswitch();
        public static readonly double FBButtonHeight = FBButtonheightsitch();

        private static int Buttongrouppaddingswitch()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return 25;
                default:
                    return 0;
            }
        }

        private static int Signupbuttonswitch()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    return 80;
                default:
                    return 40;
            }
        }
        private static int FBButtonheightsitch()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    return 64;
                default:
                    return 50;
            }
        }

    }
}

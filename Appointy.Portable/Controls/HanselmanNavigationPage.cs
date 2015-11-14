using System;
using Xamarin.Forms;

namespace Appointy.Portable.Controls
{
    public class AppointyNavigationPage :NavigationPage
    {
		public AppointyNavigationPage(Page root) : base(root)
        {
            Init();
        }

		public AppointyNavigationPage()
        {
            Init();
        }

        void Init()
        {

			BarBackgroundColor = Color.FromHex("#92298E");
            BarTextColor = Color.White;
        }
    }
}


using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using Appointy.Portable.Controls;

namespace Appointy.Portable.Views
{
    public class RootPage : MasterDetailPage
                 {
        Dictionary<MenuType, NavigationPage> Pages { get; set;} 
        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
                {
                    Title = "Appointy Blogs",
                    Icon = "slideout.png"
                };
            //setup home page
            NavigateAsync(MenuType.About);
        }



        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {

                switch (id)
                {
                    case MenuType.About:
					Pages.Add(id, new AppointyNavigationPage(new AboutPage()));
                        break;
                    case MenuType.Hanselminutes:
					Pages.Add(id, new AppointyNavigationPage(new PodcastPage(id)));
                        break;
                }
            }

            newPage = Pages[id];
            if(newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if(Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}


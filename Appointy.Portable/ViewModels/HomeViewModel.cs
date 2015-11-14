using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Appointy.Portable
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }
        public HomeViewModel()
        {
            CanLoadMore = true;
            Title = "Appointy";
            MenuItems = new ObservableCollection<HomeMenuItem>();
			MenuItems.Add (new HomeMenuItem {
				Id = 0,
				Title = "About",
				MenuType = MenuType.About,
				Icon = "about.png"
			});
            MenuItems.Add(new HomeMenuItem
            {
                Id = 3,
                Title = "Blogs",
                MenuType = MenuType.Hanselminutes,
                Icon = "blog.png"
            });
         
        }

    }
}


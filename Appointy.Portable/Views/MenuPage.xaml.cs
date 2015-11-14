using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Appointy.Portable.Views
{
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<HomeMenuItem> menuItems;
        public MenuPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();
            BindingContext = new BaseViewModel
                {
                    Title = "Shan.Forms",
					Subtitle="Shan.Forms",
                    Icon = "slideout.png"
                };

            ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = "About", MenuType = MenuType.About, Icon ="about.png" },
                    new HomeMenuItem { Title = "Blogs", MenuType = MenuType.Hanselminutes, Icon = "blog.png" },
                   
                };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) => 
                {
                    if(ListViewMenu.SelectedItem == null)
                        return;

                    await this.root.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
                };
        }
    }
}


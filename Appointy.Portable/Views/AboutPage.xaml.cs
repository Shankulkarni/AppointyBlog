using Appointy.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Appointy.Portable.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            twitter.GestureRecognizers.Add(new TapGestureRecognizer()
              {
                  Command = new Command(async () =>
                  {
                      
							await this.Navigation.PushAsync(new WebsiteView("https://m.twitter.com/appointy", "@Appointy"));
                  })
              });

            facebook.GestureRecognizers.Add(new TapGestureRecognizer()
             {
                 Command = new Command(async () =>
                 {
                     
							await this.Navigation.PushAsync(new WebsiteView("https://www.facebook.com/appointy", "Appointy @Facebook"));
                 })
             });

            linkedin.GestureRecognizers.Add(new TapGestureRecognizer()
             {
                 Command = new Command(async () =>
                 {
                    
							await this.Navigation.PushAsync(new WebsiteView("https://www.linkedin.com/company/appointy-inc", "Appointy @LinkedIn"));
                 })
             });

            google.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    
							await this.Navigation.PushAsync(new WebsiteView("https://plus.google.com/102192118755606432710/about", "Appointy+"));
                })
            });
        }
    }
}

using Appointy.Portable.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Appointy.Portable.Views
{
  public partial class PodcastPlaybackPage : ContentPage
  {
    public PodcastPlaybackPage(FeedItem item)
    {
      InitializeComponent();
      BindingContext = item;
	  webView.Source = item.Link;
      var share = new ToolbarItem
      {
        Icon = "ic_share.png",
        Text = "Share",
        Command = new Command(() =>
          {
            DependencyService.Get<IShare>()
          .ShareText("Listening to @shanselman's " + item.Title + " " + item.Link);
          })
      };

      ToolbarItems.Add(share);


    }
  }
}

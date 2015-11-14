using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Xml.Linq;

namespace Appointy.Portable.ViewModels
{
    public class PodcastViewModel : BaseViewModel
    {
        MenuType item;
        private string image;
        public PodcastViewModel(MenuType item)
        {
            this.item = item;
			image = "hm_full.jpg";
			Title = "Blogs";
               
        }


        private ObservableCollection<FeedItem> feedItems = new ObservableCollection<FeedItem>();

        public ObservableCollection<FeedItem> FeedItems
        {
            get { return feedItems; }
            set { feedItems = value; OnPropertyChanged(); }
        }

        private FeedItem selectedFeedItem;
     
        public FeedItem SelectedFeedItem
        {
            get { return selectedFeedItem; }
            set
            {
                selectedFeedItem = value;
                OnPropertyChanged();
            }
        }

        private Command loadItemsCommand;
        
        public Command LoadItemsCommand
        {
            get { return loadItemsCommand ?? (loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand())); }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var error = false;
            try
            {
                var httpClient = new HttpClient();
				var feed = "http://blog.appointy.com/feed/";

                var responseString = await httpClient.GetStringAsync(feed);

                FeedItems.Clear();
                var items = await ParseFeed(responseString);
                foreach (var feedItem in items)
                {
                    FeedItems.Add(feedItem);
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                var result = page.DisplayAlert("Oops!", "Unable to load .", "OK");

            }


            IsBusy = false;
        }

        private async Task<List<FeedItem>> ParseFeed(string rss)
        {
            return await Task.Run(() =>
            {
                var xdoc = XDocument.Parse(rss);
                var id = 0;
                return (from item in xdoc.Descendants("item")
                     
                        select new FeedItem
                        {
                            Title = (string)item.Element("title"),
                            Link = (string)item.Element("link"),
							PublishDate = (string)item.Element("pubDate"),
							Image = image,
                            Id = id++
                        }).ToList();
            });
        }
        public FeedItem GetFeedItem(int id)
        {
            return FeedItems.FirstOrDefault(i => i.Id == id);
        }
    }
}

using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using TMDbLib.Objects.Movies;
using Xamarin.Forms;

namespace Movie_Explorer.ViewModels
{
    [QueryProperty(nameof(MovieId), nameof(MovieId))]
    public class MovieDetailViewModel : BaseViewModel
    {
        private int movieId;

        private string videoUrl;
        public string VideoUrl
        {
            get => videoUrl;
            set => SetProperty(ref videoUrl, value);
        }

        public int MovieId
        {
            get
            {
                return movieId;
            }
            set
            {
                movieId = value;
                LoadMovie(value);
            }
        }

        public async void LoadMovie(int itemId)
        {
            try
            {
                Movie = await MoviesService.GetMovie(itemId);

                Title = Movie.Title;
                OnPropertyChanged(nameof(Movie));

                if (Movie.Videos.Results.Any())
                {
                    VideoUrl = await GetYouTubeUrl(Movie.Videos.Results[0].Key);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public Movie Movie { get; private set; }

        public async Task<string> GetYouTubeUrl(string videoId)
        {
            var videoInfoUrl = $"https://www.youtube.com/get_video_info?html5=1&video_id={videoId}";

            using (var client = new HttpClient())
            {
                var videoPageContent = await client.GetStringAsync(videoInfoUrl);
                var videoParameters = HttpUtility.ParseQueryString(videoPageContent);
                var encodedStreamsDelimited1 = WebUtility.HtmlDecode(videoParameters["player_response"]);
                var jObject = JObject.Parse(encodedStreamsDelimited1);
                return (string)jObject["streamingData"]["formats"][0]["url"];
            }
        }
    }
}

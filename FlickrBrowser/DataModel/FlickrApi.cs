using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FlickrBrowser.Common;
using FlickrBrowser.Infrastructure;
using Windows.UI.Xaml;

namespace FlickrBrowser.DataModel
{
    public sealed class FlickrApi
    {
        private readonly string _apiKey;
        private readonly string _apiBaseAddress;
        private const string GetRecent = "flickr.photos.getRecent";
        
        public static readonly FlickrApi Instance = new FlickrApi();

        public event EventHandler<ApiErrorOccuredEventArgs> ApiErrorOccured;

        private FlickrApi()
        {
            _apiKey = LocalAppSettings.Instance.FlickrApiKey;
            _apiBaseAddress = LocalAppSettings.Instance.FlickrApiUrl;
        }

        public async Task<IEnumerable<FlickrPhoto>> GetRecentlyAddedPhotosAsync(int? numberOfPhotos = 100)
        {
            IEnumerable<FlickrPhoto> flickrPhotos = new FlickrPhoto[0];
            try
            {
                var arguments = new Dictionary<string, string>
                {
                    {"per_page", (numberOfPhotos ?? 100).ToString()},
                    {"extras", "owner_name,date_upload,original_format,date_taken"}
                };

                var result = await GetFromRestApiAsync(GetRecent, arguments);
                flickrPhotos = FlickrHelpers.CreateFlickrPhotoFromXml(result.Root);
            }
            catch (Exception e)
            {
                OnApiErrorOccured(new ApiErrorOccuredEventArgs(e) { ErrorMessage = e.Message });
            }
            return flickrPhotos;
        }

        private async Task<XDocument> GetFromRestApiAsync(string method, Dictionary<string,string> arguments = null)
        {
         using(var httpClient = new HttpClient())
         {
             httpClient.BaseAddress = new Uri(_apiBaseAddress);

             var response = await httpClient.GetAsync(string.Format("?method={0}&api_key={1}&format=rest{2}",
                 method, _apiKey, ConvertArgumentsToUrlParameters(arguments)));

             var xmlString = await response.Content.ReadAsStringAsync();

             return XDocument.Parse(xmlString);
         }   
        }

        private string ConvertArgumentsToUrlParameters(Dictionary<string, string> arguments)
        {
            if (arguments == null)
                return string.Empty;

            return "&" + string.Join("&",
                from kvp in arguments
                select string.Format("{0}={1}", kvp.Key, kvp.Value));
        }


        public void OnApiErrorOccured(ApiErrorOccuredEventArgs e)
        {
            var handler = ApiErrorOccured;
            if (handler != null)
                handler(this, e);
        }
    }
}

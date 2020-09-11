using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlsTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class PhotoWrappingPage : Page
    {
        [DataContract]
        class ImageList
        {
            [DataMember(Name = "photos")]
            public List<string> Photos = null;
        }


        public PhotoWrappingPage()
        {
            this.InitializeComponent();
            LoadBitmapCollection();
        }


        async void LoadBitmapCollection()
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    // Download the list of stock photos
                    Uri listUri = new Uri("https://raw.githubusercontent.com/xamarin/docs-archive/master/Images/stock/small/stock.json");
                    byte[] listData = await webClient.DownloadDataTaskAsync(listUri);

                    // Convert to a Stream object
                    using (Stream listStream = new MemoryStream(listData))
                    {
                        // Deserialize the JSON into an ImageList object
                        var jsonSerializer = new DataContractJsonSerializer(typeof(ImageList));
                        ImageList imageList = (ImageList)jsonSerializer.ReadObject(listStream);

                        // Create an Image object for each bitmap
                        foreach (string filepath in imageList.Photos)
                        //var filepath = imageList.Photos[0];
                        {
                            var imageUri = new Uri(filepath, UriKind.Absolute);

                            byte[] imageBytes = await webClient.DownloadDataTaskAsync(imageUri);
                            var bitmapImage = await BitmapImageFromBytes(imageBytes);
                            var image = new Image { Stretch=Stretch.None, Source = bitmapImage };
                            flexPanel.Children.Add(image);
                        }
                    }
                }
                catch
                {
                    flexPanel.Children.Add(new TextBox
                    {
                        Text = "Cannot access list of bitmap files"
                    });
                }
            }

            //activityIndicator.IsRunning = false;
            activityIndicator.Visibility = Visibility.Collapsed;
        }

        public async static Task<BitmapImage> BitmapImageFromBytes(Byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }
            return image;
        }



    }
}

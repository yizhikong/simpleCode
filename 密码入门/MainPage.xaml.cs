using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace 密码入门
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DispatcherTimer tile = new DispatcherTimer();
            tile.Interval = new TimeSpan(0, 0, 3);
            tile.Tick += new EventHandler<object>(change);
            tile.Start();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(indexPage));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(challenge));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(enCodePage));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var dlg = new Windows.UI.Popups.MessageDialog("建议先进行学习，再去解密。");
            var show = dlg.ShowAsync();
        }

        void change(object o, object args)
        {
            Random radnum = new Random();
            int i = radnum.Next(0, 5);
            string[] picArray = new string[5];
            picArray[0] = "Assets/maoli.jpg";
            picArray[1] = "Assets/shiliang.jpg";
            picArray[2] = "Assets/pingci.jpg";
            picArray[3] = "Assets/kenan2.jpg";
            picArray[4] = "Assets/jiami.jpg";
            XmlDocument tileSquareImage = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareImage);
            XmlElement pic = (XmlElement)(tileSquareImage.GetElementsByTagName("image")[0]);
            pic.SetAttribute("src", picArray[i]);
            TileNotification notification = new TileNotification(tileSquareImage);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }
    }
}

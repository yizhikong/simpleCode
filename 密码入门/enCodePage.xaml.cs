using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class enCodePage : Page
    {
        public enCodePage()
        {
            this.InitializeComponent();
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
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string ori = origin.Text;
            try
            {
                ori = ori.ToLower();
            }
            catch
            {
                var dlg = new Windows.UI.Popups.MessageDialog("请确保输入的字符全为英文字母");
                var result = dlg.ShowAsync();
                return;
            }
            int len = ori.Length;
            int falseFlag = 0;
            for (int i = 0; i < len; i++)
            {
                if (ori[i] < 'a' || ori[i] > 'z')
                {
                    falseFlag = 1;
                    break;
                }
            }
            if (falseFlag == 1)
            {
                var dlg = new Windows.UI.Popups.MessageDialog("请确保输入的字符全为英文字母");
                var result = dlg.ShowAsync();
                return;
            }
            encode theCode = new encode();
            theCode.init(ori);
            int choose = choice.SelectedIndex;
            if (choose == 1)
            {
                int k = 1;
                int i;
                for (i = 3; i < ori.Length; i++)
                    if (len % i == 0)
                        k = i;
                if (k == 1)
                {
                    var dlg = new Windows.UI.Popups.MessageDialog("该明文长度不适合用于栅栏加密");
                    var result = dlg.ShowAsync();
                    return;
                }
            }
            theCode.selectCode(choose);
            ans.Text = theCode.getCode();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var dlg = new Windows.UI.Popups.MessageDialog("百度贴吧上有一个五层加密（女生回复表白）的贴子，很有趣，可以去看看哦~");
            var show = dlg.ShowAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace 密码入门
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class challenge : Page
    {
        private List<string> all;
        private encode theCode;
        private int mark;
        private int tipTime;
        private int state;
        private int seed;
        public challenge()
        {
            this.InitializeComponent();
            all = new List<string>();
            theCode = new encode();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            all.Add("iloveyou");
            all.Add("helloworld");
            all.Add("loveiszero");
            all.Add("zeroisstart");
            all.Add("iamtheone");
            all.Add("ihateyou");
            all.Add("thankyou");
            all.Add("helovesyou");
            all.Add("shelovesyou");
            all.Add("waitforyou");
            all.Add("happybirthday");
            all.Add("youaresmart");
            all.Add("justagame");
            all.Add("areyoukiddingme");
            all.Add("guduyisheng");
            all.Add("firstblood");
            all.Add("doublekill");
            all.Add("detective");
            all.Add("iamsleepy");
            all.Add("youarebeautiful");
            all.Add("youcanyouup");
            all.Add("followyourheart");
            all.Add("nevergiveup");
            all.Add("intheend");
            all.Add("gameover");
            all.Add("goodluck");
            all.Add("leavemealone");
            all.Add("nocannobb");
            all.Add("iamsorry");
            all.Add("thatistoolate");
            all.Add("thankyou");
            all.Add("triplekill");
            all.Add("killingspree");
            all.Add("superman");
            all.Add("dontbesilly");
            all.Add("legendary");
            all.Add("pocketmonster");
            all.Add("onepiece");
            all.Add("dragonball");
            all.Add("password");
            all.Add("xiwenlejian");
            all.Add("microsoft");
            all.Add("girlfriend");
            all.Add("yamiedie");
            all.Add("springbrother");
            all.Add("onetwothree");
            all.Add("longtimenosee");
            all.Add("youareright");
            all.Add("hopeless");
            all.Add("allright");
            all.Add("bytheway");
            all.Add("timeaftertime");
            all.Add("forexample");
            renden();
            mark = 0;
            state = 0;
            tipTime = 8;
            point.Text = Convert.ToString(mark);
            changLevel();
            toast();
            timeTip();
        }

        private void renden()
        {
            Random randomSeed = new Random();
            seed = randomSeed.Next(0, 100);
            double temp = Math.Sin((double)seed);
            int pos = (int)(temp * 100);
            if (pos < 0)
                pos *= -1;
            pos = pos % all.Count;
            theCode.init(all[pos]);
            temp = Math.Sin(temp + mark);
            int spos = (int)(temp + tipTime);
            if (spos < 0)
                spos *= -1;
            var debug = randomSeed.Next(0, 4);
            theCode.selectCode(debug);
            tCode.Text = theCode.getCode();
        }

        private void tips(object sender, RoutedEventArgs e)
        {
            if (tipTime > 0)
            {
                tipTime -= 1;
                var dlg = new Windows.UI.Popups.MessageDialog("加密方式为" + theCode.type + "。剩余提示次数为" + Convert.ToString(tipTime) + "次");
                var result = dlg.ShowAsync();
                mark -= 5;
                point.Text = Convert.ToString(mark);
                changLevel();
            }
            else
            {
                var dlg = new Windows.UI.Popups.MessageDialog("你已经没有提示机会了");
                var result = dlg.ShowAsync();
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (state == 0)
            {
                state = 1;
                check();
            }
            else
            {
                state = 0;
                next();
            }
        }

        private void check()
        {
            if (userReply.Text.Equals(theCode.getAns()))
            {
                mark += 10;
                point.Text = Convert.ToString(mark);
                changLevel();
                // imagechange
                answer.Text = "正确!";
            }
            else
            {
                mark -= 5;
                point.Text = Convert.ToString(mark);
                changLevel();
                answer.Text = "错误，正确答案为" + theCode.getAns();
            }
            submit.Content = "继续";
        }

        private void next()
        {
            renden();
            userReply.Text = "";
            submit.Content = "提交";
            answer.Text = "";
        }

        private void giveup(object sender, RoutedEventArgs e)
        {
            mark -= 5;
            point.Text = Convert.ToString(mark);
            state = 0;
            submit.Content = "提交";
            changLevel();
            renden();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void changLevel()
        {
            level1.Opacity = 0;
            level2.Opacity = 0;
            level3.Opacity = 0;
            level4.Opacity = 0;
            level5.Opacity = 0;
            if (mark >= 91)
            {
                level5.Opacity = 1;
                return;
            }
            if (mark >= 61 && mark < 91)
            {
                level4.Opacity = 1;
                return;
            }
            if (mark >= 31 && mark < 61)
            {
                level3.Opacity = 1;
                return;
            }
            if (mark >= 11 && mark < 31)
            {
                level2.Opacity = 1;
                return;
            }
            if (mark < 11)
                level1.Opacity = 1;
        }
        void toast()
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            stringElements[0].AppendChild(toastXml.CreateTextNode("随着分数的改变，人物会变化哦"));
            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            ((XmlElement)imageElements[0]).SetAttribute("src", "Assets/kenan2.jpg");
            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.IM");
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            toastNode.AppendChild(audio);
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        void timeTip()
        {
            DateTime dueTime = DateTime.Now.AddSeconds(600); // 10分钟提醒一次
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            stringElements[0].AppendChild(toastXml.CreateTextNode("您已游戏" + "10" + "分钟"));
            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            ((XmlElement)imageElements[0]).SetAttribute("src", "Assets/pingci.jpg");
            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.IM");
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            toastNode.AppendChild(audio);
            ScheduledToastNotification schedualedToast = new ScheduledToastNotification(toastXml, dueTime);
            schedualedToast.Id = "Schedule";
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(schedualedToast);

        }

    }
}

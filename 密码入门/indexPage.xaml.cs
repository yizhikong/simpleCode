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
    public sealed partial class indexPage : Page
    {
        public indexPage()
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
            var viewModel = new ViewModel();
            viewModel.CodeList.Add(new codes { Msg = "hello world", Code = "tqxxaiadxp" });
            viewModel.CodeList.Add(new codes { Msg = "fire in the hole", Code = "mpylpuaolovsl" });
            viewModel.CodeList.Add(new codes { Msg = "let soul burns", Code = "ohwvrxoexuqv" });
            viewModel.CodeList.Add(new codes { Msg = "forget you", Code = "ajmbzotjp" });
            viewModel.Name = "凯撒密码";
            viewModel.Introduce = "\n    在密码学中，恺撒密码（或称恺撒加密、恺撒变换、变换加密）是一种最简单且最广为人知的加密技术。" +
                "它是一种替换加密的技术，明文中的所有字母都在字母表上向后（或向前）按照一个固定数目进行偏移后被替换成密文。例如，" +
                "当偏移量是3的时候，所有的字母A将被替换成D，B变成E，以此类推。这个加密方法是以恺撒的名字命名的，当年恺撒曾用此方法" +
                "与其将军们进行联系。\n    根据偏移量的不同，还存在若干特定的恺撒密码名称：\n    偏移量为10：Avocat(A→K)\n" +
                "    偏移量为13：ROT13\n    偏移量为-5：Cassis (K 6）\n    偏移量为-6：Cassette (K 7）";
            Frame.Navigate(typeof(introduction), viewModel);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var viewModel = new ViewModel();
            viewModel.CodeList.Add(new codes { Msg = "hello world", Code = "hweolrllod" });
            viewModel.CodeList.Add(new codes { Msg = "fire in the hole", Code = "无合适分组" });
            viewModel.CodeList.Add(new codes { Msg = "let soul burns", Code = "llebtusronus" });
            viewModel.CodeList.Add(new codes { Msg = "forget you", Code = "fgyoeortu" });
            viewModel.Name = "栅栏密码";
            viewModel.Introduce = "    所谓栅栏密码，就是把要加密的明文分成N个一组，然后把每组的第i个字连起来，形成一段无规律的话。" +
            "一般比较常见的是2栏的棚栏密码。 比如明文：THERE IS A CIPHER \n去掉空格后变为：THEREISACIPHER \n两个一组，得到：" +
            "TH ER EI SA CI PH ER \n先取出第一个字母：TEESCPE \n再取出第二个字母：HRIAIHR \n连在一起就是：TEESCPEHRIAIHR \n这" +
            "样就得到我们需要的密码了！ \n而解密的时候，我们先把密文从中间分开，变为两行： \nT E E S C P E \nH R I A I H R \n再" +
            "按上下上下的顺序组合起来： \nTHEREISACIPHER \n分出空格，就可以得到原文了。";
            Frame.Navigate(typeof(introduction), viewModel);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var viewModel = new ViewModel();
            viewModel.CodeList.Add(new codes { Msg = "hello world", Code = "42325353639163735331" });
            viewModel.CodeList.Add(new codes { Msg = "fire in the hole", Code = "33437332436281423242635332" });
            viewModel.CodeList.Add(new codes { Msg = "let soul burns", Code = "533281746382532282736274" });
            viewModel.CodeList.Add(new codes { Msg = "forget you", Code = "336373413281936382" });
            viewModel.Name = "（手机）键盘密码";
            viewModel.Introduce = "\n    所谓手机键盘密码，就是根据按键式手机打错英文字母的方法来加密，比如说Y是9号键的第3个字母，就" +
            "译为93，同理Z可译为94。对于触屏手机，则对应‘拼音9键’的输入模式。这个加密的特征比较明显，按2个数字两个数字来看，第二个" +
            "数字如果都在1-4的范围内，就可以怀疑是使用了手机键盘加密了。\n\n    除了手机键盘加密外，还有电脑键盘加密，简单来说就是对应着" +
            "键盘上的键位了（QWERTY）对应（ABCDEF)。另外还有一些加密是结合数字键盘进行的，这里就不详细说了。";
            Frame.Navigate(typeof(introduction), viewModel);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var viewModel = new ViewModel();
            viewModel.CodeList.Add(new codes { Msg = "SOS(求救信号)", Code = "··· --- ···" });
            viewModel.CodeList.Add(new codes { Msg = "morse code", Code = "-- --- ·-· ··· · / -·-· --- -·· ·" });
            viewModel.CodeList.Add(new codes { Msg = "shut up", Code = "··· ···· ··- - / ··- ·--·" });
            viewModel.CodeList.Add(new codes { Msg = "good luck", Code = "--· --- --- -·· / ·-·· ··- -·-· -·-" });
            viewModel.Name = "摩斯电码";
            viewModel.Introduce = "\n    摩尔斯电码是一种早期的数字化通信形式，但是它不同于现代只使用0和1两种状态的二进制代码，它的代码包括五种，即：" +
            "1.点（·）  2.划（—）  3.每个字符间短的停顿(在点和划之间的停顿)  4.每个词之间中等的停顿  5.以及句子之间长的停顿\n" +
            "    “-”表示划，“.”表示点，划一般是三个点的长度；点划之间的间隔是一个点的长度；字符之间的间隔是三个点的长度(例子中用空格表示);" +
            "单词之间的间隔是七个点的长度(例子中用/表示)。另外，商业代码精心设计了五个字符组成一组的代码，做为一个单词发送，如LIOUY（Why do you not answer my question?，为什么不回复？）" +
            "\n    摩斯电码的特征比较明显，很容易分辨出来，主要是在于译码了，而译码则依赖于背表/查表了。";
            Frame.Navigate(typeof(introduction), viewModel);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var viewModel = new ViewModel();
            viewModel.CodeList.Add(new codes { Msg = "hello world", Code = "85121215231518124" });
            viewModel.CodeList.Add(new codes { Msg = "fire in the hole", Code = "691859142085815125" });
            viewModel.CodeList.Add(new codes { Msg = "let soul burns", Code = "1252019152112221181419" });
            viewModel.CodeList.Add(new codes { Msg = "forget you", Code = "615187520251521" });
            viewModel.Name = "字母-数字密码";
            viewModel.Introduce = "\n\n    所谓字母-数字密码，就是简单的把每个字母转化为对应的数字了。像A译为1，B译为2这样子。" +
                "因为这种加密方法的特征比较明显，所以也可用作二重加密（如果用恺撒或者栅栏等加密方法对已经加密过的信息再加密（二重密码），" +
                "会使得密码太过难解，因为特征不明显，比较难分析）";
            Frame.Navigate(typeof(introduction), viewModel);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var dlg = new Windows.UI.Popups.MessageDialog("此处列举的加密方式皆简单易学，无需任何基础，请尽情享受学习的过程~");
            var show = dlg.ShowAsync();
        }
    }
}

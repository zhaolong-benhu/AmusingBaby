using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;
using Windows.Networking.Connectivity;
using System.Collections.ObjectModel;
using Windows.Web.Http;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Text;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.System.Profile;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AmusingBaby
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private int nTableSelected;

        VersionUpDialog versiondlg = new VersionUpDialog();

        AbousUsContentDialog1 auoutUsdlg = new AbousUsContentDialog1();

        private async void PageLoadedHandler(Object sender, RoutedEventArgs e)
        {
            try
            {
                ApplicationView view = ApplicationView.GetForCurrentView();
                ApplicationViewTitleBar bar = view.TitleBar;
                Color color;
                color.A = 255; color.R = 230; color.G = 25; color.B = 74;
                bar.BackgroundColor = color;


                //bar.ForegroundColor = color;
                bar.ButtonBackgroundColor = color;
                color.A = 255; color.R = 248; color.G = 110; color.B = 88;
                bar.ButtonForegroundColor = color;
                bar.ButtonHoverBackgroundColor = color;
                bar.ButtonPressedBackgroundColor = Colors.Red;

               // BabyWebView.Navigate(new Uri(Define.BabyUri));
             
            }
            catch
            {
                return;
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
            nTableSelected = 1;

            var Cur = SystemNavigationManager.GetForCurrentView();
            Cur.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            Cur.BackRequested += AppViewBackRequestedButton;
        }

        //窗体尺寸大小变化
        private void rootGrid_SizeChanged(Object sender, SizeChangedEventArgs e)
        {
            try
            {
                Grid rootGrid = (Grid)(sender);
                if (rootGrid != null)
                {
                    String strTag = rootGrid.Tag.ToString();
                    double dWidth = rootGrid.ActualWidth;
                    if (dWidth > 640)//大于640
                    {


                      //  LeftGrid.Visibility = Visibility.Visible;

                    }
                    else
                    {

                    }
                }
            }
            catch
            {
                return;
            }
        }

        //void LeftTab_Btn_Clicked(Object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        RadioButton btn = (RadioButton)sender;
        //        if (btn != null)
        //        {
        //             //menuGridBtnSlide(btn.Tag.ToString());
        //        }
        //    }
        //    catch
        //    {
        //        return;
        //    }

        //}

        //private void menuGridBtnSlide(String btnTag)
        //{
        //    if (btnTag == null) return;
        //    if ("LeftHomePage" == btnTag)
        //    {
        //        //m_menuPrevBtnTag = m_menuCurBtnTag;
        //        //m_menuCurBtnTag = btnTag;
        //        nTableSelected = 1;
        //        SwitchMenuBtnStatus(nTableSelected);
        //        CenterGrid_Baby.Visibility = Visibility.Visible;
        //        CenterGrid_Log.Visibility = Visibility.Collapsed;
        //        CenterGrid_Helper.Visibility = Visibility.Collapsed;
        //        CenterGrid_Look.Visibility = Visibility.Collapsed;
        //        LeftTab_Baby();

        //    }
        //    else if ("LeftHotSell" == btnTag)
        //    {
        //        // m_menuPrevBtnTag = m_menuCurBtnTag;
        //        //m_menuCurBtnTag = btnTag;
        //        nTableSelected = 2;
        //        SwitchMenuBtnStatus(nTableSelected);
        //        CenterGrid_Baby.Visibility = Visibility.Collapsed;
        //        CenterGrid_Log.Visibility = Visibility.Visible;
        //        CenterGrid_Helper.Visibility = Visibility.Collapsed;
        //        CenterGrid_Look.Visibility = Visibility.Collapsed;
        //        LeftTab_Log();


        //    }
        //    else if ("LeftClassify" == btnTag)
        //    {
        //        // m_menuPrevBtnTag = m_menuCurBtnTag;
        //        // m_menuCurBtnTag = btnTag;
        //        nTableSelected = 3;
        //        SwitchMenuBtnStatus(nTableSelected);
        //        CenterGrid_Baby.Visibility = Visibility.Collapsed;
        //        CenterGrid_Log.Visibility = Visibility.Collapsed;
        //        CenterGrid_Helper.Visibility = Visibility.Visible;
        //        CenterGrid_Look.Visibility = Visibility.Collapsed;
        //        LeftTab_Helper();


        //    }
        //    else if ("LeftMe" == btnTag)
        //    {
        //        // m_menuPrevBtnTag = m_menuCurBtnTag;
        //        // m_menuCurBtnTag = btnTag;
        //        nTableSelected = 4;
        //        SwitchMenuBtnStatus(nTableSelected);
        //        CenterGrid_Baby.Visibility = Visibility.Collapsed;
        //        CenterGrid_Log.Visibility = Visibility.Collapsed;
        //        CenterGrid_Helper.Visibility = Visibility.Collapsed;
        //        CenterGrid_Look.Visibility = Visibility.Visible;
        //        LeftTab_Look();


        //    }

        //}

        //private void SwitchMenuBtnStatus(int nSelect)
        //{
        //    Color color, color2;
        //    color.A = 255; color.R = 255; color.G = 0; color.B = 0;
        //    color2.A = 255; color2.R = 0; color2.G = 0; color2.B = 0;


        //    switch (nSelect)
        //    {
        //        case 1:
        //            {
        //                Left_Baby_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/baby_selected.png"));
        //                Left_Baby_TextBlock.Foreground = new SolidColorBrush(color);

        //                Left_Log_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/log_normal.png"));
        //                Left_Log_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Helper_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/helper_normal.png"));
        //                Left_Helper_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Look_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/look_normal.png"));
        //                Left_Look_TextBlock.Foreground = new SolidColorBrush(color2);
        //            }
        //            break;


        //        case 2:
        //            {
        //                Left_Baby_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/baby_normal.png"));
        //                Left_Baby_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Log_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/log_selected.png"));
        //                Left_Log_TextBlock.Foreground = new SolidColorBrush(color);

        //                Left_Helper_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/helper_normal.png"));
        //                Left_Helper_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Look_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/look_normal.png"));
        //                Left_Look_TextBlock.Foreground = new SolidColorBrush(color2);
        //            }
        //            break;

        //        case 3:
        //            {
        //                Left_Baby_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/baby_normal.png"));
        //                Left_Baby_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Log_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/log_normal.png"));
        //                Left_Log_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Helper_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/helper_selected.png"));
        //                Left_Helper_TextBlock.Foreground = new SolidColorBrush(color);

        //                Left_Look_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/look_normal.png"));
        //                Left_Look_TextBlock.Foreground = new SolidColorBrush(color2);
        //            }
        //            break;


        //        case 4:
        //            {
        //                Left_Baby_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/baby_normal.png"));
        //                Left_Baby_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Log_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/log_normal.png"));
        //                Left_Log_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Helper_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/helper_normal.png"));
        //                Left_Helper_TextBlock.Foreground = new SolidColorBrush(color2);

        //                Left_Look_Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/look_selected.png"));
        //                Left_Look_TextBlock.Foreground = new SolidColorBrush(color);
        //            }
        //            break;

        //    }


        //}

        //private void LeftTab_Baby()
        //{
        //    BabyWebView.Navigate(new Uri(Define.EatUri));

        //}

        //private void LeftTab_Log()
        //{
        //    LogWebView.Navigate(new Uri(Define.TotoUri));

        //}

        //private void LeftTab_Helper()
        //{

        //    HelperWebView.Navigate(new Uri(Define.UnusualUri));

        //}

        //private void LeftTab_Look()
        //{
        //    LookWebView.Navigate(new Uri(Define.NurseUri));

        //}

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            HomePageGrid.Visibility = Visibility.Collapsed;
            MainPageGrid.Visibility = Visibility.Visible;
        }


        //WebView页面加载相关函数
        private void BabyWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            try
            {
                InfoProgressgRing.Visibility = Visibility.Visible;


                InfoProgressgRing.IsActive = true;


            }
            catch
            {

                InfoProgressgRing.Visibility = Visibility.Collapsed;


                InfoProgressgRing.IsActive = false;

                return;
            }

        }
        private void BabyWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            //string s = BabyWebView.DocumentTitle;

        }
        private void BabyWebView_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            sender.Navigate(args.Uri);
            args.Handled = false;
            return;
        }
        private void BabyWebView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            try
            {
                InfoProgressgRing.Visibility = Visibility.Collapsed;


                InfoProgressgRing.IsActive = false;

            }
            catch
            {
                InfoProgressgRing.Visibility = Visibility.Collapsed;


                InfoProgressgRing.IsActive = false;


                return;
            }
        }

        //显示系统返回按钮
        private void ShowBackRequestedButton()
        {
            var Cur = SystemNavigationManager.GetForCurrentView();
            if (Cur.AppViewBackButtonVisibility == AppViewBackButtonVisibility.Collapsed)
            {
                Cur.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
        }

        //隐藏系统返回按钮
        private void HideBackRequestedButton()
        {
            var Cur = SystemNavigationManager.GetForCurrentView();
            if (Cur.AppViewBackButtonVisibility == AppViewBackButtonVisibility.Visible)
            {
                Cur.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        //返回按钮事件
        private void AppViewBackRequestedButton(Object sender, Windows.UI.Core.BackRequestedEventArgs args)
        {
          


            if (InfoWebView.CanGoBack)
            {
                InfoWebView.GoBack();
            }
            else
            {
                WebView_Grid.Visibility = Visibility.Collapsed;
                Button_Grid.Visibility = Visibility.Visible;

                HideBackRequestedButton();

                args.Handled = true;
            }

        }
        //返回
        private void RetuenButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnBtn.Visibility = Visibility.Collapsed;
            SettingBtn.Visibility = Visibility.Visible;

            EightBtn_Grid.Visibility = Visibility.Visible;
            Settting_Grid.Visibility = Visibility.Collapsed;


            TitleBar.Text = "趣宝宝";

            

        }

        //设置
        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            EightBtn_Grid.Visibility = Visibility.Collapsed;
            Settting_Grid.Visibility = Visibility.Visible;




            TitleBar.Text = "设置";
            ReturnBtn.Visibility = Visibility.Visible;
            SettingBtn.Visibility = Visibility.Collapsed;
        }

        //版本更新
        private void VisionUpGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            versiondlg.ShowAsync();
        }

        //关于我们
        private void AboutOursGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            auoutUsdlg.ShowAsync();

        }

        //按钮响应事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button_Grid.Visibility = Visibility.Collapsed;
            WebView_Grid.Visibility = Visibility.Visible;
            ShowBackRequestedButton();

            Button btn = (Button)sender;
            String xName = btn.Name.ToString();
            //string strTempUri;
            if (xName == "btn1")
            {
                InfoWebView.Navigate(new Uri(Define.EatUri));
            }
            else if (xName == "btn2")
            {
                InfoWebView.Navigate(new Uri(Define.TotoUri));
            }
            else if (xName == "btn3")
            {
                InfoWebView.Navigate(new Uri(Define.UnusualUri));
            }
            else if (xName == "btn4")
            {
                InfoWebView.Navigate(new Uri(Define.NurseUri));

            }
            else if (xName == "btn5")
            {
                InfoWebView.Navigate(new Uri(Define.SleepUri));

            }
            else if (xName == "btn6")
            {
                InfoWebView.Navigate(new Uri(Define.GrowUri));

            }
            else if (xName == "btn7")
            {
                InfoWebView.Navigate(new Uri(Define.GuardUri));

            }
            else if (xName == "btn8")
            {
                InfoWebView.Navigate(new Uri(Define.PostpartumeUri));

            }
            else
            {

            }



        }
    }
}
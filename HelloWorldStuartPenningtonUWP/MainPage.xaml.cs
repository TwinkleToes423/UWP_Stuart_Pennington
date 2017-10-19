using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HelloWorldStuartPenningtonUWP
{
   /// <summary>
   /// An empty page that can be used on its own or navigated to within a Frame.
   /// </summary>
   public sealed partial class MainPage : Page
   {
      public MainPage()
      {
         this.InitializeComponent();
      }

      private async void addQuoteButton_Click(object sender, RoutedEventArgs e)
      {
         var currentAV = ApplicationView.GetForCurrentView();
         var newAV = CoreApplication.CreateNewView();
         await newAV.Dispatcher.RunAsync(
                         CoreDispatcherPriority.Normal,
                         async () =>
                         {
                            var newWindow = Window.Current;
                            var newAppView = ApplicationView.GetForCurrentView();
                            newAppView.Title = "Order Window";

                            var frame = new Frame();
                            frame.Navigate(typeof(AddQuote), null);
                            newWindow.Content = frame;
                            newWindow.Activate();

                            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                       newAppView.Id,
                       ViewSizePreference.UseMinimum,
                       currentAV.Id,
                       ViewSizePreference.UseMinimum);
                         });
      }
   }
}

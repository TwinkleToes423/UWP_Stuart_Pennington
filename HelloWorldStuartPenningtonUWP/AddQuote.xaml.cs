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

namespace HelloWorldStuartPenningtonUWP
{
   /// <summary>
   /// An empty page that can be used on its own or navigated to within a Frame.
   /// </summary>
   public sealed partial class AddQuote : Page
   {
      private DeskQuote DeskQuote;

      public AddQuote()
      {
         DeskQuote = new DeskQuote();
         this.InitializeComponent();
      }

      private void displayPrice()
      {
         // No last name given
         if (lastNameBox.Text == "")
         {
            ContentDialog rangeErr = new ContentDialog()
            {
               Title = "Name Required",
               Content = "A last name is required for each quote. Company names should be entered in as Last Names.",
               CloseButtonText = "Ok"
            };
            displayError(rangeErr);
         }
         // No order size given
         else if (numDesksBox.Text == "")
         {
            ContentDialog rangeErr = new ContentDialog()
            {
               Title = "Number of Desks Required",
               Content = "A number of desks must be entered.",
               CloseButtonText = "Ok"
            };
            displayError(rangeErr);
         }
         // Everything is working fine
         else
         {
            try
            {
               this.priceDisplayBlock.Text = "$" + DeskQuote.makeDesk(
               firstNameBox.Text,
               lastNameBox.Text,
               (int)widthSlider.Value,        //Width
               (int)depthSlider.Value,        //Depth
               (int)drawerSlider.Value,      //Drawers
               rushDaysBox.SelectionBoxItem.ToString()[0],     //Rush days
               (Desk.Material)Enum.Parse(typeof(Desk.Material),
               materialBox.SelectionBoxItem.ToString()), // Material
               int.Parse(numDesksBox.Text)         //Number of desks
               ).ToString("0.00");  //Display 2 decimal places
            }
            catch
            {
               ContentDialog rangeErr = new ContentDialog()
               {
                  Title = "Form Incomplete",
                  Content = "Please make sure all forms have a selected option.",
                  CloseButtonText = "Ok"
               };
               displayError(rangeErr);
            }
         }
      }


      private void calcButton_Click(object sender, RoutedEventArgs e)
      {
         displayPrice();
      }

      private async void displayError(ContentDialog err)
      {
         await err.ShowAsync();
      }
   }
}

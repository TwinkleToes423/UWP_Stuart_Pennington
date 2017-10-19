﻿using System;
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
         string mat = materialBox.SelectionBoxItem.ToString();

         this.priceDisplayBlock.Text = "$" + DeskQuote.makeDesk(
            (int)this.widthSlider.Value,        //Width
            (int)this.depthSlider.Value,        //Depth
            (int)this.drawerSlider.Value,      //Drawers
            rushDaysBox.SelectionBoxItem.ToString()[0],     //Rush days
            (Desk.Material)Enum.Parse(typeof(Desk.Material),
            materialBox.SelectionBoxItem.ToString()), // Material
            int.Parse(this.numDesksBox.Text)         //Number of desks
            ).ToString("0.00");  //Display 2 decimal places
      }

      private void calcButton_Click(object sender, RoutedEventArgs e)
      {
         displayPrice();
      }
   }
}

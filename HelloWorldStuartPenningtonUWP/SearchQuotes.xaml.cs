using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HelloWorldStuartPenningtonUWP
{
   /// <summary>
   /// An empty page that can be used on its own or navigated to within a Frame.
   /// </summary>
   public sealed partial class SearchQuotes : Page
   {
      public SearchQuotes()
      {
         this.InitializeComponent();
      }

      private void button_Click(object sender, RoutedEventArgs e)
      {
         DeskQuote.searchAsync(nameBox.Text);
      }
   }
}

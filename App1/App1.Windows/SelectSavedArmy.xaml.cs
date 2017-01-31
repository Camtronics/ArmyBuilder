using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectSavedArmy : Page
    {

        List<string>  savedArmy = new List<string>();

        public SelectSavedArmy()
        {
            this.InitializeComponent();

            /* For Multi Save posibility 
          Task<List<string>> armySaves = savedArmies.GetFileNames();

            
          foreach (string troop in troopTypes)
            {
                Button button = new Button();
                button.Height = 75;
                button.Width = 500;
                button.HorizontalAlignment = HorizontalAlignment.Center;
                button.FontSize = 36;
                button.Content = troop;
                button.Margin = new Thickness(13, 13, 13, 13);
                button.Foreground = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                button.Background = new SolidColorBrush(Color.FromArgb(100, 40, 83, 20));
                button.Name = troop;
                button.Tapped += Button_Tapped2;
                unitsStackPanel.Children.Add(button);
                Rectangle rect = new Rectangle();
                rect.Height = 5;
                rect.Width = 500;
                rect.HorizontalAlignment = HorizontalAlignment.Center;
                rect.Margin = new Thickness(5, 5, 5, 5);
                rect.Fill = new SolidColorBrush(Colors.Red);
                unitsStackPanel.Children.Add(rect);
            }
           */
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            savedArmy = e.Parameter as List<string>;
            txtPointsValue.Text = savedArmy[0];

            for(int i = 1; i < savedArmy.Count; i++)
            {
                TextBlock text = new TextBlock();
                text.FontSize = 23;
                text.Text = savedArmy[i];
                text.Padding = new Thickness(7);
                text.Foreground = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                text.TextWrapping = TextWrapping.Wrap;
                text.Name = "txt" + i;
                unitsStackPanel.Children.Add(text);
                Rectangle rect = new Rectangle();
                rect.Height = 2;
                rect.Width = 750;
                rect.Margin = new Thickness(3);
                rect.Fill = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                unitsStackPanel.Children.Add(rect);
            }
        }

        private void GoHome(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(OpeningPage));
        }
    }
}

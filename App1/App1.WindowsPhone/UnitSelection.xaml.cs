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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App1
{

    public sealed partial class UnitSelection : Page
    {
       
        Squad squad = new Squad();

        public UnitSelection()
        {
            this.InitializeComponent();
            List<string> unitTypes = squad.GetTypes();
            cboxUnitTypes.Items.Clear();
            cboxUnitTypes.Items.Add("Choose Unit Type");
            foreach (string type in unitTypes)
            {
                cboxUnitTypes.Items.Add(type);
            }
            cboxUnitTypes.SelectedIndex = 0;
            

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void UnitTypeSelected(object sender, SelectionChangedEventArgs e)
        {
            string selUnitType = cboxUnitTypes.SelectedIndex.ToString();
           // SolidColorBrush myGreen = new SolidColorBrush();
           // myGreen.Color = Color.FromArgb(100, 226, 222, 222);

            switch (selUnitType)
            {
                case ("HQ"):
                    {
                        break;
                    }
                case ("Troop"):
                    {
                        List<string> troopTypes = squad.GetTroops();
                        

                        foreach (string troop in troopTypes)
                        {
                           TextBlock text = new TextBlock();
                            text.FontSize = 23;
                            text.Text = troop;
                            text.Padding = new Thickness(7);
                            text.Foreground = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                            text.TextWrapping = TextWrapping.Wrap;
                            text.Name = troop;
                            text.Tapped += Text_Tapped;
                            unitsStackPanel.Children.Add(text);
                            Rectangle rect = new Rectangle();
                            rect.Height = 50;
                            rect.Width = 3000;
                            rect.HorizontalAlignment = HorizontalAlignment.Center;
                            rect.Margin = new Thickness(5);
                            rect.Fill = new SolidColorBrush(Color.FromArgb(100,40,83,20));
                            rect.Stroke = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                            unitsStackPanel.Children.Add(rect);
                         }
                        break;
                    }
                case ("Elite"):
                    {
                        break;
                    }
                case ("Fast Attack"):
                    {
                        break;
                    }
                case ("Vehicles"):
                    {
                        break;
                    }
                case ("Heavy Support"):
                    {
                        break;
                    }
            }
        }//end UnitTypeSelected

        private void Text_Tapped(object sender, TappedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
    
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
    public sealed partial class UnitSelection : Page
    {
        Squad squad = new Squad();
        List<string> troopTypes;
        Army thisArmy;
        
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

         protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            thisArmy = e.Parameter as Army;
        }

        private void UnitTypeSelected(object sender, SelectionChangedEventArgs e)
        {
            string selUnitType = cboxUnitTypes.SelectedValue.ToString();
            
           // myGreen.Color = Color.FromArgb(100, 226, 222, 222);

            switch (selUnitType)
            {
                case ("HQ"):
                    {

                        unitsStackPanel.Children.Clear();
                        troopTypes = squad.GetHQs();


                        foreach (string HQ in troopTypes)
                        {
                            Button button = new Button();
                            button.Height = 75;
                            button.Width = 500;
                            button.HorizontalAlignment = HorizontalAlignment.Center;
                            button.FontSize = 36;
                            button.Content = HQ;
                            button.Margin = new Thickness(13, 13, 13, 13);
                            button.Foreground = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                            button.Background = new SolidColorBrush(Color.FromArgb(100, 40, 83, 20));
                            button.Name = HQ;
                            button.Tapped += Text_Tapped;
                            unitsStackPanel.Children.Add(button);
                            Rectangle rect = new Rectangle();
                            rect.Height = 5;
                            rect.Width = 500;
                            rect.HorizontalAlignment = HorizontalAlignment.Center;
                            rect.Margin = new Thickness(5, 5, 5, 5);
                            rect.Fill = new SolidColorBrush(Colors.Red);
                            unitsStackPanel.Children.Add(rect);
                        }
                        break;
                    }
                case ("Troop"):
                    {
                        unitsStackPanel.Children.Clear();
                        troopTypes = squad.GetTroops();


                        foreach (string troop in troopTypes)
                        {
                            Button button = new Button();
                            button.Height = 75;
                            button.Width = 500;
                            button.HorizontalAlignment = HorizontalAlignment.Center;
                            button.FontSize = 36;
                            button.Content = troop;
                            button.Margin = new Thickness(13,13,13,13);
                            button.Foreground = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                            button.Background = new SolidColorBrush(Color.FromArgb(100, 40, 83, 20));
                            button.Name = troop; 
                            button.Tapped += Text_Tapped;
                            unitsStackPanel.Children.Add(button);
                            Rectangle rect = new Rectangle();
                            rect.Height = 5;
                            rect.Width = 500;
                            rect.HorizontalAlignment = HorizontalAlignment.Center;
                            rect.Margin = new Thickness(5,5,5,5);
                            rect.Fill = new SolidColorBrush(Colors.Red);
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
            Button selected = sender as Button;
            string newUnitType = selected.Content.ToString();

            switch(newUnitType)
            {
                case "Tactical Squad":
                    {
                        thisArmy.newUnitType = "Tactical Squad";
                        Frame.Navigate(typeof(BuildTacSquad), thisArmy);
                        break;
                    }
            }

        }
    }
}

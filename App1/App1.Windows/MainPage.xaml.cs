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
    public sealed partial class MainPage : Page
    {
        Army thisArmy = new Army();
        List<Squad> armyList;
        SaveArmy saveArmy = new SaveArmy();
        int selectedIndex = 0;
        bool itemSelected = false;
        int desSel;
        int curSel;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AddNewUnit(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(UnitSelection), thisArmy);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null) // keep current army and show list
            {
                thisArmy = e.Parameter as Army;
                armyList = thisArmy.GetArmyList();
                ListUnits();
               
            }
        }

        public void ListUnits()
        {
            int squadCount = 0;
            armyListPannel.Children.Clear();
            foreach (Squad squad in armyList)
            {
                TextBlock text = new TextBlock();
                text.FontSize = 23;
                text.Text = squad.squadDesc;
                text.Padding = new Thickness(7);
                text.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                text.LineHeight = 35;
                text.TextWrapping = TextWrapping.Wrap;
                text.Name = "txt" + squadCount;
                text.Tapped += Text_Tapped;
                armyListPannel.Children.Add(text);
                Rectangle rect = new Rectangle();
                rect.Height = 2;
                rect.Width = 750;
                rect.Margin = new Thickness(3);
                rect.Fill = new SolidColorBrush(Color.FromArgb(100, 226, 222, 222));
                armyListPannel.Children.Add(rect);
                squadCount++;
            }
            txtArmyPoints.Text = thisArmy.armyPoints.ToString();
        }


        private void Text_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
            TextBlock newText = sender as TextBlock;
            string name = newText.Name;
            string val = name.Substring(3, name.Length - 3);
            selectedIndex = Convert.ToInt16(val);
            desSel = Convert.ToInt16(val);
            
            if (itemSelected) // item is selected
            {
                if (curSel == desSel)
                {
                    btnDeleteUnit.IsEnabled = false; // disable buttons
                    newText.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                    itemSelected = false;
                }
            }
            else // nothing selected yet
            {
                curSel = desSel;
                btnDeleteUnit.IsEnabled = true; // enable buttons
                newText.Foreground = new SolidColorBrush(Colors.Red);
                itemSelected = true;
            }
        }

        private void SaveTheArmy(object sender, TappedRoutedEventArgs e)
        {
            saveArmy.SaveTheArmy(thisArmy);
            Frame.Navigate(typeof(OpeningPage));
        }

        private void DeleteUnit(object sender, TappedRoutedEventArgs e)
        {
            // remove that item from the order
            Squad removedSquad = armyList[curSel];
            thisArmy.armyPoints -= removedSquad.squadPointValue;
            
            armyList.RemoveAt(curSel);
            btnDeleteUnit.IsEnabled = false;
            itemSelected = false;

            // redraw/populate our list
            TextBlock txt = new TextBlock();
            txt.Name = "Please Work";
            armyListPannel.Children.Add(txt);
            armyListPannel.Children.Clear();
            ListUnits();          
            txtArmyPoints.Text = thisArmy.armyPoints.ToString();
        }

        

    }
}

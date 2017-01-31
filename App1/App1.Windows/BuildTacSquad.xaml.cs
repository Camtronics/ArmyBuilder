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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BuildTacSquad : Page
    {
        Army thisArmy;
        List<Squad> army;
        TacSquad thisSquad = new TacSquad();
        static int endOfSub;

        public BuildTacSquad()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            thisArmy = e.Parameter as Army;
            army = thisArmy.GetArmyList();
            thisSquad.ClearMarines();
            thisSquad = new TacSquad();
            //fill cboxes for marine 4
            cboxSpecial1.Items.Add("Special Weapons");
            List<string> specialWeapons = SpecialWeapon.GetSpecials();
            foreach (string weapon in specialWeapons)
            {
                cboxSpecial1.Items.Add(weapon);
            }
            cboxSpecial1.SelectedIndex = 0;
            cboxHeavy1.Items.Add("Heavy Weapons");
            List<string> heavyWeapons = HeavyWeapons.GetHeavy();
            foreach (string weapon in heavyWeapons)
            {
                cboxHeavy1.Items.Add(weapon);
            }
            cboxHeavy1.SelectedIndex = 0;

            //fill cboxes for marine 9
            cboxSpecial2.Items.Add("Special Weapons");
            foreach (string weapon in specialWeapons)
            {
                cboxSpecial2.Items.Add(weapon);
            }
            cboxSpecial2.SelectedIndex = 0;
            cboxHeavy2.Items.Add("Heavy Weapons");
            foreach (string weapon in heavyWeapons)
            {
                cboxHeavy2.Items.Add(weapon);
            }
            cboxHeavy2.SelectedIndex = 0;

            //fill Sgt Weapons Boxes

            List<string> sgtRanged = RangedWeapon.GetNonPistol();
            List<string> sgtPistol = RangedWeapon.GetPistols();
            List<string> sgtMelee = MeleeWeapon.GetMeleeList();

            //ranged
            foreach (string ranged in sgtRanged)
            {
                cboxSgtRanged.Items.Add(ranged);
            }
            cboxSgtRanged.SelectedIndex = 0;
            //pistol
            foreach (string pistol in sgtPistol)
            {
                cboxSgtPistol.Items.Add(pistol);
            }
            cboxSgtPistol.SelectedIndex = 0;
            //melee
            foreach (string melee in sgtMelee)
            {
                cboxSgtMelee.Items.Add(melee);
            }
            cboxSgtMelee.SelectedIndex = 0;

           

            txtPointsCount.Text = thisSquad.squadPointValue.ToString();

            int squadNumber = thisArmy.countTacSquads();

            if (squadNumber < 1)
            {
                thisSquad.squadName = "Tac Squad 1";
            }
            else
            {
                thisSquad.squadName = "Tac Squad" + (squadNumber + 1);
            }
            txtUnitCount.Text = thisSquad.squadSize.ToString();
        }

     
        private void RemoveMarine(object sender, TappedRoutedEventArgs e)
        {
            if (thisSquad.spaceMarineCount < 9)//rmeove a marine if there is 8 or less
            {
                thisSquad.RemoveSpaceMarine();
                txtUnitCount.Text = thisSquad.squadSize.ToString();
                txtPointsCount.Text = thisSquad.squadPointValue.ToString();
            }//emd if there is less than 9
            else//if 9 Marines
            {
                Weapon weapon = thisSquad.GetMarine9Wepaon();//Get wepaon of final marine
                if (weapon.wepName != "Boltgun")//check if not a bolter
                {
                    //remove points value of weapon from squad total
                    thisSquad.squadPointValue -= weapon.wepPointsValue;

                    //remove marine and reset visuals
                    thisSquad.RemoveSpaceMarine();
                    txtUnitCount.Text = thisSquad.squadSize.ToString();
                    txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                    cboxSpecial2.IsEnabled = false;
                    cboxHeavy2.IsEnabled = false;
                    cboxSpecial2.SelectedIndex = 0;
                    cboxHeavy2.SelectedIndex = 0;
                    //turn off wepaon selections for 9 if he is not there
                }
                else//if 9 has a bolter remove him and set visuals
                {
                    thisSquad.RemoveSpaceMarine();
                    txtUnitCount.Text = thisSquad.squadSize.ToString();
                    txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                    //turn off weapon selection for 9 if he is not there
                    cboxSpecial2.IsEnabled = false;
                    cboxHeavy2.IsEnabled = false;
                    cboxSpecial2.SelectedIndex = 0;
                    cboxHeavy2.SelectedIndex = 0;
                }
            }//end if there are 9
        }

        private void AddMarine(object sender, TappedRoutedEventArgs e)
        {
            thisSquad.AddSpaceMarine();
            txtUnitCount.Text = thisSquad.squadSize.ToString();
            txtPointsCount.Text = thisSquad.squadPointValue.ToString();
            if((thisSquad.spaceMarineCount == 9) && (checkAddEquip1.IsChecked == true))
                {

                    if (thisSquad.IsMarine4Special())
                        {
                            cboxHeavy2.IsEnabled = true;
                        }
                    else if (thisSquad.IsMarine4Heavy())
                        {
                            cboxSpecial2.IsEnabled = true;
                         }
                    else
                        {
                            cboxSpecial2.IsEnabled = true;
                            cboxHeavy2.IsEnabled = true;
                        }
                }
        }//end AddMarine

        private void AllowWepChange(object sender, RoutedEventArgs e)
        {
            if (thisSquad.spaceMarineCount < 9)//if less than 9 marines
            {
                cboxSpecial1.IsEnabled = true;
                cboxHeavy1.IsEnabled = true;
            }
            else  //if 9 marines 
            {
                cboxSpecial1.IsEnabled = true;
                cboxHeavy1.IsEnabled = true;
                cboxSpecial2.IsEnabled = true;
                cboxHeavy2.IsEnabled = true;
            }
        }

        //method to reset the first heavy/special
        private void RemoveHevSpec1(object sender, RoutedEventArgs e)
        {
            //if there is only one possible heavy/special weapon
            if (thisSquad.spaceMarineCount < 9)
            {
                //get unit 4s weapon
                Weapon weapon = thisSquad.GetMarine4Wepaon();
                if (weapon.wepName != "Boltgun")
                {
                    //get points value of the weapon and remove from current points
                    thisSquad.squadPointValue -= weapon.wepPointsValue;
                    //reset the weapon of space marine 4
                    thisSquad.ResetBolter4();
                    cboxSpecial1.SelectedIndex = 0;
                    cboxHeavy1.SelectedIndex = 0;
                    cboxSpecial1.IsEnabled = false;
                    cboxHeavy1.IsEnabled = false;
                    txtUnitCount.Text = thisSquad.squadSize.ToString();
                    txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                }
                else
                {
                    cboxSpecial1.IsEnabled = false;
                    cboxHeavy1.IsEnabled = false;
                }
            }
            else
            {
                //get weapons from 4 and 9
                Weapon weapon1 = thisSquad.GetMarine4Wepaon();
                Weapon weapon2 = thisSquad.GetMarine9Wepaon();

                //remove their points from the total
                thisSquad.squadPointValue -= weapon1.wepPointsValue;
                thisSquad.squadPointValue -= weapon2.wepPointsValue;

                //reset weapons for numbers 4 and 9
                thisSquad.ResetBolter4();
                thisSquad.ResetBolter9();
                txtUnitCount.Text = thisSquad.squadSize.ToString();
                txtPointsCount.Text = thisSquad.squadPointValue.ToString();

                cboxSpecial1.IsEnabled = false;
                cboxHeavy1.IsEnabled = false;
                cboxSpecial2.IsEnabled = false;
                cboxHeavy2.IsEnabled = false;
                cboxSpecial1.SelectedIndex = 0;
                cboxHeavy1.SelectedIndex = 0;
                cboxSpecial2.SelectedIndex = 0;
                cboxHeavy2.SelectedIndex = 0;
            }
        }//end remove heavy and special toggle method

        private void AddSpecial1(object sender, SelectionChangedEventArgs e)
        {
            //get new weapon name and current weapon of marine 4
            string selSpecial = cboxSpecial1.SelectedValue.ToString();

            if (selSpecial == "Special Weapons")
            {
                //do nothing
            }
            else//if not special
            {
               

                for (int i = selSpecial.Length - 1; i > 0; i--)
                {
                    char letter = selSpecial.ElementAt(i);
                    if (letter.Equals(' '))
                    {
                        endOfSub = i;
                        break;
                    }
                    else
                    {

                    }
                }//end of for should break to here

                string special = selSpecial.Substring(0, endOfSub);
                Weapon curWeapon = thisSquad.GetMarine4Wepaon();

                //check for unit sizw
                if (thisSquad.spaceMarineCount < 9)
                {
                        //check for if it is a bolgun or not
                        if (curWeapon.wepName != "Boltgun")
                        {
                            //remove points from total of old weapon
                            thisSquad.squadPointValue -= curWeapon.wepPointsValue;
                            //set the new weapon
                            thisSquad.ChangeWepSpecial4(special);
                            //grab weapon and add points to army
                            Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                            thisSquad.squadPointValue += newWeapon.wepPointsValue;
                            cboxHeavy1.IsEnabled = false;
                            txtPointsCount.Text = thisSquad.squadPointValue.ToString();

                        }
                        else
                        {
                            thisSquad.ChangeWepSpecial4(special);
                            Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                            thisSquad.squadPointValue += newWeapon.wepPointsValue;
                            txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                            cboxHeavy1.IsEnabled = false;
                        }
                    }
                    else
                    {
                        if (curWeapon.wepName != "Boltgun")
                        {
                            //remove points from total of old weapon
                            thisSquad.squadPointValue -= curWeapon.wepPointsValue;
                            //set the new weapon
                            thisSquad.ChangeWepSpecial4(special);
                            //grab weapon and add points to army
                            Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                            thisSquad.squadPointValue += newWeapon.wepPointsValue;
                            cboxHeavy1.IsEnabled = false;
                            cboxSpecial2.IsEnabled = false;
                            txtPointsCount.Text = thisSquad.squadPointValue.ToString();

                        }
                        else
                        {
                            thisSquad.ChangeWepSpecial4(special);
                            Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                            thisSquad.squadPointValue += newWeapon.wepPointsValue;
                            txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                            cboxHeavy1.IsEnabled = false;
                            cboxSpecial2.IsEnabled = false;
                    }
                }//end else
              }//end for if selSpecial != Special Weapons
            }//end of the AddSpecial1 method

        private void AddHeavy1(object sender, SelectionChangedEventArgs e)
        {
            //get new weapon name and current weapon of marine 4
            string selHeavy = cboxHeavy1.SelectedValue.ToString();

            if (selHeavy == "Heavy Weapons")
            {
                //do nothing
            }
            else//if not "Heavy Weapons"
            {
                //loop to remove points from selection
                for (int i = selHeavy.Length - 1; i > 0; i--)
                {
                    char letter = selHeavy.ElementAt(i);
                    if (letter.Equals(' '))
                    {
                        endOfSub = i;
                        break;
                    }
                    else
                    {

                    }
                }//end of for should break to here

                string heavy = selHeavy.Substring(0, endOfSub);
                Weapon curWeapon = thisSquad.GetMarine4Wepaon();

                //check for unit sizw
                if (thisSquad.spaceMarineCount < 9)
                {
                    //check for if it is a bolgun or not
                    if (curWeapon.wepName != "Boltgun")
                    {
                        //remove points from total of old weapon
                        thisSquad.squadPointValue -= curWeapon.wepPointsValue;
                        //set the new weapon
                        thisSquad.ChangeWepHeavy4(heavy);
                        //grab weapon and add points to army
                        Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                        thisSquad.squadPointValue += newWeapon.wepPointsValue;
                        cboxSpecial1.IsEnabled = false;
                        txtPointsCount.Text = thisSquad.squadPointValue.ToString();

                    }
                    else
                    {
                        thisSquad.ChangeWepHeavy4(heavy);
                        Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                        thisSquad.squadPointValue += newWeapon.wepPointsValue;
                        txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                        cboxSpecial1.IsEnabled = false;
                    }
                }
                else
                {
                    if (curWeapon.wepName != "Boltgun")
                    {
                        //remove points from total of old weapon
                        thisSquad.squadPointValue -= curWeapon.wepPointsValue;
                        //set the new weapon
                        thisSquad.ChangeWepHeavy4(heavy);
                        //grab weapon and add points to army
                        Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                        thisSquad.squadPointValue += newWeapon.wepPointsValue;
                        cboxHeavy2.IsEnabled = false;
                        cboxSpecial1.IsEnabled = false;
                        txtPointsCount.Text = thisSquad.squadPointValue.ToString();

                    }
                    else
                    {
                        thisSquad.ChangeWepHeavy4(heavy);
                        Weapon newWeapon = thisSquad.GetMarine4Wepaon();
                        thisSquad.squadPointValue += newWeapon.wepPointsValue;
                        txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                        cboxHeavy2.IsEnabled = false;
                        cboxSpecial1.IsEnabled = false;
                    }
                }//end else
            }//end for if selHeavy not Heavy Weapons
        }//end of the AddHeavy1 method

        private void AddSpecial2(object sender, SelectionChangedEventArgs e)
        {
            //get new weapon name and current weapon of marine 9
            string selSpecial = cboxSpecial2.SelectedValue.ToString();

            if (selSpecial == "Special Weapons")
            {
                //do nothing
            }
            else//if not special
            {


                for (int i = selSpecial.Length - 1; i > 0; i--)
                {
                    char letter = selSpecial.ElementAt(i);
                    if (letter.Equals(' '))
                    {
                        endOfSub = i;
                        break;
                    }
                    else
                    {

                    }
                }//end of for should break to here

                string special = selSpecial.Substring(0, endOfSub);
                Weapon curWeapon = thisSquad.GetMarine9Wepaon();

                //check for unit sizw
                if (curWeapon.wepName != "Boltgun")
                    {
                        //remove points from total of old weapon
                        thisSquad.squadPointValue -= curWeapon.wepPointsValue;
                        //set the new weapon
                        thisSquad.ChangeWepSpecial9(special);
                        //grab weapon and add points to army
                        Weapon newWeapon = thisSquad.GetMarine9Wepaon();
                        thisSquad.squadPointValue += newWeapon.wepPointsValue;
                        cboxHeavy2.IsEnabled = false;
                        cboxSpecial1.IsEnabled = false;
                        txtPointsCount.Text = thisSquad.squadPointValue.ToString();

                    }
                    else
                    {
                        thisSquad.ChangeWepSpecial9(special);
                        Weapon newWeapon = thisSquad.GetMarine9Wepaon();
                        thisSquad.squadPointValue += newWeapon.wepPointsValue;
                        txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                        cboxHeavy2.IsEnabled = false;
                        cboxSpecial1.IsEnabled = false;
                    }
                
            }//end for if selSpecial != Special Weapons
        }

        private void AddSgtRanged(object sender, SelectionChangedEventArgs e)
        {
            string selRanged = cboxSgtRanged.SelectedValue.ToString();

            //loop for name
            for (int i = selRanged.Length - 1; i > 0; i--)
            {
                char letter = selRanged.ElementAt(i);
                if (letter.Equals(' '))
                {
                    endOfSub = i;
                    break;
                }
                else
                {

                }
            }

            //pull name
            string ranged = selRanged.Substring(0, endOfSub);
            Weapon curWeapon = thisSquad.GetSgtRangedWepaon();
           
            //remove points from total for old weapon
            thisSquad.squadPointValue -= curWeapon.wepPointsValue;
            //set the new weapon
            thisSquad.ChangeSgtRanged(ranged);
            //grab weapon and add points to army
            Weapon newWeapon = thisSquad.GetSgtRangedWepaon();
            thisSquad.squadPointValue += newWeapon.wepPointsValue;
            txtPointsCount.Text = thisSquad.squadPointValue.ToString();
        }

        private void AddSgtMelee(object sender, SelectionChangedEventArgs e)
        {
            string selMelee = cboxSgtMelee.SelectedValue.ToString();

            //loop for name
            for (int i = selMelee.Length - 1; i > 0; i--)
            {
                char letter = selMelee.ElementAt(i);
                if (letter.Equals(' '))
                {
                    endOfSub = i;
                    break;
                }
                else
                {

                }
            }

            //pull name
            string melee = selMelee.Substring(0, endOfSub);
            Weapon curWeapon = thisSquad.GetSgtMeleeWepaon();

            //remove points from total for old weapon
            thisSquad.squadPointValue -= curWeapon.wepPointsValue;
            //set the new weapon
            thisSquad.ChangeSgtMelee(melee);
            //grab weapon and add points to army
            Weapon newWeapon = thisSquad.GetSgtMeleeWepaon();
            thisSquad.squadPointValue += newWeapon.wepPointsValue;
            txtPointsCount.Text = thisSquad.squadPointValue.ToString();
        }

        private void AddSgtPistol(object sender, SelectionChangedEventArgs e)
        {
            string selPistol = cboxSgtPistol.SelectedValue.ToString();

            //loop for name
            for (int i = selPistol.Length - 1; i > 0; i--)
            {
                char letter = selPistol.ElementAt(i);
                if (letter.Equals(' '))
                {
                    endOfSub = i;
                    break;
                }
                else
                {

                }
            }

            //pull name
            string pistol = selPistol.Substring(0, endOfSub);
            Weapon curWeapon = thisSquad.GetSgtPistolWepaon();

            //remove points from total for old weapon
            thisSquad.squadPointValue -= curWeapon.wepPointsValue;
            
            //set the new weapon
            thisSquad.ChangeSgtPistol(pistol);
            
            //grab weapon and add points to army
            Weapon newWeapon = thisSquad.GetSgtPistolWepaon();
            thisSquad.squadPointValue += newWeapon.wepPointsValue;
            txtPointsCount.Text = thisSquad.squadPointValue.ToString();
        }

        private void ToggleSgt(object sender, RoutedEventArgs e)
        {
            if (tglSgt.IsOn == false)
            {
                thisSquad.MakeSgt();
                thisSquad.squadPointValue -= 10;
                txtPointsCount.Text = thisSquad.squadPointValue.ToString();
            }
            else
            {
                thisSquad.MakeVetSgt();
                thisSquad.squadPointValue += 10;
                txtPointsCount.Text = thisSquad.squadPointValue.ToString();
            }
        }

        private void AddUnit(object sender, TappedRoutedEventArgs e)
        {
            //create description of squad
            thisSquad.squadDesc += (thisSquad.squadName + "     Points Value: " + thisSquad.squadPointValue + "\n"
                                  + thisSquad.spaceMarineCount + " Space Marines and a " + thisSquad.GetSgtType() + "\n");

            //weapons checks and additions
            int bolterCount = thisSquad.CountBolters();
            Weapon sgtRange = thisSquad.GetSgtRangedWepaon();
            Weapon sgtPistol = thisSquad.GetSgtPistolWepaon();
            Weapon sgtMelee = thisSquad.GetSgtMeleeWepaon();
            Weapon unit4 = thisSquad.GetMarine4Wepaon();


            //Check bolters for unit 4, 9 and Sgt

            if (thisSquad.squadSize == 10)
            {
                Weapon unit9 = thisSquad.GetMarine9Wepaon();

                if (bolterCount == 9)//all SM have bolters
                {
                    thisSquad.squadDesc += ("Space Marine Weapons:\n9 x Boltguns, 9 Bolt pistols\n"
                                           + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");

                }
                else if (bolterCount == 8)//if one SM has a bolter
                {
                    if (unit4.priWepName != "Boltgun")//if unit 4 doesnt have bgun
                    {
                        thisSquad.squadDesc += ("Space Marine Weapons:\n8 x Boltguns, 1 " + unit4.priWepName + ",  9 Bolt pistols\n"
                                          + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");
                    }
                    else if (unit9.priWepName != "Boltgun")//if unit 9 doesnt have bgun
                    {
                        thisSquad.squadDesc += ("Space Marine Weapons:\n8 x Boltguns, 1 " + unit9.priWepName + ",  9 Bolt pistols\n"
                                          + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");
                    }
                    else
                    {
                        thisSquad.squadDesc += ("Space Marine Weapons:\n9 x Boltguns, 9 Bolt pistols\n"
                                          + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");
                    }
                }//end 8 bolters
                else if (bolterCount == 7)//if 2 SM dont have bolters
                {
                    if (sgtRange.priWepName != "Boltgun")//if sgt doesnt have a bgun, do alternatives for other 2 posibilites
                    {
                        if (unit4.priWepName != "Boltgun")
                        {
                            thisSquad.squadDesc += ("Space Marine Weapons:\n8 x Boltguns, 1 " + unit4.priWepName + ",  9 Bolt pistols\n"
                                         + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");
                        }
                        else
                        {
                            thisSquad.squadDesc += ("Space Marine Weapons:\n8 x Boltguns, 1 " + unit9.priWepName + ",  9 Bolt pistols\n"
                                          + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");
                        }
                    }
                    else//if Sgt has a bolt gun, unit 4 and 9 do not (yay Maths!)
                    {
                        thisSquad.squadDesc += ("Space Marine Weapons:\n7 x Boltguns, 1 " + unit4.priWepName + ", 1 " + unit9.priWepName + ",  9 Bolt pistols\n"
                                    + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");
                    }
                }//end if 8 bolters
            }//end if squad is 10
            else if (thisSquad.squadSize < 10)
            {
                if (unit4.priWepName != "Boltgun")
                {
                    thisSquad.squadDesc += ("Space Marine Weapons:\n" + bolterCount + " x Boltguns, 1 " + unit4.priWepName + ", " + thisSquad.spaceMarineCount + " Bolt pistols\n"
                                        + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");

                }
                else
                {
                    thisSquad.squadDesc += ("Space Marine Weapons:\n" + bolterCount + " x Boltguns, " + thisSquad.spaceMarineCount + " Bolt pistols\n"
                                + thisSquad.GetSgtType() + ":\n" + sgtRange.priWepName + ", " + sgtPistol.priWepName + ", " + sgtMelee.priWepName + "\n");
                }
            }//less than 10

            //last parts of description
            thisSquad.squadDesc += thisSquad.squadSpecialRules;
            thisSquad.squadDesc += thisSquad.squadEquipment;

            //add points of amry to squad
            thisArmy.armyPoints += thisSquad.squadPointValue;

            army.Add(thisSquad);
            Frame.Navigate(typeof(MainPage), thisArmy);



        }

        private void AddHeavy2(object sender, SelectionChangedEventArgs e)
        {
            string selHeavy = cboxHeavy2.SelectedValue.ToString();

            if (selHeavy == "Heavy Weapons")
            {
                //do nothing
            }
            else//if not special
            {
                //loop for substring length
                for (int i = selHeavy.Length - 1; i > 0; i--)
                {
                    char letter = selHeavy.ElementAt(i);
                    if (letter.Equals(' '))
                    {
                        endOfSub = i;
                        break;
                    }
                    else
                    {

                    }
                }//end of for loop, break to here

                string heavy = selHeavy.Substring(0, endOfSub);
                Weapon curWeapon = thisSquad.GetMarine9Wepaon();

                //check for unit sizw
                if (curWeapon.wepName != "Boltgun")
                {
                    //remove points from total of old weapon
                    thisSquad.squadPointValue -= curWeapon.wepPointsValue;
                    //set the new weapon
                    thisSquad.ChangeWepHeavy9(heavy);
                    //grab weapon and add points to army
                    Weapon newWeapon = thisSquad.GetMarine9Wepaon();
                    thisSquad.squadPointValue += newWeapon.wepPointsValue;
                    cboxHeavy1.IsEnabled = false;
                    cboxSpecial2.IsEnabled = false;
                    txtPointsCount.Text = thisSquad.squadPointValue.ToString();

                }
                else
                {
                    thisSquad.ChangeWepHeavy9(heavy);
                    Weapon newWeapon = thisSquad.GetMarine9Wepaon();
                    thisSquad.squadPointValue += newWeapon.wepPointsValue;
                    txtPointsCount.Text = thisSquad.squadPointValue.ToString();
                    cboxHeavy1.IsEnabled = false;
                    cboxSpecial2.IsEnabled = false;
                }

            }//end for if selSpecial != Special Weapons
        }
    }
}

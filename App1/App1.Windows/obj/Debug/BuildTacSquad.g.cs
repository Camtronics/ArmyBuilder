﻿

#pragma checksum "C:\Users\User\Desktop\Stuff For Porfolio LInk\ArmyBuilder\App1\App1.Windows\BuildTacSquad.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EAB7347FC823A01D2CFB1D002639B6C1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1
{
    partial class BuildTacSquad : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 216 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.AddUnit;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 176 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.AddMarine;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 181 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.RemoveMarine;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 186 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.ToggleSwitch)(target)).Toggled += this.ToggleSgt;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 194 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AddSpecial1;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 195 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AddHeavy1;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 197 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Checked += this.AllowWepChange;
                 #line default
                 #line hidden
                #line 197 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Unchecked += this.RemoveHevSpec1;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 200 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AddSpecial2;
                 #line default
                 #line hidden
                break;
            case 9:
                #line 201 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AddHeavy2;
                 #line default
                 #line hidden
                break;
            case 10:
                #line 205 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AddSgtPistol;
                 #line default
                 #line hidden
                break;
            case 11:
                #line 206 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AddSgtRanged;
                 #line default
                 #line hidden
                break;
            case 12:
                #line 208 "..\..\BuildTacSquad.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.AddSgtMelee;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



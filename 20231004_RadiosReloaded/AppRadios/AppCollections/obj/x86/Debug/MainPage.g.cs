﻿#pragma checksum "E:\Docencia\Material_Moduls\M7_DI\repoGit\ICB0_M07_DI_Samples_23_24\20231002_Radios\AppRadios\AppCollections\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CBC56BA5FE69628A5CBAC0E63B548C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppCollections
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // MainPage.xaml line 19
                {
                    this.lsvPersones = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lsvPersones).SelectionChanged += this.lsvPersones_SelectionChanged;
                }
                break;
            case 3: // MainPage.xaml line 24
                {
                    this.rdoLevelNoob = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdoLevelNoob).Checked += this.rdoLevelNoob_Checked;
                }
                break;
            case 4: // MainPage.xaml line 25
                {
                    this.rdoLevelAverage = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdoLevelAverage).Checked += this.rdoLevelAverage_Checked;
                }
                break;
            case 5: // MainPage.xaml line 26
                {
                    this.rdoLevelPro = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdoLevelPro).Checked += this.rdoLevelPro_Checked;
                }
                break;
            case 6: // MainPage.xaml line 27
                {
                    this.rdoLevelHacker = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdoLevelHacker).Checked += this.rdoLevelHacker_Checked;
                }
                break;
            case 7: // MainPage.xaml line 28
                {
                    this.rdoLevelGod = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdoLevelGod).Checked += this.rdoLevelGod_Checked;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

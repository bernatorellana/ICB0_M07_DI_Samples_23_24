﻿#pragma checksum "E:\Docencia\Material_Moduls\M7_DI\repoGit\ICB0_M07_DI_Samples_23_24\20231127_SQLite\DemoSQlite\DemoSQlite\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3AC1831C58426C9EAC028B85498ACF19247D616AD19BB407BE5BAF501F6933D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoSQlite
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {
                    this.pageMain = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)this.pageMain).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // MainPage.xaml line 72
                {
                    this.txbCognomEdit = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // MainPage.xaml line 74
                {
                    this.txbOficiEdit = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // MainPage.xaml line 77
                {
                    this.cboCap = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // MainPage.xaml line 82
                {
                    this.dtpDataAltaEdit = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 6: // MainPage.xaml line 86
                {
                    this.txbSalari = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // MainPage.xaml line 89
                {
                    this.txbComissio = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // MainPage.xaml line 92
                {
                    this.cboDepartament = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 9: // MainPage.xaml line 97
                {
                    this.btnCancel = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 10: // MainPage.xaml line 98
                {
                    this.btnSave = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSave).Click += this.btnSave_Click;
                }
                break;
            case 11: // MainPage.xaml line 43
                {
                    this.dtgEmpleats = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.dtgEmpleats).SelectionChanged += this.dtgEmpleats_SelectionChanged;
                }
                break;
            case 12: // MainPage.xaml line 46
                {
                    this.txbNumEmpleats = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // MainPage.xaml line 35
                {
                    this.txbCognom = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // MainPage.xaml line 38
                {
                    this.dtpDate = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 15: // MainPage.xaml line 40
                {
                    global::Windows.UI.Xaml.Controls.Button element15 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element15).Click += this.Button_Click_1;
                }
                break;
            case 16: // MainPage.xaml line 41
                {
                    global::Windows.UI.Xaml.Controls.Button element16 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element16).Click += this.Button_Click;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}


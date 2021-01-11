using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using JPMorrow.Tools.Diagnostics;
using JPMorrow.UI.Views;

namespace JPMorrow.UI.ViewModels
{
    public partial class SmallInformationViewModel {
        /// <summary>
        /// prompt for save and exit
        /// </summary>
        public void MasterClose(Window window)
        {
            try
            {
                window.Close();
            }
            catch(Exception ex)
            {
                debugger.show(err:ex.ToString());
            }
        }
    }
}
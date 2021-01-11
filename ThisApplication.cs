using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using JPMorrow.Revit.Documents;
using JPMorrow.Tools.Diagnostics;
using JPMorrow.Revit.Tools;
using System.Diagnostics;
using JPMorrow.UI.Views;

namespace MainApp
{
    /// <summary>
    /// Main Execution
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("9BBF529B-520A-4877-B63B-BEF1238B6A05")]
    public partial class ThisApplication : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
			string[] dataDirectories = new string[0];

			//set revit model info
			bool debugApp = false;
			ModelInfo revit_info = ModelInfo.StoreDocuments(
				commandData, dataDirectories, debugApp);
			IntPtr main_rvt_wind = Process.GetCurrentProcess().MainWindowHandle;


			// START PROGRAM


			// package up strings and pass them to view
			string[] conduit_run_txt = new string[] {

			};

			try
			{
				SmallInformationView pv = new SmallInformationView(main_rvt_wind, conduit_run_txt);
				pv.Show();
			}
			catch(Exception ex)
			{
				debugger.show(err:ex.ToString());
			}

			return Result.Succeeded;
        }
    }
}

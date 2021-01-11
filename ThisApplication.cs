using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using JPMorrow.Revit.Documents;
using JPMorrow.Tools.Diagnostics;
using JPMorrow.Revit.Tools;
using System.Diagnostics;
using JPMorrow.UI.Views;
using System.Linq;
using JPMorrow.Revit.ConduitRuns;
using System.Collections.Generic;

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

			// collect selected conduit
			var sel = revit_info.SEL.GetElementIds();

			if(!sel.Any()) return Result.Succeeded;
			
			Element first_conduit = null;
			foreach(var id in sel) {
				var el = revit_info.DOC.GetElement(id);
				if(el.Category.Name.Equals("Conduits")) {
					first_conduit = el;
					break;
				}
			}
			if(first_conduit == null) return Result.Succeeded;

			// get run information
			var cris = new List<ConduitRunInfo>();
			ConduitRunInfo.ProcessCRIFromConduitId(revit_info, new[] { first_conduit.Id }, cris);
			var cri = cris.First();
			revit_info.SEL.SetElementIds(cri.ConduitIds.Concat(cri.FittingIds).Select(x => new ElementId(x)).ToList());

			var dia = cri.DiameterStr(revit_info);
			var length = cri.LengthStr(revit_info);
			var bends = cri.FittingBendsStr(revit_info);

			// package up strings and pass them to view
			string[] conduit_run_txt = new string[] {
				cri.From, cri.To, cri.ConduitMaterialType, dia, length, bends
			};

			try {
				SmallInformationView pv = new SmallInformationView(main_rvt_wind, conduit_run_txt);
				pv.Show();
			}
			catch(Exception ex) {
				debugger.show(err:ex.ToString());
			}

			return Result.Succeeded;
        }
    }
}

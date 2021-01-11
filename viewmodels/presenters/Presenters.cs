using System.ComponentModel;
using System.Runtime.CompilerServices;
using JPMorrow.Revit.ConduitRuns;
using JPMorrow.Revit.Documents;
using Autodesk.Revit.DB;
using System;
using System.Linq;
using JPMorrow.Revit.Text;
using JPMorrow.Revit.Measurements;
using JPMorrow.Revit.VoltageDrop;

namespace JPMorrow.UI.ViewModels
{
    public partial class ParentViewModel
    {
        /*
        /// <summary>
        /// Single Run Entry ListBox Binding
        /// </summary>
        public class RunPresenter : Presenter
        {
            public ConduitRunInfo Value;
            public RunPresenter(ConduitRunInfo value, ModelInfo info)
            {
                Value = value;
                RefreshDisplay(info);
            }

            public void RefreshDisplay(ModelInfo info)
            {
                var opts = CustomFormatValue.FeetAndInches;
                string cvt_dbl(double val)
                    => UnitFormatUtils.Format(info.DOC.GetUnits(), UnitType.UT_Length, val, true, false, opts);
                Has_Wire = ParentViewModel.AppData.WireManager.CheckConduitWire(Value.WireIds) ? "Yes" : "No";
                Length = cvt_dbl(Value.Length);
                From = Value.From;
                To = Value.To;
                Diameter = cvt_dbl(Value.Diameter);
                Conduit_Type = Value.ConduitMaterialType;
            }

            private string hw;
            public string Has_Wire {get => hw;
            set {
                hw = value;
                Update("Run_Items");
            }}

            private string _from;
            public string From {get => _from;
            set {
                _from = value;
                Update("Run_Items");
            }}

            private string _to;
            public string To {get => _to;
            set {
                _to = value;
                Value.OverrideToStr(_to);
                Update("Run_Items");
            }}

            private string _length;
            public string Length {get => _length;
            set {
                _length = value;
                Update("Run_Items");
            }}

            private string _diameter;
            public string Diameter {get => _diameter;
            set {
                _diameter = value;
                Update("Run_Items");
            }}

            private string _conduit_type;
            public string Conduit_Type {get => _conduit_type;
            set {
                _conduit_type = value;
                Update("Run_Items");
            }}

            //Item Selection Bindings
            private bool _isSelected;
            public bool IsSelected { get => _isSelected;
                set {
                    _isSelected = value;
                    Update("Run_Items");
            }}
        }
        */
    }

    /// <summary>
    /// Default Presenter: Just Presents a string value as a listbox item,
    /// can replace with an object for more complex listbox databindings
    /// </summary>
    public class ItemPresenter : Presenter
    {
        private readonly string _value;
        public ItemPresenter(string value) => _value = value;
    }

    #region Inherited Classes
    public abstract class Presenter : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;

         public void Update(string val) => RaisePropertyChanged(val);

         protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
         {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }
    }
    #endregion
}

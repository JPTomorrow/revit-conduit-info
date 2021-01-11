using System.Windows.Input;
using System.Windows;
using JPMorrow.Views.RelayCmd;
using System.Collections.Generic;
using System.Linq;
using System;

namespace JPMorrow.UI.ViewModels
{

    public partial class SmallInformationViewModel : Presenter
    {
        public string FromTxt {get; set;} = "From: ";
        public string ToTxt {get; set;} = "To: ";
        public string TypeTxt {get; set;} = "Type: ";
        public string DiameterTxt {get; set;} = "Diameter: ";
        public string LengthTxt {get; set;} = "Length: ";
        public string BendsTxt {get; set;} = "Total Bends: ";

        public ICommand MasterCloseCmd => new RelayCommand<Window>(MasterClose);

        public SmallInformationViewModel(IEnumerable<string> txt) {
            if(txt.Count() != 6)
                throw new Exception("Not enough string arguments passed to the view.");

            var txt_list = new List<string>(txt);
            FromTxt += txt_list[0];
            ToTxt += txt_list[1];
            TypeTxt += txt_list[2];
            DiameterTxt += txt_list[3];
            LengthTxt += txt_list[4];
            BendsTxt += txt_list[5];
        }
    }
}
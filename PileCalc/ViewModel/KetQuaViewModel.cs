using Microsoft.Reporting.WebForms;
using PileCalc.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;

namespace PileCalc.ViewModel
{
    public class KetQuaViewModel : BaseViewModel
    {
       
        private ObservableCollection<DuLieu> _ListResult;
        public ObservableCollection<DuLieu> ListResult { get => _ListResult; set { _ListResult = value; OnPropertyChanged(); } }

        public ICommand PrintCommand { get; set; }
        
        public KetQuaViewModel()
        {
            
            var data = new PileCalcPlusEntities();

            ListResult = new ObservableCollection<DuLieu>(data.DuLieux);

            PrintCommand = new RelayCommand<object>((p) => { return true; },
                (p) => 
                {
                    
                    

                });
        }
        
    }
}

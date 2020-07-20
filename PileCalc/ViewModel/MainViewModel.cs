using PileCalc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PileCalc.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
       // public static KetQuaWindow KetQuaWindow { get; set; }

        public ICommand SoLieuBanDauCommand { get; set; }
        public ICommand DuLieuCommand { get; set; }
        public ICommand KetQuaCommand { get; set; }

       
        public MainViewModel()
        {
            
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("DELETE FROM DuLieu");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("DELETE FROM SoLieuBanDau");

            

            SoLieuBanDauCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SoLieuBanDauWindow window = new SoLieuBanDauWindow(); window.ShowDialog(); });
            DuLieuCommand = new RelayCommand<object>((p) => { return true; }, (p) => { NhapDuLieuWindow window = new NhapDuLieuWindow(); window.ShowDialog(); });
            KetQuaCommand = new RelayCommand<object>((p) => { return true; },(p) => { KetQuaWindow window = new KetQuaWindow(); window.ShowDialog(); });

        }
        
    }
}

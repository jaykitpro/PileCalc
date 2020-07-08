using PileCalc.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PileCalc.ViewModel
{
    public class KetQuaViewModel : BaseViewModel
    {
        private ObservableCollection<SoLieuBanDau> _Info;
        public ObservableCollection<SoLieuBanDau> Info { get => _Info; set { _Info = value; OnPropertyChanged(); } }

        private ObservableCollection<DuLieu> _List;
        public ObservableCollection<DuLieu> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        

        private string _TenHoKhoan;
        public string TenHoKhoan { get => _TenHoKhoan; set { _TenHoKhoan = value; OnPropertyChanged(); } }

        private string _TenHangMuc;
        public string TenHangMuc { get => _TenHangMuc; set { _TenHangMuc = value; OnPropertyChanged(); } }

        private string _TenDuAn;
        public string TenDuAn { get => _TenDuAn; set { _TenDuAn = value; OnPropertyChanged(); } }

        private string _NguoiThucHien;
        public string NguoiThucHien { get => _NguoiThucHien; set { _NguoiThucHien = value; OnPropertyChanged(); } }

        private string _NguoiKiemTra;
        public string NguoiKiemTra { get => _NguoiKiemTra; set { _NguoiKiemTra = value; OnPropertyChanged(); } }

        private string _CNDA;
        public string CNDA { get => _CNDA; set { _CNDA = value; OnPropertyChanged(); } }

        private string _DuongKinhCoc;
        public string DuongKinhCoc { get => _DuongKinhCoc; set { _DuongKinhCoc = value; OnPropertyChanged(); } }

        private string _KhoiLuongRiengBeTong;
        public string KhoiLuongRiengBeTong { get => _KhoiLuongRiengBeTong; set { _KhoiLuongRiengBeTong = value; OnPropertyChanged(); } }

        private string _ChieuSauCocXuyen;
        public string ChieuSauCocXuyen { get => _ChieuSauCocXuyen; set { _ChieuSauCocXuyen = value; OnPropertyChanged(); } }

        private string _KhoangCachMatDatTuNhien;
        public string KhoangCachMatDatTuNhien { get => _KhoangCachMatDatTuNhien; set { _KhoangCachMatDatTuNhien = value; OnPropertyChanged(); } }

        private string _KhoangCachTimHaiCoc;
        public string KhoangCachTimHaiCoc { get => _KhoangCachTimHaiCoc; set { _KhoangCachTimHaiCoc = value; OnPropertyChanged(); } }

        private string _HeSoNhomCocCat;
        public string HeSoNhomCocCat { get => _HeSoNhomCocCat; set { _HeSoNhomCocCat = value; OnPropertyChanged(); } }

        private string _LoaiDatNenDuoiMuiCoc;
        public string LoaiDatNenDuoiMuiCoc { get => _LoaiDatNenDuoiMuiCoc; set { _LoaiDatNenDuoiMuiCoc = value; OnPropertyChanged(); } }

        private string _HeSoNhomCocSet;
        public string HeSoNhomCocSet { get => _HeSoNhomCocSet; set { _HeSoNhomCocSet = value; OnPropertyChanged(); } }

        private string _Nmui;
        public string Nmui { get => _Nmui; set { _Nmui = value; OnPropertyChanged(); } }
        public KetQuaViewModel()
        {
            List = new ObservableCollection<DuLieu>(DataProvider.Ins.DB.DuLieux);

            
           
        }
        void LoadData()
        {
           
        }
    }
}

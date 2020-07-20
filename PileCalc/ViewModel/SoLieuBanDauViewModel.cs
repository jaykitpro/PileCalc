using PileCalc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PileCalc.ViewModel
{
    public class SoLieuBanDauViewModel : BaseViewModel
    {
        public ICommand SoLieuBanDauCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        

        private object _loaiDatNenSelectedItem;

        int loaiDatNenValue = 1;
        public object LoaiDatNenSelectedItem
        {
            get
            {
                return _loaiDatNenSelectedItem;
            }
            set
            {
                _loaiDatNenSelectedItem = value;
                var loaiDatNen = _loaiDatNenSelectedItem as ComboBoxItem;
                if (loaiDatNen.Content.ToString() == "Cát")
                {
                    loaiDatNenValue = 1;
                }
                else if (loaiDatNen.Content.ToString() == "Sét")
                {
                    loaiDatNenValue = 2;
                }
                OnPropertyChanged();
            }
        }
        private string _TenKetCau;
        public string TenKetCau { get => _TenKetCau; set { _TenKetCau = value; OnPropertyChanged(); } }

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

        private string _BeRongCoc;
        public string BeRongCoc { get => _BeRongCoc; set { _BeRongCoc = value; OnPropertyChanged(); } }

        private string _ChieuSauCocXuyen;
        public string ChieuSauCocXuyen { get => _ChieuSauCocXuyen; set { _ChieuSauCocXuyen = value; OnPropertyChanged(); } }

        private string _KhoangCachMatDatTuNhien;
        public string KhoangCachMatDatTuNhien { get => _KhoangCachMatDatTuNhien; set { _KhoangCachMatDatTuNhien = value; OnPropertyChanged(); } }

        private string _Nmui;
        public string Nmui { get => _Nmui; set { _Nmui = value; OnPropertyChanged(); } }

        private string _CaoDoMatDat;
        public string CaoDoMatDat { get => _CaoDoMatDat; set { _CaoDoMatDat = value; OnPropertyChanged(); } }

        private string _MucNuocNgam;
        public string MucNuocNgam { get => _MucNuocNgam; set { _MucNuocNgam = value; OnPropertyChanged(); } }

        private string _ChieuDaiCoc;
        public string ChieuDaiCoc { get => _ChieuDaiCoc; set { _ChieuDaiCoc = value; OnPropertyChanged(); } }
        public SoLieuBanDauViewModel()
        {
            SaveCommand = new RelayCommand<object>((p) => {
                if (string.IsNullOrEmpty(TenDuAn) ||
                string.IsNullOrEmpty(TenHangMuc) ||
                string.IsNullOrEmpty(TenKetCau) ||
                string.IsNullOrEmpty(NguoiKiemTra) ||
                string.IsNullOrEmpty(NguoiThucHien) ||
                string.IsNullOrEmpty(CNDA) ||
                string.IsNullOrEmpty(Nmui) || 
                string.IsNullOrEmpty(BeRongCoc) ||
                string.IsNullOrEmpty(KhoangCachMatDatTuNhien) ||
                string.IsNullOrEmpty(CaoDoMatDat) ||
                string.IsNullOrEmpty(MucNuocNgam) ||
                string.IsNullOrEmpty(ChieuDaiCoc))
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                #region Kiểm tra nhập số
                if (!IsNumber(BeRongCoc)) 
                { 

                    MessageBox.Show("Đường kính cọc không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if(!IsNumber(KhoangCachMatDatTuNhien))
                {
                    MessageBox.Show("Khoảng cách mặt đất tự nhiên không hợp lệ, vui lòng kiểm tra lại");
                }
                else if(!IsNumber(CaoDoMatDat))
                {
                    MessageBox.Show("Cao độ mặt đất không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if(!IsNumber(ChieuSauCocXuyen))
                {
                    MessageBox.Show("Chiều sâu cọc xuyên không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if(!IsNumber(Nmui))
                {
                    MessageBox.Show("N mũi không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if(!IsNumber(MucNuocNgam))
                {
                    MessageBox.Show("Mực nước ngầm không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if (!IsNumber(ChieuDaiCoc))
                {
                    MessageBox.Show("Chiều dài cọc không hợp lệ, vui lòng kiểm tra lại!");
                }
                #endregion
                else
                {
                    DataProvider.Ins.DB.SoLieuBanDaus.Add(new SoLieuBanDau 
                    {
                        tenHoKhoan = TenKetCau,
                        tenHangMuc = TenHangMuc,
                        tenDuAn = TenDuAn,
                        CNDA = CNDA,
                        nguoiThucHien = NguoiThucHien,
                        nguoiKiemTra = NguoiKiemTra,
                        beRongCoc = int.Parse(BeRongCoc),
                        loaiDatNen = loaiDatNenValue,
                        caoDoMatDat = float.Parse(CaoDoMatDat),
                        khoangCachMatDatTuNhien = float.Parse(KhoangCachMatDatTuNhien),
                        mucNuocNgam = float.Parse(MucNuocNgam),
                        chieuSauCocXuyen = float.Parse(ChieuSauCocXuyen),
                        Nmui = int.Parse(Nmui),
                        chieuDaiCoc = float.Parse(ChieuDaiCoc)
                       
                    });
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Thêm số liệu thành công!");
                }  
            });

            

            ClearCommand = new RelayCommand<object>((c) => { return true; }, (c) =>
            {
                ClearContentSLBD();
            });

        }

        public void ClearContentSLBD()
        {
            TenHangMuc = "";
            TenKetCau = "";
            TenDuAn = "";
            CNDA = "";
            NguoiKiemTra = "";
            NguoiThucHien = "";
            BeRongCoc = "";
            KhoangCachMatDatTuNhien = "";
            ChieuSauCocXuyen = "";
            Nmui = "";
            CaoDoMatDat = "";
            MucNuocNgam = "";
            ChieuDaiCoc = "";
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
    }
}

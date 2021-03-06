//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PileCalc.Model
{
    using PileCalc.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class DuLieu : BaseViewModel
    {
        public int soThuTu { get; set; }
        private int _tenLopDat;
        public int tenLopDat { get => _tenLopDat; set { _tenLopDat = value; OnPropertyChanged(); } }
        private double _caoDo;
        public double caoDo { get => _caoDo; set { _caoDo = value; OnPropertyChanged(); } }
        private double _chieuDay;
        public double chieuDay { get => _chieuDay; set { _chieuDay = value; OnPropertyChanged(); } }
        private double _chieuSau;
        public double chieuSau { get => _chieuSau; set { _chieuSau = value; OnPropertyChanged(); } }
        private int _loaiDat;
        public int loaiDat { get => _loaiDat; set { _loaiDat = value; OnPropertyChanged(); } }
        private int _N;
        public int N { get => _N; set { _N = value; OnPropertyChanged(); } }
        private Nullable<double> _ybh1;
        public Nullable<double> ybh1 { get => _ybh1; set { _ybh1 = value; OnPropertyChanged(); } }
        private Nullable<double> _li;
        public Nullable<double> li { get => _li; set { _li = value; OnPropertyChanged(); } }

        private Nullable<double> _hi;
        public Nullable<double> hi { get => _hi; set { _hi = value; OnPropertyChanged(); } }
        private Nullable<double> _Su_mui;
        public Nullable<double> Su_mui { get => _Su_mui; set { _Su_mui = value; OnPropertyChanged(); } }
        private Nullable<double> _Db;
        public Nullable<double> Db { get => _Db; set { _Db = value; OnPropertyChanged(); } }
        private Nullable<double> _Sui;
        public Nullable<double> Sui { get => _Sui; set { _Sui = value; OnPropertyChanged(); } }
        public Nullable<double> ai { get; set; }
        public Nullable<double> ov { get; set; }
        public Nullable<double> Asi { get; set; }
        public Nullable<double> CN { get; set; }
        public Nullable<double> qp { get; set; }
        public Nullable<double> ql { get; set; }
        public Nullable<double> qsi { get; set; }
        public Nullable<double> Ap { get; set; }
        public Nullable<double> N1_60 { get; set; }
        public Nullable<double> N1_60mui { get; set; }
        public Nullable<double> C_Qp { get; set; }
        public Nullable<double> phiqpQp { get; set; }
        public Nullable<double> SumphiqsQsi { get; set; }
        public Nullable<double> C_Qsi { get; set; }
        public Nullable<double> phiqsQsi { get; set; }
        public Nullable<double> QR { get; set; }
        public string tenHoKhoan { get; set; }
        public Nullable<double> temp_Sumov { get; set; }
    
        public virtual SoLieuBanDau SoLieuBanDau { get; set; }
    }
}

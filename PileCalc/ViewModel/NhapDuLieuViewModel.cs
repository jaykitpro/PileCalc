using PileCalc.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PileCalc.ViewModel
{

    public class NhapDuLieuViewModel : BaseViewModel
    {

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand FinishCommand { get; set; }

        private ObservableCollection<DuLieu> _List;
        public ObservableCollection<DuLieu> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private DuLieu _SelectedItem;
        public DuLieu SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();

                if (SelectedItem != null)
                {
                    tenLopDat = SelectedItem.tenLopDat.ToString();
                    caoDo = SelectedItem.caoDo.ToString();
                    chieuDay = SelectedItem.chieuDay.ToString();
                    chieuSau = SelectedItem.chieuSau.ToString();
                    loaiDat = SelectedItem.loaiDat.ToString();
                    N = SelectedItem.N.ToString();
                    ybh1 = SelectedItem.ybh1.ToString();
                    hi = SelectedItem.hi.ToString();
                    li = SelectedItem.hi.ToString();
                    Su_mui = SelectedItem.Su_mui.ToString();
                    Sui = SelectedItem.Sui.ToString();
                    Db = SelectedItem.Db.ToString();
                }
            }
        }

        #region Khai báo
        private string _tenLopDat;
        public string tenLopDat { get => _tenLopDat; set { _tenLopDat = value; OnPropertyChanged(); } }

        private string _caoDo;
        public string caoDo { get => _caoDo; set { _caoDo = value; OnPropertyChanged(); } }

        private string _chieuDay;
        public string chieuDay { get => _chieuDay; set { _chieuDay = value; OnPropertyChanged(); } }

        private string _chieuSau;
        public string chieuSau { get => _chieuSau; set { _chieuSau = value; OnPropertyChanged(); } }

        private string _loaiDat;
        
        public string loaiDat { get => _loaiDat; set { _loaiDat= value; OnPropertyChanged(); } }

        private string _N;
        public string N { get => _N; set { _N = value; OnPropertyChanged(); } }

        private string _ybh1;
        public string ybh1 { get => _ybh1; set { _ybh1 = value; OnPropertyChanged(); } }

        private string _hi;
        public string hi { get => _hi; set { _hi = value; OnPropertyChanged(); } }

        private string _li;
        public string li { get => _li; set { _li = value; OnPropertyChanged(); } }

        private string _Su_mui;
        public string Su_mui { get => _Su_mui; set { _Su_mui = value; OnPropertyChanged(); } }  

        private string _Sui;
        public string Sui { get => _Sui; set { _Sui = value; OnPropertyChanged(); } }

        private string _Db;
        public string Db { get => _Db; set { _Db = value; OnPropertyChanged(); } }

       
        #endregion

        public NhapDuLieuViewModel()
        {
            int count = 1;

            var data = new PileCalcPlusEntities();

            List = new ObservableCollection<DuLieu>(data.DuLieux);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(tenLopDat) ||
                    string.IsNullOrEmpty(caoDo) ||
                    string.IsNullOrEmpty(chieuDay) ||
                    string.IsNullOrEmpty(chieuSau) ||
                    string.IsNullOrEmpty(loaiDat) || 
                    string.IsNullOrEmpty(N) ||
                    string.IsNullOrEmpty(ybh1) ||
                    string.IsNullOrEmpty(hi) ||
                    string.IsNullOrEmpty(Su_mui) || 
                    string.IsNullOrEmpty(li) ||
                    string.IsNullOrEmpty(Sui) ||
                    string.IsNullOrEmpty(Db)
                )
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                #region Kiểm tra nhập số
                if (!IsNumber(tenLopDat))
                {
                    MessageBox.Show("Tên lớp đất phải là số nguyên, vui lòng kiểm tra lại!");
                }
                else if (!IsNumber(caoDo))
                {
                    MessageBox.Show("Cao độ không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if (!IsNumber(chieuDay))
                {
                    MessageBox.Show("Chiều dày lớp đất không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if (!IsNumber(chieuSau))
                {
                    MessageBox.Show("Chiều sâu không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if (!IsNumber(N))
                {
                    MessageBox.Show("N không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if (!IsNumber(loaiDat) || int.Parse(loaiDat.ToString()) > 2 || int.Parse(loaiDat.ToString()) < 1)
                {
                    MessageBox.Show("Loại đất không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if (!IsNumber(ybh1))
                {
                    MessageBox.Show("Gamma bão hòa không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (!IsNumber(hi))
                {
                    MessageBox.Show("hi không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if(!IsNumber(Su_mui))
                {
                    MessageBox.Show("Su mũi không hợp lệ, vui lòng kiểm tra lại!");
                }

                else if(!IsNumber(li))
                {
                    MessageBox.Show("li mũi không hợp lệ, vui lòng kiểm tra lại!");
                }
 
                else if(!IsNumber(Sui))
                {
                    MessageBox.Show("Sui không hợp lệ, vui lòng kiểm tra lại!");
                }
                else if(!IsNumber(Db))
                {
                    MessageBox.Show("Db không hợp lệ, vui lòng kiểm tra lại!");
                }
                //

                #endregion
                else
                {
                    var dulieu = new DuLieu()
                    {

                        soThuTu = count,
                        tenLopDat = int.Parse(tenLopDat.ToString()),
                        caoDo = float.Parse(caoDo.ToString()),
                        chieuDay = float.Parse(chieuDay.ToString()),
                        chieuSau = float.Parse(chieuSau.ToString()),
                        loaiDat = int.Parse(loaiDat.ToString()),
                        N = int.Parse(N.ToString()),
                        ybh1 = float.Parse(ybh1.ToString()),
                        li = float.Parse(li.ToString()),
                        hi = float.Parse(hi.ToString()),
                        Su_mui = Math.Round(float.Parse(Su_mui.ToString()), 3),
                        Sui = Math.Round(float.Parse(Sui.ToString()), 3),
                        Db = float.Parse(Db.ToString())
                        
                       
                    };
                    DataProvider.Ins.DB.DuLieux.Add(dulieu);
                    count++;
                    DataProvider.Ins.DB.SaveChanges();
                    ClearContentNDL();
                    List.Add(dulieu);
                }
                

            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                //Get Primary Key of Selected Item;
                var displayList = DataProvider.Ins.DB.DuLieux.Where(x => x.soThuTu == SelectedItem.soThuTu);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            },
            (p) =>
            {
                var Dulieu = DataProvider.Ins.DB.DuLieux.Where(x => x.soThuTu == SelectedItem.soThuTu).SingleOrDefault();

                Dulieu.tenLopDat = int.Parse(tenLopDat.ToString());
                Dulieu.caoDo = float.Parse(caoDo.ToString());
                Dulieu.chieuDay = float.Parse(chieuDay.ToString());
                Dulieu.chieuSau = float.Parse(chieuSau.ToString());
                Dulieu.loaiDat = int.Parse(loaiDat.ToString());
                Dulieu.N = int.Parse(N.ToString());
                Dulieu.ybh1 = float.Parse(ybh1.ToString());
                Dulieu.hi = Math.Round(float.Parse(hi.ToString()), 2);
                Dulieu.Su_mui = Math.Round(float.Parse(Su_mui.ToString()), 2);
                Dulieu.li = Math.Round(float.Parse(li.ToString()), 2);
                Dulieu.Sui = Math.Round(float.Parse(Sui.ToString()), 2);
                Dulieu.Db = float.Parse(Db.ToString());
                

                DataProvider.Ins.DB.SaveChanges();
            });

            ClearCommand = new RelayCommand<object>((c) =>
            {
                return true;
            }, (c) =>
            {
                ClearContentNDL();
            });

            DeleteCommand = new RelayCommand<object>((d) => {
                if (SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.DuLieux.Where(x => x.soThuTu == SelectedItem.soThuTu);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;
            },
                (d) =>
                {

                    var selectedList = DataProvider.Ins.DB.DuLieux.Where(x => x.soThuTu == SelectedItem.soThuTu).SingleOrDefault();
                    DataProvider.Ins.DB.DuLieux.Remove(selectedList);
                    DataProvider.Ins.DB.SaveChanges();

                    List.Remove(selectedList);
                    ClearContentNDL();

                });

            FinishCommand = new RelayCommand<object>((f) => { return true; },
                (f) =>
                {
                    Calc();                           
                    MessageBox.Show("Tính toán kết quả thành công!");

                });
        }
        public void ClearContentNDL()
        {
            tenLopDat = "";
            caoDo = "";
            chieuSau = "";
            chieuDay = "";
            N = "";
            ybh1 = "";
            loaiDat = "";
            hi = "";
            Su_mui = "";
            li = "";
            Sui = "";
            Db = "";            
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        private void Calc()
        {
            #region Công sức tính sức chịu tải cọc đơn
            //Xử lý số liệu diện tích mũi cọc
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE SoLieuBanDau SET dienTichMuiCoc = beRongCoc * beRongCoc");

            //Xử lý số liệu Ap
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET Ap = (SELECT dienTichMuiCoc FROM SoLieuBanDau)");

            

            //Xử lý số liệu o'v
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET temp_Sumov = (9.81 * (ybh1 - 1000) * hi/2 * 1000 * 0.000000001) WHERE loaiDat = 1");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET temp_Sumov = (9.81 * (ybh1 - 1000) * hi * 1000 * 0.000000001) WHERE loaiDat = 2");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("EXEC Sumov");

            //Xử lý số liệu Cn
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET CN = 0.77 * LOG10(1.92 / ov)");

            //Xử lý số liệu N1_60 mũi
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET N1_60mui = CN * (SELECT Nmui FROM SoLieuBanDau)");

            //Xử lý số liệu ql
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET ql = 0.4 * N1_60mui");

            //Xử lý số liệu qp
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET qp = (9 * Su_mui) WHERE loaiDat = 2");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET qp = ((0.038 * N1_60mui * Db * 1000) / (SELECT beRongCoc FROM SoLieuBanDau)) WHERE loaiDat = 1 ");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET qp = ql WHERE qp > ql AND loaiDat = 1 ");

            //Xử lý số liệu Qp
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET _Qp = qp * Ap");

            //Xử lý số liệu alpha theo Sui
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET ai = 1 WHERE Sui < 0.025");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET ai = 1 - 0.5 * ((Sui - 0.025)/0.05) WHERE Sui > 0.025 AND Sui < 0.075");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET ai = 0.5 WHERE Sui > 0.075");

            //Xử lý N ()
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET N1_60 = CN * N");

            //Xử lý số liệu qsi
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET qsi = 0.0019 * N1_60 WHERE loaiDat = 1");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET qsi = ai * Sui WHERE loaiDat = 2");

            //Xử lý số liệu Asi
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET Asi = 4 * (SELECT beRongCoc FROM SoLieuBanDau) * li * 1000");

            //Xử lý số liệu Qsi
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET _Qsi = qsi * Asi");

            //Xử lý số liệu phiqsQsi và tổng phiqsQsi
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET phiqsQsi = 0.3 * _Qsi WHERE loaiDat = 1");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET phiqsQsi = 0.35 * _Qsi WHERE loaiDat = 2");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("EXECUTE SumphiqsQsi");

            //Xử lý số liệu phiqpQp
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET phiqpQp = 0.3 * _Qp WHERE loaiDat = 1");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET phiqpQp = 0.35 * _Qp WHERE loaiDat = 2");

            //Xử lý số liệu QR của cọc đơn
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE Dulieu SET QR = phiqpQp + SumphiqsQsi");
            #endregion


            #region Xử lý làm tròn số
            //Round number
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET Sui = ROUND(Sui, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET ai = ROUND(ai, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET temp_Sumov = ROUND(temp_Sumov, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET ov = ROUND(ov, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET Asi = ROUND(Asi, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET CN = ROUND(CN, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET qp = ROUND(qp, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET ql = ROUND(ql, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET qsi = ROUND(qsi, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET Ap = ROUND(Ap, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET N1_60 = ROUND(N1_60, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET N1_60mui = ROUND(N1_60mui, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET _Qp = ROUND(_Qp, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET _Qsi = ROUND(_Qsi, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET phiqpQp = ROUND(phiqpQp, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET phiqsQsi = ROUND(phiqsQsi, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET SumphiqsQsi = ROUND(SumphiqsQsi, 3)");
            DataProvider.Ins.DB.Database.ExecuteSqlCommand("UPDATE DuLieu SET QR = ROUND(QR, 3)");
            #endregion
        }
    }
}

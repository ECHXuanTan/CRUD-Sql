using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_SQL
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
            serverChoose.DataSource = new List<String> 
            { 
                "KhachHang", 
                "NhaXuatBan" 
            };
        }
        public List<String> KhachHangServers = new List<String> 
        { 
            @"localhost\KH_MIENBAC", 
            @"localhost\KH_MIENTRUNG", 
            @"localhost\KH_MIENNAM" 
        };
        public List<String> NhaXuatBanServers = new List<String> 
        { 
            @"localhost\NXB_1_3",
            @"localhost\NXB_4" 
        };
        public List<String> KhachHangTables = new List<String> 
        { 
            "KhachHang",
            "QuanLy", 
            "DonHang", 
            "ChiTietDonHang", 
            "DanhGiaSach", 
            "GioHang", 
            "PhieuXuat", 
            "ChiTietPhieuXuat" 
        };
        public List<String> NhaXuatBanTables = new List<String>
        {
            "NhaXuatBan",
            "Sach",
            "TacGia",
            "TheLoaiSach",
            "NgonNgu",
            "NhaCungCap",
            "PhieuNhap",
            "ChiTietPhieuNhap"
        };

        private void serverChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverChoose.Text == "KhachHang")
            {
                dbChoose.DataSource = KhachHangServers;
                tableChoose.DataSource = KhachHangTables;
            }
            else if (serverChoose.Text == "NhaXuatBan")
            {
                dbChoose.DataSource = NhaXuatBanServers;
                tableChoose.DataSource = NhaXuatBanTables;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            String connString = String.Format("data source={0};initial catalog=Nhom_Solo;persist security info=True;user id=sa;password=tanda;connect timeout = 5", dbChoose.Text);

            if (serverChoose.Text == "KhachHang")
            {
                var db = new KhachHangClassDataContext(connString);
                switch (tableChoose.Text)
                {
                    case "KhachHang":
                        dataGridView1.DataSource = db.KhachHangs;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "QuanLy":
                        dataGridView1.DataSource = db.QuanLies;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "DonHang":
                        dataGridView1.DataSource = db.DonHangs;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        dataGridView1.Columns["KhachHang"].Visible = false;
                        break;
                    case "ChiTietDonHang":
                        dataGridView1.DataSource = db.ChiTietDonHangs;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        dataGridView1.Columns["DonHang"].Visible = false;
                        break;
                    case "DanhGiaSach":
                        dataGridView1.DataSource = db.DanhGiaSaches;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        dataGridView1.Columns["KhachHang"].Visible = false;
                        break;
                    case "GioHang":
                        dataGridView1.DataSource = db.GioHangs;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        dataGridView1.Columns["KhachHang"].Visible = false;
                        break;
                    case "PhieuXuat":
                        dataGridView1.DataSource = db.PhieuXuats;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        dataGridView1.Columns["DonHang"].Visible = false;
                        break;
                    case "ChiTietPhieuXuat":
                        dataGridView1.DataSource = db.PhieuXuats;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        dataGridView1.Columns["DonHang"].Visible = false;

                        break;
                    default:
                        break;
                }

            }
            else if (serverChoose.Text == "NhaXuatBan")
            {
                var db = new NhaXuatBanClassDataContext(connString);
                switch (tableChoose.Text)
                {
                    case "NhaXuatBan":
                        dataGridView1.DataSource = db.NhaXuatBans;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "Sach":
                        dataGridView1.DataSource = db.Saches;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        dataGridView1.Columns["NhaXuatBan"].Visible = false;
                        dataGridView1.Columns["TacGia"].Visible = false;
                        dataGridView1.Columns["TheLoaiSach"].Visible = false;
                        break;
                    case "TheLoaiSach":
                        dataGridView1.DataSource = db.TheLoaiSaches;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "TacGia":
                        dataGridView1.DataSource = db.TacGias;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "ChiTietPhieuNhap":
                        dataGridView1.DataSource = db.ChiTietPhieuNhaps;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "NgonNgu":
                        dataGridView1.DataSource = db.NgonNgus;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "NhaCungCap":
                        dataGridView1.DataSource = db.NhaCungCaps;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    case "PhieuNhap":
                        dataGridView1.DataSource = db.PhieuNhaps;
                        dataGridView1.Columns["rowguid"].Visible = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            String connString = String.Format("data source={0};initial catalog=Nhom_Solo;persist security info=True;user id=sa;password=tanda;connect timeout = 5", dbChoose.Text);

            if (textboxRead.Text.Trim() != "")
            {
                if (serverChoose.Text == "KhachHang")
                {
                    var db = new KhachHangClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "KhachHang":
                            dataGridView1.DataSource = db.KhachHangs.Where(p => p.KH_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "QuanLy":
                            dataGridView1.DataSource = db.QuanLies.Where(p => p.QL_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "DonHang":
                            dataGridView1.DataSource = db.DonHangs.Where(p => p.DH_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            dataGridView1.Columns["KhachHang"].Visible = false;
                            break;
                        case "ChiTietDonHang":
                            dataGridView1.DataSource = db.ChiTietDonHangs.Where(p => p.CTDH_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            dataGridView1.Columns["DonHang"].Visible = false;
                            break;
                        case "DanhGiaSach":
                            dataGridView1.DataSource = db.DanhGiaSaches.Where(p => p.DGS_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "GioHang":
                            dataGridView1.DataSource = db.GioHangs.Where(p => p.GH_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "PhieuXuat":
                            dataGridView1.DataSource = db.PhieuXuats.Where(p => p.PX_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "ChiTietPhieuXuat":
                            dataGridView1.DataSource = db.ChiTietPhieuXuats.Where(p => p.CTPX_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        default:
                            break;
                    }

                }
                else if (serverChoose.Text == "NhaXuatBan")
                {
                    var db = new NhaXuatBanClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "NhaXuatBan":
                            dataGridView1.DataSource = db.NhaXuatBans.Where(p => p.NXB_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "Sach":
                            dataGridView1.DataSource = db.Saches.Where(p => p.S_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            dataGridView1.Columns["NhaXuatBan"].Visible = false;
                            dataGridView1.Columns["TacGia"].Visible = false;
                            dataGridView1.Columns["TheLoaiSach"].Visible = false;
                            break;
                        case "TheLoaiSach":
                            dataGridView1.DataSource = db.TheLoaiSaches.Where(p => p.TL_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "TacGia":
                            dataGridView1.DataSource = db.TacGias.Where(p => p.TG_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "ChiTietPhieuNhap":
                            dataGridView1.DataSource = db.ChiTietPhieuNhaps.Where(p => p.CTPN_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "NgonNgu":
                            dataGridView1.DataSource = db.NgonNgus.Where(p => p.NN_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "NhaCungCap":
                            dataGridView1.DataSource = db.NhaCungCaps.Where(p => p.NCC_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        case "PhieuNhap":
                            dataGridView1.DataSource = db.PhieuNhaps.Where(p => p.PN_ID.Equals(textboxRead.Text));
                            dataGridView1.Columns["rowguid"].Visible = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            else btnLoad_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String connString = String.Format("data source={0};initial catalog=Nhom_Solo;persist security info=True;user id=sa;password=tanda;connect timeout = 5", dbChoose.Text);

            if (dataGridView1.DataSource != null)
            {
                var ID = dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value;
                if (serverChoose.Text == "KhachHang")
                {
                    var db = new KhachHangClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "KhachHang":
                            var KH = db.KhachHangs.Where(p => p.KH_ID.Equals(ID)).FirstOrDefault();
                            db.KhachHangs.DeleteOnSubmit(KH);
                            break;
                        case "QuanLy":
                            var QL = db.QuanLies.Where(p => p.QL_ID.Equals(ID)).FirstOrDefault();
                            db.QuanLies.DeleteOnSubmit(QL);
                            break;
                        case "DonHang":
                            var DH = db.DonHangs.Where(p => p.DH_KhachHangId.Equals(ID)).FirstOrDefault();
                            db.DonHangs.DeleteOnSubmit(DH);
                            break;
                        case "ChiTietDonHang":
                            var CTDH = db.ChiTietDonHangs.Where(p => p.CTDH_DonHangID.Equals(ID)).FirstOrDefault();
                            db.ChiTietDonHangs.DeleteOnSubmit(CTDH);
                            break;
                        case "DanhGiaSach":
                            var DGS = db.DanhGiaSaches.Where(p => p.DGS_ID.Equals(ID)).FirstOrDefault();
                            db.DanhGiaSaches.DeleteOnSubmit(DGS);
                            break;
                        case "GioHang":
                            var GH = db.GioHangs.Where(p => p.GH_ID.Equals(ID)).FirstOrDefault();
                            db.GioHangs.DeleteOnSubmit(GH);
                            break;
                        case "PhieuXuat":
                            var PX = db.PhieuXuats.Where(p => p.PX_ID.Equals(ID)).FirstOrDefault();
                            db.PhieuXuats.DeleteOnSubmit(PX);
                            break;
                        case "ChiTietPhieuXuat":
                            var CTPX = db.ChiTietPhieuXuats.Where(p => p.CTPX_ID.Equals(ID)).FirstOrDefault();
                            db.ChiTietPhieuXuats.DeleteOnSubmit(CTPX);
                            break;
                        default:
                            break;
                    }
                    db.SubmitChanges();

                }
                else if (serverChoose.Text == "NhaXuatBan")
                {
                    var db = new NhaXuatBanClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "NhaXuatBan":
                            var NXB = db.NhaXuatBans.Where(p => p.NXB_ID.Equals(ID)).FirstOrDefault();
                            db.NhaXuatBans.DeleteOnSubmit(NXB);
                            break;
                        case "Sach":
                            var Sach = db.Saches.Where(p => p.S_ID.Equals(ID)).FirstOrDefault();
                            db.Saches.DeleteOnSubmit(Sach);
                            break;
                        case "TheLoaiSach":
                            var TLS = db.TheLoaiSaches.Where(p => p.TL_ID.Equals(ID)).FirstOrDefault();
                            db.TheLoaiSaches.DeleteOnSubmit(TLS);
                            break;
                        case "TacGia":
                            var TG = db.TacGias.Where(p => p.TG_ID.Equals(ID)).FirstOrDefault();
                            db.TacGias.DeleteOnSubmit(TG);
                            break;
                        case "ChiTietPhieuNhap":
                            var CTPN = db.ChiTietPhieuNhaps.Where(p => p.CTPN_ID.Equals(ID)).FirstOrDefault();
                            db.ChiTietPhieuNhaps.DeleteOnSubmit(CTPN);
                            break;
                        case "NgonNgu":
                            var NN = db.NgonNgus.Where(p => p.NN_ID.Equals(ID)).FirstOrDefault();
                            db.NgonNgus.DeleteOnSubmit(NN);
                            break;
                        case "NhaCungCap":
                            var NCC = db.NhaCungCaps.Where(p => p.NCC_ID.Equals(ID)).FirstOrDefault();
                            db.NhaCungCaps.DeleteOnSubmit(NCC);
                            break;
                        case "PhieuNhap":
                            var PN = db.PhieuNhaps.Where(p => p.PN_ID.Equals(ID)).FirstOrDefault();
                            db.PhieuNhaps.DeleteOnSubmit(PN);
                            break;
                        default:
                            break;
                    }
                    db.SubmitChanges();
                }
                btnLoad_Click(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String connString = String.Format("data source={0};initial catalog=Nhom_Solo;persist security info=True;user id=sa;password=tanda;connect timeout = 5", dbChoose.Text);
            if (dataGridView1.DataSource != null)
            {
                var rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
                var ID = dataGridView1.Rows[rowIndex].Cells[0].Value;
                if (serverChoose.Text == "KhachHang")
                {
                    var db = new KhachHangClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "KhachHang":
                            var KH = db.KhachHangs.Where(p => p.KH_ID.Equals(ID)).FirstOrDefault();
                            {
                                KH.KH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["KH_ID"].Value;
                                KH.KH_TenTruyCap = dataGridView1.Rows[rowIndex].Cells["KH_TenTruyCap"].Value.ToString();
                                KH.KH_MatKhau = dataGridView1.Rows[rowIndex].Cells["KH_MatKhau"].Value.ToString();
                                KH.KH_HoTen = dataGridView1.Rows[rowIndex].Cells["KH_HoTen"].Value.ToString();
                                KH.KH_Email = dataGridView1.Rows[rowIndex].Cells["KH_Email"].Value.ToString();
                                KH.KH_NgayBatDau = (DateTime)dataGridView1.Rows[rowIndex].Cells["KH_NgayBatDau"].Value;
                                KH.KH_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["KH_TrangThai"].Value;
                                KH.KH_DienThoai = dataGridView1.Rows[rowIndex].Cells["KH_DienThoai"].Value.ToString();
                                KH.KH_DiaChi = dataGridView1.Rows[rowIndex].Cells["KH_DiaChi"].Value.ToString();
                                KH.KH_KhuVuc = dataGridView1.Rows[rowIndex].Cells["KH_KhuVuc"].Value.ToString();
                            }
                            break;
                        case "QuanLy":
                            var QL = db.QuanLies.Where(p => p.QL_ID.Equals(ID)).FirstOrDefault();
                            {
                                QL.QL_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["QL_ID"].Value;
                                QL.QL_TenTruyCap = dataGridView1.Rows[rowIndex].Cells["QL_TenTruyCap"].Value.ToString();
                                QL.QL_Email = dataGridView1.Rows[rowIndex].Cells["QL_Email"].Value.ToString();
                                QL.QL_MatKhau = dataGridView1.Rows[rowIndex].Cells["QL_MatKhau"].Value.ToString();
                                QL.QL_Hoten = dataGridView1.Rows[rowIndex].Cells["QL_HoTen"].Value.ToString();
                                QL.QL_CCCD =  dataGridView1.Rows[rowIndex].Cells["QL_CCCD"].Value.ToString();
                                QL.QL_NgaySinh = (DateTime)dataGridView1.Rows[rowIndex].Cells["QL_NgaySinh"].Value;
                                QL.QL_GioiTinh = (Int32)dataGridView1.Rows[rowIndex].Cells["QL_GioiTinh"].Value;
                                QL.QL_DiaChi = dataGridView1.Rows[rowIndex].Cells["QL_DiaChi"].Value.ToString();
                                QL.QL_DienThoai = dataGridView1.Rows[rowIndex].Cells["QL_DienThoai"].Value.ToString();
                                QL.QL_Quyen = (Byte)dataGridView1.Rows[rowIndex].Cells["QL_Quyen"].Value;
                                QL.QL_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["QL_Quyen"].Value;
                                QL.QL_KhuVuc = dataGridView1.Rows[rowIndex].Cells["QL_KhuVuc"].Value.ToString();
                            }
                            break;
                        case "DonHang":
                            var DH = db.DonHangs.Where(p => p.DH_KhachHangId.Equals(ID)).FirstOrDefault();
                            {
                                DH.DH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["DH_ID"].Value;
                                DH.DH_KhachHangId = (Int32)dataGridView1.Rows[rowIndex].Cells["DH_KhachHangId"].Value;
                                DH.DH_Ngay = (DateTime)dataGridView1.Rows[rowIndex].Cells["DH_Ngay"].Value;
                                DH.DH_ThanhTien = (Decimal)   dataGridView1.Rows[rowIndex].Cells["DH_ThanhTien"].Value;
                                DH.DH_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["DH_TrangThai"].Value;
                            }
                            break;
                        case "ChiTietDonHang":
                            var CTDH = db.ChiTietDonHangs.Where(p => p.CTDH_DonHangID.Equals(ID)).FirstOrDefault();
                            {
                                CTDH.CTDH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_ID"].Value;
                                CTDH.CTDH_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_SachID"].Value;
                                CTDH.CTDH_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_SoLuong"].Value;
                                CTDH.CTDH_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["CTDH_ID"].Value;
                                CTDH.CTDH_DonHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_DonHangID"].Value;
                            }
                            break;
                        case "DanhGiaSach":
                            var DGS = db.DanhGiaSaches.Where(p => p.DGS_ID.Equals(ID)).FirstOrDefault();
                            {
                                DGS.DGS_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["DGS_ID"].Value;
                                DGS.DGS_KhachHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["DGS_KhachHangID"].Value;
                                DGS.DGS_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["DGS_SachID"].Value;
                                DGS.DSG_NoiDung = dataGridView1.Rows[rowIndex].Cells["DSG_NoiDung"].Value.ToString();
                            }
                            break;
                        case "GioHang":
                            var GH = db.GioHangs.Where(p => p.GH_ID.Equals(ID)).FirstOrDefault();
                            {
                                GH.GH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_ID"].Value;
                                GH.GH_KhachHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_KhachHangID"].Value;
                                GH.GH_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_SachID"].Value;
                                GH.GH_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_SoLuong"].Value;
                                GH.GH_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["GH_ThanhTien"].Value;
                            }
                            break;
                        case "PhieuXuat":
                            var PX = db.PhieuXuats.Where(p => p.PX_ID.Equals(ID)).FirstOrDefault();
                            {
                                PX.PX_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["PX_ID"].Value;
                                PX.PX_NgayXuat = (DateTime)dataGridView1.Rows[rowIndex].Cells["PX_NgayXuat"].Value;
                                PX.PX_DonHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["PX_DonHangID"].Value;
                            }
                            break;
                        case "ChiTietPhieuXuat":
                            var CTPX = db.ChiTietPhieuXuats.Where(p => p.CTPX_ID.Equals(ID)).FirstOrDefault();
                            {
                                CTPX.CTPX_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_ID"].Value;
                                CTPX.CTPX_PhieuXuatID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_PhieuXuatID"].Value;
                                CTPX.CTPX_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_SachID"].Value;
                                CTPX.CTPX_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_SoLuong"].Value;
                                CTPX.CTPX_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["CTPX_ThanhTien"].Value;
                            }
                            break;
                        default:
                            break;
                    }
                    db.SubmitChanges();

                }
                else if (serverChoose.Text == "NhaXuatBan")
                {
                    var db = new NhaXuatBanClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "NhaXuatBan":
                            var NXB = db.NhaXuatBans.Where(p => p.NXB_ID.Equals(ID)).FirstOrDefault();
                            {
                                NXB.NXB_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["NXB_ID"].Value;
                                NXB.NXB_Ten = dataGridView1.Rows[rowIndex].Cells["NXB_Ten"].Value.ToString();
                            }
                            break;
                        case "Sach":
                            var Sach = db.Saches.Where(p => p.S_ID.Equals(ID)).FirstOrDefault();
                            {
                                Sach.S_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_ID"].Value;
                                Sach.S_TheLoaiID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_TheLoaiID"].Value;
                                Sach.S_Ten = dataGridView1.Rows[rowIndex].Cells["S_Ten"].Value.ToString();
                                Sach.S_Mota = dataGridView1.Rows[rowIndex].Cells["S_Mota"].Value.ToString();
                                Sach.S_TuKhoa = dataGridView1.Rows[rowIndex].Cells["S_TuKhoa"].Value.ToString();
                                Sach.S_GiaBan = (Decimal)dataGridView1.Rows[rowIndex].Cells["S_GiaBan"].Value;
                                Sach.S_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["S_TrangThai"].Value;
                                Sach.S_SoLanXem = (Int32)dataGridView1.Rows[rowIndex].Cells["S_SoLanXem"].Value;
                                Sach.S_KhoSach = dataGridView1.Rows[rowIndex].Cells["S_KhoSach"].Value.ToString();
                                Sach.S_NXBID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NXBID"].Value;
                                Sach.S_NamXuatBan = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NamXuatBan"].Value;
                                Sach.S_GiaNhap = (Decimal)dataGridView1.Rows[rowIndex].Cells["S_GiaNhap"].Value;
                                Sach.S_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["S_SoLuong"].Value;
                                Sach.S_SoTrang = (Int32)dataGridView1.Rows[rowIndex].Cells["S_SoTrang"].Value;
                                Sach.S_TacGiaId = (Int32)dataGridView1.Rows[rowIndex].Cells["S_TacGiaId"].Value;
                                Sach.S_TrongLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["S_TrongLuong"].Value;
                                Sach.S_NgonNguID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NgonNguID"].Value;
                                Sach.S_NhaCungCapID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NhaCungCapID"].Value;
                            }
                            break;
                        case "TheLoaiSach":
                            var TLS = db.TheLoaiSaches.Where(p => p.TL_ID.Equals(textboxRead.Text)).FirstOrDefault();
                            {
                                TLS.TL_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["TL_ID"].Value;
                                TLS.TL_Ten = dataGridView1.Rows[rowIndex].Cells["TL_Ten"].Value.ToString();
                                TLS.TL_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["TL_TrangThai"].Value;
                            }
                            break;
                        case "TacGia":
                            var TG = db.TacGias.Where(p => p.TG_ID.Equals(ID)).FirstOrDefault();
                            {
                                TG.TG_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["TG_ID"].Value;
                                TG.TG_HoTen = dataGridView1.Rows[rowIndex].Cells["TG_HoTen"].Value.ToString();
                                TG.TG_NgaySinh = (DateTime)dataGridView1.Rows[rowIndex].Cells["TG_NgaySinh"].Value;
                                TG.TG_QuocTich = dataGridView1.Rows[rowIndex].Cells["TG_QuocTich"].Value.ToString();
                            }
                            break;
                        case "ChiTietPhieuNhap":
                            var CTPN = db.ChiTietPhieuNhaps.Where(p => p.CTPN_ID.Equals(ID)).FirstOrDefault();
                            {
                                CTPN.CTPN_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_ID"].Value;
                                CTPN.CTPN_PhieuNhapID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_PhieuNhapID"].Value;
                                CTPN.CTPN_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_SachID"].Value;
                                CTPN.CTPN_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_SoLuong"].Value;
                                CTPN.CTPN_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["CTPN_ThanhTien"].Value;
                            }
                            break;
                        case "NgonNgu":
                            var NN = db.NgonNgus.Where(p => p.NN_ID.Equals(ID)).FirstOrDefault();
                            {
                                NN.NN_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["NN_ID"].Value;
                                NN.NN_Ten = dataGridView1.Rows[rowIndex].Cells["NN_Ten"].Value.ToString();
                            }
                            break;
                        case "NhaCungCap":
                            var NCC = db.NhaCungCaps.Where(p => p.NCC_ID.Equals(ID)).FirstOrDefault();
                            {
                                NCC.NCC_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["NCC_ID"].Value;
                                NCC.NCC_Ten = dataGridView1.Rows[rowIndex].Cells["NCC_Ten"].Value.ToString();
                                NCC.NCC_DiaChi = dataGridView1.Rows[rowIndex].Cells["NCC_DiaChi"].Value.ToString();
                                NCC.NCC_DienThoai = dataGridView1.Rows[rowIndex].Cells["NCC_DienThoai"].Value.ToString();
                                NCC.NCC_Email = dataGridView1.Rows[rowIndex].Cells["NCC_Email"].Value.ToString();
                            }
                            break;
                        case "PhieuNhap":
                            var PN = db.PhieuNhaps.Where(p=>p.PN_ID.Equals(ID)).FirstOrDefault();
                            {
                                PN.PN_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["PN_ID"].Value;
                                PN.PN_NgayNhap = (DateTime)dataGridView1.Rows[rowIndex].Cells["PN_NgayNhap"].Value;
                                PN.PN_NhaCungCapID = (Int32)dataGridView1.Rows[rowIndex].Cells["PN_NhaCungCapID"].Value;
                            }
                            break;
                        default:
                            break;
                    }
                    db.SubmitChanges();
                }
            }
            btnLoad_Click(sender, e);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            String connString = String.Format("data source={0};initial catalog=Nhom_Solo;persist security info=True;user id=sa;password=tanda;connect timeout = 5", dbChoose.Text);
            if (dataGridView1.DataSource != null)
            {
                var rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
                if (serverChoose.Text == "KhachHang")
                {
                    var db = new KhachHangClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "KhachHang":
                            var KH = new KhachHang();
                            {
                                KH.KH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["KH_ID"].Value;
                                KH.KH_TenTruyCap = dataGridView1.Rows[rowIndex].Cells["KH_TenTruyCap"].Value.ToString();
                                KH.KH_MatKhau = dataGridView1.Rows[rowIndex].Cells["KH_MatKhau"].Value.ToString();
                                KH.KH_HoTen = dataGridView1.Rows[rowIndex].Cells["KH_HoTen"].Value.ToString();
                                KH.KH_Email = dataGridView1.Rows[rowIndex].Cells["KH_Email"].Value.ToString();
                                KH.KH_NgayBatDau = (DateTime)dataGridView1.Rows[rowIndex].Cells["KH_NgayBatDau"].Value;
                                KH.KH_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["KH_TrangThai"].Value;
                                KH.KH_DienThoai = dataGridView1.Rows[rowIndex].Cells["KH_DienThoai"].Value.ToString();
                                KH.KH_DiaChi = dataGridView1.Rows[rowIndex].Cells["KH_DiaChi"].Value.ToString();
                                KH.KH_KhuVuc = dataGridView1.Rows[rowIndex].Cells["KH_KhuVuc"].Value.ToString();
                                KH.rowguid = Guid.NewGuid();
                                db.KhachHangs.InsertOnSubmit(KH);
                            }
                            break;
                        case "QuanLy":
                            var QL = new QuanLy();
                            {
                                QL.QL_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["QL_ID"].Value;
                                QL.QL_TenTruyCap = dataGridView1.Rows[rowIndex].Cells["QL_TenTruyCap"].Value.ToString();
                                QL.QL_Email = dataGridView1.Rows[rowIndex].Cells["QL_Email"].Value.ToString();
                                QL.QL_MatKhau = dataGridView1.Rows[rowIndex].Cells["QL_MatKhau"].Value.ToString();
                                QL.QL_Hoten = dataGridView1.Rows[rowIndex].Cells["QL_HoTen"].Value.ToString();
                                QL.QL_CCCD = dataGridView1.Rows[rowIndex].Cells["QL_CCCD"].Value.ToString();
                                QL.QL_NgaySinh = (DateTime)dataGridView1.Rows[rowIndex].Cells["QL_NgaySinh"].Value;
                                QL.QL_GioiTinh = (Int32)dataGridView1.Rows[rowIndex].Cells["QL_GioiTinh"].Value;
                                QL.QL_DiaChi = dataGridView1.Rows[rowIndex].Cells["QL_DiaChi"].Value.ToString();
                                QL.QL_DienThoai = dataGridView1.Rows[rowIndex].Cells["QL_DienThoai"].Value.ToString();
                                QL.QL_Quyen = (Byte)dataGridView1.Rows[rowIndex].Cells["QL_Quyen"].Value;
                                QL.QL_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["QL_Quyen"].Value;
                                QL.QL_KhuVuc = dataGridView1.Rows[rowIndex].Cells["QL_KhuVuc"].Value.ToString();
                                QL.rowguid = Guid.NewGuid();
                                db.QuanLies.InsertOnSubmit(QL);
                            }
                            break;
                        case "DonHang":
                            var DH = new DonHang();
                            {
                                DH.DH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["DH_ID"].Value;
                                DH.DH_KhachHangId = (Int32)dataGridView1.Rows[rowIndex].Cells["DH_KhachHangId"].Value;
                                DH.DH_Ngay = (DateTime)dataGridView1.Rows[rowIndex].Cells["DH_Ngay"].Value;
                                DH.DH_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["DH_ThanhTien"].Value;
                                DH.DH_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["DH_TrangThai"].Value;
                                DH.rowguid = Guid.NewGuid();
                                db.DonHangs.InsertOnSubmit(DH);
                            }
                            break;
                        case "ChiTietDonHang":
                            var CTDH = new ChiTietDonHang();
                            {
                                CTDH.CTDH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_ID"].Value;
                                CTDH.CTDH_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_SachID"].Value;
                                CTDH.CTDH_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_SoLuong"].Value;
                                CTDH.CTDH_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["CTDH_ID"].Value;
                                CTDH.CTDH_DonHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTDH_DonHangID"].Value;
                                CTDH.rowguid = Guid.NewGuid();
                                db.ChiTietDonHangs.InsertOnSubmit(CTDH);
                            }
                            break;
                        case "DanhGiaSach":
                            var DGS = new DanhGiaSach();
                            {
                                DGS.DGS_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["DGS_ID"].Value;
                                DGS.DGS_KhachHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["DGS_KhachHangID"].Value;
                                DGS.DGS_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["DGS_SachID"].Value;
                                DGS.DSG_NoiDung = dataGridView1.Rows[rowIndex].Cells["DSG_NoiDung"].Value.ToString();
                                DGS.rowguid = Guid.NewGuid();
                                db.DanhGiaSaches.InsertOnSubmit(DGS);
                            }
                            break;
                        case "GioHang":
                            var GH = new GioHang();
                            {
                                GH.GH_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_ID"].Value;
                                GH.GH_KhachHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_KhachHangID"].Value;
                                GH.GH_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_SachID"].Value;
                                GH.GH_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["GH_SoLuong"].Value;
                                GH.GH_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["GH_ThanhTien"].Value;
                                GH.rowguid = Guid.NewGuid();
                                db.GioHangs.InsertOnSubmit(GH);
                            }
                            break;
                        case "PhieuXuat":
                            var PX = new PhieuXuat();
                            {
                                PX.PX_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["PX_ID"].Value;
                                PX.PX_NgayXuat = (DateTime)dataGridView1.Rows[rowIndex].Cells["PX_NgayXuat"].Value;
                                PX.PX_DonHangID = (Int32)dataGridView1.Rows[rowIndex].Cells["PX_DonHangID"].Value;
                                PX.rowguid = Guid.NewGuid();
                                db.PhieuXuats.InsertOnSubmit(PX);
                            }
                            break;
                        case "ChiTietPhieuXuat":
                            var CTPX = new ChiTietPhieuXuat();
                            {
                                CTPX.CTPX_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_ID"].Value;
                                CTPX.CTPX_PhieuXuatID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_PhieuXuatID"].Value;
                                CTPX.CTPX_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_SachID"].Value;
                                CTPX.CTPX_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPX_SoLuong"].Value;
                                CTPX.CTPX_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["CTPX_ThanhTien"].Value;
                                CTPX.rowguid = Guid.NewGuid();
                                db.ChiTietPhieuXuats.InsertOnSubmit(CTPX);
                            }
                            break;
                        default:
                            break;
                    }
                    db.SubmitChanges();
                }
                else if (serverChoose.Text == "NhaXuatBan")
                {
                    var db = new NhaXuatBanClassDataContext(connString);
                    switch (tableChoose.Text)
                    {
                        case "NhaXuatBan":
                            var NXBnew = new NhaXuatBan();
                            {
                                NXBnew.NXB_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["NXB_ID"].Value;
                                NXBnew.NXB_Ten = dataGridView1.Rows[rowIndex].Cells["NXB_Ten"].Value.ToString();
                                NXBnew.rowguid = Guid.NewGuid();
                                db.NhaXuatBans.InsertOnSubmit(NXBnew);
                            }
                            break;
                        case "Sach":
                            var Sachnew = new Sach();
                            {
                                Sachnew.S_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_ID"].Value;
                                Sachnew.S_TheLoaiID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_TheLoaiID"].Value;
                                Sachnew.S_Ten = dataGridView1.Rows[rowIndex].Cells["S_Ten"].Value.ToString();
                                Sachnew.S_Mota = dataGridView1.Rows[rowIndex].Cells["S_Mota"].Value.ToString();
                                Sachnew.S_TuKhoa = dataGridView1.Rows[rowIndex].Cells["S_TuKhoa"].Value.ToString();
                                Sachnew.S_GiaBan = (Decimal)dataGridView1.Rows[rowIndex].Cells["S_GiaBan"].Value;
                                Sachnew.S_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["S_TrangThai"].Value;
                                Sachnew.S_SoLanXem = (Int32)dataGridView1.Rows[rowIndex].Cells["S_SoLanXem"].Value;
                                Sachnew.S_KhoSach = dataGridView1.Rows[rowIndex].Cells["S_KhoSach"].Value.ToString();
                                Sachnew.S_NXBID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NXBID"].Value;
                                Sachnew.S_NamXuatBan = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NamXuatBan"].Value;
                                Sachnew.S_GiaNhap = (Decimal)dataGridView1.Rows[rowIndex].Cells["S_GiaNhap"].Value;
                                Sachnew.S_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["S_SoLuong"].Value;
                                Sachnew.S_SoTrang = (Int32)dataGridView1.Rows[rowIndex].Cells["S_SoTrang"].Value;
                                Sachnew.S_TacGiaId = (Int32)dataGridView1.Rows[rowIndex].Cells["S_TacGiaId"].Value;
                                Sachnew.S_TrongLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["S_TrongLuong"].Value;
                                Sachnew.S_NgonNguID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NgonNguID"].Value;
                                Sachnew.S_NhaCungCapID = (Int32)dataGridView1.Rows[rowIndex].Cells["S_NhaCungCapID"].Value;
                                Sachnew.rowguid = Guid.NewGuid();
                                db.Saches.InsertOnSubmit(Sachnew);
                            }
                            break;
                        case "TheLoaiSach":
                            var TLSnew = new TheLoaiSach();
                            {
                                TLSnew.TL_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["TL_ID"].Value;
                                TLSnew.TL_Ten = dataGridView1.Rows[rowIndex].Cells["TL_Ten"].Value.ToString();
                                TLSnew.TL_TrangThai = (Boolean)dataGridView1.Rows[rowIndex].Cells["TL_TrangThai"].Value;
                                TLSnew.rowguid = Guid.NewGuid();
                                db.TheLoaiSaches.InsertOnSubmit(TLSnew);
                            }
                            break;
                        case "TacGia":
                            var TGnew = new TacGia();
                            {
                                TGnew.TG_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["TG_ID"].Value;
                                TGnew.TG_HoTen = dataGridView1.Rows[rowIndex].Cells["TG_HoTen"].Value.ToString();
                                TGnew.TG_NgaySinh = (DateTime)dataGridView1.Rows[rowIndex].Cells["TG_NgaySinh"].Value;
                                TGnew.TG_QuocTich = dataGridView1.Rows[rowIndex].Cells["TG_QuocTich"].Value.ToString();
                                TGnew.rowguid = Guid.NewGuid();
                                db.TacGias.InsertOnSubmit(TGnew);
                            }
                            break;
                        case "ChiTietPhieuNhap":
                            var CTPN = new ChiTietPhieuNhap();
                            {
                                CTPN.CTPN_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_ID"].Value;
                                CTPN.CTPN_PhieuNhapID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_PhieuNhapID"].Value;
                                CTPN.CTPN_SachID = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_SachID"].Value;
                                CTPN.CTPN_SoLuong = (Int32)dataGridView1.Rows[rowIndex].Cells["CTPN_SoLuong"].Value;
                                CTPN.CTPN_ThanhTien = (Decimal)dataGridView1.Rows[rowIndex].Cells["CTPN_ThanhTien"].Value;
                                CTPN.rowguid = Guid.NewGuid();
                                db.ChiTietPhieuNhaps.InsertOnSubmit(CTPN);
                            }
                            break;
                        case "NgonNgu":
                            var NN = new NgonNgu();
                            {
                                NN.NN_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["NN_ID"].Value;
                                NN.NN_Ten = dataGridView1.Rows[rowIndex].Cells["NN_Ten"].Value.ToString();
                                NN.rowguid = Guid.NewGuid();
                                db.NgonNgus.InsertOnSubmit(NN);
                            }
                            break;
                        case "NhaCungCap":
                            var NCC = new NhaCungCap();
                            {
                                NCC.NCC_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["NCC_ID"].Value;
                                NCC.NCC_Ten = dataGridView1.Rows[rowIndex].Cells["NCC_Ten"].Value.ToString();
                                NCC.NCC_DiaChi = dataGridView1.Rows[rowIndex].Cells["NCC_DiaChi"].Value.ToString();
                                NCC.NCC_DienThoai = dataGridView1.Rows[rowIndex].Cells["NCC_DienThoai"].Value.ToString();
                                NCC.NCC_Email = dataGridView1.Rows[rowIndex].Cells["NCC_Email"].Value.ToString();
                                NCC.rowguid = Guid.NewGuid();
                                db.NhaCungCaps.InsertOnSubmit(NCC);
                            }
                            break;
                        case "PhieuNhap":
                            var PN = new PhieuNhap();
                            {
                                PN.PN_ID = (Int32)dataGridView1.Rows[rowIndex].Cells["PN_ID"].Value;
                                PN.PN_NgayNhap = (DateTime)dataGridView1.Rows[rowIndex].Cells["PN_NgayNhap"].Value;
                                PN.PN_NhaCungCapID = (Int32)dataGridView1.Rows[rowIndex].Cells["PN_NhaCungCapID"].Value;
                                PN.rowguid = Guid.NewGuid();
                                db.PhieuNhaps.InsertOnSubmit(PN);
                            }
                            break;
                        default:
                            break;
                    }
                    db.SubmitChanges();
                }
            }
            btnLoad_Click(sender, e);
        }

        private void dbChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

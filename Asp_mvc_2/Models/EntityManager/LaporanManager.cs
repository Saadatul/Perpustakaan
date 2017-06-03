using Asp_mvc_2.Models.DB;
using Asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_mvc_2.Models.EntityManager
{
    public class LaporanManager
    {
        public void InsertLaporan(LaporanView lv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                laporan lap = new laporan();
                lap.id_laporan = lv.idLaporan;
                lap.id_buku = lv.idBuku;
                lap.id_pelanggan = lv.idPelanggan;
                lap.keterangan = lv.keterangan;
                lap.tgl_pinjam = lv.tglPinjam;
                lap.tgl_kembali = lv.tglKembali;
                TimeSpan d = (lv.tglKembali - lv.tglPinjam) ?? default(TimeSpan);
                int idBuku = lv.idBuku ?? default(int);
                lap.saldo = int.Parse(d.Days.ToString()) * GetHargaBuku(idBuku);
                db.laporans.Add(lap);
                db.SaveChanges();
            }
        }
        public int GetHargaBuku(int idBuku)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                var km = db.bukus.Where(o => o.id_buku.Equals(idBuku));
                if (km.Any())
                    return km.FirstOrDefault().harga ?? default(int);
                else
                    return 0;
            }
        }
        public List<LaporanView> GetLaporanData()
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                var laporan = db.laporans.Select(o => new LaporanView
                {
                    idLaporan = o.id_laporan,
                    idBuku = o.id_buku,
                    idPelanggan = o.id_pelanggan,
                    keterangan = o.keterangan,
                    tglPinjam = o.tgl_pinjam,
                    tglKembali = o.tgl_kembali,
                    saldo = o.saldo
                }).ToList();
                return laporan;
            }
        }
        public LaporanDataView GetLaporanDataView()
        {
            LaporanDataView ldv = new LaporanDataView();
            UserManager pm = new UserManager();
            BukuManager km = new BukuManager();
            ldv.LaporanProfile = GetLaporanData();
            ldv.SelectedPelanggan = 1;
            ldv.PelangganProfile = pm.GetUserDataView();
            ldv.SelectedBuku = 1;
            ldv.BukuProfile = km.GetBukuData();
            return ldv;
        }
    }
}
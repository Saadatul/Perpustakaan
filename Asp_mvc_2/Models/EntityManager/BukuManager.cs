using Asp_mvc_2.Models.DB;
using Asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Asp_mvc_2.Models.EntityManager
{
    public class BukuManager
    {
        public void AddBuku(BukuView kv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                buku km = new buku();
                km.id_buku = kv.id_buku;
                km.ISBN = kv.ISBN;
                km.judul = kv.judul;
                km.penulis = kv.penulis;
                km.penerbit = kv.penerbit;
                km.tahun = kv.tahun;
                km.stok = kv.stok;
                db.bukus.Add(km);
                db.SaveChanges();
            }
        }
        public void UpdateBuku(BukuView kv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                buku km = db.bukus.Find(kv.id_buku);
                km.id_buku = kv.id_buku;
                km.ISBN = kv.ISBN;
                km.judul = kv.judul;
                km.penulis = kv.penulis;
                km.penerbit = kv.penerbit;
                km.tahun = kv.tahun;
                km.stok = kv.stok;
                //db.kamars.Add(km);
                db.SaveChanges();
            }
        }
        public List<BukuView> GetBukuData()
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                var buku = db.bukus.Select(o => new BukuView
                {
                    id_buku = o.id_buku,
                    ISBN = o.ISBN,
                    judul = o.judul,
                    penulis = o.penulis,
                    penerbit = o.penerbit,
                    stok = o.stok,
                    tahun = o.tahun
                 
                }).ToList();
                return buku;
            }
        }
        public void DeleteBuku(int bukuID)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var Km = db.bukus.Where(o => o.id_buku == bukuID);
                        if (Km.Any())
                        {
                            db.bukus.Remove(Km.FirstOrDefault());
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
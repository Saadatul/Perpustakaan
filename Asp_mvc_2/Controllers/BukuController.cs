
using Asp_mvc_2.Models.EntityManager;
using Asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace Asp_mvc_2.Controllers
{
    public class BukuController : Controller
    {
        // GET: Buku
        public ActionResult Addbuku()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBuku(BukuView kv)
        {
            if (ModelState.IsValid)
            {
                BukuManager KM = new BukuManager();
                KM.AddBuku(kv);
                return RedirectToAction("AdminOnly", "Home");
            }
            return View();
        }
        public ActionResult ManageBukuPartial(string status = "")
        {
            //if (User.Identity.IsAuthenticated)
            //{
            string loginName = User.Identity.Name;
            BukuManager KM = new BukuManager();
            BukuDataView KDV = new BukuDataView();
            KDV.BukuProfile = KM.GetBukuData();
            string message = string.Empty;
            if (status.Equals("update"))
                message = "Update Successful";
            else if (status.Equals("delete"))
                message = "Delete Successful";
            ViewBag.Message = message;
            return PartialView(KDV);
            //}
            // return RedirectToAction("Index", "Home");
        }
        public ActionResult UpdateBukuData(int bukuID, string idBuku, string isbn, string judul, string penulis, string penerbit, int tahun, int stok)
        {
            BukuView KV = new BukuView();
            KV.id_buku = bukuID;
            KV.ISBN = isbn;
            KV.judul = judul;
            KV.penulis = penulis;
            KV.penerbit = penerbit;
            KV.tahun = tahun;
            KV.stok = stok;
            BukuManager KM = new BukuManager();
            KM.UpdateBuku(KV);
            return Json(new { success = true });
        }
        public ActionResult DeleteBuku(int bukuID)
        {
            BukuManager KM = new BukuManager();
            KM.DeleteBuku(bukuID);
            return Json(new { success = true });
        }
        public ActionResult Perubahan()
        {
            return View();
        }
    }
}
using Asp_mvc_2.Models.EntityManager;
using Asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Asp_mvc_2.Controllers
{
    public class LaporanController : Controller
    {
        // GET: Laporan
        public ActionResult ManageLaporanPartial(string status = "")
        {
            LaporanManager lm = new LaporanManager();
            LaporanDataView ldv = lm.GetLaporanDataView();
            string message = string.Empty;
            if (status.Equals("update"))
                message = "Update Successful";
            else if (status.Equals("delete"))
                message = "Delete Successful";
            else if (status.Equals("insert"))
                message = "Insert Successful";
            ViewBag.Message = message;
            return PartialView(ldv);
            //}
            // return RedirectToAction("Index", "Home");
        }
        public ActionResult InsertLaporan(int idBuku, int idPelanggan, string keterangan, DateTime tglPinjam,
        DateTime tglKembali)
        {
            LaporanView lv = new LaporanView();
            lv.idBuku = idBuku;
            lv.idPelanggan = idPelanggan;
            lv.keterangan = keterangan;
            lv.tglPinjam = tglPinjam;
            lv.tglKembali = tglKembali;
            LaporanManager lm = new LaporanManager();
            lm.InsertLaporan(lv);
            return Json(new { success = true });
        }
        public ActionResult DataLaporan()
        {
            return View();
        }
    }
}
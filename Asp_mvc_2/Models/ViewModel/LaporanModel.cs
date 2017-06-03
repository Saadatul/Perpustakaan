using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_mvc_2.Models.ViewModel
{
    public class LaporanView
    {
        [Key]
        public int idLaporan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "ID Laporan")]
        public int? idBuku{ get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "ID buku")]
        public int? idPelanggan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Keterangan")]
        public string keterangan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tgl Pinjam")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//untuk mengeluarkan tgl saja
        public DateTime? tglPinjam { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tgl Kembali")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? tglKembali { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Saldo")]
        public int? saldo { get; set; }
    }
    public class LaporanDataView
    {
        public IEnumerable<LaporanView> LaporanProfile { get; set; }
        public int? SelectedPelanggan { get; set; }
        public IEnumerable<UserDataView> PelangganProfile { get; set; }
        public int? SelectedKamar { get; set; }
        public IEnumerable<BukuView> BukuProfile { get; set; }
        public int SelectedBuku { get; internal set; }
    }
}
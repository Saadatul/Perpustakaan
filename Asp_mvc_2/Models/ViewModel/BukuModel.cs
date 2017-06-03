using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_mvc_2.Models.ViewModel
{
    public class BukuView
    {
        [Key]
        public int id_buku { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Judul Buku")]
        public string judul { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Penulis")]
        public string penulis { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Penerbit")]
        public string penerbit { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tahun")]
        public int? tahun { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Stok")]
        public int? stok { get; set; }
    }
    public class BukuDataView
    {
        public IEnumerable<BukuView> BukuProfile { get; set; }
    }
}
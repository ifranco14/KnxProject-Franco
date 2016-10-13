using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class NewsModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "La {0} es necesaria.")]
        [Display(Name = "Rama específica")]
        public int CourtBranchId { get; set; }
        [Required(ErrorMessage = "El {0} es necesario.")]
        [Editable(true)]
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Required(ErrorMessage = "El {0} es necesario.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Cuerpo")]
        public string Body { get; set; }
        [Required(ErrorMessage = "El {0} es necesario.")]
        [Display(Name = "Lugar")]
        public string Place { get; set; }
        [Required(ErrorMessage = "La {0} es necesaria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
        //[DataType(DataType.ImageUrl)]
        //[Display(Name ="Imagen")]
        //public Uri ImgUrl { get; set; }
        [Display(Name = "Membrete de la imagen")]
        public string LetterHead { get; set; }
        [Required(ErrorMessage = "La {0} es necesaria.")]
        [Display(Name = "Alcance de la noticia")]
        public int ScopeID { get; set; }
    }
}

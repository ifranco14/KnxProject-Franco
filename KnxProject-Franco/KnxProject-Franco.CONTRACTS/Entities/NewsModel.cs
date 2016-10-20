using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KnxProject_Franco.CONTRACTS.Entities.DataAnnotations;
using System.Web.UI.WebControls;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class NewsModel
    {
        public int IDNew { get; set; }
        [Required(ErrorMessage = "La {0} es necesaria.")]
        [Display(Name = "Rama específica")]
        public int IDCourtBranch { get; set; }
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
        [CustomDA._DateOfBirth]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string ImageURL { get; set; }
        [Display(Name = "Membrete de la imagen")]
        public string LetterHead { get; set; }
        [Required(ErrorMessage = "La {0} es necesaria.")]
        [Display(Name = "Alcance de la noticia")]
        public int IDScope { get; set; }
        
        public HttpPostedFileBase Image { get; set; }

        public virtual ScopeModel Scopes { get; set; }
        public virtual CourtBranchModel CourtBranches { get; set; }
    }
}

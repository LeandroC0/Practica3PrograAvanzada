using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupo4.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El texto del comentario es obligatorio.")]
        [StringLength(500, ErrorMessage = "El comentario no puede exceder los 500 caracteres.")]
        public string Texto { get; set; }
        public System.DateTime FechaCreacion { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
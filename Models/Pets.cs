using System.ComponentModel.DataAnnotations;

namespace pc2_progra.Models
{
    public class Pets
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 30, ErrorMessage = "La edad debe estar entre 0 y 30 años")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El tipo de mascota es obligatorio")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "El estado de adopción es obligatorio")]
        public string? Estado { get; set; } = "Disponible";

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Adoptions? Adoption { get; set; }
    }
}
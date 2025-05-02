using System;
using System.ComponentModel.DataAnnotations;

namespace pc2_progra.Models
{
    public class Pets
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Adoptions? Adoption { get; set; }
    }
}
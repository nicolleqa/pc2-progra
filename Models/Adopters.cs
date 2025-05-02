using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace pc2_progra.Models
{
    public class Adopters
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        public ICollection<Adoptions>? Adoptions { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pc2_progra.Models
{
    public class Adoptions
    {
        [Key]
        public int Id { get; set; }

        public DateTime AdoptionDate { get; set; }

        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public Pets? Pet { get; set; }

        public int AdopterId { get; set; }
        [ForeignKey("AdopterId")]
        public Adopters? Adopter { get; set; }
    }
}
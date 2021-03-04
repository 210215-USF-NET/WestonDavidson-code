using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToHModels;

namespace ToHMVC.Models
{
    public class HeroEditVM
    {
        /// <summary>
        /// Needed to store the Id of the hero I'm going to update
        /// </summary>

        [DisplayName("Hero Name")]
        public string HeroName { get; set; }


        [DisplayName("Health Points")]
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "HP should be a positive value!")]
        public int HP { get; set; }

        [DisplayName("Element")]
        [Required]
        public Element ElementType { get; set; }

        [DisplayName("Name of Hero Superpower")]
        [Required]
        public string SuperPowerName { get; set; }

        [DisplayName("Hero Superpower Description")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Damage of Hero Superpower")]
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Damage should be non negative!")]
        public int Damage { get; set; }

        public int HeroId { get; set; }

        public int SuperPowerId { get; set; }

    }
}

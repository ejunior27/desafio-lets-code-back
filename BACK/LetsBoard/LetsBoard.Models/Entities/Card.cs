using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetsAuth.Models.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Conteudo { get; set; }
        [Required]
        public string Lista { get; set; } 
    }
}

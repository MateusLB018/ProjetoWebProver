using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoWebProver.Models
{
    public partial class Poder:Entity
    {


        public Guid PersonagemId { get; set; }

        [Required(ErrorMessage = "O campo Poder não pode ser Nulo")]
        [Display(Name = "Poder")]
        public string Pod { get; set; }
        public Personagem Personagem { get; set; }
    }
}

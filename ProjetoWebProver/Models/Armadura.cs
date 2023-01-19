using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoWebProver.Models
{
    public class Armadura:Entity
    {


        public Guid PersonagemId { get; set; }

        [Required(ErrorMessage = "O campo Qual não pode ser Nulo")]
        [Display(Name = "Nome da Armadura")]
        public string Qual { get; set; }

        [Required(ErrorMessage = "O campo Defesa não pode ser Nulo")]
        [Range(1, 99, ErrorMessage = "O Limite é 99...")]
        [Display(Name = "Defesa")]
        public int DanoAbs { get; set; }

        [Required(ErrorMessage = "O campo Peso não pode ser Nulo")]
        [Range(1, 99, ErrorMessage = "O Limite é 99...")]
        [Display(Name = "Peso da Armadura")]
        public int Peso { get; set; }


        public Personagem Personagem { get; set; }
    }
}

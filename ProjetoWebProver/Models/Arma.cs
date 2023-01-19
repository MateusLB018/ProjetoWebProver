using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoWebProver.Models
{
    public class Arma:Entity
    {



        public Guid PersonagemId { get; set; }

        [Required(ErrorMessage = "O campo Dano não pode ser Nulo")]
        [Range(1, 99, ErrorMessage = "O Limite é 99...")]
        public int Dano { get; set; }

        [Required(ErrorMessage = "O campo Peso não pode ser Nulo")]
        [Range(1, 99, ErrorMessage = "O Limite é 99...")]
        [Display(Name = "Peso da Arma")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "O campo Qual não pode ser Nulo")]
        [Display(Name = "Nome da Arma")]
        public string Qual { get; set; }


        public Personagem Personagem { get; set; }

    }
}

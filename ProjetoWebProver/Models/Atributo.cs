using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoWebProver.Models
{
    public class Atributo:Entity
    {
        

        public Guid PersonagemId { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        [Display(Name = "Inteligência")]
        public int Inteligencia { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        public int Força { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        [Display(Name = "Fé")]
        public int Fe { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        public int Vitalidade { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        public int Energia { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        public int Magia { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        public int Defesa { get; set; }

        [Range(0, 99, ErrorMessage = "O Limite é 99...")]
        public int Vigor { get; set; }
        public Personagem Personagem { get; set; }
    }
}


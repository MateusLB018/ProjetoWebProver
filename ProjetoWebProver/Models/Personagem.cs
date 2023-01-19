using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoWebProver.Models
{
    public class Personagem:Entity
    {

        [Required(ErrorMessage = "O campo Nome é necessário ")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome precisa Ter no mínimo 3 caracteres e no máximo 100 ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Idade é necessário ")]
        public int Idade { get; set; }


        [Required(ErrorMessage = "O campo Peso é necessário ")]
        [Range(1, 200, ErrorMessage = "O Limite é 200...")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "O campo Sexo é necessário ")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "O Sexo é de apenas um caracteres f,F ou m,M")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo Item Inicial é necessário ")]
        [Display(Name = "Item Inicial")]
        public string ItemIni { get; set; }
        //public int ArmaID { get; set; }
        //public int ArmaduraID { get; set; }
        //public int PoderID { get; set; }
        //public int AtributoID { get; set; }

        public IEnumerable<Atributo> Atributos { get; set; }
        public IEnumerable<Arma> Armas { get; set; }
        public IEnumerable<Armadura> Armaduras { get; set; }
        public IEnumerable<Poder> Poderes { get; set; }




    }
}

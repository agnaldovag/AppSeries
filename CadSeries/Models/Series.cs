using CadSeries.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadSeries.Models
{
    public class Series : Entidade
    {

        public Guid DiretorId { get; set; }//(Fk) possui um relacionamento com a entidade Diretor
        public Guid GeneroId { get; set; }//FK

       

        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Cartaz é obrigatório.")]
        public string Cartaz { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório.")]
        public string Descricao { get; set; }


        [DisplayName("Ativo ?")]
        public bool Ativo { get; set; }


      
        public Genero Genero { get; set; }//Propriedade de navegação
        // Relacionamento (1:n)
        public Diretor Diretor { get; set; }// propriedade de navegação
        


    }
}

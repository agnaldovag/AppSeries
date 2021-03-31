using CadSeries.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadSeries.Models
{
    public class Diretor : Entidade
    {


        public Guid TVId { get; set; }// propriedade de nevegação
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string NomeDiretor { get; set; }

        [Required(ErrorMessage = "O campo Biografia é obrigatório.")]
        public string Biografia { get; set; }

        [DisplayName("Ativo ?")]
        public bool Ativo { get; set; }

        public TV Tv { get; set; }// Relacinamento de 1:n

        // Relacionamentos (n:1)

        public IEnumerable<Series> Series { get; set; }
    }
}

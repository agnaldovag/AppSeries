using CadSeries.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadSeries.Models
{
    public class Genero: Entidade
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string NomeGenero { get; set; }

        [DisplayName("Ativo ?")]
        public bool Ativo { get; set; }

        public IEnumerable<Series> Series { get; set; }// (Relacionamento de n:1)
    }
}

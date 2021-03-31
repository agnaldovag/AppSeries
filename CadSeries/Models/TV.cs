using CadSeries.Negocio;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadSeries.Models
{
    public class TV : Entidade
    {

        [Required(ErrorMessage = "O campo Nome da Tv é obrigatório")]
        public string NomeTv { get; set; }

        [DisplayName("Ativo ?")]
        public bool Ativo { get; set; }


        //Relacionamento de (N:1)

        public IEnumerable<Diretor> Diretor { get; set; }

    }
}

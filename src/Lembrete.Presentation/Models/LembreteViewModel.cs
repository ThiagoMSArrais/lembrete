using System;
using System.ComponentModel.DataAnnotations;

namespace Lembrete.Presentation.Models
{
    public class LembreteViewModel
    {

        public LembreteViewModel()
        {
            Usuario = new UsuarioViewModel();
        }

        public Guid LembreteId { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Data de Nofiticação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        public DateTime DataLembrete { get; set; }

        public DateTime DataLembrado { get; set; }

        public bool Lembrado { get; set; }

        [MaxLength(800, ErrorMessage = "Limite máximo de 800 carectes.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório.")]
        public string Assunto { get; set; }

        [MaxLength(150, ErrorMessage = "Limite máximo de 150 carectes.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public UsuarioViewModel Usuario { get; set; }
    }
}
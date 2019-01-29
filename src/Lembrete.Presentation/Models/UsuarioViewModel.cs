using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lembrete.Presentation.Models
{
    public class UsuarioViewModel
    {

        public UsuarioViewModel()
        {
            
        }

        public Guid UsuarioId { get; set; }

        [MaxLength(150, ErrorMessage = "Limite máximo de 150 carectes.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório.")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$", ErrorMessage = "Permitido somente letras.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        public DateTime DataDeNascimento { get; set; }

        public string Sexo { get; set; }

        public List<SelectListItem> Sexos { get; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "Feminino", Value = "F" },
            new SelectListItem { Text = "Masculino", Value = "M" }
        };

        [MaxLength(150, ErrorMessage = "Limite máximo de 150 carectes.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório.")]
        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9\._-]+@([a-zA-Z0-9\._-]+\.)[a-zA-Z-0-9]{2,3}$")]
        [Display(Name = "E-mail")]
        [ReadOnly(true)]
        public string Email { get; set; }
    }
}
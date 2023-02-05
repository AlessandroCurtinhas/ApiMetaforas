﻿using System.ComponentModel.DataAnnotations;

namespace Metaforas.Application.Models
{
    public class FrasePutModel
    {
        [Required(ErrorMessage = "O id da frase não foi informado")]
        public Guid IdFrase { get; set; }
        [Required(ErrorMessage = "O id do pensador não foi informado")]
        public Guid IdPensador { get; set; }
        [Required(ErrorMessage = "O id do time não foi informado")]
        public Guid IdTime { get; set; }
        [Required(ErrorMessage = "A frase não foi informada")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        public string FraseTexto { get; set; }
        [Required(ErrorMessage = "É necessário informado o estado do registro.")]
        public bool Ativo { get; set; }
    }
}

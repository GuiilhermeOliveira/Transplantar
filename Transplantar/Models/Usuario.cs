using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Transplantar.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Column("Id")]
        public int UsuarioId { get; set; }

        [Required, MaxLength(11)]
        public string Cpf { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public int Pin { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string Celular { get; set; }

        [Required, MaxLength(100)]
        public string Cidade { get; set; }

        [Required, MaxLength(20)]
        public string Estado { get; set; }

        [Required]
        public Orgao Orgao { get; set; }

        [Required]
        public GrupoSanguineo GrupoSanguineo  { get; set; } 

        [Required]
        public Tipo TipoUsuario { get; set; }

    }
}

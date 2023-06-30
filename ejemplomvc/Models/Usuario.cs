using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemplomvc.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("PRIMER_NOMBRE")]
        public string? primer_nombre { get; set; }
        [Column("SEGUNDO_NOMBRE")]
        public string? segundo_nombre { get; set; }
        [Column("APELLIDO")]
        public string? apellido { get; set; }
        
    }
}


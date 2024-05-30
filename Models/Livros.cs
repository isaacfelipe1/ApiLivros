using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLivros.Models
{
    [Table("Livros")]
    public class Livros
    {
    
    public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Título deve ter no máximo 100 caracteres.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Título deve ter no máximo 100 caracteres.")]
        public string Editora { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
      
        public int AnoPublicacao { get; set; }

 
    }
}
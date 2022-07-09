using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cmsMvc.Models.Domain.Entities
{
    public class Administrador
    {

        public Administrador(int id, string nome, string email, string telefone, string senha) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Senha = senha;
        }

        public Administrador() {       
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(150)]
        public string Senha { get; set; }
    }
}
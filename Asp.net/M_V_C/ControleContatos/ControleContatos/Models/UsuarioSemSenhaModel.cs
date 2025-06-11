using ControleContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set;}
        [Required(ErrorMessage = "Digite o nome do Usuário ")]
        public string? Nome { get; set;}
        [Required(ErrorMessage = "Digite o Login do Usuário ")]
        public string? Login { get; set;}
        [Required(ErrorMessage = "Digite o e-mail do Usuário ")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do Usuário ")]
        public PerfilEnum? Perfil { get; set;}
    }
}

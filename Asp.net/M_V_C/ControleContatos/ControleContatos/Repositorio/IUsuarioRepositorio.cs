using ControleContatos.Models;
using System;
using System.Collections.Generic;   
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListaPorid(int Id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}

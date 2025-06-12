using ControleContatos.Data;
using ControleContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _Context;
       

        public UsuarioRepositorio(BancoContext bancoContexto)
        {
            this._Context = bancoContexto;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _Context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListaPorid (int id) 
        {
            return _Context.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _Context.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro=DateTime.Now;
            _Context.Usuarios.Add(usuario);
            _Context.SaveChanges();

            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel UsuarioDB = ListaPorid(usuario.Id); 
            if(UsuarioDB == null) throw new System.Exception("Houve um erro na atualização do contato.");

            UsuarioDB.Nome = usuario.Nome;
            UsuarioDB.Email = usuario.Email;
            UsuarioDB.Login = usuario.Login;
            UsuarioDB.Perfil = usuario.Perfil;  
            UsuarioDB.DataAtualizacao = DateTime.Now;


            _Context.Usuarios.Update(UsuarioDB);
            _Context.SaveChanges();
            return UsuarioDB;

        }

        public bool Apagar(int id)
        {
            UsuarioModel UsuarioDB = ListaPorid(id);

            if (UsuarioDB == null) throw new System.Exception("Houve um erro na deleção do contato!");
            _Context.Usuarios.Remove(UsuarioDB);
            _Context.SaveChanges();

            return true;
        }
    }
}

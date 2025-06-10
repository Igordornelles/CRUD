using ControleContatos.Data;
using ControleContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _Context;
       

        public ContatoRepositorio(BancoContext bancoContexto)
        {
            this._Context = bancoContexto;
        }
        public ContatoModel ListaPorid(int id) 
        {
            return _Context.Contatos.FirstOrDefault(x => x.Id == id);
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _Context.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _Context.Contatos.Add(contato);
            _Context.SaveChanges();

            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListaPorid(contato.Id); 
            if(contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato.");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;    
            contatoDB.Celular = contato.Celular;

            _Context.Contatos.Update(contatoDB);
            _Context.SaveChanges();
            return contatoDB;

        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListaPorid(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato!");
            _Context.Contatos.Remove(contatoDB);
            _Context.SaveChanges();

            return true;
        }
    }
}

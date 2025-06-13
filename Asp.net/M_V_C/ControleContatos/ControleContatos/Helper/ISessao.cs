using ControleContatos.Models;

namespace ControleContatos.Helper
{
    public interface ISessao
    {
        void CrirarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario(); 
        UsuarioModel BuscarSessaoUsuario();
    }
}

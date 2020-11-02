using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transplantar.Models;

namespace Transplantar.Repositories
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(int codigo);
        Usuario Buscar(int codigo);
        Usuario BuscarCpf(string cpf);
        IList<Usuario> BuscarCompativeis(GrupoSanguineo grupoSanguineo, string cidade, Orgao orgao, Tipo tipoUsuario);
        void Salvar();
    }
}

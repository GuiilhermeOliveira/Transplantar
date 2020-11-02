using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transplantar.Models;
using Transplantar.Persistencia;

namespace Transplantar.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private TransplantarContext _context;

        public UsuarioRepository(TransplantarContext context)
        {
            _context = context;
        }
        public void Atualizar(Usuario usuario)
        {
            var local = _context.Usuarios.Local.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

            if (local != null)
                _context.Entry(local).State = EntityState.Deleted;

            _context.Usuarios.Update(usuario);
        }

        public Usuario Buscar(int codigo)
        {
            return _context.Usuarios.Find(codigo);
        }

        public IList<Usuario> BuscarCompativeis(GrupoSanguineo grupoSanguineo, string cidade, Orgao orgao, Tipo tipoUsuario)
        {
           
                return _context.Usuarios
                    .Where(u => u.GrupoSanguineo == grupoSanguineo && u.Cidade == cidade && u.Orgao == orgao && u.TipoUsuario != tipoUsuario)
                    .ToList();
         
        }

        public Usuario BuscarCpf(string cpf)
        {
            return _context.Usuarios.
                Where(c => c.Cpf == cpf)
                .FirstOrDefault();
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Remover(int codigo)
        {
            _context.Usuarios.Remove(_context.Usuarios.Find(codigo));
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

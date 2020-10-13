using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.DAO;
using View.Entidades;

namespace View.Model
{
    class UsuarioModelo
    {
        internal static int Inserir(UsuarioEnt objtabela)
        {
            return new UsuarioDAO().Inserir(objtabela);
        }

        internal List<UsuarioEnt> Lista()
        {
            return new UsuarioDAO().Lista();

        }

        internal List<UsuarioEnt> Consulta(UsuarioEnt objtabela)
        {
            return new UsuarioDAO().Consulta(objtabela);
        }

        internal static int Alterar(UsuarioEnt objtabela)
        {
            return new UsuarioDAO().Alterar(objtabela);
        }

        internal static int Deletar(UsuarioEnt objtabela)
        {
            return new UsuarioDAO().Deletar(objtabela);
        }
    }
}

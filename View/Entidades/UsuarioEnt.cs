using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Entidades
{
    class UsuarioEnt
    {
        private int id;
        private string nome;
        private string telefone;

       
        //envio e recebimento de dados, a entidade que é uma tabela é uma copia do que tem do banco de dados.
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
    }
}

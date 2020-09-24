using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models
{
    public class Resultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object ObjetoResultado { get; set; }

        public Resultado(bool sucesso, string mensagem)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }
        public Resultado(bool sucesso)
        {
            this.Sucesso = sucesso;
        }
        public Resultado()
        {

        }
    }
}

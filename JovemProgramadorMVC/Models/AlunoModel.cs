using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Models
{
    public class AlunoModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string contato { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
    }
}

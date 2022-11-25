using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace JovemProgramadorMVC.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;

        public AlunoRepositorio(JovemProgramadorContexto jovemProgramadorContexto)
        {
            _jovemProgramadorContexto = jovemProgramadorContexto;
        }

        public void InserirAluno(AlunoModel aluno)
        {
            _jovemProgramadorContexto.Aluno.Add(aluno);
            _jovemProgramadorContexto.SaveChanges();
        }

        public List<AlunoModel> BuscarAlunos()
        {
            return _jovemProgramadorContexto.Aluno.ToList();
        }

        public AlunoModel BuscarId(int id)
        {
            return _jovemProgramadorContexto.Aluno.FirstOrDefault(x => x.id == id);
        }

        public void Atualizar(AlunoModel aluno)
        {

            _jovemProgramadorContexto.Aluno.Update(aluno);
            _jovemProgramadorContexto.SaveChanges();

        }

        public void ExcluirAluno(AlunoModel aluno)
        {
            _jovemProgramadorContexto.Aluno.Remove(aluno);
            _jovemProgramadorContexto.SaveChanges();
        }

    }
}

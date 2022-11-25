using JovemProgramadorMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JovemProgramadorMVC.Data.Mapeamento
{
    public class AlunosMapping: IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(t => t.id);

            builder.Property(t => t.nome).HasColumnType("varchar(50)");
            builder.Property(t => t.idade).HasColumnType("int");
            builder.Property(t => t.contato).HasColumnType("varchar(50)");
            builder.Property(t => t.email).HasColumnType("varchar(50)");
            builder.Property(t => t.cep).HasColumnType("varchar(50)");
        }
    }
}

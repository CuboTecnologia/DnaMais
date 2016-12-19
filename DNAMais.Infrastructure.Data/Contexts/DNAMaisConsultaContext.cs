//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data.Entity;
//using System.Data.Entity.Core.Metadata.Edm;
//using System.Data.Entity.Core.Objects;
//using System.Data.Entity.Infrastructure;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using DNAMais.Domain.CustomAttributes;
//using DNAMais.Domain.Entidades;
//using DNAMais.Domain.Entidades.Consultas;

//namespace DNAMais.Infrastructure.Data.Contexts
//{
//    public class DNAMaisConsultaContext : DbContext
//    {
//        //private readonly StreamWriter arquivoLog = new StreamWriter("C:\\temp\\logDna.txt", true);

//        public DNAMaisConsultaContext() :
//            base("connDnaMais")
//        {
//            Database.Log = LogDb.WriteLog;

//            Configuration.AutoDetectChangesEnabled = false;
//            Configuration.ValidateOnSaveEnabled = false;
//            Configuration.LazyLoadingEnabled = false;

//            Database.SetInitializer<DNAMaisConsultaContext>(null);
//        }

//        public DbSet<InfoUf> InfoUfs { get; set; }
//        public DbSet<InfoMunicipio> InfoMunicipios { get; set; }
//        public DbSet<InfoPessoaFisica> PessoasFisicas { get; set; }
//        public DbSet<InfoPessoaFisicaEndereco> EnderecosPessoasFisicas { get; set; }
//        public DbSet<InfoPessoaFisicaTelefone> TelefonesPessoasFisicas { get; set; }
//        public DbSet<InfoPessoaFisicaEmail> EmailsPessoasFisicas { get; set; }
//        public DbSet<InfoPessoaFisicaComplementar> PessoasFisicasDadosComplementares { get; set; }
//        public DbSet<InfoPessoaFisicaProfissional> PessoasFisicasDadosProfissionais { get; set; }
//        public DbSet<InfoPessoaJuridica> PessoasJuridicas { get; set; }
//        public DbSet<InfoPessoaJuridicaEndereco> EnderecosPessoasJuridicas { get; set; }
//        public DbSet<InfoPessoaJuridicaTelefone> TelefonesPessoasJuridicas { get; set; }
//        public DbSet<InfoPessoaJuridicaEmail> EmailsPessoasJuridicas { get; set; }
//    }
//}

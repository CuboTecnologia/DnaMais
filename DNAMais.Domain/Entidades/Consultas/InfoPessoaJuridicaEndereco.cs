﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_JURIDICA_ENDERECO", Schema = "DNAINFO")]
    public class InfoPessoaJuridicaEndereco
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PESSOA_JURIDICA_ENDERECO")]
        public long? Id { get; set; }

        [Column("ID_PESSOA_JURIDICA")]
        public long? IdPessoaJuridica { get; set; }
        [ForeignKey("IdPessoaJuridica")]
        public virtual InfoPessoaJuridica InfoPessoaJuridica { get; set; }

        [Column("DS_LOGRADOURO")]
        public string Logradouro { get; set; }

        [Column("NR_LOGRADOURO")]
        public string NumeroLogradouro { get; set; }

        [Column("DS_COMPLEMENTO")]
        public string Complemento { get; set; }

        [Column("NM_BAIRRO")]
        public string Bairro { get; set; }

        [Column("NM_CIDADE")]
        public string Cidade { get; set; }

        [Column("SG_UF")]
        public string SiglaUF { get; set; }
        [ForeignKey("SiglaUF")]
        public virtual InfoUf UF { get; set; }

        [Column("NR_CEP")]
        public string NumeroCEP { get; set; }

        [Column("ID_ORIGEM_DADOS")]
        public short? IdOrigemDados { get; set; }
        [ForeignKey("IdOrigemDados")]
        public virtual InfoOrigemDados OrigemDados { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        #endregion

        #region Construtor

        public InfoPessoaJuridicaEndereco()
        {
        }

        #endregion
    }
}

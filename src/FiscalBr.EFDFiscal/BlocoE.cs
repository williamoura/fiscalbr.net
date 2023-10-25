﻿using FiscalBr.Common;
using FiscalBr.Common.Sped;
using FiscalBr.Common.Sped.Interfaces;
using System;
using System.Collections.Generic;

namespace FiscalBr.EFDFiscal
{
    /// <summary>
    ///     BLOCO E: APURAÇÃO DO ICMS E DO IPI
    /// </summary>
    public class BlocoE : IBlocoSped
    {
        public RegistroE001 RegE001 { get; set; }
        public RegistroE990 RegE990 { get; set; }


        /// <summary>
        ///     REGISTRO E001: ABERTURA DO BLOCO E
        /// </summary>
        public class RegistroE001 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE001" />.
            /// </summary>
            public RegistroE001() : base("E001")
            {
            }

            /// <summary>
            ///   Inicializa uma nova instância da classe <see cref="RegistroE001"/>.
            /// </summary>
            public RegistroE001(IndMovimento indMovimento) : base("E001")
            {
                IndMov = indMovimento;
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE001" />.
            /// </summary>
            public RegistroE001(bool temMovimento) : base("E001")
            {
                IndMov = temMovimento ? IndMovimento.BlocoComDados : IndMovimento.BlocoSemDados;
            }

            /// <summary>
            ///     Indicador de movimento: 
            ///     0 - Bloco com dados informados; 
            ///     1 - Bloco sem dados informados.
            /// </summary>
            [SpedCampos(2, "IND_MOV", "N", 1, 0, true, 2)]
            public IndMovimento IndMov { get; set; }

            public List<RegistroE100> RegE100s { get; set; }
            public List<RegistroE200> RegE200s { get; set; }
            public List<RegistroE300> RegE300s { get; set; }
            public List<RegistroE500> RegE500s { get; set; }

            public RegistroE001 ComIndicadorMovimento(bool v)
            {
                IndMov = v ? IndMovimento.BlocoComDados : IndMovimento.BlocoSemDados;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO E100: PERÍODO DA APURAÇÃO DO ICMS.
        /// </summary>
        public class RegistroE100 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE100" />.
            /// </summary>
            public RegistroE100() : base("E100")
            {
            }

            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE100" />.
            /// </summary>
            public RegistroE100(
                DateTime dataInicial,
                DateTime dataFinal
                ) : base("E100")
            {
                DtIni = dataInicial;
                DtFin = dataFinal;
            }

            /// <summary>
            ///     Data inicial a que a apuração se refere.
            /// </summary>
            [SpedCampos(2, "DT_INI", "N", 8, 0, true, 2)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final a que a apuração se refere.
            /// </summary>
            [SpedCampos(3, "DT_FIN", "N", 8, 0, true, 2)]
            public DateTime DtFin { get; set; }

            public RegistroE110 RegE110 { get; set; }

            public RegistroE100 ComDataInicial(DateTime v)
            {
                DtIni = v;
                return this;
            }

            public RegistroE100 ComDataFinal(DateTime v)
            {
                DtFin = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO E110: APURAÇÃO DO ICMS – OPERAÇÕES PRÓPRIAS.
        /// </summary>
        public class RegistroE110 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE110" />.
            /// </summary>
            public RegistroE110() : base("E110")
            {
            }

            /// <summary>
            ///     Valor total dos débitos por "Saídas e prestações com débito do imposto"
            /// </summary>
            [SpedCampos(2, "VL_TOT_DEBITOS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotDebitos { get; set; }

            /// <summary>
            ///     Valor total dos ajustes a débito decorrentes do documento fiscal.
            /// </summary>
            [SpedCampos(3, "VL_AJ_DEBITOS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAjDebitos { get; set; }

            /// <summary>
            ///     Valor total de "Ajustes a débito"
            /// </summary>
            [SpedCampos(4, "VL_TOT_AJ_DEBITOS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotAjDebitos { get; set; }

            /// <summary>
            ///     Valor total de Ajustes “Estornos de créditos”
            /// </summary>
            [SpedCampos(5, "VL_ESTORNOS_CRED", "N", int.MaxValue, 2, true, 2)]
            public decimal VlEstornosCred { get; set; }

            /// <summary>
            ///     Valor total dos créditos por "Entradas e aquisições com crédito do imposto"
            /// </summary>
            [SpedCampos(6, "VL_TOT_CREDITOS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotCreditos { get; set; }

            /// <summary>
            ///     Valor total dos ajustes a crédito decorrentes do documento fiscal.
            /// </summary>
            [SpedCampos(7, "VL_AJ_CREDITOS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAjCreditos { get; set; }

            /// <summary>
            ///     Valor total de "Ajustes a crédito"
            /// </summary>
            [SpedCampos(8, "VL_TOT_AJ_CREDITOS", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotAjCreditos { get; set; }

            /// <summary>
            ///     Valor total de Ajustes “Estornos de Débitos”
            /// </summary>
            [SpedCampos(9, "VL_ESTORNOS_DEB", "N", int.MaxValue, 2, true, 2)]
            public decimal VlEstornosDeb { get; set; }

            /// <summary>
            ///     Valor total de "Saldo credor do período anterior"
            /// </summary>
            [SpedCampos(10, "VL_SLD_CREDOR_ANT", "N", int.MaxValue, 2, true, 2)]
            public decimal VlSldCredorAnt { get; set; }

            /// <summary>
            ///     Valor do saldo devedor apurado
            /// </summary>
            [SpedCampos(11, "VL_SLD_APURADO", "N", int.MaxValue, 2, true, 2)]
            public decimal VlSldApurado { get; set; }

            /// <summary>
            ///     Valor total de "Deduções"
            /// </summary>
            [SpedCampos(12, "VL_TOT_DED", "N", int.MaxValue, 2, true, 2)]
            public decimal VlTotDed { get; set; }

            /// <summary>
            ///     Valor total de "ICMS a recolher (11-12)
            /// </summary>
            [SpedCampos(13, "VL_ICMS_RECOLHER", "N", int.MaxValue, 2, true, 2)]
            public decimal VlIcmsRecolher { get; set; }

            /// <summary>
            ///     Valor total de "Saldo credor a transportar para o período seguinte”
            /// </summary>
            [SpedCampos(14, "VL_SLD_CREDOR_TRANSPORTAR", "N", int.MaxValue, 2, true, 2)]
            public decimal VlSldCredorTransportar { get; set; }

            /// <summary>
            ///     Valores recolhidos ou a recolher, extraapuração.
            /// </summary>
            [SpedCampos(15, "DEB_ESP", "N", int.MaxValue, 2, true, 2)]
            public decimal DebEsp { get; set; }

            public List<RegistroE111> RegE111s { get; set; }
            public List<RegistroE115> RegE115s { get; set; }
            public List<RegistroE116> RegE116s { get; set; }

            public RegistroE110 ComValorTotalDebitos(decimal v)
            {
                VlTotDebitos = v;
                return this;
            }

            public RegistroE110 ComValorAjusteDebitos(decimal v)
            {
                VlTotAjDebitos = v;
                return this;
            }

            public RegistroE110 ComValorTotalAjusteDebitos(decimal v)
            {
                VlTotAjDebitos = v;
                return this;
            }

            public RegistroE110 ComValorEstornoCreditos(decimal v)
            {
                VlEstornosCred = v;
                return this;
            }

            public RegistroE110 ComValorTotalCreditos(decimal v)
            {
                VlTotCreditos = v;
                return this;
            }

            public RegistroE110 ComValorAjusteCreditos(decimal v)
            {
                VlTotAjCreditos = v;
                return this;
            }

            public RegistroE110 ComValorTotalAjusteCreditos(decimal v)
            {
                VlTotAjCreditos = v;
                return this;
            }

            public RegistroE110 ComValorEstornoDebitos(decimal v)
            {
                VlEstornosDeb = v;
                return this;
            }

            public RegistroE110 ComSaldoCredorPeriodoAnterior(decimal v)
            {
                VlSldCredorAnt = v;
                return this;
            }

            public RegistroE110 ComSaldoDevedorApurado(decimal v)
            {
                VlSldApurado = v;
                return this;
            }

            public RegistroE110 ComDeducoes(decimal v)
            {
                VlTotDed = v;
                return this;
            }

            public RegistroE110 ComIcmsRecolher(decimal v)
            {
                VlIcmsRecolher = v;
                return this;
            }

            public RegistroE110 ComSaldoCredorTransportar(decimal v)
            {
                VlSldCredorTransportar = v;
                return this;
            }

            public RegistroE110 ComValoresRecolhidosRecolherExtra(decimal v)
            {
                DebEsp = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO E111: AJUSTE/BENEFÍCIO/INCENTIVO DA APURAÇÃO DO ICMS
        /// </summary>
        public class RegistroE111 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE111" />.
            /// </summary>
            public RegistroE111() : base("E111")
            {
            }

            /// <summary>
            ///     Código de ajuste da apuração e dedução
            /// </summary>
            [SpedCampos(2, "COD_AJ_APUR", "C", 8, 0, true, 2)]
            public string CodAjApur { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste da apuração
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", int.MaxValue, 0, false, 2)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Valor do ajuste da apuração
            /// </summary>
            [SpedCampos(4, "VL_AJ_APUR", "N", int.MaxValue, 2, true, 2)]
            public decimal VlAjApur { get; set; }

            public List<RegistroE112> RegE112s { get; set; }
            public List<RegistroE113> RegE113s { get; set; }

            public RegistroE111 ComCodigoAjuste(string v)
            {
                CodAjApur = v;
                return this;
            }

            public RegistroE111 ComDescricaoAjuste(string v)
            {
                DescrComplAj = v;
                return this;
            }

            public RegistroE111 ComValorAjuste(decimal v)
            {
                VlAjApur = v;
                return this;
            }
        }

        /// <summary>
        ///     REGISTRO E112: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA APURAÇÃO DO ICMS
        /// </summary>
        public class RegistroE112 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE112" />.
            /// </summary>
            public RegistroE112() : base("E112")
            {
            }

            /// <summary>
            ///     Número do documento de arrecadação estadual, se houver
            /// </summary>
            [SpedCampos(2, "NUM_DA", "C", 100, 0, false, 2)]
            public string NumDa { get; set; }

            /// <summary>
            ///     Número do processo ao qual o ajuste está vinculado, se houver
            /// </summary>
            [SpedCampos(3, "NUM_PROC", "C", 15, 0, false, 2)]
            [SpedCampos(3, "NUM_PROC", "C", 60, 0, false, 17)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador de origem do processo
            /// </summary>
            /// <remarks>
            ///     0 - Sefaz
            ///     1 - Justiça Federal
            ///     2 - Justiça Estadual
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(4, "IND_PROC", "C", 1, 0, false, 2)]
            public int? IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(5, "PROC", "C", 1024, 0, false, 2)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar
            /// </summary>
            [SpedCampos(6, "TXT_COMPL", "C", 1024, 0, false, 2)]
            public string TxtCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO E113: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA APURAÇÃO DO ICMS - IDENTIFICAÇÃO DOS DOCUMENTOS FISCAIS
        /// </summary>
        public class RegistroE113 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE113" />.
            /// </summary>
            public RegistroE113() : base("E113")
            {
            }

            /// <summary>
            ///     Código do participante
            /// </summary>
            /// <remarks>
            ///     - do emitente do documento ou do remetente das mercadorias, no caso das entradas;
            ///     - do adquirente, no caso de saídas
            /// </remarks>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(6, "NUM_DOC", "N", 9, 0, true, 2)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(7, "DT_DOC", "N", 8, 0, true, 2)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(8, "COD_ITEM", "C", 60, 0, false, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Valor do ajuste para operação/item
            /// </summary>
            [SpedCampos(9, "VL_AJ_ITEM", "N", 0, 2, true, 2)]
            public decimal VlAjItem { get; set; }

            /// <summary>
            ///     Chave do Documento Eletrônico
            /// </summary>
            [SpedCampos(10, "CHV_DOCe", "N", 44, 0, false, 2)]
            public string ChvDocE { get; set; }
        }

        /// <summary>
        ///     REGISTRO E115: INFORMAÇÕES ADICIONAIS DA APURAÇÃO - VALORES DECLARATÓRIOS
        /// </summary>
        public class RegistroE115 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE115" />.
            /// </summary>
            public RegistroE115() : base("E115")
            {
            }

            /// <summary>
            ///     Código da informação adicional conforme tabela a ser definida pelas SEFAZ
            /// </summary>
            [SpedCampos(2, "COD_INF_ADIC", "C", 8, 0, true, 2)]
            public string CodInfAdic { get; set; }

            /// <summary>
            ///     Valor referente à informação adicional
            /// </summary>
            [SpedCampos(3, "VL_INF_ADIC", "N", 0, 2, true, 2)]
            public decimal VlInfAdic { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste
            /// </summary>
            [SpedCampos(4, "DESCR_COMPL_AJ", "C", 1024, 0, true, 2)]
            public string DescrComplAj { get; set; }
        }

        /// <summary>
        ///     REGISTRO E116: OBRIGAÇÕES DO ICMS RECOLHIDO OU A RECOLHER – OPERAÇÕES PRÓPRIAS.
        /// </summary>
        public class RegistroE116 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE116" />.
            /// </summary>
            public RegistroE116() : base("E116")
            {
            }

            /// <summary>
            ///     Código da obrigação a recolher, conforme a Tabela 5.4
            /// </summary>
            [SpedCampos(2, "COD_OR", "C", 3, 0, true, 2)]
            public string CodOr { get; set; }

            /// <summary>
            ///     Valor da obrigação a recolher
            /// </summary>
            [SpedCampos(3, "VL_OR", "N", 0, 2, true, 2)]
            public decimal VlOr { get; set; }

            /// <summary>
            ///     Data de vencimento da obrigação
            /// </summary>
            [SpedCampos(4, "DT_VCTO", "N", 8, 0, true, 2)]
            public DateTime DtVcto { get; set; }

            /// <summary>
            ///     Código de receita referente à obrigação, próprio da unidade da federação, conforme legislação estadual.
            /// </summary>
            [SpedCampos(5, "COD_REC", "C", int.MaxValue, 0, true, 2)]
            public string CodRec { get; set; }

            /// <summary>
            ///     Número do processo ou auto de infração ao qual a obrigação está vinculada, se houver.
            /// </summary>
            [SpedCampos(6, "NUM_PROC", "C", 15, 0, false, 2)]
            [SpedCampos(6, "NUM_PROC", "C", 60, 0, false, 17)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador da origem do processo:
            ///     0- SEFAZ;
            ///     1- Justiça Federal;
            ///     2- Justiça Estadual;
            ///     9- Outros
            /// </summary>
            [SpedCampos(7, "IND_PROC", "C", 1, 0, false, 2)]
            public int? IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(8, "PROC", "C", int.MaxValue, 0, false, 2)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar das obrigações a recolher.
            /// </summary>
            [SpedCampos(9, "TXT_COMPL", "C", 0, 0, false, 2)]
            public string TxtCompl { get; set; }

            /// <summary>
            ///     Informe o mês de referência no formato "mmaaaa"
            /// </summary>
            [SpedCampos(10, "MES_REF", "MA", 6, 0, true, 4)]
            public DateTime MesRef { get; set; }
        }

        /// <summary>
        ///     REGISTRO E200: PERÍODO DE APURAÇÃO DO ICMS - SUBSTITUIÇÃO TRIBUTÁRIA
        /// </summary>
        public class RegistroE200 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE200" />.
            /// </summary>
            public RegistroE200() : base("E200")
            {
            }

            /// <summary>
            ///     Sigla da unidade da federação a que se refere a apuração do ICMS ST
            /// </summary>
            [SpedCampos(2, "UF", "C", 2, 0, true, 2)]
            public string Uf { get; set; }

            /// <summary>
            ///     Data inicial a que a apuração se refere
            /// </summary>
            [SpedCampos(3, "DT_INI", "N", 8, 0, true, 2)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final a que a apuação se refere
            /// </summary>
            [SpedCampos(4, "DT_FUN", "N", 8, 0, true, 2)]
            public DateTime DtFin { get; set; }

            public RegistroE210 RegE210 { get; set; }
        }

        /// <summary>
        ///     REGISTRO E210: APURAÇÃO DO ICMS - SUBSTITUIÇÃO TRIBUTÁRIA
        /// </summary>
        public class RegistroE210 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE210" />.
            /// </summary>
            public RegistroE210() : base("E210")
            {
            }

            /// <summary>
            ///     Indicador de movimento
            /// </summary>
            /// <remarks>
            ///     0 - Sem operações com ST
            ///     1 - Com operações de ST
            /// </remarks>
            [SpedCampos(2, "IND_MOV_ST", "C", 1, 0, true, 2)]
            public int IndMovSt { get; set; }

            /// <summary>
            ///     Valor do "Saldo credor do período anterior - Substituição Tributária"
            /// </summary>
            [SpedCampos(3, "VL_SLD_CRED_ANT_ST", "N", 0, 2, true, 2)]
            public decimal VlSldCredAntSt { get; set; }

            /// <summary>
            ///     Valor total do ICMS ST de devolução de mercadorias
            /// </summary>
            [SpedCampos(4, "VL_DEVOL_ST", "N", 0, 2, true, 2)]
            public decimal VlDevolSt { get; set; }

            /// <summary>
            ///     Valor total do ICMS ST de ressarcimentos
            /// </summary>
            [SpedCampos(5, "VL_RESSARC_ST", "N", 0, 2, true, 2)]
            public decimal VlRessarcSt { get; set; }

            /// <summary>
            ///     Valor total de Ajustes "Outros créditos ST" e "Estorno de débitos ST"
            /// </summary>
            [SpedCampos(6, "VL_OUT_CRED_ST", "N", 0, 2, true, 2)]
            public decimal VlOutCredSt { get; set; }

            /// <summary>
            ///     Valor total dos ajustes a crédito de ICMS ST, proveninetes de ajustes do documento fiscal
            /// </summary>
            [SpedCampos(7, "VL_AJ_CREDITOS_ST", "N", 0, 2, true, 2)]
            public decimal VlAjCreditosSt { get; set; }

            /// <summary>
            ///     Valor total do ICMS retido por substituição tributária
            /// </summary>
            [SpedCampos(8, "VL_RETENÇAO_ST", "N", 0, 2, true, 2)]
            public decimal VlRetencaoSt { get; set; }

            /// <summary>
            ///     Valor total dos ajustes "Outros débitos ST" e "Estorno de créditos ST"
            /// </summary>
            [SpedCampos(9, "VL_OUT_DEB_ST", "N", 0, 2, true, 2)]
            public decimal VlOutDebSt { get; set; }

            /// <summary>
            ///     Valor total dos ajustes a débito de ICMS ST, provenientes de ajustes do documento fiscal
            /// </summary>
            [SpedCampos(10, "VL_AJ_DEBITOS_ST", "N", 0, 2, true, 2)]
            public decimal VlAjDebitosSt { get; set; }

            /// <summary>
            ///     Valor total do saldo devedor antes das deduções
            /// </summary>
            [SpedCampos(11, "VL_SLD_DEV_ANT_ST", "N", 0, 2, true, 2)]
            public decimal VlSldDevAntSt { get; set; }

            /// <summary>
            ///     Valor total dos ajustes "Deduções ST"
            /// </summary>
            [SpedCampos(12, "VL_DEDUÇÕES_ST", "N", 0, 2, true, 2)]
            public decimal VlDeducoesSt { get; set; }

            /// <summary>
            ///     Imposto a recolher ST (11-12)
            /// </summary>
            [SpedCampos(13, "VL_ICMS_RECOL_ST", "N", 0, 2, true, 2)]
            public decimal VlIcmsRecolSt { get; set; }

            /// <summary>
            ///     Saldo credor de ST a transportar para o período seguinte
            /// </summary>
            [SpedCampos(14, "VL_SLD_CRED_ST_TRANSPORTAR", "N", 0, 2, true, 2)]
            public decimal VlSldCredStTransportar { get; set; }

            /// <summary>
            ///     Valores recohidos ou a recolher, extra-apuração
            /// </summary>
            [SpedCampos(15, "DEB_ESP_ST", "N", 0, 2, true, 2)]
            public decimal DebEspSt { get; set; }

            public List<RegistroE220> RegE220s { get; set; }
            public List<RegistroE250> RegE250s { get; set; }
        }

        /// <summary>
        ///     REGISTRO E220: AJUSTE/BENEFICIO/INCENTIVO DA APURAÇÃO DO ICMS SUBSTITUIÇÃO TRIBUTÁRIA
        /// </summary>
        public class RegistroE220 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE220" />.
            /// </summary>
            public RegistroE220() : base("E220")
            {
            }

            /// <summary>
            ///     Código de ajuste da apuração e dedução
            /// </summary>
            [SpedCampos(2, "COD_AJ_APUR", "C", 8, 0, true, 2)]
            public string CodAjApur { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste da apuração
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 1024, 0, false, 2)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Valor do ajuste da apuração
            /// </summary>
            [SpedCampos(4, "VL_AJ_APUR", "N", 0, 2, true, 2)]
            public decimal VlAjApur { get; set; }

            public List<RegistroE230> RegE230s { get; set; }
            public List<RegistroE240> RegE240s { get; set; }
        }

        /// <summary>
        ///     REGISTRO E230: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA APURAÇÃO DO ICMS SUBSTITUIÇÃO TRIBUTÁRIA
        /// </summary>
        public class RegistroE230 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE230" />.
            /// </summary>
            public RegistroE230() : base("E230")
            {
            }

            /// <summary>
            ///     Número do documento de arrecadação estadual, se houver
            /// </summary>
            [SpedCampos(2, "NUM_DA", "C", 100, 0, false, 2)]
            public string NumDa { get; set; }

            /// <summary>
            ///     Número do processo ao qual o ajuste está vinculado, se houver
            /// </summary>
            [SpedCampos(3, "NUM_PROC", "C", 15, 0, false, 2)]
            [SpedCampos(3, "NUM_PROC", "C", 60, 0, false, 17)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador de origem do processo
            /// </summary>
            /// <remarks>
            ///     0 - Sefaz
            ///     1 - Justiça Federal
            ///     2 - Justiça Estadual
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(4, "IND_PROC", "N", 1, 0, false, 2)]
            public int? IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(5, "PROC", "C", 1024, 0, false, 2)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar
            /// </summary>
            [SpedCampos(6, "TXT_COMPL", "C", 1024, 0, false, 2)]
            public string TxtCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO E240: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA APURAÇÃO DO ICMS SUBSTITUIÇÃO TRIBUTÁRIA - IDENTIFICAÇÃO DOS
        ///     DOCUMENTOS FISCAIS
        /// </summary>
        public class RegistroE240 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE240" />.
            /// </summary>
            public RegistroE240() : base("E240")
            {
            }

            /// <summary>
            ///     Código do participante
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(6, "NUM_DOC", "N", 9, 0, true, 2)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(7, "DT_DOC", "N", 8, 0, true, 2)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(8, "COD_ITEM", "C", 60, 0, false, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Valor do ajuste para operação/item
            /// </summary>
            [SpedCampos(9, "VL_AJ_ITEM", "N", 0, 2, true, 2)]
            public decimal VlAjItem { get; set; }
        }

        /// <summary>
        ///     REGISTRO E250: OBRIGAÇÕES DO ICMS RECOLHIDO OU A RECOLHER - SUBSTITUIÇÃO TRIBUTÁRIA
        /// </summary>
        public class RegistroE250 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE250" />.
            /// </summary>
            public RegistroE250() : base("E250")
            {
            }

            /// <summary>
            ///     Código da obrigação a recolher
            /// </summary>
            [SpedCampos(2, "COD_OR", "C", 3, 0, true, 2)]
            public string CodOr { get; set; }

            /// <summary>
            ///     Valor da obrigação ICMS ST a recolher
            /// </summary>
            [SpedCampos(3, "VL_OR", "N", 0, 2, true, 2)]
            public decimal VlOr { get; set; }

            /// <summary>
            ///     Data de vencimento da obrigação
            /// </summary>
            [SpedCampos(4, "DT_VCTO", "N", 8, 0, true, 2)]
            public DateTime DtVcto { get; set; }

            /// <summary>
            ///     Código de receita referente à obrigação, próprio da unidade da federação do contribuinte substituído
            /// </summary>
            [SpedCampos(5, "COD_REC", "C", 100, 0, true, 2)]
            public string CodRec { get; set; }

            /// <summary>
            ///     Número do processo ou auto de infração ao qual a obrigaçaõ está vinculada, se houver
            /// </summary>
            [SpedCampos(6, "NUM_PROC", "C", 15, 0, false, 2)]
            [SpedCampos(6, "NUM_PROC", "C", 60, 0, false, 17)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador da origem do processo
            /// </summary>
            /// <remarks>
            ///     0 - SEFAZ
            ///     1 - Justiça Federal
            ///     2 - Justiça Estadual
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(7, "IND_PROC", "C", 1, 0, false, 2)]
            public int? IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(8, "PROC", "C", 1024, 0, false, 2)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar das obrigações a recolher
            /// </summary>
            [SpedCampos(9, "TXT_COMPL", "C", 1024, 0, false, 2)]
            public string TxtCompl { get; set; }

            /// <summary>
            ///     Informe o mês de referência
            /// </summary>
            [SpedCampos(10, "MES_REF", "MA", 6, 0, true, 4)]
            public DateTime MesRef { get; set; }
        }

        /// <summary>
        ///     REGISTRO E300: PERÍODO DE APURAÇÃO DO ICMS DIFERENCIAL DE ALÍQUOTA - UF ORIGEM/DESTINO EC 87/15
        /// </summary>
        public class RegistroE300 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE300" />.
            /// </summary>
            public RegistroE300() : base("E300")
            {
            }

            /// <summary>
            ///     Sigla da unidade da federação a que se refere a apuração do ICMS Diferencial de Alíquota da UF de Origem/Destino
            /// </summary>
            [SpedCampos(2, "UF", "C", 2, 0, true, 2)]
            public string Uf { get; set; }

            /// <summary>
            ///     Data inicial a que a apuração se refere
            /// </summary>
            [SpedCampos(3, "DT_INI", "N", 8, 0, true, 2)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final a que a apuração se refere
            /// </summary>
            [SpedCampos(4, "DT_FIN", "N", 8, 0, true, 2)]
            public DateTime DtFin { get; set; }

            public RegistroE310 RegE310 { get; set; }
        }

        /// <summary>
        ///     REGISTRO E310: APURAÇÃO DO ICMS DIFERENCIAL DE ALÍQUOTA - UF ORIGEM/DESTINO EC 87/15
        /// </summary>
        public class RegistroE310 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE310" />.
            /// </summary>
            public RegistroE310() : base("E310")
            {
            }

            /// <summary>
            ///     Indicador de movimento
            /// </summary>
            /// <remarks>
            ///     0 - Sem operações com ICMS Diferencial de Alíquota da UF de Origem/Destino
            ///     1 - Com operações de ICMS Diferencial de Alíquota da UF de Origem/Destino
            /// </remarks>
            [SpedCampos(2, "IND_MOV_DIFAL", "C", 1, 0, true, 2)]
            public int IndMovDifal { get; set; }

            /// <summary>
            ///     Valor do "Saldo credor do período anterior - ICMS Diferencial de Alíquota da UF de Origem/Destino"
            /// </summary>
            [SpedCampos(3, "VL_SLD_CRED_ANT_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlSldCredAntDifal { get; set; }

            /// <summary>
            ///     Valor total dos débitos por "Saídas e prestações com débito do ICMS referente ao diferencial de alíquota devido à
            ///     UF do Remetente/Destinatário"
            /// </summary>
            [SpedCampos(4, "VL_TOT_DEBITOS_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlTotDebitosDifal { get; set; }

            /// <summary>
            ///     Valor total dos ajustes "Outros débitos ICMS Diferencial de Alíquota da UF de Origem/Destino" e "Estorno de
            ///     créditos ICMS Diferencial de Alíquota da UF de Origem/Destino"
            /// </summary>
            [SpedCampos(5, "VL_OUT_DEB_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlOutDebDifal { get; set; }

            /// <summary>
            ///     Valor total dos créditos do ICMS referente ao diferencial de alíquota devido à UF de Origem/Destino
            /// </summary>
            [SpedCampos(6, "VL_TOT_CREDITOS_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlTotCreditosDifal { get; set; }

            /// <summary>
            ///     Valor total de ajustes "Outros créditos ICMS diferencial de Alíquota da UF de Origem/Destino" e "Estorno de débitos
            ///     ICMS Diferencial de Alíquota da UF de Origem/Destino"
            /// </summary>
            [SpedCampos(7, "VL_OUT_CRED_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlOutCredDifal { get; set; }

            /// <summary>
            ///     Valor total de "Saldo devedor ICMS Diferencial de Alíquota da UF de Origem/Destino antes das deduções"
            /// </summary>
            [SpedCampos(8, "VL_SLD_DEV_ANT_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlSldDevAntDifal { get; set; }

            /// <summary>
            ///     Valor total dos ajustes "Deduções ICMS Diferencial de Alíquota da UF de Origem/Destino"
            /// </summary>
            [SpedCampos(9, "VL_DEDUÇÕES_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlDeducoesDifal { get; set; }

            /// <summary>
            ///     Valor recolhido ou a recolher referente ICMS Diferencial de Alíquota da UF de de Origem/Destino (08-09)
            /// </summary>
            [SpedCampos(10, "VL_RECOL_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlRecolDifal { get; set; }

            /// <summary>
            ///     Saldo credor a transportar para o período seguinte referente ao ICMS Diferencial de Alíquota da UF de Origem/Destino
            /// </summary>
            [SpedCampos(11, "VL_SLD_CRED_TRANSPORTAR_DIFAL", "N", 0, 2, true, 2)]
            public decimal VlSldCredTransportarDifal { get; set; }

            /// <summary>
            ///      Valor recolhido ou a recolher, estra-apuração - ICMS Diferencial de Alíquota da UF de de Origem/Destino
            /// </summary>
            [SpedCampos(12, "DEB_ESP_DIFAL", "N", 0, 2, true, 2)]
            public decimal DebEspDifal { get; set; }

            /// <summary>
            ///     Valor do "Slado credor de período anterior - FCP"
            /// </summary>
            [SpedCampos(13, "VL_SLD_CRED_ANT_FCP", "N", 0, 2, true, 2)]
            public decimal VlSldCredAntFcp { get; set; }

            /// <summary>
            ///     Valor total dos débitos FCP por "Saídas e prestações"
            /// </summary>
            [SpedCampos(14, "VL_TOT_DEB_FCP", "N", 0, 2, true, 2)]
            public decimal VlTotDebFcp { get; set; }

            /// <summary>
            ///     Valor total dos ajustes "Outros débitos FCP" e "Estornos de créditos FCP"
            /// </summary>
            [SpedCampos(15, "VL_OUT_DEB_FCP", "N", 0, 2, true, 2)]
            public decimal VlOutDebFcp { get; set; }

            /// <summary>
            ///     Valor total dos créditos FCP por Entradas
            /// </summary>
            [SpedCampos(16, "VL_TOT_CRED_FCP", "N", 0, 2, true, 2)]
            public decimal VlTotCredFcp { get; set; }

            /// <summary>
            ///     Valor total dos ajustes "Outros créditos FCP" e "Estornos de débitos FCP"
            /// </summary>
            [SpedCampos(17, "VL_OUT_CRED_FCP", "N", 0, 2, true, 2)]
            public decimal VlOutCredFcp { get; set; }

            /// <summary>
            ///     Valor total de Saldo devedor FCP antes das deduções
            /// </summary>
            [SpedCampos(18, "VL_SLD_DEV_ANT_FCP", "N", 0, 2, true, 2)]
            public decimal VlSldDevAntFcp { get; set; }

            /// <summary>
            ///     Valor total das deduções "FCP"
            /// </summary>
            [SpedCampos(19, "VL_DEDUÇÕES_FCP", "N", 0, 2, true, 2)]
            public decimal VlDeduoesFcp { get; set; }

            /// <summary>
            ///     Valor recolhido ou a recolher referente ao FCP (18-19)
            /// </summary>
            [SpedCampos(20, "VL_RECOL_FCP", "N", 0, 2, true, 2)]
            public decimal VlRecolFCP { get; set; }

            /// <summary>
            ///     Saldo credor a transportar para o período seguinte referente ao FCP
            /// </summary>
            [SpedCampos(21, "VL_SLD_CRED_TRANSPORTAR_FCP", "N", 0, 2, true, 2)]
            public decimal VlSldCredTransportarFcp { get; set; }

            /// <summary>
            ///     Valores recolhidos ou a recolher, extra-apuração - FCP
            /// </summary>
            [SpedCampos(22, "DEB_ESP_FCP", "N", 0, 2, true, 2)]
            public decimal DebEspFcp { get; set; }

            public List<RegistroE311> RegE311s { get; set; }
            public List<RegistroE316> RegE316s { get; set; }
        }

        /// <summary>
        ///     REGISTRO E311: AJUSTE/BENEFICIO/INCENTIVO DA APURAÇÃO DO ICMS DIFERENCIAL DE ALÍQUOTA UF ORIGEM/DESTINO EC 87/15
        /// </summary>
        public class RegistroE311 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE311" />.
            /// </summary>
            public RegistroE311() : base("E311")
            {
            }

            /// <summary>
            ///     Código de ajuste da apuração e dedução
            /// </summary>
            [SpedCampos(2, "COD_AJ_APUR", "C", 8, 0, true, 2)]
            public string CodAjApur { get; set; }

            /// <summary>
            ///     Descrição complementar do ajuste da apuração
            /// </summary>
            [SpedCampos(3, "DESCR_COMPL_AJ", "C", 1024, 0, false, 2)]
            public string DescrComplAj { get; set; }

            /// <summary>
            ///     Valor do ajuste da apuração
            /// </summary>
            [SpedCampos(4, "VL_AJ_APUR", "N", 0, 2, true, 2)]
            public decimal VlAjApur { get; set; }

            public List<RegistroE312> RegE312s { get; set; }
            public List<RegistroE313> RegE313s { get; set; }
        }

        /// <summary>
        ///     REGISTRO E312: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA APURAÇÃO DO ICMS DIFERENCIAL DE ALÍQUOTA UF ORIGEM/DESTINO EC
        ///     87/15
        /// </summary>
        public class RegistroE312 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE312" />.
            /// </summary>
            public RegistroE312() : base("E312")
            {
            }

            /// <summary>
            ///     Número do documento de arrecadação estadual, se houver
            /// </summary>
            [SpedCampos(2, "NUM_DA", "C", 100, 0, false, 2)]
            public string NumDa { get; set; }

            /// <summary>
            ///     Número do processo ao qual o ajuste está vinculado, se houver
            /// </summary>
            [SpedCampos(3, "NUM_PROC", "C", 15, 0, false, 2)]
            [SpedCampos(3, "NUM_PROC", "C", 60, 0, false, 17)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador da origem do processo
            /// </summary>
            /// <remarks>
            ///     0 - Sefaz
            ///     1 - Justiça Federal
            ///     2 - Justiça Estadual
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(4, "IND_PROC", "N", 1, 0, false, 2)]
            public int? IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(5, "PROC", "C", 1024, 0, false, 2)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar
            /// </summary>
            [SpedCampos(6, "TXT_COMPL", "C", 1024, 0, false, 2)]
            public string TxtCompl { get; set; }
        }

        /// <summary>
        ///     REGISTRO E313: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA APURAÇÃ DO ICMS DIFERENCIAL DE ALÍQUOTA UF ORIGEM/DESTINO EC
        ///     87/15 IDENTIFICAÇÃO DOS DOCUMENTOS FISCAIS
        /// </summary>
        public class RegistroE313 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE313" />.
            /// </summary>
            public RegistroE313() : base("E313")
            {
            }

            /// <summary>
            ///     Código do participante
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, true, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "N", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(6, "NUM_DOC", "N", 9, 0, true, 2)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Chave do documento eletrônico
            /// </summary>
            [SpedCampos(7, "CHV_DOCe", "N", 44, 0, false, 2)]
            public string ChvDocE { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(8, "DT_DOC", "N", 8, 0, true, 2)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            ///     Código do item
            /// </summary>
            [SpedCampos(9, "COD_ITEM", "C", 60, 0, false, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Valor do ajuste para a operação/item
            /// </summary>
            [SpedCampos(10, "VL_AJ_ITEM", "N", 0, 2, true, 2)]
            public decimal VlAjItem { get; set; }
        }

        /// <summary>
        ///     REGISTRO E316: OBRIGAÇÕES DO ICMS RECOLHIDO OU A RECOLHER - DIFERENCIAL DE ALÍQUOTA UF ORIGEM/DESTINO EC 87/15
        /// </summary>
        public class RegistroE316 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE316" />.
            /// </summary>
            public RegistroE316() : base("E316")
            {
            }

            /// <summary>
            ///     Código da obrigação recolhida ou a recolher
            /// </summary>
            [SpedCampos(2, "COD_OR", "C", 3, 0, true, 2)]
            public string CodOr { get; set; }

            /// <summary>
            ///     Valor da obrigação recolhida ou a recolher
            /// </summary>
            [SpedCampos(3, "VL_OR", "N", 0, 2, true, 2)]
            public decimal VlOr { get; set; }

            /// <summary>
            ///     Data de vencimento da obrigação
            /// </summary>
            [SpedCampos(4, "DT_VCTO", "N", 8, 0, true, 2)]
            public DateTime DtVcto { get; set; }

            /// <summary>
            ///     Código da receita referente à obrigação, próprio da unidade da federação da origem/destino, conforme legislação
            ///     estadual
            /// </summary>
            [SpedCampos(5, "COD_REC", "C", 100, 0, true, 2)]
            public string CodRec { get; set; }

            /// <summary>
            ///     Número do processou ou auto de infração ao qual a obrigação está vinculada, se houver
            /// </summary>
            [SpedCampos(6, "NUM_PROC", "C", 15, 0, false, 2)]
            [SpedCampos(6, "NUM_PROC", "C", 60, 0, false, 17)]
            public string NumProc { get; set; }

            /// <summary>
            ///     Indicador de origem do processo
            /// </summary>
            /// <remarks>
            ///     0 - SEFAZ
            ///     1 - Justiça Federal
            ///     2 - Justiça Estadual
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(7, "IND_PROC", "C", 1, 0, false, 2)]
            public int? IndProc { get; set; }

            /// <summary>
            ///     Descrição resumida do processo que embasou o lançamento
            /// </summary>
            [SpedCampos(8, "PROC", "C", 1024, 0, false, 2)]
            public string Proc { get; set; }

            /// <summary>
            ///     Descrição complementar das obrigações recolhidas ou a recolher
            /// </summary>
            [SpedCampos(9, "TXT_COMPL", "C", 1024, 0, false, 2)]
            public string TxtCompl { get; set; }

            /// <summary>
            ///     Informe o mês de referência
            /// </summary>
            [SpedCampos(10, "MES_REF", "MA", 6, 0, true, 2)]
            public DateTime MesRef { get; set; }
        }

        /// <summary>
        ///     REGISTRO E500: PERÍODO DE APURAÇÃO DO IPI
        /// </summary>
        public class RegistroE500 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE500" />.
            /// </summary>
            public RegistroE500() : base("E500")
            {
            }

            /// <summary>
            ///     Indicador de período de apuração do IPI
            /// </summary>
            /// <remarks>
            ///     0 - Mensal
            ///     1 - Decendial
            /// </remarks>
            [SpedCampos(2, "IND_APUR", "C", 1, 0, true, 2)]
            public string IndApur { get; set; }

            /// <summary>
            ///     Data inicial a que a apuração se refere
            /// </summary>
            [SpedCampos(3, "DT_INI", "N", 8, 0, true, 2)]
            public DateTime DtIni { get; set; }

            /// <summary>
            ///     Data final a que a apuração se refere
            /// </summary>
            [SpedCampos(4, "DT_FIN", "N", 8, 0, true, 2)]
            public DateTime DtFin { get; set; }

            public List<RegistroE510> RegE510s { get; set; }
            public RegistroE520 RegE520 { get; set; }
        }

        /// <summary>
        ///     REGISTRO E510: CONSOLIDAÇÃO DOS VALORES DO IPI
        /// </summary>
        public class RegistroE510 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE510" />.
            /// </summary>
            public RegistroE510() : base("E510")
            {
            }

            /// <summary>
            ///     Código fiscal de operação e prestação do agrupamento de itens
            /// </summary>
            [SpedCampos(2, "CFOP", "N", 4, 0, true, 2)]
            public int Cfop { get; set; }

            /// <summary>
            ///     Código da situação tributária referente ao IPI
            /// </summary>
            [SpedCampos(3, "CST_IPI", "C", 2, 0, true, 2)]
            public int CstIpi { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor Contábil" referente ao CFOP e ao Código de Tributação do IPI
            /// </summary>
            [SpedCampos(4, "VL_CONT_IPI", "N", 0, 2, true, 2)]
            public decimal VlContIpi { get; set; }

            /// <summary>
            ///     Parcela correspondente ao "Valor da base de cálculo do IPI" referente ao CFOP e ao Código de Tributação do IPI,
            ///     para operação tributadas
            /// </summary>
            [SpedCampos(5, "VL_BC_IPI", "N", 0, 2, true, 2)]
            public decimal VlBcIpi { get; set; }

            /// <summary>
            ///     Parcela correspondete ao "Valor do IPI" referente ao CFOP e ao Código de Tributação do IPI, para operações
            ///     tributadas
            /// </summary>
            [SpedCampos(6, "VL_IPI", "N", 0, 2, true, 2)]
            public decimal VlIpi { get; set; }
        }

        /// <summary>
        ///     REGISTRO E50: APURAÇÃO DO IPI
        /// </summary>
        public class RegistroE520 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE520" />.
            /// </summary>
            public RegistroE520() : base("E520")
            {
            }

            /// <summary>
            ///     Saldo credor do IPI transferido do período anterior
            /// </summary>
            [SpedCampos(2, "VL_SD_ANT_IPI", "N", 0, 2, true, 2)]
            public decimal VlSdAntIpi { get; set; }

            /// <summary>
            ///     Valor total dos débitos por "Saídas com débito do imposto"
            /// </summary>
            [SpedCampos(3, "VL_DEB_IPI", "N", 0, 2, true, 2)]
            public decimal VlDebIpi { get; set; }

            /// <summary>
            ///     Valor total dos créditos por "Entradas e aquisições com crédito do imposto"
            /// </summary>
            [SpedCampos(4, "VL_CRED_IPI", "N", 0, 2, true, 2)]
            public decimal VlCredIpi { get; set; }

            /// <summary>
            ///     Valor de "Outros débitos" do IPI (inclusive estornos de crédito)
            /// </summary>
            [SpedCampos(5, "VL_OD_IPI", "N", 0, 2, true, 2)]
            public decimal VlOdIpi { get; set; }

            /// <summary>
            ///     Valor de "Outros créditos" do IPI (inclusive estornos de débitos)
            /// </summary>
            [SpedCampos(6, "VL_OC_IPI", "N", 0, 2, true, 2)]
            public decimal VlOcIpi { get; set; }

            /// <summary>
            ///     Valor do saldo credor do IPI a transportar para o período seguinte
            /// </summary>
            [SpedCampos(7, "VL_SC_IPI", "N", 0, 2, true, 2)]
            public decimal VlScIpi { get; set; }

            /// <summary>
            ///     Valor do saldo devedor do IPI a recolher
            /// </summary>
            [SpedCampos(8, "VL_SD_IPI", "N", 0, 2, true, 2)]
            public decimal VlSdIpi { get; set; }

            public List<RegistroE530> RegE530s { get; set; }
        }

        /// <summary>
        ///     REGISTRO E530: AJUSTES DA APURAÇÃO DO IPI
        /// </summary>
        public class RegistroE530 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE530" />.
            /// </summary>
            public RegistroE530() : base("E530")
            {
            }

            /// <summary>
            ///     Indicador do tipo de ajuste
            /// </summary>
            /// <remarks>
            ///     0 - Ajuste a débito
            ///     1 - Ajuste a crédito
            /// </remarks>
            [SpedCampos(2, "IND_AJ", "C", 1, 0, true, 2)]
            public int IndAj { get; set; }

            /// <summary>
            ///     Valor do ajuste
            /// </summary>
            [SpedCampos(3, "VL_AJ", "N", 0, 2, true, 2)]
            public decimal VlAj { get; set; }

            /// <summary>
            ///     Código do ajuste da apuração
            /// </summary>
            [SpedCampos(4, "COD_AJ", "C", 3, 0, true, 2)]
            public string CodAj { get; set; }

            /// <summary>
            ///     Indicador da origem do documento vinculado ao ajuste
            /// </summary>
            /// <remarks>
            ///     0 - Processo Judicial
            ///     1 - Processo Administrativo
            ///     2 - PER/DCOMP
            ///     9 - Outros
            /// </remarks>
            [SpedCampos(5, "IND_DOC", "C", 1, 0, false, 2)]
            public int? IndDoc { get; set; }

            /// <summary>
            ///     Número do documento/processo/declaração ao qual o ajuste está vinculado, se houver
            /// </summary>
            [SpedCampos(6, "NUM_DOC", "C", 1024, 0, false, 2)]
            public string NumDoc { get; set; }

            /// <summary>
            ///     Descrição detalhada do ajuste, com citação dos documentos fiscais
            /// </summary>
            [SpedCampos(7, "DESCR_AJ", "C", 1024, 0, true, 2)]
            public string DescrAj { get; set; }

            public List<RegistroE531> RegE531s { get; set; }
        }

        /// <summary>
        ///     REGISTRO E531: INFORMAÇÕES ADICIONAIS DOS AJUSTES DA APURAÇÃO DO IPI – IDENTIFICAÇÃO DOS DOCUMENTOS FISCAIS(01 e 55)
        /// </summary>
        public class RegistroE531 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE531" />.
            /// </summary>
            public RegistroE531() : base("E531")
            {
            }

            /// <summary>
            ///     Código do participante (campo 02 do Registro 0150):
            ///     - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
            ///     - do adquirente, no caso de saídas.
            /// </summary>
            [SpedCampos(2, "COD_PART", "C", 60, 0, false, 2)]
            public string CodPart { get; set; }

            /// <summary>
            ///     Código do modelo do documento fiscal, conforme a Tabela 4.1.1
            /// </summary>
            [SpedCampos(3, "COD_MOD", "C", 2, 0, true, 2)]
            public string CodMod { get; set; }

            /// <summary>
            ///     Série do documento fiscal
            /// </summary>
            [SpedCampos(4, "SER", "C", 4, 0, false, 2)]
            public string Ser { get; set; }

            /// <summary>
            ///     Subsérie do documento fiscal
            /// </summary>
            [SpedCampos(5, "SUB", "C", 3, 0, false, 2)]
            public string Sub { get; set; }

            /// <summary>
            ///     Número do documento fiscal
            /// </summary>
            [SpedCampos(6, "NUM_DOC", "N", 9, 0, true, 2)]
            public long NumDoc { get; set; }

            /// <summary>
            ///     Data da emissão do documento fiscal
            /// </summary>
            [SpedCampos(7, "DT_DOC", "N", 8, 0, true, 2)]
            public DateTime DtDoc { get; set; }

            /// <summary>
            /// Codigo do item (campo 02 do Registro 0200)
            /// </summary>
            [SpedCampos(8, "COD_ITEM", "C", 60, 0, true, 2)]
            public string CodItem { get; set; }

            /// <summary>
            ///     Valor do ajuste para operação/item
            /// </summary>
            [SpedCampos(9, "VL_AJ_ITEM", "N", 0, 2, true, 2)]
            public decimal VlAjItem { get; set; }

            /// <summary>
            ///     Chave da nota fiscal eletrônica (modelo 55)
            /// </summary>
            [SpedCampos(10, "CHV_NFE", "N", 44, 0, false, 2)]
            public string ChvNfe { get; set; }
        }

        /// <summary>
        ///     REGISTRO E990: ENCERRAMENTO DO BLOCO E
        /// </summary>
        public class RegistroE990 : RegistroSped
        {
            /// <summary>
            ///     Inicializa uma nova instância da classe <see cref="RegistroE990" />.
            /// </summary>
            public RegistroE990() : base("E990")
            {
            }

            /// <summary>
            ///     Quantidade total de linhas do Bloco E
            /// </summary>
            [SpedCampos(2, "QTD_LIN_E", "N", int.MaxValue, 0, true, 2)]
            public int QtdLinE { get; set; }
        }
    }
}

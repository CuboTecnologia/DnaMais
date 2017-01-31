using System;
using System.Collections.Generic;
using System.Text;

namespace DNAMais.Framework
{
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Formatação Genérica
        /// </summary>
        /// <param name="valor">Valor a ser formatado</param>
        /// <param name="mascara">Máscara de formatação</param>
        /// <returns></returns>
        private static string Formatar(string valor, string mascara)
        {
            StringBuilder dado = new StringBuilder();
            // remove caracteres nao numericos
            foreach (char c in valor)
            {
                if (Char.IsNumber(c))
                    dado.Append(c);
            }

            int indMascara = mascara.Length;
            int indCampo = dado.Length;

            for (; indCampo > 0 && indMascara > 0; )
            {
                if (mascara[--indMascara] == '#')
                    indCampo--;
            }

            StringBuilder saida = new StringBuilder();
            for (; indMascara < mascara.Length; indMascara++)
                saida.Append((mascara[indMascara] == '#') ? dado[indCampo++] : mascara[indMascara]);

            return saida.ToString();
        }

        public static string FormatarHora(this DateTime data)
        {
            return data.ToString("HH:mm");
        }

        public static string FormatarHora(this DateTime? data)
        {
            return ((DateTime)data).ToString("HH:mm");
        }

        public static string FormatarCEP(this string cep)
        {
            return Formatar(cep, "######-###");
        }

        public static string FormatarSexo(this string sexo)
        {
            if (sexo == null)
            {
                return "Indisponível";
            }

            return sexo == "M" ? "Masculino" : "Feminino";
        }

        public static string FormatarCPF(this string cpf)
        {
            if (cpf == null) return cpf;

            return Formatar(cpf, "###.###.###-##");
        }

        public static string FormatarCNPJ(this string cnpj)
        {
            if (cnpj == null) return cnpj;

            return Formatar(cnpj, "##.###.###/####-##");
        }

        public static string FormatarTelefone(this string fone, string ddd)
        {
            string foneCompleto = string.Empty;

            if (fone != null)
            {
                if (fone.Length == 9)
                {
                    foneCompleto = ddd + "." + Formatar(fone, "#####-####");
                }
                else if (fone.Length <= 8)
                {
                    foneCompleto = ddd + "." + Formatar(fone, "####-####");
                }
                else
                {
                    foneCompleto = ddd + "." + Formatar(fone, "########-####");
                }
            }
            return foneCompleto;
        }

        public static string FormatarTelefone(this string fone)
        {
            string foneCompleto = string.Empty;

            if (fone != null)
            {
                if (fone.Length == 9)
                {
                    foneCompleto = Formatar(fone, "#####-####");
                }
                else if (fone.Length <= 8)
                {
                    foneCompleto = Formatar(fone, "####-####");
                }
                else
                {
                    foneCompleto = Formatar(fone, "########-####");
                }
            }
            return foneCompleto;
        }

        public static string FormatarDataHora(this DateTime data)
        {
            return data == DateTime.MinValue ? string.Empty : data.ToString("dd/MM/yyyy HH:mm");
        }

        public static string FormatarDataHora(this DateTime? data)
        {
            return data == null ? string.Empty : (data == DateTime.MinValue ? string.Empty : ((DateTime)data).ToString("dd/MM/yyyy HH:mm"));
        }

        public static string FormatarData(this DateTime data)
        {
            return data == DateTime.MinValue ? string.Empty : data.ToString("dd/MM/yyyy");
        }

        public static string FormatarData(this DateTime? data)
        {
            return data == null ? string.Empty : (data == DateTime.MinValue ? string.Empty : ((DateTime)data).ToString("dd/MM/yyyy"));
        }

        public static string CalcularSigno(this DateTime? data)
        {
            if (data == null)
            {
                return "Indisponível";
            }

            int dia = data.Value.Day;

            switch (data.Value.Month)
            {
                case 1:
                    if (dia <= 20)
                        return "Capricórnio";
                    else
                        return "Aquário";
                case 2:
                    if (dia <= 19)
                        return "Aquário";
                    else
                        return "Peixes";
                case 3:
                    if (dia <= 20)
                        return "Peixes";
                    else
                        return "Áries";
                case 4:
                    if (dia <= 20)
                        return "Áries";
                    else
                        return "Touro";
                case 5:
                    if (dia <= 20)
                        return "Touro";
                    else
                        return "Gêmeos";
                case 6:
                    if (dia <= 20)
                        return "Gêmeos";
                    else
                        return "Câncer";
                case 7:
                    if (dia <= 21)
                        return "Câncer";
                    else
                        return "Leão";
                case 8:
                    if (dia <= 22)
                        return "Leão";
                    else
                        return "Virgem";
                case 9:
                    if (dia <= 22)
                        return "Virgem";
                    else
                        return "Libra";
                case 10:
                    if (dia <= 22)
                        return "Libra";
                    else
                        return "Escorpião";
                case 11:
                    if (dia <= 21)
                        return "Escorpião";
                    else
                        return "Sagitário";
                case 12:
                    if (dia <= 21)
                        return "Sagitário";
                    else
                        return "Capricórnio";
                default:
                    return "Indisponível";
            }
        }

        public static string FormatarValor(this decimal valor)
        {
            return String.Format("{0:N}", valor);
        }

        public static string FormatarValor(this decimal? valor)
        {
            return String.Format("{0:N}", valor ?? 0);
        }

        public static string FormatarMoeda(this decimal valor)
        {
            return String.Format("{0:C}", valor);
        }

        public static string FormatarMoeda(this decimal? valor)
        {
            return String.Format("{0:C}", valor ?? 0);
        }

        //********************************************************

        public static byte ToByte(this string campo)
        {
            return campo.Trim() == string.Empty ? byte.MinValue : Convert.ToByte(campo);
        }

        public static short ToShort(this string campo)
        {
            return campo.Trim() == string.Empty ? short.MinValue : Convert.ToInt16(campo);
        }

        public static int ToInt(this string campo)
        {
            return campo.Trim() == string.Empty ? int.MinValue : Convert.ToInt32(campo);
        }

        public static long ToLong(this string campo)
        {
            return campo.Trim() == string.Empty ? long.MinValue : Convert.ToInt64(campo);
        }

        public static double ToDouble(this string campo)
        {
            return campo.Trim() == string.Empty ? double.MinValue : Convert.ToDouble(campo);
        }

        public static decimal ToDecimal(this string campo)
        {
            return campo.Trim() == string.Empty ? decimal.MinValue : Convert.ToDecimal(campo);
        }

        public static DateTime ToDateTime(this string campo)
        {
            DateTime dataConvertida;
            bool ok = DateTime.TryParse(campo, out dataConvertida);
            return campo.Trim() == string.Empty ? DateTime.MinValue : (ok ? dataConvertida : DateTime.MinValue);
        }

        public static string ToStringClean(this string campo)
        {
            return campo.Trim() == string.Empty ? string.Empty : campo.Trim();
        }

        //******************************************************************************************

        public static string ToField(this byte property)
        {
            return property == byte.MinValue ? string.Empty : property.ToString();
        }

        public static string ToField(this short property)
        {
            return property == short.MinValue ? string.Empty : property.ToString();
        }

        public static string ToField(this int property)
        {
            return property == int.MinValue ? string.Empty : property.ToString();
        }

        public static string ToField(this long property)
        {
            return property == long.MinValue ? string.Empty : property.ToString();
        }

        public static string ToField(this double property)
        {
            return property == double.MinValue ? string.Empty : property.ToString();
        }

        public static string ToField(this decimal property)
        {
            return property == decimal.MinValue ? string.Empty : property.ToString();
        }

        public static string ToField(this DateTime property)
        {
            return property == DateTime.MinValue ? string.Empty : property.FormatarData();
        }

        public static string ToField(this string property)
        {
            return property == string.Empty ? string.Empty : property;
        }

        //**********************************************************

        public static string LimparCaracteresCEP(this string campo)
        {
            return campo.Replace("-", "").Replace(".", "").Replace(" ", "");
        }

        public static string LimparCaracteresTelefone(this string campo)
        {
            return campo.Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "");
        }

        public static string LimparCaracteresCPF(this string campo)
        {
            return campo.Replace("-", "").Replace(".", "");
        }

        public static string LimparCaracteresCNPJ(this string campo)
        {
            return campo.Replace("-", "").Replace(".", "").Replace("/", "");
        }

        public static string LimparCaracteresPastaFtp(this string campo)
        {
            return campo.Replace("-", "").Replace(".", "").Replace(" ", "_").ToUpper();
        }

        public static string NormalizeText(this string text)
        {
            text = text.Replace("ã", "a");
            text = text.Replace("õ", "o");
            text = text.Replace("Ã", "A");
            text = text.Replace("Õ", "O");

            text = text.Replace("á", "a");
            text = text.Replace("é", "e");
            text = text.Replace("í", "i");
            text = text.Replace("ó", "o");
            text = text.Replace("ú", "u");

            text = text.Replace("Á", "A");
            text = text.Replace("É", "E");
            text = text.Replace("Í", "I");
            text = text.Replace("Ó", "O");
            text = text.Replace("Ú", "U");

            text = text.Replace("ä", "a");
            text = text.Replace("ë", "e");
            text = text.Replace("ï", "i");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");

            text = text.Replace("Ä", "A");
            text = text.Replace("Ë", "E");
            text = text.Replace("Ï", "I");
            text = text.Replace("Ö", "O");
            text = text.Replace("Ü", "U");

            text = text.Replace("à", "a");
            text = text.Replace("À", "A");

            text = text.Replace("ç", "c");
            text = text.Replace("Ç", "C");

            text = text.Replace("â", "a");
            text = text.Replace("ê", "e");
            text = text.Replace("î", "i");
            text = text.Replace("ô", "o");
            text = text.Replace("û", "u");

            text = text.Replace("Â", "A");
            text = text.Replace("Ê", "E");
            text = text.Replace("Î", "I");
            text = text.Replace("Ô", "O");
            text = text.Replace("Û", "U");

            return text;
        }

        public static string TempoDecorrido(this DateTime? Data)
        {
            /// Variáveis
            string _tempdata = string.Empty;

            DateTime DataFinal = DateTime.Now;
            DateTime DataInicial = ((DateTime)Data);

            TimeSpan diferenca = DataFinal - DataInicial;

            if (diferenca.Days == 0)
            {
                if (diferenca.Hours == 0)
                {
                    _tempdata = "Agora";
                }
                else if (diferenca.Hours == 1)
                {
                    _tempdata = "1 Hora";
                }
                else
                {
                    _tempdata = diferenca.Hours.ToString() + " Horas";
                }
            }
            else if (diferenca.Days == 1)
            {
                _tempdata = "1 Dia";
            }
            else
            {
                _tempdata = Convert.ToString(diferenca.Days) + " Dias";
            }

            return _tempdata;

        }

        public static string GerarCodigoRandomico8Posicoes()
        {
            Random random = new Random();
            int rand = random.Next(1, 99999999);
            return rand.ToString().PadLeft(8, '0');
        }
    }
}

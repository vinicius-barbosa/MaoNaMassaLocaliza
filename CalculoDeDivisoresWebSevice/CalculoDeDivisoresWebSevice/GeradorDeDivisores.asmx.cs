using CalculoDeDivisores;
using Newtonsoft.Json;
using System;
using System.Web.Services;

namespace CalculoDeDivisoresWebSevice
{
	/// <summary>
	/// Summary description for GeradorDeDivisores
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class GeradorDeDivisores : System.Web.Services.WebService
	{

		[WebMethod]
		public string ObterDivisoresDeUmNumero(string numero)
		{
			try
			{
				return ProcessarRequisicao(numero, apenasDivisoresPrimos: false);
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
		}

		[WebMethod]
		public string ObterDivisoresPrimosDeUmNumero(string numero)
		{
			try
			{
				return ProcessarRequisicao(numero, apenasDivisoresPrimos: true);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		private string ProcessarRequisicao(string numero, bool apenasDivisoresPrimos)
		{
			var numeroTratado = TratarNumeroPreenchido(numero);

			ValidarPreenchimentoDaRequisicao(numeroTratado);

			var decomposicao = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(numeroTratado.Value, apenasDivisoresPrimos: apenasDivisoresPrimos).ToArray();

			return JsonConvert.SerializeObject(decomposicao);
		}

		private void ValidarPreenchimentoDaRequisicao(int? numero)
		{   
			bool preenchimentoValido = (numero.HasValue && (numero >= 2) && (numero <= 1998000000));

			if (!preenchimentoValido)
				throw new Exception("Favor inserir um número inteiro positivo a partir de 2 e menor que 1998000000.");
		}

		private int? TratarNumeroPreenchido(string numeroPreenchido)
		{
			var valorPreenchido = numeroPreenchido.Trim();
			int numeroTratado;

			if (ValorPreenchidoEhValido(valorPreenchido, out numeroTratado))
				return numeroTratado;

			return null;
		}

		private static bool ValorPreenchidoEhValido(string textoNumero, out int numeroPreenchido)
		{
			return int.TryParse(textoNumero, out numeroPreenchido);
		}
	}
}

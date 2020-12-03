using CalculoDeDivisores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
		public int[] ObterDivisoresDeUmNumero(int numero)
		{
			return GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(numero, apenasDivisoresPrimos:false).ToArray();
		}

		[WebMethod]
		public int[] ObterDivisoresPrimosDeUmNumero(int numero)
		{
			return GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(numero, apenasDivisoresPrimos: true).ToArray();
		}
	}
}

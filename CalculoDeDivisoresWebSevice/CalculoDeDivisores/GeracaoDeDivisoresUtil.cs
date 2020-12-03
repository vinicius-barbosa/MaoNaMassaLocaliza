using System.Collections.Generic;
using System.Linq;

namespace CalculoDeDivisores
{
	public class GeracaoDeDivisoresUtil
	{
		public static List<int> ObterDivisoresDoNumero(int numero, bool apenasDivisoresPrimos)
		{
			var divisores = new List<int>() { 1 };

			var listaAuxiliar = new List<int>() { 1 };

			var decomposicaoEmFatoresPrimos = ObterDecomposicaoEmFatoresPrimos(numero);
			var divisoresPrimos = decomposicaoEmFatoresPrimos.Where(d => d.Key != 1).Select(d => d.Value.Value).ToList();

			if(apenasDivisoresPrimos)
			{
				return divisoresPrimos.Distinct().ToList();
			}
			else
			{
				foreach (int divisorPrimo in divisoresPrimos)
				{
					listaAuxiliar.Clear();

					foreach (int divisor in divisores)
					{
						var produto = divisorPrimo * divisor;

						if (!divisores.Contains(produto))
						{
							listaAuxiliar.Add(produto);
						}
					}

					divisores.AddRange(listaAuxiliar);
				}

				divisores.Sort();

				return divisores;
			}
		}

		private static Dictionary<int, int?> ObterDecomposicaoEmFatoresPrimos(int numero)
		{
			int divisorParaRecursividade = 7;
			var decomposicaoCompleta = new Dictionary<int, int?>();

			if (NumeroPrimoUtil.NumeroEhPrimo(numero, divisorParaRecursividade))
			{
				decomposicaoCompleta.Add(numero, numero);
				decomposicaoCompleta.Add(1, null);
			}
			else
			{
				PreencherDecomposicao(decomposicaoCompleta, numero);
				decomposicaoCompleta.Add(1, null);
			}

			return decomposicaoCompleta;
		}

		private static void PreencherDecomposicao(Dictionary<int, int?> decomposicaoCompleta, int numero)
		{
			int divisorAtual = 2;
			do
			{
				if (NumeroPrimoUtil.EhDivisivelPorAlgumDosDivisores(numero, divisorAtual))
				{
					decomposicaoCompleta.Add(numero, divisorAtual);
					int proximoDividendo = (numero / divisorAtual);
					PreencherDecomposicao(decomposicaoCompleta, proximoDividendo);
				}
				else if (numero > 1)
				{
					divisorAtual = NumeroPrimoUtil.ObterProximoNumeroPrimo(divisorAtual);
				}

			} while ((decomposicaoCompleta.Count == 0) || (decomposicaoCompleta.Last().Key != decomposicaoCompleta.Last().Value));
		}
	}
}

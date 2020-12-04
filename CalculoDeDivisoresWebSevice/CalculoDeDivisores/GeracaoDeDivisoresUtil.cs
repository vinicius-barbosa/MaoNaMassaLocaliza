using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoDeDivisores
{
	public class GeracaoDeDivisoresUtil
	{
		private const int DivisorParaRecursividade = 7;

		public static List<int> ObterDivisoresDoNumero(int numero, bool apenasDivisoresPrimos)
		{
			var divisores = new List<int>();
			var listaAuxiliar = new List<int>();

			IncluirNumeroUmALista(divisores);
			IncluirNumeroUmALista(listaAuxiliar);

			var decomposicaoEmFatoresPrimos = ObterDecomposicaoEmFatoresPrimos(numero);
			var divisoresPrimos = ObterFatoresPrimosDiferentesDeUm(decomposicaoEmFatoresPrimos);

			if (apenasDivisoresPrimos)
				return divisoresPrimos.Distinct().ToList();

			ProcessarDecomposicao(divisores, listaAuxiliar, divisoresPrimos);

			return divisores;
		}

		private static void ProcessarDecomposicao(List<int> divisores, List<int> listaAuxiliar, List<int> divisoresPrimos)
		{
			foreach (int divisorPrimo in divisoresPrimos)
			{
				listaAuxiliar.Clear();

				foreach (int divisor in divisores)
				{
					var produto = (divisorPrimo * divisor);

					if (!divisores.Contains(produto))
						listaAuxiliar.Add(produto);
				}

				divisores.AddRange(listaAuxiliar);
			}

			divisores.Sort();
		}

		private static List<int> ObterFatoresPrimosDiferentesDeUm(Dictionary<int, int?> decomposicaoEmFatoresPrimos)
		{
			return decomposicaoEmFatoresPrimos.Where(d => (d.Key != 1)).Select(d => d.Value.Value).ToList();
		}

		private static void IncluirNumeroUmALista(List<int> lista)
		{
			lista.Add(1);
		}

		private static Dictionary<int, int?> ObterDecomposicaoEmFatoresPrimos(int numero)
		{
			var decomposicaoCompleta = new Dictionary<int, int?>();

			if (NumeroPrimoUtil.NumeroEhPrimo(numero, DivisorParaRecursividade))
				decomposicaoCompleta.Add(numero, numero);
			else
				PreencherDecomposicao(decomposicaoCompleta, numero);

			decomposicaoCompleta.Add(1, value: null);

			return decomposicaoCompleta;
		}

		private static void PreencherDecomposicao(Dictionary<int, int?> decomposicaoCompleta, int numero)
		{
			int divisorAtual = 2;

			do
			{
				if (NumeroPrimoUtil.EhDivisivelPorAlgumDosDivisores(numero, divisorAtual))
				{
					int proximoDividendo = (numero / divisorAtual);

					decomposicaoCompleta.Add(numero, divisorAtual);
					PreencherDecomposicao(decomposicaoCompleta, proximoDividendo);
				}
				else if (numero > 1)
					divisorAtual = NumeroPrimoUtil.ObterProximoNumeroPrimo(divisorAtual);

			} while (NenhumaDecomposicaoFoiFeita(decomposicaoCompleta) || UltimaDecomposicaoFoiFeita(decomposicaoCompleta));
		}

		private static bool UltimaDecomposicaoFoiFeita(Dictionary<int, int?> decomposicaoCompleta)
		{
			return (decomposicaoCompleta.Last().Key != decomposicaoCompleta.Last().Value);
		}

		private static bool NenhumaDecomposicaoFoiFeita(Dictionary<int, int?> decomposicaoCompleta)
		{
			return (decomposicaoCompleta.Count == 0);
		}
	}
}

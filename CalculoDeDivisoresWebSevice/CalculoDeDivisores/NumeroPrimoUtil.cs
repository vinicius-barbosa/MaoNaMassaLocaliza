using System;

namespace CalculoDeDivisores
{
	public static class NumeroPrimoUtil
	{
		public static bool NumeroEhPrimo(int numero, int divisorParaRecursividade)
		{
			if (Array.IndexOf(new int[] { 0, 1 }, numero) >= 0)
			{
				return false;
			}
			else if (Array.IndexOf(new int[] { 2, 3, 5, 7 }, numero) >= 0)
			{
				return true;
			}
			else if (EhDivisivelPorAlgumDosDivisores(numero, 2, 3, 5))
			{
				return false;
			}
			else
			{
				if (numero % divisorParaRecursividade == 0)
				{
					return false;
				}
				else
				{
					if (numero / divisorParaRecursividade > divisorParaRecursividade)
					{
						var proximoNumeroPrimo = ObterProximoNumeroPrimo(divisorParaRecursividade);

						return NumeroEhPrimo(numero, proximoNumeroPrimo);
					}
					else
					{
						return true;
					}
				}
			}
		}

		public static bool EhDivisivelPorAlgumDosDivisores(int numero, params int[] divisores)
		{
			foreach (int divisor in divisores)
			{
				if (numero % divisor == 0)
				{
					return true;
				}
			}

			return false;
		}

		public static int ObterProximoNumeroPrimo(int numero)
		{
			do
			{
				numero++;
			} while (!NumeroEhPrimo(numero, 7));

			return numero;
		}
	}
}

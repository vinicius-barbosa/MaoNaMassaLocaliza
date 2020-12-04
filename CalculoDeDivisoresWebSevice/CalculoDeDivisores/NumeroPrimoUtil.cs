using System;

namespace CalculoDeDivisores
{
	public static class NumeroPrimoUtil
	{
		private const int DivisorParaRecursividade = 7;

		public static bool NumeroEhPrimo(int numero, int divisorParaRecursividade)
		{
			if (NumeroNaoEhPrimo(numero))
				return false;
			else if (NumeroEhUmDosPrimeirosQuatroNumerosPrimos(numero))
				return true;
			else if (EhDivisivelPorAlgumDosDivisores(numero, 2, 3, 5))
				return false;
			else
			{
				if (DivisaoEhExata(numero, divisorParaRecursividade))
					return false;
				else
				{
					if (QuocienteDaDivisaoEhMaiorQueODivisor(numero, divisorParaRecursividade))
					{
						var proximoNumeroPrimo = ObterProximoNumeroPrimo(divisorParaRecursividade);

						return NumeroEhPrimo(numero, proximoNumeroPrimo);
					}
					else
						return true;
				}
			}
		}

		private static bool QuocienteDaDivisaoEhMaiorQueODivisor(int numero, int divisorParaRecursividade)
		{
			return ((numero / divisorParaRecursividade) > divisorParaRecursividade);
		}

		private static bool DivisaoEhExata(int numero, int divisorParaRecursividade)
		{
			return ((numero % divisorParaRecursividade) == 0);
		}

		private static bool NumeroEhUmDosPrimeirosQuatroNumerosPrimos(int numero)
		{
			return (Array.IndexOf(new int[] { 2, 3, 5, 7 }, numero) >= 0);
		}

		private static bool NumeroNaoEhPrimo(int numero)
		{
			return (Array.IndexOf(new int[] { 0, 1 }, numero) >= 0);
		}

		public static bool EhDivisivelPorAlgumDosDivisores(int numero, params int[] divisores)
		{
			foreach (int divisor in divisores)
				if (numero % divisor == 0)
					return true;

			return false;
		}

		public static int ObterProximoNumeroPrimo(int numero)
		{
			do numero++; while (!NumeroEhPrimo(numero, DivisorParaRecursividade));

			return numero;
		}
	}
}

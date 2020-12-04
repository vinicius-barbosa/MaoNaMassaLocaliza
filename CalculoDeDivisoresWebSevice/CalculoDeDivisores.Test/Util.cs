namespace CalculoDeDivisores.Test
{
	public static class Util
	{
		public static string ObterTextoTratado(string textoNaoTratado)
		{
			return textoNaoTratado
					.Replace("\n", string.Empty)
					.Replace("\r", string.Empty)
					.Replace("\t", string.Empty)
					.Replace("]", string.Empty)
					.Replace("[", string.Empty);
		}
	}
}

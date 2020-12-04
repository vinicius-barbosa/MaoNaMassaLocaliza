using CalculoDeDivisores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalculoDeDivisoresClient
{
	public partial class Principal : Form
	{
		#region Propriedades

		private int? Numero
		{
			get
			{
				var valorPreenchido = txtNumero.Text.Trim();
				int numero;
				
				if (ValorPreenchidoEhValido(valorPreenchido, out numero))
					return numero;

				return null;
			}
			set
			{
				txtNumero.Text = value.HasValue ? value.ToString() : string.Empty;
			}
		}

		private bool DeveListarSomentePrimos
		{
			get
			{
				return cbxListarSomentePrimos.Checked;
			}
			set
			{
				cbxListarSomentePrimos.Checked = value;
			}
		}

		#endregion

		#region Métodos utilitários

		private static bool ValorPreenchidoEhValido(string textoNumero, out int numeroPreenchido)
		{
			return int.TryParse(textoNumero, out numeroPreenchido);
		}

		private void ValidarPreenchimentoDoFormulario()
		{
			bool preenchimentoValido = (Numero.HasValue && (Numero >= 2));

			if (!preenchimentoValido)
				throw new Exception("Favor inserir um número inteiro positivo a partir de 2.");
		}

		private void LimparControles()
		{
			DeveListarSomentePrimos = false;
			Numero = null;
		}

		private void ProcessarPreenchimentoDeDivisoresNoFormulario()
		{
			List<int> divisoresObtidos = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(Numero.Value, DeveListarSomentePrimos);

			lbxDivisores.DataSource = divisoresObtidos;
			tbxTotalDivisores.Text = divisoresObtidos.Count.ToString();
			
			AjustarTituloDoAgrupamento(divisoresObtidos); 
		}

		private void AjustarTituloDoAgrupamento(List<int> divisoresObtidos)
		{
			string textoTitulo = "Lista de divisores {0} de {1}";
			string detalheDaListagem = DeveListarSomentePrimos ? "primos" : string.Empty;

			gbxListaDivisores.Text = String.Format(textoTitulo, detalheDaListagem, Numero);
		}

		#endregion

		public Principal()
		{
			InitializeComponent();
		}

		#region Eventos

		private void btnCalcular_Click(object sender, EventArgs e)
		{
			try
			{
				ValidarPreenchimentoDoFormulario();
				ProcessarPreenchimentoDeDivisoresNoFormulario();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Aviso");
			}
			finally
			{
				LimparControles();
			}
		}

		#endregion
	}
}

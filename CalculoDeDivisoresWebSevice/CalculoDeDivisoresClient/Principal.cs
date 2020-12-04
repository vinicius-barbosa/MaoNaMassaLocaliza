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

		private List<int> Divisores;

		#endregion

		#region Métodos utilitários

		private static bool ValorPreenchidoEhValido(string textoNumero, out int numeroPreenchido)
		{
			return int.TryParse(textoNumero, out numeroPreenchido);
		}

		private void ValidarPreenchimentoDoFormulario()
		{
			bool preenchimentoValido = (Numero.HasValue && (Numero >= 2) && (Numero <= 1998000000));

			if (!preenchimentoValido)
				throw new Exception("Favor inserir um número inteiro positivo a partir de 2 e menor que 1998000000.");
		}

		private void LimparControles()
		{
			DeveListarSomentePrimos = false;
			Numero = null;

			lbxDivisores.DataSource = null;
			tbxTotalDivisores.Text = string.Empty;

			AjustarTituloDoAgrupamento(limpar: true);
		}

		private void ProcessarPreenchimentoDeDivisoresNoFormulario()
		{
			Divisores = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(Numero.Value, DeveListarSomentePrimos);
			
			lbxDivisores.DataSource = Divisores;
			tbxTotalDivisores.Text = Divisores.Count.ToString();
			
			AjustarTituloDoAgrupamento(); 
		}

		private void AjustarTituloDoAgrupamento(bool limpar = false)
		{
			if (limpar)
			{
				gbxListaDivisores.Text = string.Empty;
				return;
			}

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
		}

		private void btnLimparControles_Click(object sender, EventArgs e)
		{
			LimparControles();
		}

		#endregion
	}
}

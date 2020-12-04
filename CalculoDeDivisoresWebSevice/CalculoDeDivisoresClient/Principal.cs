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
				var textoNumero = txtNumero.Text.Trim();

				if (int.TryParse(textoNumero, out int numeroPreenchido))
					return numeroPreenchido;

				return null;
			}
		}

		private bool DeveListarSomentePrimos
		{
			get
			{
				return cbxListarSomentePrimos.Checked;
			}
		}

		#endregion

		#region Métodos utilitários

		private bool FormularioFoiPreenchidoCorretamente()
		{
			return (Numero.HasValue && (Numero >= 2));
		}

		#endregion

		public Principal()
		{
			InitializeComponent();
		}

		#region Eventos

		private void btnCalcular_Click(object sender, EventArgs e)
		{
			if(FormularioFoiPreenchidoCorretamente())
			{
				List<int> divisoresObtidos = GeracaoDeDivisoresUtil.ObterDivisoresDoNumero(Numero.Value, DeveListarSomentePrimos);

				lbxDivisores.DataSource = divisoresObtidos;
				tbxTotalDivisores.Text = divisoresObtidos.Count.ToString();
			}
			else
				MessageBox.Show("Favor inserir um número inteiro positivo a partir de 2.", "Aviso");
		}

		#endregion
	}
}

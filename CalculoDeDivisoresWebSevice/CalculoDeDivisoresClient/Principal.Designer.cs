namespace CalculoDeDivisoresClient
{
	partial class Principal
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblNumero = new System.Windows.Forms.Label();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.cbxListarSomentePrimos = new System.Windows.Forms.CheckBox();
			this.btnCalcular = new System.Windows.Forms.Button();
			this.gbxListaDivisores = new System.Windows.Forms.GroupBox();
			this.lbxDivisores = new System.Windows.Forms.ListBox();
			this.lblTotalDivisores = new System.Windows.Forms.Label();
			this.tbxTotalDivisores = new System.Windows.Forms.TextBox();
			this.gbxListaDivisores.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblNumero
			// 
			this.lblNumero.AutoSize = true;
			this.lblNumero.Location = new System.Drawing.Point(24, 24);
			this.lblNumero.Name = "lblNumero";
			this.lblNumero.Size = new System.Drawing.Size(179, 17);
			this.lblNumero.TabIndex = 0;
			this.lblNumero.Text = "Listar divisores do número:";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(209, 21);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(147, 22);
			this.txtNumero.TabIndex = 1;
			// 
			// cbxListarSomentePrimos
			// 
			this.cbxListarSomentePrimos.AutoSize = true;
			this.cbxListarSomentePrimos.Location = new System.Drawing.Point(27, 55);
			this.cbxListarSomentePrimos.Name = "cbxListarSomentePrimos";
			this.cbxListarSomentePrimos.Size = new System.Drawing.Size(248, 21);
			this.cbxListarSomentePrimos.TabIndex = 2;
			this.cbxListarSomentePrimos.Text = "Listar somente os divisores primos";
			this.cbxListarSomentePrimos.UseVisualStyleBackColor = true;
			// 
			// btnCalcular
			// 
			this.btnCalcular.Location = new System.Drawing.Point(109, 87);
			this.btnCalcular.Name = "btnCalcular";
			this.btnCalcular.Size = new System.Drawing.Size(176, 30);
			this.btnCalcular.TabIndex = 3;
			this.btnCalcular.Text = "Calcular";
			this.btnCalcular.UseVisualStyleBackColor = true;
			this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
			// 
			// gbxListaDivisores
			// 
			this.gbxListaDivisores.Controls.Add(this.lbxDivisores);
			this.gbxListaDivisores.Location = new System.Drawing.Point(12, 127);
			this.gbxListaDivisores.Name = "gbxListaDivisores";
			this.gbxListaDivisores.Size = new System.Drawing.Size(359, 277);
			this.gbxListaDivisores.TabIndex = 4;
			this.gbxListaDivisores.TabStop = false;
			// 
			// lbxDivisores
			// 
			this.lbxDivisores.FormattingEnabled = true;
			this.lbxDivisores.ItemHeight = 16;
			this.lbxDivisores.Location = new System.Drawing.Point(15, 31);
			this.lbxDivisores.Name = "lbxDivisores";
			this.lbxDivisores.Size = new System.Drawing.Size(329, 228);
			this.lbxDivisores.TabIndex = 0;
			// 
			// lblTotalDivisores
			// 
			this.lblTotalDivisores.AutoSize = true;
			this.lblTotalDivisores.Location = new System.Drawing.Point(184, 416);
			this.lblTotalDivisores.Name = "lblTotalDivisores";
			this.lblTotalDivisores.Size = new System.Drawing.Size(128, 17);
			this.lblTotalDivisores.TabIndex = 5;
			this.lblTotalDivisores.Text = "Total de divisores: ";
			// 
			// tbxTotalDivisores
			// 
			this.tbxTotalDivisores.Enabled = false;
			this.tbxTotalDivisores.Location = new System.Drawing.Point(315, 412);
			this.tbxTotalDivisores.Name = "tbxTotalDivisores";
			this.tbxTotalDivisores.Size = new System.Drawing.Size(56, 22);
			this.tbxTotalDivisores.TabIndex = 6;
			// 
			// Principal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 444);
			this.Controls.Add(this.tbxTotalDivisores);
			this.Controls.Add(this.lblTotalDivisores);
			this.Controls.Add(this.gbxListaDivisores);
			this.Controls.Add(this.btnCalcular);
			this.Controls.Add(this.cbxListarSomentePrimos);
			this.Controls.Add(this.txtNumero);
			this.Controls.Add(this.lblNumero);
			this.MaximizeBox = false;
			this.Name = "Principal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Calculo de divisores";
			this.gbxListaDivisores.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNumero;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.CheckBox cbxListarSomentePrimos;
		private System.Windows.Forms.Button btnCalcular;
		private System.Windows.Forms.GroupBox gbxListaDivisores;
		private System.Windows.Forms.ListBox lbxDivisores;
		private System.Windows.Forms.Label lblTotalDivisores;
		private System.Windows.Forms.TextBox tbxTotalDivisores;
	}
}


namespace MidiCommunicationTest
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_MidiOut = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_MidiIn = new System.Windows.Forms.ComboBox();
			this.textBox_MidiOut = new System.Windows.Forms.TextBox();
			this.textBox_MidiIn = new System.Windows.Forms.TextBox();
			this.button_MidiOutOpen = new System.Windows.Forms.Button();
			this.button_MidiInOpen = new System.Windows.Forms.Button();
			this.button_Tx = new System.Windows.Forms.Button();
			this.button_ClearTx = new System.Windows.Forms.Button();
			this.button_ClearRx = new System.Windows.Forms.Button();
			this.button_MidiOutClose = new System.Windows.Forms.Button();
			this.button_MidiInClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(24, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "MIDI OUTデバイス";
			// 
			// comboBox_MidiOut
			// 
			this.comboBox_MidiOut.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.comboBox_MidiOut.FormattingEnabled = true;
			this.comboBox_MidiOut.Location = new System.Drawing.Point(24, 64);
			this.comboBox_MidiOut.Name = "comboBox_MidiOut";
			this.comboBox_MidiOut.Size = new System.Drawing.Size(344, 27);
			this.comboBox_MidiOut.TabIndex = 1;
			this.comboBox_MidiOut.DropDown += new System.EventHandler(this.comboBox_MidiOut_DropDown);
			this.comboBox_MidiOut.SelectedIndexChanged += new System.EventHandler(this.comboBox_MidiOut_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(424, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(140, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "MIDI INデバイス";
			// 
			// comboBox_MidiIn
			// 
			this.comboBox_MidiIn.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.comboBox_MidiIn.FormattingEnabled = true;
			this.comboBox_MidiIn.Location = new System.Drawing.Point(424, 64);
			this.comboBox_MidiIn.Name = "comboBox_MidiIn";
			this.comboBox_MidiIn.Size = new System.Drawing.Size(344, 27);
			this.comboBox_MidiIn.TabIndex = 1;
			this.comboBox_MidiIn.DropDown += new System.EventHandler(this.comboBox_MidiIn_DropDown);
			this.comboBox_MidiIn.SelectedIndexChanged += new System.EventHandler(this.comboBox_MidiIn_SelectedIndexChanged);
			// 
			// textBox_MidiOut
			// 
			this.textBox_MidiOut.Font = new System.Drawing.Font("ＭＳ ゴシック", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox_MidiOut.Location = new System.Drawing.Point(8, 96);
			this.textBox_MidiOut.Multiline = true;
			this.textBox_MidiOut.Name = "textBox_MidiOut";
			this.textBox_MidiOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_MidiOut.Size = new System.Drawing.Size(384, 352);
			this.textBox_MidiOut.TabIndex = 2;
			// 
			// textBox_MidiIn
			// 
			this.textBox_MidiIn.Font = new System.Drawing.Font("ＭＳ ゴシック", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox_MidiIn.Location = new System.Drawing.Point(408, 96);
			this.textBox_MidiIn.Multiline = true;
			this.textBox_MidiIn.Name = "textBox_MidiIn";
			this.textBox_MidiIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_MidiIn.Size = new System.Drawing.Size(384, 352);
			this.textBox_MidiIn.TabIndex = 2;
			// 
			// button_MidiOutOpen
			// 
			this.button_MidiOutOpen.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button_MidiOutOpen.Location = new System.Drawing.Point(192, 32);
			this.button_MidiOutOpen.Name = "button_MidiOutOpen";
			this.button_MidiOutOpen.Size = new System.Drawing.Size(76, 31);
			this.button_MidiOutOpen.TabIndex = 3;
			this.button_MidiOutOpen.Text = "Open";
			this.button_MidiOutOpen.UseVisualStyleBackColor = true;
			this.button_MidiOutOpen.Click += new System.EventHandler(this.button_MidiOutOpen_Click);
			// 
			// button_MidiInOpen
			// 
			this.button_MidiInOpen.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button_MidiInOpen.Location = new System.Drawing.Point(570, 32);
			this.button_MidiInOpen.Name = "button_MidiInOpen";
			this.button_MidiInOpen.Size = new System.Drawing.Size(78, 31);
			this.button_MidiInOpen.TabIndex = 3;
			this.button_MidiInOpen.Text = "Open";
			this.button_MidiInOpen.UseVisualStyleBackColor = true;
			this.button_MidiInOpen.Click += new System.EventHandler(this.button_MidiInOpen_Click);
			// 
			// button_Tx
			// 
			this.button_Tx.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button_Tx.Location = new System.Drawing.Point(12, 465);
			this.button_Tx.Name = "button_Tx";
			this.button_Tx.Size = new System.Drawing.Size(100, 32);
			this.button_Tx.TabIndex = 4;
			this.button_Tx.Text = "Send";
			this.button_Tx.UseVisualStyleBackColor = true;
			this.button_Tx.Click += new System.EventHandler(this.button_Tx_Click);
			// 
			// button_ClearTx
			// 
			this.button_ClearTx.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button_ClearTx.Location = new System.Drawing.Point(118, 465);
			this.button_ClearTx.Name = "button_ClearTx";
			this.button_ClearTx.Size = new System.Drawing.Size(100, 32);
			this.button_ClearTx.TabIndex = 4;
			this.button_ClearTx.Text = "Clear";
			this.button_ClearTx.UseVisualStyleBackColor = true;
			this.button_ClearTx.Click += new System.EventHandler(this.button_ClearTx_Click);
			// 
			// button_ClearRx
			// 
			this.button_ClearRx.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button_ClearRx.Location = new System.Drawing.Point(408, 465);
			this.button_ClearRx.Name = "button_ClearRx";
			this.button_ClearRx.Size = new System.Drawing.Size(100, 32);
			this.button_ClearRx.TabIndex = 4;
			this.button_ClearRx.Text = "Clear";
			this.button_ClearRx.UseVisualStyleBackColor = true;
			this.button_ClearRx.Click += new System.EventHandler(this.button_ClearRx_Click);
			// 
			// button_MidiOutClose
			// 
			this.button_MidiOutClose.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button_MidiOutClose.Location = new System.Drawing.Point(274, 32);
			this.button_MidiOutClose.Name = "button_MidiOutClose";
			this.button_MidiOutClose.Size = new System.Drawing.Size(76, 31);
			this.button_MidiOutClose.TabIndex = 3;
			this.button_MidiOutClose.Text = "Close";
			this.button_MidiOutClose.UseVisualStyleBackColor = true;
			this.button_MidiOutClose.Click += new System.EventHandler(this.button_MidiOutClose_Click);
			// 
			// button_MidiInClose
			// 
			this.button_MidiInClose.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button_MidiInClose.Location = new System.Drawing.Point(654, 32);
			this.button_MidiInClose.Name = "button_MidiInClose";
			this.button_MidiInClose.Size = new System.Drawing.Size(78, 31);
			this.button_MidiInClose.TabIndex = 3;
			this.button_MidiInClose.Text = "Close";
			this.button_MidiInClose.UseVisualStyleBackColor = true;
			this.button_MidiInClose.Click += new System.EventHandler(this.button_MidiInClose_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 522);
			this.Controls.Add(this.button_ClearRx);
			this.Controls.Add(this.button_ClearTx);
			this.Controls.Add(this.button_Tx);
			this.Controls.Add(this.button_MidiInClose);
			this.Controls.Add(this.button_MidiInOpen);
			this.Controls.Add(this.button_MidiOutClose);
			this.Controls.Add(this.button_MidiOutOpen);
			this.Controls.Add(this.textBox_MidiIn);
			this.Controls.Add(this.textBox_MidiOut);
			this.Controls.Add(this.comboBox_MidiIn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox_MidiOut);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "MIDI Communication Test";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_MidiOut;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_MidiIn;
		private System.Windows.Forms.TextBox textBox_MidiOut;
		private System.Windows.Forms.TextBox textBox_MidiIn;
		private System.Windows.Forms.Button button_MidiOutOpen;
		private System.Windows.Forms.Button button_MidiInOpen;
		private System.Windows.Forms.Button button_Tx;
		private System.Windows.Forms.Button button_ClearTx;
		private System.Windows.Forms.Button button_ClearRx;
		private System.Windows.Forms.Button button_MidiOutClose;
		private System.Windows.Forms.Button button_MidiInClose;
	}
}


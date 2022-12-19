namespace RistinollaProjekti
{
    partial class Tiedot
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
            this.components = new System.ComponentModel.Container();
            this.btnLisaa = new System.Windows.Forms.Button();
            this.tbNimi = new System.Windows.Forms.TextBox();
            this.tbVuosi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLisaa
            // 
            this.btnLisaa.Location = new System.Drawing.Point(166, 118);
            this.btnLisaa.Margin = new System.Windows.Forms.Padding(2);
            this.btnLisaa.Name = "btnLisaa";
            this.btnLisaa.Size = new System.Drawing.Size(79, 35);
            this.btnLisaa.TabIndex = 0;
            this.btnLisaa.Text = "Lisää";
            this.btnLisaa.UseVisualStyleBackColor = true;
            this.btnLisaa.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbNimi
            // 
            this.tbNimi.Location = new System.Drawing.Point(146, 39);
            this.tbNimi.Margin = new System.Windows.Forms.Padding(2);
            this.tbNimi.Name = "tbNimi";
            this.tbNimi.Size = new System.Drawing.Size(119, 20);
            this.tbNimi.TabIndex = 1;
            // 
            // tbVuosi
            // 
            this.tbVuosi.Location = new System.Drawing.Point(146, 79);
            this.tbVuosi.Margin = new System.Windows.Forms.Padding(2);
            this.tbVuosi.Name = "tbVuosi";
            this.tbVuosi.Size = new System.Drawing.Size(119, 20);
            this.tbVuosi.TabIndex = 2;
            this.tbVuosi.Validating += new System.ComponentModel.CancelEventHandler(this.tbVuosi_Validating);
            this.tbVuosi.Validated += new System.EventHandler(this.tbVuosi_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nimi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Syntymavuosi";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Tiedot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 186);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVuosi);
            this.Controls.Add(this.tbNimi);
            this.Controls.Add(this.btnLisaa);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Tiedot";
            this.Text = "Tiedot";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLisaa;
        private System.Windows.Forms.TextBox tbNimi;
        private System.Windows.Forms.TextBox tbVuosi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
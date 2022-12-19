namespace RistinollaProjekti
{
    partial class Tilastot
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
            this.dgvTilastot = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTilastot)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTilastot
            // 
            this.dgvTilastot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTilastot.Location = new System.Drawing.Point(1, 1);
            this.dgvTilastot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvTilastot.Name = "dgvTilastot";
            this.dgvTilastot.RowHeadersWidth = 62;
            this.dgvTilastot.RowTemplate.Height = 28;
            this.dgvTilastot.Size = new System.Drawing.Size(507, 320);
            this.dgvTilastot.TabIndex = 0;
            // 
            // Tilastot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 325);
            this.Controls.Add(this.dgvTilastot);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Tilastot";
            this.Text = "Tilastot";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTilastot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTilastot;
    }
}
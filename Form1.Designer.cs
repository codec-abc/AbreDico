
namespace AbreDico
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMIAP = new System.Windows.Forms.Panel();
            this.labelMot = new System.Windows.Forms.Label();
            this.ImageGai = new System.Windows.Forms.PictureBox();
            this.ImageTriste = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtCreateTree = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelMIAP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMIAP
            // 
            this.panelMIAP.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.panelMIAP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMIAP.Controls.Add(this.labelMot);
            this.panelMIAP.Controls.Add(this.ImageGai);
            this.panelMIAP.Controls.Add(this.ImageTriste);
            this.panelMIAP.Controls.Add(this.textBox1);
            this.panelMIAP.Controls.Add(this.BtCreateTree);
            this.panelMIAP.Location = new System.Drawing.Point(530, 89);
            this.panelMIAP.Name = "panelMIAP";
            this.panelMIAP.Size = new System.Drawing.Size(421, 181);
            this.panelMIAP.TabIndex = 1;
            // 
            // labelMot
            // 
            this.labelMot.AutoSize = true;
            this.labelMot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMot.Location = new System.Drawing.Point(159, 33);
            this.labelMot.Name = "labelMot";
            this.labelMot.Size = new System.Drawing.Size(123, 25);
            this.labelMot.TabIndex = 5;
            this.labelMot.Text = "Mot à vérifier";
            // 
            // ImageGai
            // 
            this.ImageGai.Image = global::AbreDico.Properties.Resources.gai;
            this.ImageGai.Location = new System.Drawing.Point(18, 0);
            this.ImageGai.Name = "ImageGai";
            this.ImageGai.Size = new System.Drawing.Size(52, 50);
            this.ImageGai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageGai.TabIndex = 4;
            this.ImageGai.TabStop = false;
            this.ImageGai.Visible = false;
            // 
            // ImageTriste
            // 
            this.ImageTriste.Image = global::AbreDico.Properties.Resources.triste;
            this.ImageTriste.Location = new System.Drawing.Point(345, 5);
            this.ImageTriste.Name = "ImageTriste";
            this.ImageTriste.Size = new System.Drawing.Size(52, 50);
            this.ImageTriste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageTriste.TabIndex = 3;
            this.ImageTriste.TabStop = false;
            this.ImageTriste.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(18, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // BtCreateTree
            // 
            this.BtCreateTree.Location = new System.Drawing.Point(18, 114);
            this.BtCreateTree.Name = "BtCreateTree";
            this.BtCreateTree.Size = new System.Drawing.Size(379, 41);
            this.BtCreateTree.TabIndex = 0;
            this.BtCreateTree.Text = "Vérification";
            this.BtCreateTree.UseVisualStyleBackColor = true;
            this.BtCreateTree.Click += new System.EventHandler(this.BtVerifMot);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AbreDico.Properties.Resources.tenor;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelMIAP);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vérification de l\'existance d\'un mot français";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panelMIAP.ResumeLayout(false);
            this.panelMIAP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMIAP;
        private System.Windows.Forms.Button BtCreateTree;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox ImageTriste;
        private System.Windows.Forms.PictureBox ImageGai;
        private System.Windows.Forms.Label labelMot;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}


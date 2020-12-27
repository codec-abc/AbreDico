
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMIAP = new System.Windows.Forms.Panel();
            this.BtCreateTree = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panelMIAP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMIAP
            // 
            this.panelMIAP.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.panelMIAP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMIAP.Controls.Add(this.BtCreateTree);
            this.panelMIAP.Location = new System.Drawing.Point(531, 30);
            this.panelMIAP.Name = "panelMIAP";
            this.panelMIAP.Size = new System.Drawing.Size(237, 135);
            this.panelMIAP.TabIndex = 1;
            // 
            // BtCreateTree
            // 
            this.BtCreateTree.Location = new System.Drawing.Point(13, 19);
            this.BtCreateTree.Name = "BtCreateTree";
            this.BtCreateTree.Size = new System.Drawing.Size(197, 41);
            this.BtCreateTree.TabIndex = 0;
            this.BtCreateTree.Text = "Création de l\'arbre";
            this.BtCreateTree.UseVisualStyleBackColor = true;
            this.BtCreateTree.Click += new System.EventHandler(this.BtCreateTree_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(30, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(417, 372);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panelMIAP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMIAP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMIAP;
        private System.Windows.Forms.Button BtCreateTree;
        private System.Windows.Forms.ListBox listBox1;
    }
}



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
            this.panelMIAP = new System.Windows.Forms.Panel();
            this.BtCreateTree = new System.Windows.Forms.Button();
            this.panelMIAP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMIAP
            // 
            this.panelMIAP.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.panelMIAP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMIAP.Controls.Add(this.BtCreateTree);
            this.panelMIAP.Location = new System.Drawing.Point(252, 32);
            this.panelMIAP.Name = "panelMIAP";
            this.panelMIAP.Size = new System.Drawing.Size(505, 380);
            this.panelMIAP.TabIndex = 1;
            // 
            // BtCreateTree
            // 
            this.BtCreateTree.Location = new System.Drawing.Point(31, 30);
            this.BtCreateTree.Name = "BtCreateTree";
            this.BtCreateTree.Size = new System.Drawing.Size(413, 41);
            this.BtCreateTree.TabIndex = 0;
            this.BtCreateTree.Text = "Création de l\'arbre";
            this.BtCreateTree.UseVisualStyleBackColor = true;
            this.BtCreateTree.Click += new System.EventHandler(this.BtCreateTree_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMIAP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMIAP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMIAP;
        private System.Windows.Forms.Button BtCreateTree;
    }
}


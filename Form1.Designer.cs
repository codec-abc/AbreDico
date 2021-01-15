
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
            this.L9 = new System.Windows.Forms.Label();
            this.L8 = new System.Windows.Forms.Label();
            this.L10 = new System.Windows.Forms.Label();
            this.L7 = new System.Windows.Forms.Label();
            this.L11 = new System.Windows.Forms.Label();
            this.L6 = new System.Windows.Forms.Label();
            this.L12 = new System.Windows.Forms.Label();
            this.L5 = new System.Windows.Forms.Label();
            this.L13 = new System.Windows.Forms.Label();
            this.L4 = new System.Windows.Forms.Label();
            this.L14 = new System.Windows.Forms.Label();
            this.L3 = new System.Windows.Forms.Label();
            this.L15 = new System.Windows.Forms.Label();
            this.L2 = new System.Windows.Forms.Label();
            this.L16 = new System.Windows.Forms.Label();
            this.L1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labNotification = new System.Windows.Forms.Label();
            this.panelMIAP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panelMIAP.Location = new System.Drawing.Point(708, 15);
            this.panelMIAP.Margin = new System.Windows.Forms.Padding(4);
            this.panelMIAP.Name = "panelMIAP";
            this.panelMIAP.Size = new System.Drawing.Size(526, 226);
            this.panelMIAP.TabIndex = 1;
            // 
            // labelMot
            // 
            this.labelMot.AutoSize = true;
            this.labelMot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMot.Location = new System.Drawing.Point(199, 41);
            this.labelMot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMot.Name = "labelMot";
            this.labelMot.Size = new System.Drawing.Size(123, 25);
            this.labelMot.TabIndex = 5;
            this.labelMot.Text = "Mot à vérifier";
            // 
            // ImageGai
            // 
            this.ImageGai.Image = global::AbreDico.Properties.Resources.gai;
            this.ImageGai.Location = new System.Drawing.Point(22, 0);
            this.ImageGai.Margin = new System.Windows.Forms.Padding(4);
            this.ImageGai.Name = "ImageGai";
            this.ImageGai.Size = new System.Drawing.Size(65, 62);
            this.ImageGai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageGai.TabIndex = 4;
            this.ImageGai.TabStop = false;
            this.ImageGai.Visible = false;
            // 
            // ImageTriste
            // 
            this.ImageTriste.Image = global::AbreDico.Properties.Resources.triste;
            this.ImageTriste.Location = new System.Drawing.Point(431, 6);
            this.ImageTriste.Margin = new System.Windows.Forms.Padding(4);
            this.ImageTriste.Name = "ImageTriste";
            this.ImageTriste.Size = new System.Drawing.Size(65, 62);
            this.ImageTriste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageTriste.TabIndex = 3;
            this.ImageTriste.TabStop = false;
            this.ImageTriste.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(22, 76);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(473, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // BtCreateTree
            // 
            this.BtCreateTree.Location = new System.Drawing.Point(22, 142);
            this.BtCreateTree.Margin = new System.Windows.Forms.Padding(4);
            this.BtCreateTree.Name = "BtCreateTree";
            this.BtCreateTree.Size = new System.Drawing.Size(474, 51);
            this.BtCreateTree.TabIndex = 0;
            this.BtCreateTree.Text = "Vérification";
            this.BtCreateTree.UseVisualStyleBackColor = true;
            this.BtCreateTree.Click += new System.EventHandler(this.BtVerifMot);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AbreDico.Properties.Resources.tenor;
            this.pictureBox1.Location = new System.Drawing.Point(945, 272);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 272);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "nouvelle donne";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // L9
            // 
            this.L9.AutoSize = true;
            this.L9.BackColor = System.Drawing.SystemColors.Control;
            this.L9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L9.ForeColor = System.Drawing.Color.Navy;
            this.L9.Location = new System.Drawing.Point(63, 133);
            this.L9.Name = "L9";
            this.L9.Size = new System.Drawing.Size(40, 39);
            this.L9.TabIndex = 12;
            this.L9.Text = "A";
            // 
            // L8
            // 
            this.L8.AutoSize = true;
            this.L8.BackColor = System.Drawing.SystemColors.Control;
            this.L8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L8.ForeColor = System.Drawing.Color.Navy;
            this.L8.Location = new System.Drawing.Point(209, 83);
            this.L8.Name = "L8";
            this.L8.Size = new System.Drawing.Size(40, 39);
            this.L8.TabIndex = 11;
            this.L8.Text = "A";
            // 
            // L10
            // 
            this.L10.AutoSize = true;
            this.L10.BackColor = System.Drawing.SystemColors.Control;
            this.L10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L10.ForeColor = System.Drawing.Color.Navy;
            this.L10.Location = new System.Drawing.Point(113, 133);
            this.L10.Name = "L10";
            this.L10.Size = new System.Drawing.Size(40, 39);
            this.L10.TabIndex = 13;
            this.L10.Text = "A";
            // 
            // L7
            // 
            this.L7.AutoSize = true;
            this.L7.BackColor = System.Drawing.SystemColors.Control;
            this.L7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L7.ForeColor = System.Drawing.Color.Navy;
            this.L7.Location = new System.Drawing.Point(163, 83);
            this.L7.Name = "L7";
            this.L7.Size = new System.Drawing.Size(40, 39);
            this.L7.TabIndex = 10;
            this.L7.Text = "A";
            // 
            // L11
            // 
            this.L11.AutoSize = true;
            this.L11.BackColor = System.Drawing.SystemColors.Control;
            this.L11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L11.ForeColor = System.Drawing.Color.Navy;
            this.L11.Location = new System.Drawing.Point(163, 133);
            this.L11.Name = "L11";
            this.L11.Size = new System.Drawing.Size(40, 39);
            this.L11.TabIndex = 14;
            this.L11.Text = "A";
            // 
            // L6
            // 
            this.L6.AutoSize = true;
            this.L6.BackColor = System.Drawing.SystemColors.Control;
            this.L6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L6.ForeColor = System.Drawing.Color.Navy;
            this.L6.Location = new System.Drawing.Point(113, 83);
            this.L6.Name = "L6";
            this.L6.Size = new System.Drawing.Size(40, 39);
            this.L6.TabIndex = 9;
            this.L6.Text = "A";
            // 
            // L12
            // 
            this.L12.AutoSize = true;
            this.L12.BackColor = System.Drawing.SystemColors.Control;
            this.L12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L12.ForeColor = System.Drawing.Color.Navy;
            this.L12.Location = new System.Drawing.Point(213, 133);
            this.L12.Name = "L12";
            this.L12.Size = new System.Drawing.Size(40, 39);
            this.L12.TabIndex = 15;
            this.L12.Text = "A";
            // 
            // L5
            // 
            this.L5.AutoSize = true;
            this.L5.BackColor = System.Drawing.SystemColors.Control;
            this.L5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L5.ForeColor = System.Drawing.Color.Navy;
            this.L5.Location = new System.Drawing.Point(63, 83);
            this.L5.Name = "L5";
            this.L5.Size = new System.Drawing.Size(40, 39);
            this.L5.TabIndex = 8;
            this.L5.Text = "A";
            // 
            // L13
            // 
            this.L13.AutoSize = true;
            this.L13.BackColor = System.Drawing.SystemColors.Control;
            this.L13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L13.ForeColor = System.Drawing.Color.Navy;
            this.L13.Location = new System.Drawing.Point(63, 184);
            this.L13.Name = "L13";
            this.L13.Size = new System.Drawing.Size(40, 39);
            this.L13.TabIndex = 16;
            this.L13.Text = "A";
            // 
            // L4
            // 
            this.L4.AutoSize = true;
            this.L4.BackColor = System.Drawing.SystemColors.Control;
            this.L4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L4.ForeColor = System.Drawing.Color.Navy;
            this.L4.Location = new System.Drawing.Point(209, 32);
            this.L4.Name = "L4";
            this.L4.Size = new System.Drawing.Size(40, 39);
            this.L4.TabIndex = 7;
            this.L4.Text = "A";
            // 
            // L14
            // 
            this.L14.AutoSize = true;
            this.L14.BackColor = System.Drawing.SystemColors.Control;
            this.L14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L14.ForeColor = System.Drawing.Color.Navy;
            this.L14.Location = new System.Drawing.Point(113, 184);
            this.L14.Name = "L14";
            this.L14.Size = new System.Drawing.Size(40, 39);
            this.L14.TabIndex = 17;
            this.L14.Text = "A";
            // 
            // L3
            // 
            this.L3.AutoSize = true;
            this.L3.BackColor = System.Drawing.SystemColors.Control;
            this.L3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L3.ForeColor = System.Drawing.Color.Navy;
            this.L3.Location = new System.Drawing.Point(159, 32);
            this.L3.Name = "L3";
            this.L3.Size = new System.Drawing.Size(40, 39);
            this.L3.TabIndex = 6;
            this.L3.Text = "A";
            this.L3.Click += new System.EventHandler(this.L3_Click);
            // 
            // L15
            // 
            this.L15.AutoSize = true;
            this.L15.BackColor = System.Drawing.SystemColors.Control;
            this.L15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L15.ForeColor = System.Drawing.Color.Navy;
            this.L15.Location = new System.Drawing.Point(163, 184);
            this.L15.Name = "L15";
            this.L15.Size = new System.Drawing.Size(40, 39);
            this.L15.TabIndex = 18;
            this.L15.Text = "A";
            // 
            // L2
            // 
            this.L2.AutoSize = true;
            this.L2.BackColor = System.Drawing.SystemColors.Control;
            this.L2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2.ForeColor = System.Drawing.Color.Navy;
            this.L2.Location = new System.Drawing.Point(109, 32);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(40, 39);
            this.L2.TabIndex = 5;
            this.L2.Text = "A";
            this.L2.Click += new System.EventHandler(this.L2_Click);
            // 
            // L16
            // 
            this.L16.AutoSize = true;
            this.L16.BackColor = System.Drawing.SystemColors.Control;
            this.L16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L16.ForeColor = System.Drawing.Color.Navy;
            this.L16.Location = new System.Drawing.Point(213, 184);
            this.L16.Name = "L16";
            this.L16.Size = new System.Drawing.Size(40, 39);
            this.L16.TabIndex = 19;
            this.L16.Text = "A";
            // 
            // L1
            // 
            this.L1.AutoSize = true;
            this.L1.BackColor = System.Drawing.SystemColors.Control;
            this.L1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L1.ForeColor = System.Drawing.Color.Navy;
            this.L1.Location = new System.Drawing.Point(59, 32);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(40, 39);
            this.L1.TabIndex = 4;
            this.L1.Text = "A";
            this.L1.Click += new System.EventHandler(this.L1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(293, -2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(392, 552);
            this.textBox2.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labNotification);
            this.panel1.Location = new System.Drawing.Point(14, 356);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 108);
            this.panel1.TabIndex = 21;
            // 
            // labNotification
            // 
            this.labNotification.AutoSize = true;
            this.labNotification.Location = new System.Drawing.Point(15, 20);
            this.labNotification.Name = "labNotification";
            this.labNotification.Size = new System.Drawing.Size(90, 20);
            this.labNotification.TabIndex = 0;
            this.labNotification.Text = "notification";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.L1);
            this.Controls.Add(this.L16);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.L2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.L15);
            this.Controls.Add(this.panelMIAP);
            this.Controls.Add(this.L3);
            this.Controls.Add(this.L7);
            this.Controls.Add(this.L14);
            this.Controls.Add(this.L9);
            this.Controls.Add(this.L4);
            this.Controls.Add(this.L8);
            this.Controls.Add(this.L13);
            this.Controls.Add(this.L10);
            this.Controls.Add(this.L5);
            this.Controls.Add(this.L11);
            this.Controls.Add(this.L12);
            this.Controls.Add(this.L6);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Vérification de l\'existance d\'un mot français";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panelMIAP.ResumeLayout(false);
            this.panelMIAP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label L9;
        private System.Windows.Forms.Label L8;
        private System.Windows.Forms.Label L10;
        private System.Windows.Forms.Label L7;
        private System.Windows.Forms.Label L11;
        private System.Windows.Forms.Label L6;
        private System.Windows.Forms.Label L12;
        private System.Windows.Forms.Label L5;
        private System.Windows.Forms.Label L13;
        private System.Windows.Forms.Label L4;
        private System.Windows.Forms.Label L14;
        private System.Windows.Forms.Label L3;
        private System.Windows.Forms.Label L15;
        private System.Windows.Forms.Label L2;
        private System.Windows.Forms.Label L16;
        private System.Windows.Forms.Label L1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labNotification;
    }
}


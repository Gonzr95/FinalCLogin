
namespace WinFormsApp
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            verLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deserializarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtUsuariosLog = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            lstUsuarios = new System.Windows.Forms.ListBox();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { usuariosToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { listadoToolStripMenuItem, verLogToolStripMenuItem, deserializarToolStripMenuItem, taskToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // listadoToolStripMenuItem
            // 
            listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            listadoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            listadoToolStripMenuItem.Text = "1.- Listado CRUD";
            listadoToolStripMenuItem.Click += listadoToolStripMenuItem_Click;
            // 
            // verLogToolStripMenuItem
            // 
            verLogToolStripMenuItem.Name = "verLogToolStripMenuItem";
            verLogToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            verLogToolStripMenuItem.Text = "2.- Ver log";
            verLogToolStripMenuItem.Click += verLogToolStripMenuItem_Click;
            // 
            // deserializarToolStripMenuItem
            // 
            deserializarToolStripMenuItem.Name = "deserializarToolStripMenuItem";
            deserializarToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            deserializarToolStripMenuItem.Text = "3.- Deserializar JSON";
            deserializarToolStripMenuItem.Click += deserializarToolStripMenuItem_Click;
            // 
            // taskToolStripMenuItem
            // 
            taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            taskToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            taskToolStripMenuItem.Text = "4.- Task";
            taskToolStripMenuItem.Click += taskToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtUsuariosLog);
            groupBox1.Location = new System.Drawing.Point(12, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(752, 200);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Log Usuarios";
            // 
            // txtUsuariosLog
            // 
            txtUsuariosLog.Location = new System.Drawing.Point(6, 22);
            txtUsuariosLog.Multiline = true;
            txtUsuariosLog.Name = "txtUsuariosLog";
            txtUsuariosLog.Size = new System.Drawing.Size(740, 172);
            txtUsuariosLog.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstUsuarios);
            groupBox2.Location = new System.Drawing.Point(12, 271);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(752, 200);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Usuarios Activos";
            // 
            // lstUsuarios
            // 
            lstUsuarios.FormattingEnabled = true;
            lstUsuarios.ItemHeight = 15;
            lstUsuarios.Location = new System.Drawing.Point(12, 22);
            lstUsuarios.Name = "lstUsuarios";
            lstUsuarios.Size = new System.Drawing.Size(740, 169);
            lstUsuarios.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 487);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Text = "Form1";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deserializarToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUsuariosLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstUsuarios;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
    }
}


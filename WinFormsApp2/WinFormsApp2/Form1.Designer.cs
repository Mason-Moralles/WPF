namespace WinFormsApp2
{
    partial class Form1
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
            txtResizable = new TextBox();
            btnResizable = new Button();
            panelNav = new Panel();
            panelMain = new Panel();
            SuspendLayout();
            // 
            // txtResizable
            // 
            txtResizable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtResizable.Location = new Point(333, 146);
            txtResizable.Name = "txtResizable";
            txtResizable.Size = new Size(100, 23);
            txtResizable.TabIndex = 0;
            // 
            // btnResizable
            // 
            btnResizable.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnResizable.Location = new Point(345, 186);
            btnResizable.Name = "btnResizable";
            btnResizable.Size = new Size(75, 23);
            btnResizable.TabIndex = 1;
            btnResizable.Text = "Жмякай";
            btnResizable.UseVisualStyleBackColor = true;
            // 
            // panelNav
            // 
            panelNav.BackColor = SystemColors.ControlDark;
            panelNav.Dock = DockStyle.Left;
            panelNav.Location = new Point(0, 0);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(200, 450);
            panelNav.TabIndex = 2;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(200, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(600, 450);
            panelMain.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            Controls.Add(panelNav);
            Controls.Add(btnResizable);
            Controls.Add(txtResizable);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtResizable;
        private Button btnResizable;
        private Panel panelNav;
        private Panel panelMain;
    }
}

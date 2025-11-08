namespace USPG_PII_Ejercicio_ED
{
    partial class frmEditorTxt
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
            textBox1 = new TextBox();
            btnUndo = new Button();
            btnSave = new Button();
            btnRedo = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(588, 321);
            textBox1.TabIndex = 0;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(12, 360);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(112, 34);
            btnUndo.TabIndex = 2;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += BtnUndo_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(248, 360);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // btnRedo
            // 
            btnRedo.Location = new Point(481, 360);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(112, 34);
            btnRedo.TabIndex = 3;
            btnRedo.Text = "Redo";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += BtnRedo_Click;
            // 
            // frmEditorTxt
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 417);
            Controls.Add(btnRedo);
            Controls.Add(btnSave);
            Controls.Add(btnUndo);
            Controls.Add(textBox1);
            Name = "frmEditorTxt";
            Text = "Editor de Texto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnUndo;
        private Button btnSave;
        private Button btnRedo;
    }
}

namespace elephantocracy.View
{
    partial class StartMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenuForm));
            btn1LVL = new Button();
            btnLVL2 = new Button();
            btnLVL3 = new Button();
            tittle = new Label();
            SuspendLayout();
            // 
            // btn1LVL
            // 
            btn1LVL.BackColor = SystemColors.ActiveCaption;
            btn1LVL.Location = new Point(44, 276);
            btn1LVL.Name = "btn1LVL";
            btn1LVL.Size = new Size(225, 72);
            btn1LVL.TabIndex = 0;
            btn1LVL.Text = "1 уровень";
            btn1LVL.UseVisualStyleBackColor = false;
            btn1LVL.Click += btn1LVL_Click;
            // 
            // btnLVL2
            // 
            btnLVL2.BackColor = SystemColors.ActiveCaption;
            btnLVL2.Location = new Point(303, 276);
            btnLVL2.Name = "btnLVL2";
            btnLVL2.Size = new Size(225, 72);
            btnLVL2.TabIndex = 1;
            btnLVL2.Text = "2 уровень";
            btnLVL2.UseVisualStyleBackColor = false;
            btnLVL2.Click += btn2LVL_Click;
            // 
            // btnLVL3
            // 
            btnLVL3.BackColor = SystemColors.ActiveCaption;
            btnLVL3.Location = new Point(563, 276);
            btnLVL3.Name = "btnLVL3";
            btnLVL3.Size = new Size(225, 72);
            btnLVL3.TabIndex = 2;
            btnLVL3.Text = "3 уровень";
            btnLVL3.UseVisualStyleBackColor = false;
            btnLVL3.Click += btn3LVL_Click;
            // 
            // tittle
            // 
            tittle.AutoSize = true;
            tittle.Font = new Font("Rockwell Condensed", 100F);
            tittle.Location = new Point(53, 50);
            tittle.Name = "tittle";
            tittle.Size = new Size(702, 157);
            tittle.TabIndex = 3;
            tittle.Text = "elephantocracy";
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(818, 450);
            Controls.Add(tittle);
            Controls.Add(btnLVL3);
            Controls.Add(btnLVL2);
            Controls.Add(btn1LVL);
            Name = "StartMenuForm";
            Text = "Начало игры";
            TransparencyKey = Color.FromArgb(255, 192, 128);
            FormClosed += StartMenuForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn1LVL;
        private Button btnLVL2;
        private Button btnLVL3;
        private Label tittle;
    }
}
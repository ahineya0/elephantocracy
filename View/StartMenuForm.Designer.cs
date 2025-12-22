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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btn1LVL
            // 
            btn1LVL.BackColor = SystemColors.ActiveCaption;
            btn1LVL.Location = new Point(45, 195);
            btn1LVL.Name = "btn1LVL";
            btn1LVL.Size = new Size(225, 72);
            btn1LVL.TabIndex = 0;
            btn1LVL.Text = "1 уровень";
            btn1LVL.UseVisualStyleBackColor = false;
            btn1LVL.Click += btn1LVL_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(301, 195);
            button1.Name = "button1";
            button1.Size = new Size(225, 72);
            button1.TabIndex = 1;
            button1.Text = "2 уровень";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btn2LVL_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(554, 195);
            button2.Name = "button2";
            button2.Size = new Size(225, 72);
            button2.TabIndex = 2;
            button2.Text = "3 уровень";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btn3LVL_Click;
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btn1LVL);
            Name = "StartMenuForm";
            Text = "Начало игры";
            TransparencyKey = Color.FromArgb(255, 192, 128);
            FormClosed += StartMenuForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Button btn1LVL;
        private Button button1;
        private Button button2;
    }
}
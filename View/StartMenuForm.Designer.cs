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
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btn1LVL);
            Name = "StartMenuForm";
            Text = "Начало игры";
            TransparencyKey = Color.FromArgb(255, 192, 128);
            FormClosed += StartMenuForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Button btn1LVL;
    }
}
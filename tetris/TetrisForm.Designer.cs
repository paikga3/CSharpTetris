
namespace Tetris
{
    partial class TetrisForm
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
            this.boardPanel = new System.Windows.Forms.Panel();
            this.nextBlockPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(2, 1);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(401, 600);
            this.boardPanel.TabIndex = 0;
            this.boardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.boardPanel_Paint);
            // 
            // nextBlockPanel
            // 
            this.nextBlockPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nextBlockPanel.Location = new System.Drawing.Point(422, 1);
            this.nextBlockPanel.Name = "nextBlockPanel";
            this.nextBlockPanel.Size = new System.Drawing.Size(162, 138);
            this.nextBlockPanel.TabIndex = 1;
            this.nextBlockPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.nextBlockPanel_Paint);
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(585, 646);
            this.Controls.Add(this.nextBlockPanel);
            this.Controls.Add(this.boardPanel);
            this.MaximizeBox = false;
            this.Name = "TetrisForm";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.TetrisForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TetrisForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Panel nextBlockPanel;
    }
}


namespace MemriseHelper
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
            rtbIn = new RichTextBox();
            rtbOut = new RichTextBox();
            buttonStart = new Button();
            buttonCopy = new Button();
            SuspendLayout();
            // 
            // rtbIn
            // 
            rtbIn.Location = new Point(12, 12);
            rtbIn.Name = "rtbIn";
            rtbIn.Size = new Size(776, 216);
            rtbIn.TabIndex = 0;
            rtbIn.Text = "";
            // 
            // rtbOut
            // 
            rtbOut.Location = new Point(12, 234);
            rtbOut.Name = "rtbOut";
            rtbOut.Size = new Size(776, 216);
            rtbOut.TabIndex = 1;
            rtbOut.Text = "";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 456);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(93, 456);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(75, 23);
            buttonCopy.TabIndex = 3;
            buttonCopy.Text = "Copy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 489);
            Controls.Add(buttonCopy);
            Controls.Add(buttonStart);
            Controls.Add(rtbOut);
            Controls.Add(rtbIn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbIn;
        private RichTextBox rtbOut;
        private Button buttonStart;
        private Button buttonCopy;
    }
}
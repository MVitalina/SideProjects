namespace RiseOfIndustryHelper
{
    partial class FormROI
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
            bStart = new Button();
            bAdd = new Button();
            cbProducts = new ComboBox();
            SuspendLayout();
            // 
            // rtbIn
            // 
            rtbIn.Location = new Point(12, 12);
            rtbIn.Name = "rtbIn";
            rtbIn.Size = new Size(498, 216);
            rtbIn.TabIndex = 1;
            rtbIn.Text = "";
            // 
            // rtbOut
            // 
            rtbOut.Location = new Point(12, 234);
            rtbOut.Name = "rtbOut";
            rtbOut.Size = new Size(776, 216);
            rtbOut.TabIndex = 2;
            rtbOut.Text = "";
            // 
            // bStart
            // 
            bStart.Location = new Point(516, 205);
            bStart.Name = "bStart";
            bStart.Size = new Size(272, 23);
            bStart.TabIndex = 3;
            bStart.Text = "Start";
            bStart.UseVisualStyleBackColor = true;
            bStart.Click += bStart_Click;
            // 
            // bAdd
            // 
            bAdd.Location = new Point(516, 41);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(272, 23);
            bAdd.TabIndex = 5;
            bAdd.Text = "Add";
            bAdd.UseVisualStyleBackColor = true;
            bAdd.Click += bAdd_Click;
            // 
            // cbProducts
            // 
            cbProducts.FormattingEnabled = true;
            cbProducts.Location = new Point(516, 12);
            cbProducts.Name = "cbProducts";
            cbProducts.Size = new Size(272, 23);
            cbProducts.TabIndex = 6;
            cbProducts.Click += cbProducts_Click;
            // 
            // FormROI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 466);
            Controls.Add(cbProducts);
            Controls.Add(bAdd);
            Controls.Add(bStart);
            Controls.Add(rtbOut);
            Controls.Add(rtbIn);
            Enabled = false;
            Name = "FormROI";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbIn;
        private RichTextBox rtbOut;
        private Button bStart;
        private TextBox tbProduct;
        private Button bAdd;
        private ComboBox cbProducts;
    }
}
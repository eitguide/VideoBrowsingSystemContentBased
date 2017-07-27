namespace VideoBrowsingSystemContentBased.View
{
    partial class EvaluationForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numNumberOfTopGet = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResultCalculation = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtTrecEvalResult = new System.Windows.Forms.TextBox();
            this.btnGetResultForTrecEval = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGetResultForTrecEvalTextSpotting = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGetResultForTrecEvalColor = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfTopGet)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(904, 495);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numNumberOfTopGet);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtResultCalculation);
            this.tabPage1.Controls.Add(this.btnCalculate);
            this.tabPage1.Controls.Add(this.txtTrecEvalResult);
            this.tabPage1.Controls.Add(this.btnGetResultForTrecEval);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(896, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text Captioning";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numNumberOfTopGet
            // 
            this.numNumberOfTopGet.Location = new System.Drawing.Point(14, 30);
            this.numNumberOfTopGet.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numNumberOfTopGet.Name = "numNumberOfTopGet";
            this.numNumberOfTopGet.Size = new System.Drawing.Size(143, 22);
            this.numNumberOfTopGet.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of top get";
            // 
            // txtResultCalculation
            // 
            this.txtResultCalculation.Location = new System.Drawing.Point(494, 58);
            this.txtResultCalculation.Multiline = true;
            this.txtResultCalculation.Name = "txtResultCalculation";
            this.txtResultCalculation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultCalculation.Size = new System.Drawing.Size(393, 398);
            this.txtResultCalculation.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(411, 225);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(80, 66);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtTrecEvalResult
            // 
            this.txtTrecEvalResult.Location = new System.Drawing.Point(14, 58);
            this.txtTrecEvalResult.Multiline = true;
            this.txtTrecEvalResult.Name = "txtTrecEvalResult";
            this.txtTrecEvalResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrecEvalResult.Size = new System.Drawing.Size(393, 398);
            this.txtTrecEvalResult.TabIndex = 1;
            // 
            // btnGetResultForTrecEval
            // 
            this.btnGetResultForTrecEval.Location = new System.Drawing.Point(164, 8);
            this.btnGetResultForTrecEval.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetResultForTrecEval.Name = "btnGetResultForTrecEval";
            this.btnGetResultForTrecEval.Size = new System.Drawing.Size(189, 43);
            this.btnGetResultForTrecEval.TabIndex = 0;
            this.btnGetResultForTrecEval.Text = "Get result for trec_eval";
            this.btnGetResultForTrecEval.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGetResultForTrecEvalTextSpotting);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(896, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Text Spotting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGetResultForTrecEvalTextSpotting
            // 
            this.btnGetResultForTrecEvalTextSpotting.Location = new System.Drawing.Point(7, 7);
            this.btnGetResultForTrecEvalTextSpotting.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetResultForTrecEvalTextSpotting.Name = "btnGetResultForTrecEvalTextSpotting";
            this.btnGetResultForTrecEvalTextSpotting.Size = new System.Drawing.Size(165, 57);
            this.btnGetResultForTrecEvalTextSpotting.TabIndex = 1;
            this.btnGetResultForTrecEvalTextSpotting.Text = "Get result for trec_eval text spotting";
            this.btnGetResultForTrecEvalTextSpotting.UseVisualStyleBackColor = true;
            this.btnGetResultForTrecEvalTextSpotting.Click += new System.EventHandler(this.btnGetResultForTrecEvalTextSpotting_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGetResultForTrecEvalColor);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(896, 466);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Color";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGetResultForTrecEvalColor
            // 
            this.btnGetResultForTrecEvalColor.Location = new System.Drawing.Point(7, 7);
            this.btnGetResultForTrecEvalColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetResultForTrecEvalColor.Name = "btnGetResultForTrecEvalColor";
            this.btnGetResultForTrecEvalColor.Size = new System.Drawing.Size(165, 57);
            this.btnGetResultForTrecEvalColor.TabIndex = 2;
            this.btnGetResultForTrecEvalColor.Text = "Get result for trec_eval color";
            this.btnGetResultForTrecEvalColor.UseVisualStyleBackColor = true;
            this.btnGetResultForTrecEvalColor.Click += new System.EventHandler(this.btnGetResultForTrecEvalColor_Click);
            // 
            // EvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 495);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EvaluationForm";
            this.Text = "EvaluationForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfTopGet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnGetResultForTrecEval;
        private System.Windows.Forms.TextBox txtResultCalculation;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtTrecEvalResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numNumberOfTopGet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGetResultForTrecEvalTextSpotting;
        private System.Windows.Forms.Button btnGetResultForTrecEvalColor;
    }
}
namespace lab4Metoda
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
            this.graphPlot = new ScottPlot.WinForms.FormsPlot();
            this.updateGraphBtn = new System.Windows.Forms.Button();
            this.updateFilterBtn = new System.Windows.Forms.Button();
            this.ClearDataCB = new System.Windows.Forms.CheckBox();
            this.NoisyDataCB = new System.Windows.Forms.CheckBox();
            this.filtredDataCB = new System.Windows.Forms.CheckBox();
            this.filterFreqBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // graphPlot
            // 
            this.graphPlot.DisplayScale = 1F;
            this.graphPlot.Location = new System.Drawing.Point(12, 12);
            this.graphPlot.Name = "graphPlot";
            this.graphPlot.Size = new System.Drawing.Size(1049, 385);
            this.graphPlot.TabIndex = 0;
            // 
            // updateGraphBtn
            // 
            this.updateGraphBtn.Location = new System.Drawing.Point(49, 527);
            this.updateGraphBtn.Name = "updateGraphBtn";
            this.updateGraphBtn.Size = new System.Drawing.Size(171, 23);
            this.updateGraphBtn.TabIndex = 1;
            this.updateGraphBtn.Text = "Отобразить график";
            this.updateGraphBtn.UseVisualStyleBackColor = true;
            this.updateGraphBtn.Click += new System.EventHandler(this.updateGraphBtn_Click);
            // 
            // updateFilterBtn
            // 
            this.updateFilterBtn.Location = new System.Drawing.Point(745, 527);
            this.updateFilterBtn.Name = "updateFilterBtn";
            this.updateFilterBtn.Size = new System.Drawing.Size(255, 23);
            this.updateFilterBtn.TabIndex = 2;
            this.updateFilterBtn.Text = "Пересчитать фильтр";
            this.updateFilterBtn.UseVisualStyleBackColor = true;
            this.updateFilterBtn.Click += new System.EventHandler(this.updateFilterBtn_Click);
            // 
            // ClearDataCB
            // 
            this.ClearDataCB.AutoSize = true;
            this.ClearDataCB.Checked = true;
            this.ClearDataCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ClearDataCB.Location = new System.Drawing.Point(49, 421);
            this.ClearDataCB.Name = "ClearDataCB";
            this.ClearDataCB.Size = new System.Drawing.Size(124, 19);
            this.ClearDataCB.TabIndex = 3;
            this.ClearDataCB.Text = "Исходный сигнал";
            this.ClearDataCB.UseVisualStyleBackColor = true;
            this.ClearDataCB.CheckedChanged += new System.EventHandler(this.ClearDataCB_CheckedChanged);
            // 
            // NoisyDataCB
            // 
            this.NoisyDataCB.AutoSize = true;
            this.NoisyDataCB.Location = new System.Drawing.Point(49, 454);
            this.NoisyDataCB.Name = "NoisyDataCB";
            this.NoisyDataCB.Size = new System.Drawing.Size(149, 19);
            this.NoisyDataCB.TabIndex = 4;
            this.NoisyDataCB.Text = "Зашумленный сигнал";
            this.NoisyDataCB.UseVisualStyleBackColor = true;
            this.NoisyDataCB.CheckedChanged += new System.EventHandler(this.NoisyDataCB_CheckedChanged);
            // 
            // filtredDataCB
            // 
            this.filtredDataCB.AutoSize = true;
            this.filtredDataCB.Location = new System.Drawing.Point(49, 489);
            this.filtredDataCB.Name = "filtredDataCB";
            this.filtredDataCB.Size = new System.Drawing.Size(171, 19);
            this.filtredDataCB.TabIndex = 5;
            this.filtredDataCB.Text = "Отфильтрованный сигнал";
            this.filtredDataCB.UseVisualStyleBackColor = true;
            this.filtredDataCB.CheckedChanged += new System.EventHandler(this.filtredDataCB_CheckedChanged);
            // 
            // filterFreqBox
            // 
            this.filterFreqBox.Location = new System.Drawing.Point(900, 417);
            this.filterFreqBox.Name = "filterFreqBox";
            this.filterFreqBox.Size = new System.Drawing.Size(100, 23);
            this.filterFreqBox.TabIndex = 6;
            this.filterFreqBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(745, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Частота среза фильра (Гц)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 573);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterFreqBox);
            this.Controls.Add(this.filtredDataCB);
            this.Controls.Add(this.NoisyDataCB);
            this.Controls.Add(this.ClearDataCB);
            this.Controls.Add(this.updateFilterBtn);
            this.Controls.Add(this.updateGraphBtn);
            this.Controls.Add(this.graphPlot);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.WinForms.FormsPlot graphPlot;
        private Button updateGraphBtn;
        private Button updateFilterBtn;
        private CheckBox ClearDataCB;
        private CheckBox NoisyDataCB;
        private CheckBox filtredDataCB;
        private TextBox filterFreqBox;
        private Label label1;
    }
}
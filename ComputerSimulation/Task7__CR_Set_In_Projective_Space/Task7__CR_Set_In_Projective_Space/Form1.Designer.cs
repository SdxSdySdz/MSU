namespace Task7__CR_Set_In_Projective_Space
{
    partial class MainForm
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
            this.Canvas = new System.Windows.Forms.Panel();
            this.ProjectSettingsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.IterationCountLabel = new System.Windows.Forms.Label();
            this.IterationCountInput = new System.Windows.Forms.TextBox();
            this.CalculationButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.matrix20TextBox = new System.Windows.Forms.TextBox();
            this.matrix21TextBox = new System.Windows.Forms.TextBox();
            this.matrix22TextBox = new System.Windows.Forms.TextBox();
            this.matrix12TextBox = new System.Windows.Forms.TextBox();
            this.matrix11TextBox = new System.Windows.Forms.TextBox();
            this.matrix10TextBox = new System.Windows.Forms.TextBox();
            this.matrix02TextBox = new System.Windows.Forms.TextBox();
            this.matrix00TextBox = new System.Windows.Forms.TextBox();
            this.matrix01TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProjectSettingsPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1246, 861);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // ProjectSettingsPanel
            // 
            this.ProjectSettingsPanel.Controls.Add(this.tableLayoutPanel2);
            this.ProjectSettingsPanel.Controls.Add(this.CalculationButton);
            this.ProjectSettingsPanel.Controls.Add(this.panel1);
            this.ProjectSettingsPanel.Controls.Add(this.label1);
            this.ProjectSettingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ProjectSettingsPanel.Location = new System.Drawing.Point(1254, 0);
            this.ProjectSettingsPanel.Name = "ProjectSettingsPanel";
            this.ProjectSettingsPanel.Size = new System.Drawing.Size(330, 861);
            this.ProjectSettingsPanel.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.15151F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.84848F));
            this.tableLayoutPanel2.Controls.Add(this.IterationCountLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.IterationCountInput, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 749);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 42);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // IterationCountLabel
            // 
            this.IterationCountLabel.AutoSize = true;
            this.IterationCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IterationCountLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IterationCountLabel.Location = new System.Drawing.Point(3, 0);
            this.IterationCountLabel.Name = "IterationCountLabel";
            this.IterationCountLabel.Size = new System.Drawing.Size(209, 42);
            this.IterationCountLabel.TabIndex = 0;
            this.IterationCountLabel.Text = "Iteration Count";
            this.IterationCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IterationCountInput
            // 
            this.IterationCountInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IterationCountInput.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IterationCountInput.Location = new System.Drawing.Point(218, 4);
            this.IterationCountInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.IterationCountInput.Name = "IterationCountInput";
            this.IterationCountInput.Size = new System.Drawing.Size(109, 34);
            this.IterationCountInput.TabIndex = 1;
            this.IterationCountInput.Text = "1";
            // 
            // CalculationButton
            // 
            this.CalculationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CalculationButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CalculationButton.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CalculationButton.Location = new System.Drawing.Point(0, 791);
            this.CalculationButton.Name = "CalculationButton";
            this.CalculationButton.Size = new System.Drawing.Size(330, 70);
            this.CalculationButton.TabIndex = 2;
            this.CalculationButton.Text = "Calculate";
            this.CalculationButton.UseVisualStyleBackColor = false;
            this.CalculationButton.Click += new System.EventHandler(this.CalculationButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 285);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.matrix20TextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.matrix21TextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.matrix22TextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.matrix12TextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.matrix11TextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.matrix10TextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.matrix02TextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.matrix00TextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.matrix01TextBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 201);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // matrix20TextBox
            // 
            this.matrix20TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix20TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix20TextBox.Location = new System.Drawing.Point(3, 137);
            this.matrix20TextBox.Name = "matrix20TextBox";
            this.matrix20TextBox.Size = new System.Drawing.Size(73, 61);
            this.matrix20TextBox.TabIndex = 8;
            this.matrix20TextBox.Text = "1";
            this.matrix20TextBox.TextChanged += new System.EventHandler(this.matrix20TextBox_TextChanged);
            // 
            // matrix21TextBox
            // 
            this.matrix21TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix21TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix21TextBox.Location = new System.Drawing.Point(82, 137);
            this.matrix21TextBox.Name = "matrix21TextBox";
            this.matrix21TextBox.Size = new System.Drawing.Size(74, 61);
            this.matrix21TextBox.TabIndex = 7;
            this.matrix21TextBox.Text = "3";
            this.matrix21TextBox.TextChanged += new System.EventHandler(this.matrix21TextBox_TextChanged);
            // 
            // matrix22TextBox
            // 
            this.matrix22TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix22TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix22TextBox.Location = new System.Drawing.Point(162, 137);
            this.matrix22TextBox.Name = "matrix22TextBox";
            this.matrix22TextBox.Size = new System.Drawing.Size(75, 61);
            this.matrix22TextBox.TabIndex = 6;
            this.matrix22TextBox.Text = "1";
            this.matrix22TextBox.TextChanged += new System.EventHandler(this.matrix22TextBox_TextChanged);
            // 
            // matrix12TextBox
            // 
            this.matrix12TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix12TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix12TextBox.Location = new System.Drawing.Point(162, 70);
            this.matrix12TextBox.Name = "matrix12TextBox";
            this.matrix12TextBox.Size = new System.Drawing.Size(75, 61);
            this.matrix12TextBox.TabIndex = 5;
            this.matrix12TextBox.Text = "1";
            this.matrix12TextBox.TextChanged += new System.EventHandler(this.matrix12TextBox_TextChanged);
            // 
            // matrix11TextBox
            // 
            this.matrix11TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix11TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix11TextBox.Location = new System.Drawing.Point(82, 70);
            this.matrix11TextBox.Name = "matrix11TextBox";
            this.matrix11TextBox.Size = new System.Drawing.Size(74, 61);
            this.matrix11TextBox.TabIndex = 4;
            this.matrix11TextBox.Text = "0";
            this.matrix11TextBox.TextChanged += new System.EventHandler(this.matrix11TextBox_TextChanged);
            // 
            // matrix10TextBox
            // 
            this.matrix10TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix10TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix10TextBox.Location = new System.Drawing.Point(3, 70);
            this.matrix10TextBox.Name = "matrix10TextBox";
            this.matrix10TextBox.Size = new System.Drawing.Size(73, 61);
            this.matrix10TextBox.TabIndex = 3;
            this.matrix10TextBox.Text = "1";
            this.matrix10TextBox.TextChanged += new System.EventHandler(this.matrix10TextBox_TextChanged);
            // 
            // matrix02TextBox
            // 
            this.matrix02TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix02TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix02TextBox.Location = new System.Drawing.Point(162, 3);
            this.matrix02TextBox.Name = "matrix02TextBox";
            this.matrix02TextBox.Size = new System.Drawing.Size(75, 61);
            this.matrix02TextBox.TabIndex = 2;
            this.matrix02TextBox.Text = "-1";
            this.matrix02TextBox.TextChanged += new System.EventHandler(this.matrix02TextBox_TextChanged);
            // 
            // matrix00TextBox
            // 
            this.matrix00TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix00TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix00TextBox.Location = new System.Drawing.Point(3, 3);
            this.matrix00TextBox.Name = "matrix00TextBox";
            this.matrix00TextBox.Size = new System.Drawing.Size(73, 61);
            this.matrix00TextBox.TabIndex = 1;
            this.matrix00TextBox.Text = "1";
            this.matrix00TextBox.TextChanged += new System.EventHandler(this.matrix00TextBox_TextChanged);
            // 
            // matrix01TextBox
            // 
            this.matrix01TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrix01TextBox.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrix01TextBox.Location = new System.Drawing.Point(82, 3);
            this.matrix01TextBox.Name = "matrix01TextBox";
            this.matrix01TextBox.Size = new System.Drawing.Size(74, 61);
            this.matrix01TextBox.TabIndex = 0;
            this.matrix01TextBox.Text = "3";
            this.matrix01TextBox.TextChanged += new System.EventHandler(this.matrix01TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mapping";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.ProjectSettingsPanel);
            this.Controls.Add(this.Canvas);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ProjectSettingsPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Panel ProjectSettingsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox matrix01TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox matrix02TextBox;
        private System.Windows.Forms.TextBox matrix00TextBox;
        private System.Windows.Forms.TextBox matrix20TextBox;
        private System.Windows.Forms.TextBox matrix21TextBox;
        private System.Windows.Forms.TextBox matrix22TextBox;
        private System.Windows.Forms.TextBox matrix12TextBox;
        private System.Windows.Forms.TextBox matrix11TextBox;
        private System.Windows.Forms.TextBox matrix10TextBox;
        private System.Windows.Forms.Button CalculationButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label IterationCountLabel;
        private System.Windows.Forms.TextBox IterationCountInput;
    }
}
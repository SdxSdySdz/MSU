
namespace Task5_Task6__AveragingSpectrum__ExtremeCycles
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Canvas = new System.Windows.Forms.Panel();
            this.InterfaceHolder = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NodesCountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IterationCountLabel = new System.Windows.Forms.Label();
            this.IterationCountInput = new System.Windows.Forms.TextBox();
            this.CalculationButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BInput = new System.Windows.Forms.TextBox();
            this.ALabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.AInput = new System.Windows.Forms.TextBox();
            this.MappingImage = new System.Windows.Forms.PictureBox();
            this.MappingTitle = new System.Windows.Forms.Label();
            this.SpectrumTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InterfaceHolder.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1459, 961);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // InterfaceHolder
            // 
            this.InterfaceHolder.Controls.Add(this.label1);
            this.InterfaceHolder.Controls.Add(this.SpectrumTextBox);
            this.InterfaceHolder.Controls.Add(this.tableLayoutPanel2);
            this.InterfaceHolder.Controls.Add(this.CalculationButton);
            this.InterfaceHolder.Controls.Add(this.tableLayoutPanel3);
            this.InterfaceHolder.Controls.Add(this.tableLayoutPanel1);
            this.InterfaceHolder.Controls.Add(this.MappingImage);
            this.InterfaceHolder.Controls.Add(this.MappingTitle);
            this.InterfaceHolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.InterfaceHolder.Location = new System.Drawing.Point(1465, 0);
            this.InterfaceHolder.Name = "InterfaceHolder";
            this.InterfaceHolder.Size = new System.Drawing.Size(419, 961);
            this.InterfaceHolder.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.77804F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.22196F));
            this.tableLayoutPanel2.Controls.Add(this.NodesCountTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.IterationCountLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.IterationCountInput, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 819);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(419, 100);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // NodesCountTextBox
            // 
            this.NodesCountTextBox.Location = new System.Drawing.Point(198, 65);
            this.NodesCountTextBox.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.NodesCountTextBox.Name = "NodesCountTextBox";
            this.NodesCountTextBox.Size = new System.Drawing.Size(218, 20);
            this.NodesCountTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nodes Count";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IterationCountLabel
            // 
            this.IterationCountLabel.AutoSize = true;
            this.IterationCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IterationCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IterationCountLabel.Location = new System.Drawing.Point(3, 0);
            this.IterationCountLabel.Name = "IterationCountLabel";
            this.IterationCountLabel.Size = new System.Drawing.Size(189, 50);
            this.IterationCountLabel.TabIndex = 0;
            this.IterationCountLabel.Text = "Iteration Count";
            this.IterationCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IterationCountInput
            // 
            this.IterationCountInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IterationCountInput.Location = new System.Drawing.Point(198, 15);
            this.IterationCountInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.IterationCountInput.Name = "IterationCountInput";
            this.IterationCountInput.Size = new System.Drawing.Size(218, 20);
            this.IterationCountInput.TabIndex = 1;
            this.IterationCountInput.Text = "1";
            // 
            // CalculationButton
            // 
            this.CalculationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CalculationButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CalculationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculationButton.Location = new System.Drawing.Point(0, 919);
            this.CalculationButton.Name = "CalculationButton";
            this.CalculationButton.Size = new System.Drawing.Size(419, 42);
            this.CalculationButton.TabIndex = 8;
            this.CalculationButton.Text = "Calculate";
            this.CalculationButton.UseVisualStyleBackColor = false;
            this.CalculationButton.Click += new System.EventHandler(this.CalculationButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.37795F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.62205F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TimeTextBox, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 754);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(413, 40);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeTextBox
            // 
            this.TimeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeTextBox.Location = new System.Drawing.Point(111, 5);
            this.TimeTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.TimeTextBox.Name = "TimeTextBox";
            this.TimeTextBox.Size = new System.Drawing.Size(299, 30);
            this.TimeTextBox.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.31496F));
            this.tableLayoutPanel1.Controls.Add(this.BInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ALabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AInput, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 160);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(419, 100);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // BInput
            // 
            this.BInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.BInput.Location = new System.Drawing.Point(85, 65);
            this.BInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.BInput.Name = "BInput";
            this.BInput.Size = new System.Drawing.Size(331, 20);
            this.BInput.TabIndex = 3;
            this.BInput.Text = "1.2";
            this.BInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ALabel
            // 
            this.ALabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ALabel.Location = new System.Drawing.Point(3, 0);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(76, 50);
            this.ALabel.TabIndex = 0;
            this.ALabel.Text = "a";
            this.ALabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BLabel
            // 
            this.BLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BLabel.Location = new System.Drawing.Point(3, 50);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(76, 50);
            this.BLabel.TabIndex = 1;
            this.BLabel.Text = "b";
            this.BLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AInput
            // 
            this.AInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.AInput.Location = new System.Drawing.Point(85, 15);
            this.AInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.AInput.Name = "AInput";
            this.AInput.Size = new System.Drawing.Size(331, 20);
            this.AInput.TabIndex = 2;
            this.AInput.Text = "-0.9";
            this.AInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MappingImage
            // 
            this.MappingImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MappingImage.BackgroundImage")));
            this.MappingImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MappingImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.MappingImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.MappingImage.InitialImage = null;
            this.MappingImage.Location = new System.Drawing.Point(0, 43);
            this.MappingImage.Name = "MappingImage";
            this.MappingImage.Size = new System.Drawing.Size(419, 117);
            this.MappingImage.TabIndex = 3;
            this.MappingImage.TabStop = false;
            // 
            // MappingTitle
            // 
            this.MappingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MappingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MappingTitle.Location = new System.Drawing.Point(0, 0);
            this.MappingTitle.Name = "MappingTitle";
            this.MappingTitle.Size = new System.Drawing.Size(419, 43);
            this.MappingTitle.TabIndex = 2;
            this.MappingTitle.Text = "Quadratic Mapping";
            this.MappingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpectrumTextBox
            // 
            this.SpectrumTextBox.Location = new System.Drawing.Point(14, 344);
            this.SpectrumTextBox.Multiline = true;
            this.SpectrumTextBox.Name = "SpectrumTextBox";
            this.SpectrumTextBox.Size = new System.Drawing.Size(393, 389);
            this.SpectrumTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(147, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Spectrum";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 961);
            this.Controls.Add(this.InterfaceHolder);
            this.Controls.Add(this.Canvas);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.InterfaceHolder.ResumeLayout(false);
            this.InterfaceHolder.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Panel InterfaceHolder;
        private System.Windows.Forms.Label MappingTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox NodesCountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label IterationCountLabel;
        private System.Windows.Forms.TextBox IterationCountInput;
        private System.Windows.Forms.Button CalculationButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TimeTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox BInput;
        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.TextBox AInput;
        private System.Windows.Forms.PictureBox MappingImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SpectrumTextBox;
    }
}


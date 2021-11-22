
namespace Task2__HomoclinicPoints__WinForm
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
            this.CalculationButton = new System.Windows.Forms.Button();
            this.MappingImage = new System.Windows.Forms.PictureBox();
            this.MappingTitle = new System.Windows.Forms.Label();
            this.AlphaInput = new System.Windows.Forms.TextBox();
            this.ReLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.IterationCountLabel = new System.Windows.Forms.Label();
            this.EigenVectorLengthInput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.MinSideLengthInput = new System.Windows.Forms.TextBox();
            this.MinSideLengthLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IterationCountInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MappingImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.Table.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1644, 911);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // CalculationButton
            // 
            this.CalculationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CalculationButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CalculationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculationButton.Location = new System.Drawing.Point(1644, 869);
            this.CalculationButton.Name = "CalculationButton";
            this.CalculationButton.Size = new System.Drawing.Size(260, 42);
            this.CalculationButton.TabIndex = 5;
            this.CalculationButton.Text = "Calculate";
            this.CalculationButton.UseVisualStyleBackColor = false;
            this.CalculationButton.Click += new System.EventHandler(this.CalculationButton_Click);
            // 
            // MappingImage
            // 
            this.MappingImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MappingImage.BackgroundImage")));
            this.MappingImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MappingImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.MappingImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.MappingImage.InitialImage = null;
            this.MappingImage.Location = new System.Drawing.Point(1644, 43);
            this.MappingImage.Name = "MappingImage";
            this.MappingImage.Size = new System.Drawing.Size(260, 114);
            this.MappingImage.TabIndex = 7;
            this.MappingImage.TabStop = false;
            // 
            // MappingTitle
            // 
            this.MappingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MappingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MappingTitle.Location = new System.Drawing.Point(1644, 0);
            this.MappingTitle.Name = "MappingTitle";
            this.MappingTitle.Size = new System.Drawing.Size(260, 43);
            this.MappingTitle.TabIndex = 6;
            this.MappingTitle.Text = "Mapping";
            this.MappingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlphaInput
            // 
            this.AlphaInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlphaInput.Location = new System.Drawing.Point(54, 15);
            this.AlphaInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.AlphaInput.Name = "AlphaInput";
            this.AlphaInput.Size = new System.Drawing.Size(203, 20);
            this.AlphaInput.TabIndex = 2;
            this.AlphaInput.Text = ".43";
            this.AlphaInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AlphaInput.TextChanged += new System.EventHandler(this.AlphaInput_TextChanged);
            // 
            // ReLabel
            // 
            this.ReLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReLabel.Location = new System.Drawing.Point(3, 0);
            this.ReLabel.Name = "ReLabel";
            this.ReLabel.Size = new System.Drawing.Size(45, 50);
            this.ReLabel.TabIndex = 0;
            this.ReLabel.Text = "α";
            this.ReLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.31496F));
            this.tableLayoutPanel1.Controls.Add(this.ReLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AlphaInput, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1644, 157);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 100);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Table
            // 
            this.Table.ColumnCount = 2;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.07692F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.92308F));
            this.Table.Controls.Add(this.IterationCountLabel, 0, 0);
            this.Table.Controls.Add(this.EigenVectorLengthInput, 1, 0);
            this.Table.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Table.Location = new System.Drawing.Point(1644, 819);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Table.Size = new System.Drawing.Size(260, 50);
            this.Table.TabIndex = 9;
            // 
            // IterationCountLabel
            // 
            this.IterationCountLabel.AutoSize = true;
            this.IterationCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IterationCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IterationCountLabel.Location = new System.Drawing.Point(3, 0);
            this.IterationCountLabel.Name = "IterationCountLabel";
            this.IterationCountLabel.Size = new System.Drawing.Size(209, 50);
            this.IterationCountLabel.TabIndex = 0;
            this.IterationCountLabel.Text = "EigenVector Length";
            this.IterationCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EigenVectorLengthInput
            // 
            this.EigenVectorLengthInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EigenVectorLengthInput.Location = new System.Drawing.Point(218, 15);
            this.EigenVectorLengthInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.EigenVectorLengthInput.Name = "EigenVectorLengthInput";
            this.EigenVectorLengthInput.Size = new System.Drawing.Size(39, 20);
            this.EigenVectorLengthInput.TabIndex = 1;
            this.EigenVectorLengthInput.Text = "0.1";
            this.EigenVectorLengthInput.TextChanged += new System.EventHandler(this.EigenVectorLengthInput_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.07692F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.92308F));
            this.tableLayoutPanel3.Controls.Add(this.MinSideLengthInput, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.MinSideLengthLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.IterationCountInput, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1644, 719);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(260, 100);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // MinSideLengthInput
            // 
            this.MinSideLengthInput.Location = new System.Drawing.Point(218, 65);
            this.MinSideLengthInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.MinSideLengthInput.Name = "MinSideLengthInput";
            this.MinSideLengthInput.Size = new System.Drawing.Size(39, 20);
            this.MinSideLengthInput.TabIndex = 3;
            this.MinSideLengthInput.Text = "0.001";
            // 
            // MinSideLengthLabel
            // 
            this.MinSideLengthLabel.AutoSize = true;
            this.MinSideLengthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinSideLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinSideLengthLabel.Location = new System.Drawing.Point(3, 50);
            this.MinSideLengthLabel.Name = "MinSideLengthLabel";
            this.MinSideLengthLabel.Size = new System.Drawing.Size(209, 50);
            this.MinSideLengthLabel.TabIndex = 2;
            this.MinSideLengthLabel.Text = "Min Side Length";
            this.MinSideLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 50);
            this.label4.TabIndex = 0;
            this.label4.Text = "Iteration Count";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IterationCountInput
            // 
            this.IterationCountInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IterationCountInput.Location = new System.Drawing.Point(218, 15);
            this.IterationCountInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.IterationCountInput.Name = "IterationCountInput";
            this.IterationCountInput.Size = new System.Drawing.Size(39, 20);
            this.IterationCountInput.TabIndex = 1;
            this.IterationCountInput.Text = "15";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 911);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MappingImage);
            this.Controls.Add(this.MappingTitle);
            this.Controls.Add(this.CalculationButton);
            this.Controls.Add(this.Canvas);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.MappingImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Table.ResumeLayout(false);
            this.Table.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Button CalculationButton;
        private System.Windows.Forms.PictureBox MappingImage;
        private System.Windows.Forms.Label MappingTitle;
        private System.Windows.Forms.TextBox AlphaInput;
        private System.Windows.Forms.Label ReLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.Label IterationCountLabel;
        private System.Windows.Forms.TextBox EigenVectorLengthInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox MinSideLengthInput;
        private System.Windows.Forms.Label MinSideLengthLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IterationCountInput;
    }
}


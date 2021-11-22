
namespace Task1__CR_Localizator
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
            this.MappingTitle = new System.Windows.Forms.Label();
            this.MappingImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ImInput = new System.Windows.Forms.TextBox();
            this.ReLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ReInput = new System.Windows.Forms.TextBox();
            this.CalculationButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NodesCountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IterationCountLabel = new System.Windows.Forms.Label();
            this.IterationCountInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MappingImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1042, 656);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // MappingTitle
            // 
            this.MappingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MappingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MappingTitle.Location = new System.Drawing.Point(1042, 0);
            this.MappingTitle.Name = "MappingTitle";
            this.MappingTitle.Size = new System.Drawing.Size(254, 43);
            this.MappingTitle.TabIndex = 1;
            this.MappingTitle.Text = "Quadratic Mapping";
            this.MappingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MappingImage
            // 
            this.MappingImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MappingImage.BackgroundImage")));
            this.MappingImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MappingImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.MappingImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.MappingImage.InitialImage = null;
            this.MappingImage.Location = new System.Drawing.Point(1042, 43);
            this.MappingImage.Name = "MappingImage";
            this.MappingImage.Size = new System.Drawing.Size(254, 65);
            this.MappingImage.TabIndex = 2;
            this.MappingImage.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.31496F));
            this.tableLayoutPanel1.Controls.Add(this.ImInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ReLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ReInput, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1042, 108);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 100);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ImInput
            // 
            this.ImInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImInput.Location = new System.Drawing.Point(53, 65);
            this.ImInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.ImInput.Name = "ImInput";
            this.ImInput.Size = new System.Drawing.Size(198, 20);
            this.ImInput.TabIndex = 3;
            this.ImInput.Text = "-0.1";
            this.ImInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ImInput.TextChanged += new System.EventHandler(this.ImInput_TextChanged);
            // 
            // ReLabel
            // 
            this.ReLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReLabel.Location = new System.Drawing.Point(3, 0);
            this.ReLabel.Name = "ReLabel";
            this.ReLabel.Size = new System.Drawing.Size(44, 50);
            this.ReLabel.TabIndex = 0;
            this.ReLabel.Text = "Re";
            this.ReLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Im";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReInput
            // 
            this.ReInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReInput.Location = new System.Drawing.Point(53, 15);
            this.ReInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.ReInput.Name = "ReInput";
            this.ReInput.Size = new System.Drawing.Size(198, 20);
            this.ReInput.TabIndex = 2;
            this.ReInput.Text = ".29";
            this.ReInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReInput.TextChanged += new System.EventHandler(this.ReInput_TextChanged);
            // 
            // CalculationButton
            // 
            this.CalculationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CalculationButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CalculationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculationButton.Location = new System.Drawing.Point(1042, 614);
            this.CalculationButton.Name = "CalculationButton";
            this.CalculationButton.Size = new System.Drawing.Size(254, 42);
            this.CalculationButton.TabIndex = 4;
            this.CalculationButton.Text = "Calculate";
            this.CalculationButton.UseVisualStyleBackColor = false;
            this.CalculationButton.Click += new System.EventHandler(this.CalculationButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.35433F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.64567F));
            this.tableLayoutPanel2.Controls.Add(this.NodesCountTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.IterationCountLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.IterationCountInput, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1042, 514);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(254, 100);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // NodesCountTextBox
            // 
            this.NodesCountTextBox.Location = new System.Drawing.Point(169, 65);
            this.NodesCountTextBox.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.NodesCountTextBox.Name = "NodesCountTextBox";
            this.NodesCountTextBox.Size = new System.Drawing.Size(82, 20);
            this.NodesCountTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 50);
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
            this.IterationCountLabel.Size = new System.Drawing.Size(160, 50);
            this.IterationCountLabel.TabIndex = 0;
            this.IterationCountLabel.Text = "Iteration Count";
            this.IterationCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IterationCountInput
            // 
            this.IterationCountInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IterationCountInput.Location = new System.Drawing.Point(169, 15);
            this.IterationCountInput.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.IterationCountInput.Name = "IterationCountInput";
            this.IterationCountInput.Size = new System.Drawing.Size(82, 20);
            this.IterationCountInput.TabIndex = 1;
            this.IterationCountInput.Text = "1";
            this.IterationCountInput.TextChanged += new System.EventHandler(this.IterationCountInput_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 656);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.CalculationButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MappingImage);
            this.Controls.Add(this.MappingTitle);
            this.Controls.Add(this.Canvas);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CR Set Localizator";
            ((System.ComponentModel.ISupportInitialize)(this.MappingImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Label MappingTitle;
        private System.Windows.Forms.PictureBox MappingImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ReLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ImInput;
        private System.Windows.Forms.TextBox ReInput;
        private System.Windows.Forms.Button CalculationButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox NodesCountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label IterationCountLabel;
        private System.Windows.Forms.TextBox IterationCountInput;
    }
}


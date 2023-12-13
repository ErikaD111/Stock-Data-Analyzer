namespace COP4931Proj2
{
    partial class Form1
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
            this.openFileDialog_stockLoader = new System.Windows.Forms.OpenFileDialog();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.button_loadStock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog_stockLoader
            // 
            this.openFileDialog_stockLoader.FileName = "openFileDialog_stockLoader";
            this.openFileDialog_stockLoader.Multiselect = true;
            this.openFileDialog_stockLoader.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockLoader_FileOk);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(12, 18);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(58, 13);
            this.label_startDate.TabIndex = 0;
            this.label_startDate.Text = "Start Date:";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(380, 18);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(55, 13);
            this.label_endDate.TabIndex = 1;
            this.label_endDate.Text = "End Date:";
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(12, 36);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_startDate.TabIndex = 2;
            this.dateTimePicker_startDate.Value = new System.DateTime(2021, 3, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(383, 36);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_endDate.TabIndex = 3;
            this.dateTimePicker_endDate.Value = new System.DateTime(2021, 7, 1, 0, 0, 0, 0);
            // 
            // button_loadStock
            // 
            this.button_loadStock.Location = new System.Drawing.Point(266, 32);
            this.button_loadStock.Name = "button_loadStock";
            this.button_loadStock.Size = new System.Drawing.Size(75, 23);
            this.button_loadStock.TabIndex = 4;
            this.button_loadStock.Text = "Load Stock";
            this.button_loadStock.UseVisualStyleBackColor = true;
            this.button_loadStock.Click += new System.EventHandler(this.button_loadStock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 81);
            this.Controls.Add(this.button_loadStock);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_stockLoader;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Button button_loadStock;
    }
}


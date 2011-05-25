namespace WL_V2
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
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.label_Chose = new System.Windows.Forms.Label();
            this.label_Number_of_input = new System.Windows.Forms.Label();
            this.textBox_Number_of_input = new System.Windows.Forms.TextBox();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.button_Redo = new System.Windows.Forms.Button();
            this.button_calculate = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Location = new System.Drawing.Point(12, 40);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.Size = new System.Drawing.Size(299, 20);
            this.textBox_FilePath.TabIndex = 0;
            this.textBox_FilePath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_FilePath_MouseClick);
            // 
            // label_Chose
            // 
            this.label_Chose.AutoSize = true;
            this.label_Chose.Location = new System.Drawing.Point(12, 21);
            this.label_Chose.Name = "label_Chose";
            this.label_Chose.Size = new System.Drawing.Size(35, 13);
            this.label_Chose.TabIndex = 2;
            this.label_Chose.Text = "label1";
            // 
            // label_Number_of_input
            // 
            this.label_Number_of_input.AutoSize = true;
            this.label_Number_of_input.Location = new System.Drawing.Point(12, 86);
            this.label_Number_of_input.Name = "label_Number_of_input";
            this.label_Number_of_input.Size = new System.Drawing.Size(35, 13);
            this.label_Number_of_input.TabIndex = 3;
            this.label_Number_of_input.Text = "label1";
            // 
            // textBox_Number_of_input
            // 
            this.textBox_Number_of_input.Location = new System.Drawing.Point(12, 102);
            this.textBox_Number_of_input.Name = "textBox_Number_of_input";
            this.textBox_Number_of_input.Size = new System.Drawing.Size(299, 20);
            this.textBox_Number_of_input.TabIndex = 4;
            // 
            // button_Confirm
            // 
            this.button_Confirm.Location = new System.Drawing.Point(15, 155);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(75, 23);
            this.button_Confirm.TabIndex = 6;
            this.button_Confirm.Text = "button1";
            this.button_Confirm.UseVisualStyleBackColor = true;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // button_Redo
            // 
            this.button_Redo.Location = new System.Drawing.Point(119, 155);
            this.button_Redo.Name = "button_Redo";
            this.button_Redo.Size = new System.Drawing.Size(75, 23);
            this.button_Redo.TabIndex = 7;
            this.button_Redo.Text = "button2";
            this.button_Redo.UseVisualStyleBackColor = true;
            this.button_Redo.Click += new System.EventHandler(this.button_Redo_Click);
            // 
            // button_calculate
            // 
            this.button_calculate.Location = new System.Drawing.Point(236, 155);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(75, 23);
            this.button_calculate.TabIndex = 8;
            this.button_calculate.Text = "button3";
            this.button_calculate.UseVisualStyleBackColor = true;
            this.button_calculate.Click += new System.EventHandler(this.button_calculate_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(20, 201);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(35, 13);
            this.label_status.TabIndex = 9;
            this.label_status.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 333);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_calculate);
            this.Controls.Add(this.button_Redo);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.textBox_Number_of_input);
            this.Controls.Add(this.label_Number_of_input);
            this.Controls.Add(this.label_Chose);
            this.Controls.Add(this.textBox_FilePath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_FilePath;
        private System.Windows.Forms.Label label_Chose;
        private System.Windows.Forms.Label label_Number_of_input;
        private System.Windows.Forms.TextBox textBox_Number_of_input;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.Button button_Redo;
        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.Label label_status;

    }
}


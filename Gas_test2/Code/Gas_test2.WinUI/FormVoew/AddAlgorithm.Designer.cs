namespace Gas_test2.WinUI.FormVoew
{
    partial class AddAlgorithm
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
            this.btn_Enter = new System.Windows.Forms.Button();
            this.textShortName = new System.Windows.Forms.TextBox();
            this.textAlgName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Enter
            // 
            this.btn_Enter.Location = new System.Drawing.Point(101, 194);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(75, 23);
            this.btn_Enter.TabIndex = 9;
            this.btn_Enter.Text = "确认";
            this.btn_Enter.UseVisualStyleBackColor = true;
            // 
            // textShortName
            // 
            this.textShortName.Location = new System.Drawing.Point(137, 125);
            this.textShortName.Name = "textShortName";
            this.textShortName.Size = new System.Drawing.Size(100, 21);
            this.textShortName.TabIndex = 8;
            // 
            // textAlgName
            // 
            this.textAlgName.Location = new System.Drawing.Point(137, 43);
            this.textAlgName.Name = "textAlgName";
            this.textAlgName.Size = new System.Drawing.Size(100, 21);
            this.textAlgName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "算法简称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "算法名称：";
            // 
            // AddAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.textShortName);
            this.Controls.Add(this.textAlgName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddAlgorithm";
            this.Text = "AddAlgorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.TextBox textShortName;
        private System.Windows.Forms.TextBox textAlgName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
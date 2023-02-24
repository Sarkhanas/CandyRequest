
namespace CandyRequest
{
    partial class OrderScreen
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
            this.fio = new System.Windows.Forms.TextBox();
            this.adress = new System.Windows.Forms.TextBox();
            this.tel = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.TextBox();
            this.obtain = new System.Windows.Forms.ComboBox();
            this.payment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fio
            // 
            this.fio.Location = new System.Drawing.Point(317, 140);
            this.fio.Name = "fio";
            this.fio.Size = new System.Drawing.Size(218, 22);
            this.fio.TabIndex = 0;
            // 
            // adress
            // 
            this.adress.Location = new System.Drawing.Point(317, 168);
            this.adress.Name = "adress";
            this.adress.Size = new System.Drawing.Size(218, 22);
            this.adress.TabIndex = 1;
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(317, 196);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(218, 22);
            this.tel.TabIndex = 2;
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(317, 224);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(218, 22);
            this.mail.TabIndex = 3;
            // 
            // obtain
            // 
            this.obtain.FormattingEnabled = true;
            this.obtain.Location = new System.Drawing.Point(380, 252);
            this.obtain.Name = "obtain";
            this.obtain.Size = new System.Drawing.Size(155, 24);
            this.obtain.TabIndex = 4;
            // 
            // payment
            // 
            this.payment.FormattingEnabled = true;
            this.payment.Location = new System.Drawing.Point(380, 282);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(155, 24);
            this.payment.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Адрес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Телефон";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Способ получения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Способ оплаты";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(696, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Далее";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.payment);
            this.Controls.Add(this.obtain);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.adress);
            this.Controls.Add(this.fio);
            this.Enabled = false;
            this.Name = "OrderScreen";
            this.Text = "CandyRequest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderScreen_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fio;
        private System.Windows.Forms.TextBox adress;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.ComboBox obtain;
        private System.Windows.Forms.ComboBox payment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}
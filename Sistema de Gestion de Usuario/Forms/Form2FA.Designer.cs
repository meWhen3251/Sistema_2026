namespace Sistema_de_Gestion_de_Usuario.Forms
{
    partial class Form2FA
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
            components = new System.ComponentModel.Container();
            lbl_Titulo = new Label();
            lbl_Inf1 = new Label();
            tbox_2FA = new TextBox();
            lbl_Info2 = new Label();
            lbl_Leyenda = new Label();
            btn_Reenviar = new Button();
            btn_Enviar = new Button();
            tmr_1seg = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.Anchor = AnchorStyles.Top;
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lbl_Titulo.ImageAlign = ContentAlignment.TopCenter;
            lbl_Titulo.Location = new Point(154, 38);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(310, 24);
            lbl_Titulo.TabIndex = 0;
            lbl_Titulo.Text = "Verificación de la cuenta";
            lbl_Titulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_Inf1
            // 
            lbl_Inf1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_Inf1.AutoSize = true;
            lbl_Inf1.Font = new Font("Consolas", 11.25F);
            lbl_Inf1.Location = new Point(12, 90);
            lbl_Inf1.Name = "lbl_Inf1";
            lbl_Inf1.Size = new Size(592, 18);
            lbl_Inf1.TabIndex = 1;
            lbl_Inf1.Text = "Se ha enviado un código de verificación al correo asociado a esta cuenta.\r\n";
            // 
            // tbox_2FA
            // 
            tbox_2FA.Font = new Font("Lucida Console", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbox_2FA.Location = new Point(168, 165);
            tbox_2FA.Name = "tbox_2FA";
            tbox_2FA.Size = new Size(214, 28);
            tbox_2FA.TabIndex = 2;
            // 
            // lbl_Info2
            // 
            lbl_Info2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_Info2.AutoSize = true;
            lbl_Info2.Font = new Font("Consolas", 11.25F);
            lbl_Info2.Location = new Point(12, 111);
            lbl_Info2.Name = "lbl_Info2";
            lbl_Info2.Size = new Size(584, 18);
            lbl_Info2.TabIndex = 3;
            lbl_Info2.Text = "Si no lo encuentra, revise en su bandeja de correo no deseado o de spam.";
            // 
            // lbl_Leyenda
            // 
            lbl_Leyenda.AutoSize = true;
            lbl_Leyenda.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Leyenda.Location = new Point(223, 145);
            lbl_Leyenda.Name = "lbl_Leyenda";
            lbl_Leyenda.Size = new Size(101, 17);
            lbl_Leyenda.TabIndex = 4;
            lbl_Leyenda.Text = "Código de 2FA:";
            // 
            // btn_Reenviar
            // 
            btn_Reenviar.Location = new Point(407, 165);
            btn_Reenviar.Name = "btn_Reenviar";
            btn_Reenviar.Size = new Size(106, 28);
            btn_Reenviar.TabIndex = 5;
            btn_Reenviar.Text = "Reenviar código";
            btn_Reenviar.UseVisualStyleBackColor = true;
            btn_Reenviar.Click += btn_Reenviar_Click;
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(236, 199);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 23);
            btn_Enviar.TabIndex = 6;
            btn_Enviar.Text = "Enviar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // tmr_1seg
            // 
            tmr_1seg.Interval = 1000;
            tmr_1seg.Tick += tmr_1seg_Tick;
            // 
            // Form2FA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 292);
            Controls.Add(btn_Enviar);
            Controls.Add(btn_Reenviar);
            Controls.Add(lbl_Leyenda);
            Controls.Add(lbl_Info2);
            Controls.Add(tbox_2FA);
            Controls.Add(lbl_Inf1);
            Controls.Add(lbl_Titulo);
            Name = "Form2FA";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2FA";
            Load += Form2FA_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Titulo;
        private Label lbl_Inf1;
        private TextBox tbox_2FA;
        private Label lbl_Info2;
        private Label lbl_Leyenda;
        private Button btn_Reenviar;
        private Button btn_Enviar;
        private System.Windows.Forms.Timer tmr_1seg;
    }
}
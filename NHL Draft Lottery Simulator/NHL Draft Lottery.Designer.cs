namespace NHL_Draft_Lottery_Simulator
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
            this.UI_BTN_LoadStandings = new System.Windows.Forms.Button();
            this.UI_OFD_Import = new System.Windows.Forms.OpenFileDialog();
            this.UI_BTN_GenerateCombos = new System.Windows.Forms.Button();
            this.UI_CB_SelectTeam = new System.Windows.Forms.ComboBox();
            this.UI_DGV = new System.Windows.Forms.DataGridView();
            this.UI_BTN_Draw = new System.Windows.Forms.Button();
            this.UI_BTN_Reset = new System.Windows.Forms.Button();
            this.UI_LBL_1Overall = new System.Windows.Forms.Label();
            this.UI_TB_1Overall = new System.Windows.Forms.TextBox();
            this.UI_TB_2Overall = new System.Windows.Forms.TextBox();
            this.UI_LBL_2Overall = new System.Windows.Forms.Label();
            this.UI_TB_3Overall = new System.Windows.Forms.TextBox();
            this.UI_LBL_3Overall = new System.Windows.Forms.Label();
            this.UI_TB_1Winner = new System.Windows.Forms.TextBox();
            this.UI_TB_2Winner = new System.Windows.Forms.TextBox();
            this.UI_TB_3Winner = new System.Windows.Forms.TextBox();
            this.UI_LBL_DGV_Title = new System.Windows.Forms.Label();
            this.UI_PB1 = new System.Windows.Forms.PictureBox();
            this.UI_PB2 = new System.Windows.Forms.PictureBox();
            this.UI_PB3 = new System.Windows.Forms.PictureBox();
            this.UI_LBL_Info = new System.Windows.Forms.Label();
            this.UI_BTN_Result = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PB3)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_BTN_LoadStandings
            // 
            this.UI_BTN_LoadStandings.Location = new System.Drawing.Point(12, 9);
            this.UI_BTN_LoadStandings.Name = "UI_BTN_LoadStandings";
            this.UI_BTN_LoadStandings.Size = new System.Drawing.Size(102, 23);
            this.UI_BTN_LoadStandings.TabIndex = 0;
            this.UI_BTN_LoadStandings.Text = "Load Standings";
            this.UI_BTN_LoadStandings.UseVisualStyleBackColor = true;
            this.UI_BTN_LoadStandings.Click += new System.EventHandler(this.UI_BTN_LoadStandings_Click);
            // 
            // UI_OFD_Import
            // 
            this.UI_OFD_Import.FileName = "openFileDialog1";
            // 
            // UI_BTN_GenerateCombos
            // 
            this.UI_BTN_GenerateCombos.Enabled = false;
            this.UI_BTN_GenerateCombos.Location = new System.Drawing.Point(12, 37);
            this.UI_BTN_GenerateCombos.Name = "UI_BTN_GenerateCombos";
            this.UI_BTN_GenerateCombos.Size = new System.Drawing.Size(102, 23);
            this.UI_BTN_GenerateCombos.TabIndex = 1;
            this.UI_BTN_GenerateCombos.Text = "Generate Combos";
            this.UI_BTN_GenerateCombos.UseVisualStyleBackColor = true;
            this.UI_BTN_GenerateCombos.Click += new System.EventHandler(this.UI_BTN_GenerateCombos_Click);
            // 
            // UI_CB_SelectTeam
            // 
            this.UI_CB_SelectTeam.FormattingEnabled = true;
            this.UI_CB_SelectTeam.Location = new System.Drawing.Point(12, 184);
            this.UI_CB_SelectTeam.Name = "UI_CB_SelectTeam";
            this.UI_CB_SelectTeam.Size = new System.Drawing.Size(121, 21);
            this.UI_CB_SelectTeam.TabIndex = 2;
            this.UI_CB_SelectTeam.SelectedIndexChanged += new System.EventHandler(this.UI_CB_SelectTeam_SelectedIndexChanged);
            // 
            // UI_DGV
            // 
            this.UI_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DGV.Location = new System.Drawing.Point(139, 184);
            this.UI_DGV.Name = "UI_DGV";
            this.UI_DGV.Size = new System.Drawing.Size(449, 407);
            this.UI_DGV.TabIndex = 3;
            // 
            // UI_BTN_Draw
            // 
            this.UI_BTN_Draw.Enabled = false;
            this.UI_BTN_Draw.Location = new System.Drawing.Point(12, 66);
            this.UI_BTN_Draw.Name = "UI_BTN_Draw";
            this.UI_BTN_Draw.Size = new System.Drawing.Size(121, 57);
            this.UI_BTN_Draw.TabIndex = 4;
            this.UI_BTN_Draw.Text = "Draw Ball";
            this.UI_BTN_Draw.UseVisualStyleBackColor = true;
            this.UI_BTN_Draw.Click += new System.EventHandler(this.UI_BTN_Draw_Click);
            // 
            // UI_BTN_Reset
            // 
            this.UI_BTN_Reset.Enabled = false;
            this.UI_BTN_Reset.Location = new System.Drawing.Point(120, 9);
            this.UI_BTN_Reset.Name = "UI_BTN_Reset";
            this.UI_BTN_Reset.Size = new System.Drawing.Size(75, 23);
            this.UI_BTN_Reset.TabIndex = 5;
            this.UI_BTN_Reset.Text = "Reset";
            this.UI_BTN_Reset.UseVisualStyleBackColor = true;
            this.UI_BTN_Reset.Click += new System.EventHandler(this.UI_BTN_Reset_Click);
            // 
            // UI_LBL_1Overall
            // 
            this.UI_LBL_1Overall.AutoSize = true;
            this.UI_LBL_1Overall.Location = new System.Drawing.Point(192, 37);
            this.UI_LBL_1Overall.Name = "UI_LBL_1Overall";
            this.UI_LBL_1Overall.Size = new System.Drawing.Size(57, 13);
            this.UI_LBL_1Overall.TabIndex = 6;
            this.UI_LBL_1Overall.Text = "1st Overall";
            // 
            // UI_TB_1Overall
            // 
            this.UI_TB_1Overall.Location = new System.Drawing.Point(172, 145);
            this.UI_TB_1Overall.Name = "UI_TB_1Overall";
            this.UI_TB_1Overall.ReadOnly = true;
            this.UI_TB_1Overall.Size = new System.Drawing.Size(90, 20);
            this.UI_TB_1Overall.TabIndex = 17;
            this.UI_TB_1Overall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_TB_2Overall
            // 
            this.UI_TB_2Overall.Location = new System.Drawing.Point(309, 145);
            this.UI_TB_2Overall.Name = "UI_TB_2Overall";
            this.UI_TB_2Overall.ReadOnly = true;
            this.UI_TB_2Overall.Size = new System.Drawing.Size(90, 20);
            this.UI_TB_2Overall.TabIndex = 19;
            this.UI_TB_2Overall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_LBL_2Overall
            // 
            this.UI_LBL_2Overall.AutoSize = true;
            this.UI_LBL_2Overall.Location = new System.Drawing.Point(319, 37);
            this.UI_LBL_2Overall.Name = "UI_LBL_2Overall";
            this.UI_LBL_2Overall.Size = new System.Drawing.Size(61, 13);
            this.UI_LBL_2Overall.TabIndex = 18;
            this.UI_LBL_2Overall.Text = "2nd Overall";
            // 
            // UI_TB_3Overall
            // 
            this.UI_TB_3Overall.Location = new System.Drawing.Point(440, 145);
            this.UI_TB_3Overall.Name = "UI_TB_3Overall";
            this.UI_TB_3Overall.ReadOnly = true;
            this.UI_TB_3Overall.Size = new System.Drawing.Size(90, 20);
            this.UI_TB_3Overall.TabIndex = 21;
            this.UI_TB_3Overall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_LBL_3Overall
            // 
            this.UI_LBL_3Overall.AutoSize = true;
            this.UI_LBL_3Overall.Location = new System.Drawing.Point(461, 37);
            this.UI_LBL_3Overall.Name = "UI_LBL_3Overall";
            this.UI_LBL_3Overall.Size = new System.Drawing.Size(58, 13);
            this.UI_LBL_3Overall.TabIndex = 20;
            this.UI_LBL_3Overall.Text = "3rd Overall";
            // 
            // UI_TB_1Winner
            // 
            this.UI_TB_1Winner.Location = new System.Drawing.Point(172, 119);
            this.UI_TB_1Winner.Name = "UI_TB_1Winner";
            this.UI_TB_1Winner.ReadOnly = true;
            this.UI_TB_1Winner.Size = new System.Drawing.Size(90, 20);
            this.UI_TB_1Winner.TabIndex = 22;
            this.UI_TB_1Winner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_TB_2Winner
            // 
            this.UI_TB_2Winner.Location = new System.Drawing.Point(309, 119);
            this.UI_TB_2Winner.Name = "UI_TB_2Winner";
            this.UI_TB_2Winner.ReadOnly = true;
            this.UI_TB_2Winner.Size = new System.Drawing.Size(90, 20);
            this.UI_TB_2Winner.TabIndex = 23;
            this.UI_TB_2Winner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_TB_3Winner
            // 
            this.UI_TB_3Winner.Location = new System.Drawing.Point(440, 119);
            this.UI_TB_3Winner.Name = "UI_TB_3Winner";
            this.UI_TB_3Winner.ReadOnly = true;
            this.UI_TB_3Winner.Size = new System.Drawing.Size(90, 20);
            this.UI_TB_3Winner.TabIndex = 24;
            this.UI_TB_3Winner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_LBL_DGV_Title
            // 
            this.UI_LBL_DGV_Title.AutoSize = true;
            this.UI_LBL_DGV_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_DGV_Title.Location = new System.Drawing.Point(261, 9);
            this.UI_LBL_DGV_Title.Name = "UI_LBL_DGV_Title";
            this.UI_LBL_DGV_Title.Size = new System.Drawing.Size(195, 24);
            this.UI_LBL_DGV_Title.TabIndex = 25;
            this.UI_LBL_DGV_Title.Text = "2018 NHL Draft Lottery";
            // 
            // UI_PB1
            // 
            this.UI_PB1.Location = new System.Drawing.Point(172, 53);
            this.UI_PB1.Name = "UI_PB1";
            this.UI_PB1.Size = new System.Drawing.Size(90, 60);
            this.UI_PB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UI_PB1.TabIndex = 26;
            this.UI_PB1.TabStop = false;
            // 
            // UI_PB2
            // 
            this.UI_PB2.Location = new System.Drawing.Point(309, 53);
            this.UI_PB2.Name = "UI_PB2";
            this.UI_PB2.Size = new System.Drawing.Size(90, 60);
            this.UI_PB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UI_PB2.TabIndex = 27;
            this.UI_PB2.TabStop = false;
            // 
            // UI_PB3
            // 
            this.UI_PB3.Location = new System.Drawing.Point(440, 53);
            this.UI_PB3.Name = "UI_PB3";
            this.UI_PB3.Size = new System.Drawing.Size(90, 60);
            this.UI_PB3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UI_PB3.TabIndex = 28;
            this.UI_PB3.TabStop = false;
            // 
            // UI_LBL_Info
            // 
            this.UI_LBL_Info.AutoSize = true;
            this.UI_LBL_Info.Location = new System.Drawing.Point(136, 594);
            this.UI_LBL_Info.Name = "UI_LBL_Info";
            this.UI_LBL_Info.Size = new System.Drawing.Size(0, 13);
            this.UI_LBL_Info.TabIndex = 29;
            // 
            // UI_BTN_Result
            // 
            this.UI_BTN_Result.Enabled = false;
            this.UI_BTN_Result.Location = new System.Drawing.Point(12, 129);
            this.UI_BTN_Result.Name = "UI_BTN_Result";
            this.UI_BTN_Result.Size = new System.Drawing.Size(102, 23);
            this.UI_BTN_Result.TabIndex = 31;
            this.UI_BTN_Result.Text = "Draw Winner";
            this.UI_BTN_Result.UseVisualStyleBackColor = true;
            this.UI_BTN_Result.Click += new System.EventHandler(this.UI_BTN_Result_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 616);
            this.Controls.Add(this.UI_BTN_Result);
            this.Controls.Add(this.UI_LBL_Info);
            this.Controls.Add(this.UI_PB3);
            this.Controls.Add(this.UI_PB2);
            this.Controls.Add(this.UI_PB1);
            this.Controls.Add(this.UI_LBL_DGV_Title);
            this.Controls.Add(this.UI_TB_3Winner);
            this.Controls.Add(this.UI_TB_2Winner);
            this.Controls.Add(this.UI_TB_1Winner);
            this.Controls.Add(this.UI_TB_3Overall);
            this.Controls.Add(this.UI_LBL_3Overall);
            this.Controls.Add(this.UI_TB_2Overall);
            this.Controls.Add(this.UI_LBL_2Overall);
            this.Controls.Add(this.UI_TB_1Overall);
            this.Controls.Add(this.UI_LBL_1Overall);
            this.Controls.Add(this.UI_BTN_Reset);
            this.Controls.Add(this.UI_BTN_Draw);
            this.Controls.Add(this.UI_DGV);
            this.Controls.Add(this.UI_CB_SelectTeam);
            this.Controls.Add(this.UI_BTN_GenerateCombos);
            this.Controls.Add(this.UI_BTN_LoadStandings);
            this.MaximumSize = new System.Drawing.Size(611, 655);
            this.MinimumSize = new System.Drawing.Size(611, 655);
            this.Name = "Form1";
            this.Text = "NHL Draft Lottery";
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PB3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_LoadStandings;
        private System.Windows.Forms.OpenFileDialog UI_OFD_Import;
        private System.Windows.Forms.Button UI_BTN_GenerateCombos;
        private System.Windows.Forms.ComboBox UI_CB_SelectTeam;
        private System.Windows.Forms.DataGridView UI_DGV;
        private System.Windows.Forms.Button UI_BTN_Draw;
        private System.Windows.Forms.Button UI_BTN_Reset;
        private System.Windows.Forms.Label UI_LBL_1Overall;
        private System.Windows.Forms.TextBox UI_TB_1Overall;
        private System.Windows.Forms.TextBox UI_TB_2Overall;
        private System.Windows.Forms.Label UI_LBL_2Overall;
        private System.Windows.Forms.TextBox UI_TB_3Overall;
        private System.Windows.Forms.Label UI_LBL_3Overall;
        private System.Windows.Forms.TextBox UI_TB_1Winner;
        private System.Windows.Forms.TextBox UI_TB_2Winner;
        private System.Windows.Forms.TextBox UI_TB_3Winner;
        private System.Windows.Forms.Label UI_LBL_DGV_Title;
        private System.Windows.Forms.PictureBox UI_PB1;
        private System.Windows.Forms.PictureBox UI_PB2;
        private System.Windows.Forms.PictureBox UI_PB3;
        private System.Windows.Forms.Label UI_LBL_Info;
        private System.Windows.Forms.Button UI_BTN_Result;
    }
}


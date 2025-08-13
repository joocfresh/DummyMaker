namespace DummyMaker
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboDrive = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnFill = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerElapsed = new System.Windows.Forms.Timer(this.components);
            this.numPercent = new System.Windows.Forms.NumericUpDown();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // comboDrive
            // 
            this.comboDrive.FormattingEnabled = true;
            this.comboDrive.Location = new System.Drawing.Point(31, 12);
            this.comboDrive.Name = "comboDrive";
            this.comboDrive.Size = new System.Drawing.Size(110, 20);
            this.comboDrive.TabIndex = 0;
            this.comboDrive.Text = "드라이브 선택";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(29, 68);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 1;
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(207, 12);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(69, 23);
            this.btnFill.TabIndex = 2;
            this.btnFill.Text = "생성";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(31, 90);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(245, 23);
            this.progressBar.TabIndex = 3;
            // 
            // numPercent
            // 
            this.numPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPercent.Location = new System.Drawing.Point(147, 13);
            this.numPercent.Name = "numPercent";
            this.numPercent.Size = new System.Drawing.Size(54, 21);
            this.numPercent.TabIndex = 4;
            this.numPercent.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(205, 41);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "더미삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(29, 44);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 12);
            this.lblResult.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 129);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.numPercent);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboDrive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Dummy Maker";
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDrive;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timerElapsed;
        private System.Windows.Forms.NumericUpDown numPercent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblResult;
    }
}


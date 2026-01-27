namespace MouseClickTimer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.NumericUpDown nudMinutes;
        private System.Windows.Forms.Label lblLoopCount;
        private System.Windows.Forms.NumericUpDown nudLoopCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblCurrentLoop;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Button btnOpenLogFolder;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.nudMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblLoopCount = new System.Windows.Forms.Label();
            this.nudLoopCount = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblCurrentLoop = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnOpenLogFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoopCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(170, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "定时鼠标点击工具";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMinutes.Location = new System.Drawing.Point(140, 70);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(79, 20);
            this.lblMinutes.TabIndex = 1;
            this.lblMinutes.Text = "倒计时(分钟):";
            // 
            // nudMinutes
            // 
            this.nudMinutes.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudMinutes.Location = new System.Drawing.Point(225, 68);
            this.nudMinutes.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinutes.Name = "nudMinutes";
            this.nudMinutes.Size = new System.Drawing.Size(120, 25);
            this.nudMinutes.TabIndex = 2;
            this.nudMinutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblLoopCount
            // 
            this.lblLoopCount.AutoSize = true;
            this.lblLoopCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoopCount.Location = new System.Drawing.Point(140, 110);
            this.lblLoopCount.Name = "lblLoopCount";
            this.lblLoopCount.Size = new System.Drawing.Size(79, 20);
            this.lblLoopCount.TabIndex = 3;
            this.lblLoopCount.Text = "循环次数:";
            // 
            // nudLoopCount
            // 
            this.nudLoopCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudLoopCount.Location = new System.Drawing.Point(225, 108);
            this.nudLoopCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudLoopCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLoopCount.Name = "nudLoopCount";
            this.nudLoopCount.Size = new System.Drawing.Size(120, 25);
            this.nudLoopCount.TabIndex = 4;
            this.nudLoopCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(170, 150);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 35);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStop.Location = new System.Drawing.Point(290, 150);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 35);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCountdown.ForeColor = System.Drawing.Color.Blue;
            this.lblCountdown.Location = new System.Drawing.Point(210, 210);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(120, 21);
            this.lblCountdown.TabIndex = 7;
            this.lblCountdown.Text = "剩余时间: 00:00";
            // 
            // lblCurrentLoop
            // 
            this.lblCurrentLoop.AutoSize = true;
            this.lblCurrentLoop.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentLoop.ForeColor = System.Drawing.Color.Green;
            this.lblCurrentLoop.Location = new System.Drawing.Point(210, 240);
            this.lblCurrentLoop.Name = "lblCurrentLoop";
            this.lblCurrentLoop.Size = new System.Drawing.Size(120, 20);
            this.lblCurrentLoop.TabIndex = 8;
            this.lblCurrentLoop.Text = "当前循环: 0 / 0";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLog.Location = new System.Drawing.Point(20, 280);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(79, 20);
            this.lblLog.TabIndex = 9;
            this.lblLog.Text = "执行日志:";
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLog.Location = new System.Drawing.Point(20, 305);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(500, 200);
            this.txtLog.TabIndex = 10;
            this.txtLog.Text = "";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearLog.Location = new System.Drawing.Point(360, 280);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 25);
            this.btnClearLog.TabIndex = 11;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnOpenLogFolder
            // 
            this.btnOpenLogFolder.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenLogFolder.Location = new System.Drawing.Point(445, 280);
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.Size = new System.Drawing.Size(75, 25);
            this.btnOpenLogFolder.TabIndex = 12;
            this.btnOpenLogFolder.Text = "打开日志";
            this.btnOpenLogFolder.UseVisualStyleBackColor = true;
            this.btnOpenLogFolder.Click += new System.EventHandler(this.btnOpenLogFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 520);
            this.Controls.Add(this.btnOpenLogFolder);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lblCurrentLoop);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudLoopCount);
            this.Controls.Add(this.lblLoopCount);
            this.Controls.Add(this.nudMinutes);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时鼠标点击工具";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoopCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

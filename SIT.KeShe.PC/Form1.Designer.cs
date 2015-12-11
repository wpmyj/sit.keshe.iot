namespace SIT.KeShe.PC
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboPort = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FrameDataList = new System.Windows.Forms.TextBox();
            this.sensorDataList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择通信端口";
            // 
            // cmboPort
            // 
            this.cmboPort.FormattingEnabled = true;
            this.cmboPort.Location = new System.Drawing.Point(122, 30);
            this.cmboPort.Name = "cmboPort";
            this.cmboPort.Size = new System.Drawing.Size(121, 20);
            this.cmboPort.TabIndex = 1;
            this.cmboPort.TabStop = false;
            this.cmboPort.DropDown += new System.EventHandler(this.cmboPort_DropDown);
            this.cmboPort.SelectedIndexChanged += new System.EventHandler(this.cmboPort_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(249, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "启动接受数据";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(357, 30);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "停止接受数据";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(27, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "节点数据包";
            // 
            // FrameDataList
            // 
            this.FrameDataList.Location = new System.Drawing.Point(27, 117);
            this.FrameDataList.Multiline = true;
            this.FrameDataList.Name = "FrameDataList";
            this.FrameDataList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FrameDataList.Size = new System.Drawing.Size(432, 339);
            this.FrameDataList.TabIndex = 5;
            this.FrameDataList.TabStop = false;
            // 
            // sensorDataList
            // 
            this.sensorDataList.Location = new System.Drawing.Point(475, 117);
            this.sensorDataList.Multiline = true;
            this.sensorDataList.Name = "sensorDataList";
            this.sensorDataList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sensorDataList.Size = new System.Drawing.Size(465, 339);
            this.sensorDataList.TabIndex = 7;
            this.sensorDataList.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(472, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "节点数据值";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.sensorDataList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FrameDataList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmboPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FrameDataList;
        private System.Windows.Forms.TextBox sensorDataList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}


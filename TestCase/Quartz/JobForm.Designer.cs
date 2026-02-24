namespace Cqwang.BackEnd.CSharp.Job
{
    partial class JobForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNextTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExpression = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPause = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemStartAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPauseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExecuteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip);
            this.splitContainer1.Size = new System.Drawing.Size(1806, 976);
            this.splitContainer1.SplitterDistance = 780;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnDescription,
            this.columnStatus,
            this.columnLastTime,
            this.columnNextTime,
            this.columnExpression});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1806, 780);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "任务名称";
            this.columnName.Width = 200;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "任务描述";
            this.columnDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDescription.Width = 250;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "任务状态";
            // 
            // columnLastTime
            // 
            this.columnLastTime.Text = "上次执行时间";
            this.columnLastTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLastTime.Width = 80;
            // 
            // columnNextTime
            // 
            this.columnNextTime.Text = "下次执行时间";
            this.columnNextTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnNextTime.Width = 80;
            // 
            // columnExpression
            // 
            this.columnExpression.Text = "触发表达式";
            this.columnExpression.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnExpression.Width = 250;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStart,
            this.menuItemPause,
            this.menuItemFresh,
            this.menuItemExecute,
            this.toolStripSeparator1,
            this.menuItemStartAll,
            this.menuItemPauseAll,
            this.menuItemExecuteAll});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(185, 262);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // menuItemStart
            // 
            this.menuItemStart.Name = "menuItemStart";
            this.menuItemStart.Size = new System.Drawing.Size(184, 36);
            this.menuItemStart.Text = "开启";
            this.menuItemStart.Click += new System.EventHandler(this.menuItemStart_Click);
            // 
            // menuItemPause
            // 
            this.menuItemPause.Name = "menuItemPause";
            this.menuItemPause.Size = new System.Drawing.Size(184, 36);
            this.menuItemPause.Text = "暂停";
            this.menuItemPause.Click += new System.EventHandler(this.menuItemPause_Click);
            // 
            // menuItemFresh
            // 
            this.menuItemFresh.Name = "menuItemFresh";
            this.menuItemFresh.Size = new System.Drawing.Size(184, 36);
            this.menuItemFresh.Text = "刷新";
            this.menuItemFresh.Click += new System.EventHandler(this.menuItemFresh_Click);
            // 
            // menuItemExecute
            // 
            this.menuItemExecute.Name = "menuItemExecute";
            this.menuItemExecute.Size = new System.Drawing.Size(184, 36);
            this.menuItemExecute.Text = "执行";
            this.menuItemExecute.Click += new System.EventHandler(this.menuItemExecute_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // menuItemStartAll
            // 
            this.menuItemStartAll.Name = "menuItemStartAll";
            this.menuItemStartAll.Size = new System.Drawing.Size(184, 36);
            this.menuItemStartAll.Text = "全部开启";
            this.menuItemStartAll.Click += new System.EventHandler(this.menuItemStartAll_Click);
            // 
            // menuItemPauseAll
            // 
            this.menuItemPauseAll.Name = "menuItemPauseAll";
            this.menuItemPauseAll.Size = new System.Drawing.Size(184, 36);
            this.menuItemPauseAll.Text = "全部暂停";
            this.menuItemPauseAll.Click += new System.EventHandler(this.menuItemPauseAll_Click);
            // 
            // menuItemExecuteAll
            // 
            this.menuItemExecuteAll.Name = "menuItemExecuteAll";
            this.menuItemExecuteAll.Size = new System.Drawing.Size(184, 36);
            this.menuItemExecuteAll.Text = "全部执行";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 166);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(1806, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // JobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 976);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "JobForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JobForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnLastTime;
        private System.Windows.Forms.ColumnHeader columnNextTime;
        private System.Windows.Forms.ColumnHeader columnExpression;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemStart;
        private System.Windows.Forms.ToolStripMenuItem menuItemPause;
        private System.Windows.Forms.ToolStripMenuItem menuItemFresh;
        private System.Windows.Forms.ToolStripMenuItem menuItemExecute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemStartAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemPauseAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemExecuteAll;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}


namespace Rulers
{
    partial class Ruler
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
            this.textBoxRuler = new System.Windows.Forms.TextBox();
            this.listBoxRuler = new System.Windows.Forms.ListBox();
            this.imageListRuler = new System.Windows.Forms.ImageList(this.components);
            this.listViewRuler = new System.Windows.Forms.ListView();
            this.pictureBoxRuler = new System.Windows.Forms.PictureBox();
            this.contextMenuStripRuler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRuler)).BeginInit();
            this.contextMenuStripRuler.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxRuler
            // 
            this.textBoxRuler.BackColor = System.Drawing.Color.Black;
            this.textBoxRuler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRuler.Font = new System.Drawing.Font("Microsoft YaHei UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRuler.ForeColor = System.Drawing.Color.HotPink;
            this.textBoxRuler.Location = new System.Drawing.Point(13, 7);
            this.textBoxRuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRuler.MaxLength = 128;
            this.textBoxRuler.Name = "textBoxRuler";
            this.textBoxRuler.Size = new System.Drawing.Size(973, 62);
            this.textBoxRuler.TabIndex = 0;
            this.textBoxRuler.TextChanged += new System.EventHandler(this.textBoxRuler_TextChanged);
            this.textBoxRuler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRuler_KeyDown);
            this.textBoxRuler.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRuler_KeyPress);
            // 
            // listBoxRuler
            // 
            this.listBoxRuler.BackColor = System.Drawing.Color.Black;
            this.listBoxRuler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxRuler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxRuler.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxRuler.ForeColor = System.Drawing.Color.White;
            this.listBoxRuler.FormattingEnabled = true;
            this.listBoxRuler.ItemHeight = 50;
            this.listBoxRuler.Location = new System.Drawing.Point(16, 81);
            this.listBoxRuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxRuler.Name = "listBoxRuler";
            this.listBoxRuler.Size = new System.Drawing.Size(1035, 350);
            this.listBoxRuler.TabIndex = 1;
            this.listBoxRuler.Click += new System.EventHandler(this.listBoxRuler_Click);
            this.listBoxRuler.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxRuler_DrawItem);
            this.listBoxRuler.DoubleClick += new System.EventHandler(this.listBoxRuler_DoubleClick);
            // 
            // imageListRuler
            // 
            this.imageListRuler.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListRuler.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListRuler.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewRuler
            // 
            this.listViewRuler.BackColor = System.Drawing.Color.Black;
            this.listViewRuler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewRuler.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewRuler.ForeColor = System.Drawing.Color.Aqua;
            this.listViewRuler.FullRowSelect = true;
            this.listViewRuler.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewRuler.Location = new System.Drawing.Point(16, 81);
            this.listViewRuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewRuler.Name = "listViewRuler";
            this.listViewRuler.Size = new System.Drawing.Size(1035, 375);
            this.listViewRuler.TabIndex = 4;
            this.listViewRuler.UseCompatibleStateImageBehavior = false;
            this.listViewRuler.View = System.Windows.Forms.View.Details;
            this.listViewRuler.DoubleClick += new System.EventHandler(this.listViewRuler_DoubleClick);
            // 
            // pictureBoxRuler
            // 
            this.pictureBoxRuler.ContextMenuStrip = this.contextMenuStripRuler;
            this.pictureBoxRuler.Location = new System.Drawing.Point(1001, 12);
            this.pictureBoxRuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxRuler.Name = "pictureBoxRuler";
            this.pictureBoxRuler.Size = new System.Drawing.Size(53, 50);
            this.pictureBoxRuler.TabIndex = 0;
            this.pictureBoxRuler.TabStop = false;
            this.pictureBoxRuler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRuler_MouseDown);
            this.pictureBoxRuler.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRuler_MouseMove);
            this.pictureBoxRuler.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRuler_MouseUp);
            // 
            // contextMenuStripRuler
            // 
            this.contextMenuStripRuler.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripRuler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.startupToolStripMenuItem});
            this.contextMenuStripRuler.Name = "contextMenuStripRuler";
            this.contextMenuStripRuler.Size = new System.Drawing.Size(128, 124);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.startupToolStripMenuItem.Text = "Startup";
            this.startupToolStripMenuItem.Click += new System.EventHandler(this.startupToolStripMenuItem_Click);
            // 
            // Ruler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1067, 75);
            this.Controls.Add(this.pictureBoxRuler);
            this.Controls.Add(this.listBoxRuler);
            this.Controls.Add(this.listViewRuler);
            this.Controls.Add(this.textBoxRuler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ruler";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Rulers";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Ruler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ruler_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRuler)).EndInit();
            this.contextMenuStripRuler.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRuler;
        private System.Windows.Forms.ListBox listBoxRuler;
        private System.Windows.Forms.ImageList imageListRuler;
        private System.Windows.Forms.ListView listViewRuler;
        private System.Windows.Forms.PictureBox pictureBoxRuler;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRuler;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
    }
}


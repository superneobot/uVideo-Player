
namespace uVideo_Player
{
    partial class mainform
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.st_strip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.buffer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tor_speed = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.loaded = new System.Windows.Forms.ToolStripStatusLabel();
            this.streaming = new System.Windows.Forms.ToolStripStatusLabel();
            this.torrent_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.peers_found = new System.Windows.Forms.ToolStripStatusLabel();
            this.top_panel = new System.Windows.Forms.Panel();
            this.caption = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.main_panel = new System.Windows.Forms.Panel();
            this.viewport = new System.Windows.Forms.PictureBox();
            this.main_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openTorrent = new System.Windows.Forms.ToolStripMenuItem();
            this.open_watch = new System.Windows.Forms.ToolStripMenuItem();
            this.open_stream = new System.Windows.Forms.ToolStripMenuItem();
            this.start_stream = new System.Windows.Forms.ToolStripMenuItem();
            this.http = new System.Windows.Forms.ToolStripMenuItem();
            this.rsp = new System.Windows.Forms.ToolStripMenuItem();
            this.udp = new System.Windows.Forms.ToolStripMenuItem();
            this.fullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.control_panel = new System.Windows.Forms.Panel();
            this.seeker_panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.total_time = new System.Windows.Forms.Label();
            this.current_time = new System.Windows.Forms.Label();
            this.seek_p = new System.Windows.Forms.Panel();
            this.seeker = new ColorSlider.ColorSlider();
            this.volume_panel = new System.Windows.Forms.Panel();
            this.vol_state = new System.Windows.Forms.Label();
            this.volume_tr = new ColorSlider.ColorSlider();
            this.buttons_panel = new System.Windows.Forms.Panel();
            this.stop_btn = new System.Windows.Forms.Button();
            this.pause_btn = new System.Windows.Forms.Button();
            this.play_btn = new System.Windows.Forms.Button();
            this.seeker_tip = new System.Windows.Forms.ToolTip(this.components);
            this.vol_tip = new System.Windows.Forms.ToolTip(this.components);
            this.st_strip.SuspendLayout();
            this.top_panel.SuspendLayout();
            this.main_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewport)).BeginInit();
            this.main_menu.SuspendLayout();
            this.control_panel.SuspendLayout();
            this.seeker_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.seek_p.SuspendLayout();
            this.volume_panel.SuspendLayout();
            this.buttons_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_strip
            // 
            this.st_strip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.st_strip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.st_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.buffer,
            this.tor_speed,
            this.progress,
            this.loaded,
            this.streaming,
            this.torrent_status,
            this.peers_found});
            this.st_strip.Location = new System.Drawing.Point(0, 378);
            this.st_strip.Name = "st_strip";
            this.st_strip.Size = new System.Drawing.Size(720, 22);
            this.st_strip.TabIndex = 0;
            this.st_strip.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.ForeColor = System.Drawing.Color.Gainsboro;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(33, 17);
            this.status.Text = "Стоп";
            // 
            // buffer
            // 
            this.buffer.ForeColor = System.Drawing.Color.Gainsboro;
            this.buffer.Name = "buffer";
            this.buffer.Size = new System.Drawing.Size(96, 17);
            this.buffer.Text = "Буферизация 0%";
            this.buffer.Visible = false;
            // 
            // tor_speed
            // 
            this.tor_speed.ForeColor = System.Drawing.Color.Gainsboro;
            this.tor_speed.Name = "tor_speed";
            this.tor_speed.Size = new System.Drawing.Size(126, 17);
            this.tor_speed.Text = "Download 0 | Upload 0";
            this.tor_speed.Visible = false;
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(100, 16);
            this.progress.Visible = false;
            // 
            // loaded
            // 
            this.loaded.ForeColor = System.Drawing.Color.Gainsboro;
            this.loaded.Name = "loaded";
            this.loaded.Size = new System.Drawing.Size(22, 17);
            this.loaded.Text = "0%";
            this.loaded.Visible = false;
            // 
            // streaming
            // 
            this.streaming.ForeColor = System.Drawing.Color.Gainsboro;
            this.streaming.Name = "streaming";
            this.streaming.Size = new System.Drawing.Size(13, 17);
            this.streaming.Text = "0";
            this.streaming.Visible = false;
            // 
            // torrent_status
            // 
            this.torrent_status.ForeColor = System.Drawing.Color.Gainsboro;
            this.torrent_status.Name = "torrent_status";
            this.torrent_status.Size = new System.Drawing.Size(13, 17);
            this.torrent_status.Text = "0";
            this.torrent_status.Visible = false;
            // 
            // peers_found
            // 
            this.peers_found.ForeColor = System.Drawing.Color.Gainsboro;
            this.peers_found.Name = "peers_found";
            this.peers_found.Size = new System.Drawing.Size(100, 17);
            this.peers_found.Text = "Найдено пиров 0";
            this.peers_found.Visible = false;
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.top_panel.Controls.Add(this.caption);
            this.top_panel.Controls.Add(this.button1);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(720, 32);
            this.top_panel.TabIndex = 1;
            this.top_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
            // 
            // caption
            // 
            this.caption.AutoSize = true;
            this.caption.Font = new System.Drawing.Font("Motiva Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.caption.ForeColor = System.Drawing.Color.Gainsboro;
            this.caption.Location = new System.Drawing.Point(10, 8);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(95, 16);
            this.caption.TabIndex = 1;
            this.caption.Text = "uVideo Player";
            this.caption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(688, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Close_form);
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.main_panel.Controls.Add(this.viewport);
            this.main_panel.Controls.Add(this.control_panel);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 32);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(720, 346);
            this.main_panel.TabIndex = 2;
            // 
            // viewport
            // 
            this.viewport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.viewport.ContextMenuStrip = this.main_menu;
            this.viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewport.Image = global::uVideo_Player.Properties.Resources.logo;
            this.viewport.Location = new System.Drawing.Point(0, 0);
            this.viewport.Name = "viewport";
            this.viewport.Size = new System.Drawing.Size(720, 303);
            this.viewport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.viewport.TabIndex = 1;
            this.viewport.TabStop = false;
            this.viewport.DoubleClick += new System.EventHandler(this.viewport_DoubleClick);
            this.viewport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.viewport_MouseClick);
            this.viewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewport_MouseDown);
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openbtn,
            this.openTorrent,
            this.start_stream,
            this.fullscreen,
            this.exit});
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(185, 114);
            // 
            // openbtn
            // 
            this.openbtn.Image = global::uVideo_Player.Properties.Resources.open;
            this.openbtn.Name = "openbtn";
            this.openbtn.Size = new System.Drawing.Size(184, 22);
            this.openbtn.Text = "Открыть видео";
            this.openbtn.Click += new System.EventHandler(this.openbtn_Click);
            // 
            // openTorrent
            // 
            this.openTorrent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_watch,
            this.open_stream});
            this.openTorrent.Name = "openTorrent";
            this.openTorrent.Size = new System.Drawing.Size(184, 22);
            this.openTorrent.Text = "Открыть торрент";
            this.openTorrent.Click += new System.EventHandler(this.openTorrent_Click);
            // 
            // open_watch
            // 
            this.open_watch.Name = "open_watch";
            this.open_watch.Size = new System.Drawing.Size(216, 22);
            this.open_watch.Text = "Открыть и смотреть";
            this.open_watch.Click += new System.EventHandler(this.open_watch_Click);
            // 
            // open_stream
            // 
            this.open_stream.Name = "open_stream";
            this.open_stream.Size = new System.Drawing.Size(216, 22);
            this.open_stream.Text = "Открыть и транслировать";
            this.open_stream.Click += new System.EventHandler(this.open_stream_Click);
            // 
            // start_stream
            // 
            this.start_stream.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.http,
            this.rsp,
            this.udp});
            this.start_stream.Image = global::uVideo_Player.Properties.Resources.record;
            this.start_stream.Name = "start_stream";
            this.start_stream.Size = new System.Drawing.Size(184, 22);
            this.start_stream.Text = "Начать трансляцию";
            this.start_stream.Click += new System.EventHandler(this.start_stream_Click);
            // 
            // http
            // 
            this.http.Image = global::uVideo_Player.Properties.Resources.globe;
            this.http.Name = "http";
            this.http.Size = new System.Drawing.Size(102, 22);
            this.http.Text = "HTTP";
            this.http.Click += new System.EventHandler(this.http_Click);
            // 
            // rsp
            // 
            this.rsp.Image = global::uVideo_Player.Properties.Resources.display;
            this.rsp.Name = "rsp";
            this.rsp.Size = new System.Drawing.Size(102, 22);
            this.rsp.Text = "RTSP";
            this.rsp.Click += new System.EventHandler(this.rsp_Click);
            // 
            // udp
            // 
            this.udp.Image = global::uVideo_Player.Properties.Resources.two_displays;
            this.udp.Name = "udp";
            this.udp.Size = new System.Drawing.Size(102, 22);
            this.udp.Text = "UDP";
            this.udp.Click += new System.EventHandler(this.udp_Click);
            // 
            // fullscreen
            // 
            this.fullscreen.Image = global::uVideo_Player.Properties.Resources.bottom_border;
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Size = new System.Drawing.Size(184, 22);
            this.fullscreen.Text = "Во весь экран";
            this.fullscreen.Click += new System.EventHandler(this.fullscreen_Click);
            // 
            // exit
            // 
            this.exit.Image = global::uVideo_Player.Properties.Resources.exit;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(184, 22);
            this.exit.Text = "Выход";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // control_panel
            // 
            this.control_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.control_panel.Controls.Add(this.seeker_panel);
            this.control_panel.Controls.Add(this.volume_panel);
            this.control_panel.Controls.Add(this.buttons_panel);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.control_panel.Location = new System.Drawing.Point(0, 303);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(720, 43);
            this.control_panel.TabIndex = 0;
            // 
            // seeker_panel
            // 
            this.seeker_panel.Controls.Add(this.panel2);
            this.seeker_panel.Controls.Add(this.seek_p);
            this.seeker_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seeker_panel.Location = new System.Drawing.Point(120, 0);
            this.seeker_panel.Name = "seeker_panel";
            this.seeker_panel.Size = new System.Drawing.Size(480, 43);
            this.seeker_panel.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.total_time);
            this.panel2.Controls.Add(this.current_time);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 21);
            this.panel2.TabIndex = 1;
            // 
            // total_time
            // 
            this.total_time.Dock = System.Windows.Forms.DockStyle.Right;
            this.total_time.ForeColor = System.Drawing.Color.Silver;
            this.total_time.Location = new System.Drawing.Point(431, 0);
            this.total_time.Name = "total_time";
            this.total_time.Size = new System.Drawing.Size(49, 21);
            this.total_time.TabIndex = 5;
            this.total_time.Text = "00:00:00";
            this.total_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // current_time
            // 
            this.current_time.Dock = System.Windows.Forms.DockStyle.Left;
            this.current_time.ForeColor = System.Drawing.Color.Silver;
            this.current_time.Location = new System.Drawing.Point(0, 0);
            this.current_time.Name = "current_time";
            this.current_time.Size = new System.Drawing.Size(49, 21);
            this.current_time.TabIndex = 4;
            this.current_time.Text = "00:00:00";
            this.current_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seek_p
            // 
            this.seek_p.Controls.Add(this.seeker);
            this.seek_p.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.seek_p.Location = new System.Drawing.Point(0, 21);
            this.seek_p.Name = "seek_p";
            this.seek_p.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.seek_p.Size = new System.Drawing.Size(480, 22);
            this.seek_p.TabIndex = 0;
            // 
            // seeker
            // 
            this.seeker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.seeker.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.seeker.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.seeker.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.seeker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seeker.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.seeker.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.seeker.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.seeker.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.seeker.ForeColor = System.Drawing.Color.White;
            this.seeker.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.seeker.Location = new System.Drawing.Point(5, 2);
            this.seeker.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seeker.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seeker.Name = "seeker";
            this.seeker.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seeker.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.seeker.ShowDivisionsText = true;
            this.seeker.ShowSmallScale = false;
            this.seeker.Size = new System.Drawing.Size(470, 18);
            this.seeker.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seeker.TabIndex = 0;
            this.seeker.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.seeker.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.seeker.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.seeker.ThumbSize = new System.Drawing.Size(10, 10);
            this.seeker.TickAdd = 0F;
            this.seeker.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.seeker.TickDivide = 0F;
            this.seeker.TickStyle = System.Windows.Forms.TickStyle.None;
            this.seeker.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seeker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.seeker_MouseClick);
            this.seeker.MouseMove += new System.Windows.Forms.MouseEventHandler(this.seeker_MouseMove);
            // 
            // volume_panel
            // 
            this.volume_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.volume_panel.Controls.Add(this.vol_state);
            this.volume_panel.Controls.Add(this.volume_tr);
            this.volume_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.volume_panel.Location = new System.Drawing.Point(600, 0);
            this.volume_panel.Name = "volume_panel";
            this.volume_panel.Padding = new System.Windows.Forms.Padding(5, 21, 5, 0);
            this.volume_panel.Size = new System.Drawing.Size(120, 43);
            this.volume_panel.TabIndex = 3;
            // 
            // vol_state
            // 
            this.vol_state.BackColor = System.Drawing.Color.Transparent;
            this.vol_state.ForeColor = System.Drawing.Color.Gainsboro;
            this.vol_state.Location = new System.Drawing.Point(8, 3);
            this.vol_state.Name = "vol_state";
            this.vol_state.Size = new System.Drawing.Size(104, 21);
            this.vol_state.TabIndex = 1;
            this.vol_state.Text = "Громкость 100%";
            this.vol_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volume_tr
            // 
            this.volume_tr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.volume_tr.BarInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.volume_tr.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.volume_tr.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.volume_tr.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.volume_tr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volume_tr.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.volume_tr.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.volume_tr.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.volume_tr.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.volume_tr.ForeColor = System.Drawing.Color.White;
            this.volume_tr.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.volume_tr.Location = new System.Drawing.Point(5, 21);
            this.volume_tr.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.volume_tr.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.volume_tr.Name = "volume_tr";
            this.volume_tr.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.volume_tr.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.volume_tr.ShowDivisionsText = false;
            this.volume_tr.ShowSmallScale = false;
            this.volume_tr.Size = new System.Drawing.Size(110, 22);
            this.volume_tr.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.volume_tr.TabIndex = 0;
            this.volume_tr.Text = "colorSlider1";
            this.volume_tr.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.volume_tr.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.volume_tr.ThumbRoundRectSize = new System.Drawing.Size(12, 12);
            this.volume_tr.ThumbSize = new System.Drawing.Size(12, 12);
            this.volume_tr.TickAdd = 0F;
            this.volume_tr.TickColor = System.Drawing.Color.White;
            this.volume_tr.TickDivide = 0F;
            this.volume_tr.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volume_tr.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.volume_tr.Scroll += new System.Windows.Forms.ScrollEventHandler(this.volume_tr_Scroll);
            // 
            // buttons_panel
            // 
            this.buttons_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.buttons_panel.Controls.Add(this.stop_btn);
            this.buttons_panel.Controls.Add(this.pause_btn);
            this.buttons_panel.Controls.Add(this.play_btn);
            this.buttons_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttons_panel.Location = new System.Drawing.Point(0, 0);
            this.buttons_panel.MaximumSize = new System.Drawing.Size(120, 43);
            this.buttons_panel.MinimumSize = new System.Drawing.Size(120, 43);
            this.buttons_panel.Name = "buttons_panel";
            this.buttons_panel.Size = new System.Drawing.Size(120, 43);
            this.buttons_panel.TabIndex = 1;
            // 
            // stop_btn
            // 
            this.stop_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stop_btn.FlatAppearance.BorderSize = 0;
            this.stop_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.stop_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.stop_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stop_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.stop_btn.Location = new System.Drawing.Point(82, 6);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(32, 32);
            this.stop_btn.TabIndex = 1;
            this.stop_btn.Text = "[ ]";
            this.stop_btn.UseVisualStyleBackColor = false;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // pause_btn
            // 
            this.pause_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pause_btn.FlatAppearance.BorderSize = 0;
            this.pause_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.pause_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.pause_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pause_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.pause_btn.Location = new System.Drawing.Point(44, 6);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(32, 32);
            this.pause_btn.TabIndex = 2;
            this.pause_btn.Text = "I I";
            this.pause_btn.UseVisualStyleBackColor = false;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // play_btn
            // 
            this.play_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.play_btn.FlatAppearance.BorderSize = 0;
            this.play_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.play_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.play_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.play_btn.Location = new System.Drawing.Point(6, 6);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(32, 32);
            this.play_btn.TabIndex = 3;
            this.play_btn.Text = ">";
            this.play_btn.UseVisualStyleBackColor = false;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // seeker_tip
            // 
            this.seeker_tip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.seeker_tip.ForeColor = System.Drawing.Color.Gainsboro;
            this.seeker_tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.seeker_tip.ToolTipTitle = "Перейти к";
            // 
            // vol_tip
            // 
            this.vol_tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.vol_tip.ToolTipTitle = "Громкость";
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 400);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.st_strip);
            this.Font = new System.Drawing.Font("Motiva Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uVideo Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainform_FormClosing);
            this.Load += new System.EventHandler(this.mainform_Load);
            this.st_strip.ResumeLayout(false);
            this.st_strip.PerformLayout();
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            this.main_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewport)).EndInit();
            this.main_menu.ResumeLayout(false);
            this.control_panel.ResumeLayout(false);
            this.seeker_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.seek_p.ResumeLayout(false);
            this.volume_panel.ResumeLayout(false);
            this.buttons_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip st_strip;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.PictureBox viewport;
        private System.Windows.Forms.ContextMenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem openbtn;
        private System.Windows.Forms.ToolStripMenuItem openTorrent;
        private System.Windows.Forms.ToolStripMenuItem start_stream;
        private System.Windows.Forms.Label caption;
        private System.Windows.Forms.Panel buttons_panel;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button pause_btn;
        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.Panel seeker_panel;
        private System.Windows.Forms.Panel volume_panel;
        private System.Windows.Forms.ToolTip seeker_tip;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripStatusLabel buffer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel seek_p;
        private System.Windows.Forms.Label total_time;
        private System.Windows.Forms.Label current_time;
        private System.Windows.Forms.ToolStripMenuItem fullscreen;
        private System.Windows.Forms.ToolStripStatusLabel tor_speed;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.ToolStripStatusLabel loaded;
        private System.Windows.Forms.ToolTip vol_tip;
        private ColorSlider.ColorSlider volume_tr;
        private ColorSlider.ColorSlider seeker;
        private System.Windows.Forms.Label vol_state;
        private System.Windows.Forms.ToolStripStatusLabel streaming;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripStatusLabel torrent_status;
        private System.Windows.Forms.ToolStripStatusLabel peers_found;
        private System.Windows.Forms.ToolStripMenuItem http;
        private System.Windows.Forms.ToolStripMenuItem rsp;
        private System.Windows.Forms.ToolStripMenuItem udp;
        private System.Windows.Forms.ToolStripMenuItem open_watch;
        private System.Windows.Forms.ToolStripMenuItem open_stream;
    }
}


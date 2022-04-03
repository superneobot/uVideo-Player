using MonoTorrent;
using MonoTorrent.Client;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;

enum extension
{
    Torrent,
    File,
    Streaming
}

namespace uVideo_Player
{
    public partial class mainform : Form
    {
        public Torrent torrent;
        public TorrentManager manager;
        public VlcMediaPlayer player { get; }
        public ClientEngine engine;
        public Stream stream;
        public string file_to_play;
        public float buf;
        public int buf_int;
        extension playing_status;
        public mainform()
        {
            InitializeComponent();
            engine = new ClientEngine();
            stream = null;

            DirectoryInfo vlcLibDirectory = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            player = new VlcMediaPlayer(vlcLibDirectory);
            player.VideoHostControlHandle = viewport.Handle;
            //player.Video.AspectRatio = "16:9";

            seeker.Enabled = false;



            player.TimeChanged += Player_TimeChanged;
            player.LengthChanged += Player_LengthChanged;
            player.Playing += Player_Playing;
            player.Opening += Player_Opening;
            player.Buffering += Player_Buffering;
            player.Stopped += Player_Stopped;
            player.Video.Deinterlace = "";
            player.EndReached += Player_EndReached;


        }

        private async void Player_EndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            stop = true;
            status.Text = "Останавливаем";

            //player.Stop();

            if (engine.IsRunning)
            {
                await manager.StopAsync();
                await engine.StopAllAsync();
            }
            OnStopHideTorrentStr();
            status.Text = "Стоп";
            seeker.Value = 0;
            Invoke(new Action(delegate
            {
                seeker.Enabled = false;
                current_time.Text = "00:00:00";
                total_time.Text = "00:00:00";
                caption.Text = "uVideo Player";
            }));
        }

        private async void Player_Stopped(object sender, VlcMediaPlayerStoppedEventArgs e)
        {
            stop = true;
            status.Text = "Останавливаем";
            Invoke(new Action(delegate { seeker.Enabled = false; }));
            player.Stop();
            http.Checked = false;
            rsp.Checked = false;
            udp.Checked = false;
            if (engine.IsRunning)
            {
                await manager.StopAsync();
                await engine.StopAllAsync();
            }
            OnStopHideTorrentStr();
            status.Text = "Стоп";
            seeker.Value = 0;
            current_time.Text = "00:00:00";
            total_time.Text = "00:00:00";
            caption.Text = "uVideo Player";
        }

        private void Player_Buffering(object sender, VlcMediaPlayerBufferingEventArgs e)
        {
            buf = e.NewCache;
            buf_int = (int)buf;
            //buffer.Text = $"Буферизация " + buf.ToString("0") + "%";

        }

        private void Player_Opening(object sender, VlcMediaPlayerOpeningEventArgs e)
        {
            Invoke(new Action(delegate { status.Text = "Открываем видео"; }));
        }

        private void Player_Playing(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            var time = TimeSpan.FromMilliseconds(player.Time).ToString(@"hh\:mm\:ss");
            var total = TimeSpan.FromMilliseconds(player.Length).ToString(@"hh\:mm\:ss");
            Invoke(new Action(delegate
            {

                status.Text = "Воспроизведение";
                current_time.Text = time;
                total_time.Text = total;
                caption.Text = file_to_play;
                seeker.Enabled = true;

                if (playing_status == extension.File)
                {
                    progress.Visible = false;
                    loaded.Visible = false;
                    buffer.Visible = false;
                    tor_speed.Visible = false;
                    streaming.Visible = false;
                    torrent_status.Visible = false;
                    peers_found.Visible = false;
                }
                else if (playing_status == extension.Torrent)
                {
                    progress.Visible = true;
                    loaded.Visible = true;
                    buffer.Visible = true;
                    tor_speed.Visible = true;
                    streaming.Visible = false;
                    torrent_status.Visible = true;
                    peers_found.Visible = true;
                }
                else if (playing_status == extension.Streaming)
                {
                    progress.Visible = false;
                    loaded.Visible = false;
                    buffer.Visible = false;
                    tor_speed.Visible = false;
                    streaming.Visible = true;
                    torrent_status.Visible = false;
                    peers_found.Visible = false;
                }
            }));
        }

        private void Player_LengthChanged(object sender, VlcMediaPlayerLengthChangedEventArgs e)
        {
            Invoke(new Action(delegate
            {
                seeker.Maximum = (int)e.NewLength;
                seeker.Value = (int)player.Time;
            }));
        }

        private void Player_TimeChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            Invoke(new Action(delegate
            {
                seeker.Value = (int)player.Time;
                current_time.Text = TimeSpan.FromMilliseconds(player.Time).ToString(@"hh\:mm\:ss");
            }));
        }

        public bool mouse = false;
        private bool stop = false;
        private bool hide = false;
        private bool fullscreen_status = false;
        private bool playing = false;
        private string destination;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private async void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                player.Stop();
                if (engine.IsRunning)
                {
                    await manager.StopAsync();
                    await engine.StopAllAsync();
                }
            }
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            var logo = player.Video.Logo;
            logo.File = @"C:\Users\Sergey\Pictures\newsimg94353.jpg";

        }

        public async void OpenMedia()
        {
            //player.Stop();
            if (engine.IsRunning)
            {
                player.Stop();
                OnStopHideTorrentStr();
            }
            if (playing)
            {
                player.Stop();
                stop = true;
                playing = false;
            }
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Available files *.mkv, *.mp3, *.mp4, *.mpeg, *.avi | *mkv; *.mp3; *.mp4; *.mpeg; *.avi|Matroska Video file *.mkv | *.mkv|Music file *.mp3 | *.mp3|MP4 file *.mp4 | *.mp4|MPEG Video file *.mpeg | *.mpeg|AVI Video file *.avi | *.avi";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    stream = new FileStream(op.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    playing_status = extension.File;
                    file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                    player.Video.IsKeyInputEnabled = false;
                    player.Video.IsMouseInputEnabled = false;

                    var mediaOptions = new[]
                       {
                          ":sout =#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"
                          //":sout-keep"
                        };

                    player.SetMedia(stream, mediaOptions);
                    player.Play();
                    playing = true;
                    stop = false;
                }
            }
            // player.Play(stream); 
        }

        private void top_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void openbtn_Click(object sender, EventArgs e)
        {
            OpenMedia();
        }

        private void viewport_DoubleClick(object sender, EventArgs e)
        {
            if (!hide)
            {
                hide = true;
                top_panel.Visible = false;
                control_panel.Visible = false;
                st_strip.Visible = false;
            }
            else
            {
                hide = false;
                top_panel.Visible = true;
                control_panel.Visible = true;
                st_strip.Visible = true;
            }
        }

        private void Close_form(object sender, EventArgs e)
        {
            player.Stop();
            Close();
        }

        private async void openTorrent_Click(object sender, EventArgs e)
        {

        }

        private async Task OpenTorrentStream()
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Torrent file *.torrent | *.torrent";
                if (op.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        torrent = await Torrent.LoadAsync(op.FileName);
                        manager = await engine.AddStreamingAsync(torrent, "Downloads");
                        torrent_status.Visible = true;
                        peers_found.Visible = true;
                        await manager.StartAsync();
                        await manager.WaitForMetadataAsync();

                        var file = manager.Files[0];
                        var tor_stream = await manager.StreamProvider.CreateStreamAsync(file, CancellationToken.None);
                        stream = tor_stream;

                        manager.TorrentStateChanged += Manager_TorrentStateChanged;
                        manager.PeersFound += Manager_PeersFound;


                        playing_status = extension.Torrent;
                        file_to_play = $"uVideo Player [ {manager.Torrent.Name} ]";
                        player.Video.IsMouseInputEnabled = false;
                        player.Video.IsKeyInputEnabled = false;

                        var mediaOptions = new[]
                        {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":http{mux=ts, sdp=http://192.168.0.103:8080/}",
                        ":sout-keep",
                        ":no-sout-all"
                        };

                        player.SetMedia(stream, mediaOptions);
                        player.Play();
                        playing = true;
                        seeker.Minimum = 0;
                        seeker.Maximum = (int)player.Length;
                    }
                    catch { }
                    var task = Task.Run(() =>
                    {
                        Name = manager.Torrent.Name;
                        StringBuilder sb = new StringBuilder(1024);
                        sb.Remove(0, sb.Length);
                        try
                        {
                            while (engine.IsRunning)
                            {
                                Invoke(new Action(delegate { progress.Value = (int)manager.Progress; }));
                                Invoke(new Action(delegate { loaded.Text = $"{(int)manager.Progress}%"; }));
                                Invoke(new Action(delegate { buffer.Text = $"Буферизация {buf_int}%"; }));
                                Invoke(new Action(delegate { tor_speed.Text = AppendFormat(sb, $"{engine.TotalDownloadSpeed / 1024.0:0.00}kB/sec ↓ / {engine.TotalUploadSpeed / 1024.0:0.00}kB/sec ↑"); }));
                            }
                        }
                        catch { }
                    });
                    await Task.WhenAll(task);
                }
            }
        }



        private void Manager_PeersFound(object sender, PeersAddedEventArgs e)
        {
            Invoke(new Action(delegate { peers_found.Text = $"Пиры {e.ExistingPeers} | {e.NewPeers}"; }));
        }

        private void Manager_TorrentStateChanged(object sender, TorrentStateChangedEventArgs e)
        {
            if (e.NewState == TorrentState.Starting)
            {
                torrent_status.Text = "Подключение";
            }
            else if (e.NewState == TorrentState.Downloading)
            {
                torrent_status.Text = "Загрузка";
            }
            else if (e.NewState == TorrentState.Stopping)
            {
                torrent_status.Text = "Останавливаем";
            }
            else if (e.NewState == TorrentState.Stopped)
            {
                torrent_status.Text = "Остановлено";
            }
            else if (e.NewState == TorrentState.Hashing)
            {
                torrent_status.Text = "Грузим";
            }
        }

        string AppendFormat(StringBuilder sb, string str, params object[] formatting)
        {
            if (formatting != null && formatting.Length > 0)
                sb.AppendFormat(str, formatting);
            else
                sb.Append(str);
            sb.AppendLine();

            return str;
        }

        private void seeker_MouseClick(object sender, MouseEventArgs e)
        {
            long Faktor = (player.Length / seeker.Width);
            player.Time = (e.X * Faktor);
        }

        private void seeker_MouseMove(object sender, MouseEventArgs e)
        {
            long Faktor = (player.Length / seeker.Width);
            var time_pos = Faktor * e.X;
            var time_tip = TimeSpan.FromMilliseconds(time_pos).ToString();
            var index = time_tip.IndexOf('.');
            if (index >= 0)
            {
                time_tip = time_tip.Substring(0, index);
            }

            seeker_tip.SetToolTip(seeker, time_tip);
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                if (stop)
                {
                    stop = true;
                    player.Play(stream);
                    status.Text = "Воспроизведение";
                }
                else
                {
                    stop = false;
                    player.Play();
                    status.Text = "Воспроизведение";
                }
            }
            //player.Play();
        }

        private void pause_btn_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                stop = false;
                player.Pause();
                status.Text = "Пауза";
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            stop = true;
            player.Stop();
        }

        private void viewport_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void fullscreen_Click(object sender, EventArgs e)
        {
            if (!fullscreen_status)
            {
                fullscreen_status = true;
                fullscreen.Checked = true;
                fullscreen.Text = "Во весь экран";
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                fullscreen_status = false;
                fullscreen.Checked = false;
                fullscreen.Text = "Во весь экран";
                WindowState = FormWindowState.Normal;
            }
        }

        public void OnStopHideTorrentStr()
        {
            progress.Visible = false;
            loaded.Visible = false;
            buffer.Visible = false;
            tor_speed.Visible = false;
            streaming.Visible = false;
            torrent_status.Visible = false;
            peers_found.Visible = false;
        }

        private void volume_tr_Scroll(object sender, EventArgs e)
        {

        }

        private void volume_tr_Scroll(object sender, ScrollEventArgs e)
        {
            var param = volume_tr.Value;
            player.Audio.Volume = (int)param;
            vol_state.Text = $"Громкость {param}%";
            vol_tip.SetToolTip(volume_tr, $"{param}%");
        }

        private void start_stream_Click(object sender, EventArgs e)
        {

        }

        private void Stream_start()
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                if (op.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(op.FileName);
                    playing_status = extension.Streaming;

                    var mediaOptions = new[]
                    {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":http{mux=ts, sdp=http_address}",
                        ":sout-keep",
                        ":no-sout-all"
                    };

                    file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                    player.GetMedia();
                    player.SetMedia(file, mediaOptions);
                    player.Play();
                    playing = true;
                    stop = false;
                    streaming.Text = "Трансляция на rtsp://192.168.0.103:8080/";
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void http_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                player.Stop();
                stop = true;
                playing = false;

                using (OpenFileDialog op = new OpenFileDialog())
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(op.FileName);
                        playing_status = extension.Streaming;

                        var mediaOptions = new[]
                        {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":http{mux=ts, sdp=http_address}",
                        ":sout-keep",
                        ":no-sout-all"
                    };

                        file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                        player.GetMedia();
                        player.SetMedia(file, mediaOptions);
                        player.Play();
                        playing = true;
                        stop = false;
                        streaming.Text = $@"Трансляция на http://192.168.0.103:8080/";
                        http.Checked = true;
                    }
                }
            }
            else
            {
                using (OpenFileDialog op = new OpenFileDialog())
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(op.FileName);
                        playing_status = extension.Streaming;

                        var mediaOptions = new[]
                        {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":http{mux=ts, sdp=http_address}",
                        ":sout-keep",
                        ":no-sout-all"
                    };

                        file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                        player.GetMedia();
                        player.SetMedia(file, mediaOptions);
                        player.Play();
                        playing = true;
                        stop = false;
                        streaming.Text = $@"Трансляция на http://192.168.0.103:8080/";
                        http.Checked = true;
                    }
                }
            }
        }

        private void rsp_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                player.Stop();
                stop = true;
                playing = false;

                using (OpenFileDialog op = new OpenFileDialog())
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(op.FileName);
                        playing_status = extension.Streaming;


                        // :http{ mux = ffmpeg{ mux = flv},dst =:8080 /}
                        var mediaOptions = new[]
                        {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":rtp{mux=ts, sdp=rtsp://192.168.0.103:8080/}",
                        ":sout-keep",
                        ":no-sout-all"
                    };

                        file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                        player.GetMedia();
                        player.SetMedia(file, mediaOptions);
                        player.Play();
                        playing = true;
                        stop = false;
                        streaming.Text = "Трансляция на rtsp://192.168.0.103:8080/";
                        rsp.Checked = true;
                    }
                }
            }
            else
            {
                using (OpenFileDialog op = new OpenFileDialog())
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(op.FileName);
                        playing_status = extension.Streaming;


                        // :http{ mux = ffmpeg{ mux = flv},dst =:8080 /}
                        var mediaOptions = new[]
                        {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":rtp{mux=ts, sdp=rtsp://192.168.0.103:8080/}",
                        ":sout-keep",
                        ":no-sout-all"
                    };

                        file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                        player.GetMedia();
                        player.SetMedia(file, mediaOptions);
                        player.Play();
                        playing = true;
                        stop = false;
                        streaming.Text = "Трансляция на rtsp://192.168.0.103:8080/";
                        rsp.Checked = true;
                    }
                }
            }
        }

        private void udp_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                player.Stop();
                stop = true;
                playing = false;

                using (OpenFileDialog op = new OpenFileDialog())
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(op.FileName);
                        playing_status = extension.Streaming;

                        var mediaOptions = new[]
                        {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":udp{dst=192.168.0.103:1234/}",
                        ":sout-keep",
                        ":no-sout-all"
                    };

                        file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                        player.GetMedia();
                        player.SetMedia(file, mediaOptions);
                        player.Play();
                        playing = true;
                        stop = false;
                        streaming.Text = "Трансляция на UDP 192.168.0.103:1234/";
                        udp.Checked = true;
                    }
                }
            }
            else
            {
                using (OpenFileDialog op = new OpenFileDialog())
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(op.FileName);
                        playing_status = extension.Streaming;

                        var mediaOptions = new[]
                        {
                        ":sout=#transcode{vcodec=h264,vb=2000,venc=x264{profile=baseline},width=1280,height=720,acodec=mpga,ab=192,channels=2,samplerate=44100,scodec=none}"+
                        ":udp{dst=192.168.0.103:1234/}",
                        ":sout-keep",
                        ":no-sout-all"
                    };

                        file_to_play = $"uVideo Player [ {Path.GetFileNameWithoutExtension(op.FileName)} ]";
                        player.GetMedia();
                        player.SetMedia(file, mediaOptions);
                        player.Play();
                        playing = true;
                        stop = false;
                        streaming.Text = "Трансляция на UDP 192.168.0.103:1234/";
                        udp.Checked = true;
                    }
                }
            }
        }

        private async void open_stream_Click(object sender, EventArgs e)
        {
            if (engine.IsRunning)
            {
                player.Stop();
                playing = false;
                stop = true;
                await OpenTorrentStream();
            }
            else
            {
                await OpenTorrentStream();
            }
        }

        private async void open_watch_Click(object sender, EventArgs e)
        {
            if (engine.IsRunning)
            {
                player.Stop();
                playing = false;
                stop = true;
                await OpenTorrentPlay();
            }
            else
            {
                await OpenTorrentPlay();
            }
        }

        private async Task OpenTorrentPlay()
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Torrent file *.torrent | *.torrent";
                if (op.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        torrent = await Torrent.LoadAsync(op.FileName);
                        manager = await engine.AddStreamingAsync(torrent, "Downloads");
                        torrent_status.Visible = true;
                        peers_found.Visible = true;
                        await manager.StartAsync();
                        await manager.WaitForMetadataAsync();

                        var file = manager.Files[0];
                        var tor_stream = await manager.StreamProvider.CreateStreamAsync(file, CancellationToken.None);
                        stream = tor_stream;

                        manager.TorrentStateChanged += Manager_TorrentStateChanged;
                        manager.PeersFound += Manager_PeersFound;


                        playing_status = extension.Torrent;
                        file_to_play = $"uVideo Player [ {manager.Torrent.Name} ]";
                        player.Video.IsMouseInputEnabled = false;
                        player.Video.IsKeyInputEnabled = false;


                        player.SetMedia(stream);
                        player.Play();
                        playing = true;
                        seeker.Minimum = 0;
                        seeker.Maximum = (int)player.Length;
                    }
                    catch { }
                    var task = Task.Run(() =>
                    {
                        Name = manager.Torrent.Name;
                        StringBuilder sb = new StringBuilder(1024);
                        sb.Remove(0, sb.Length);
                        try
                        {
                            while (engine.IsRunning)
                            {
                                Invoke(new Action(delegate { progress.Value = (int)manager.Progress; }));
                                Invoke(new Action(delegate { loaded.Text = $"{(int)manager.Progress}%"; }));
                                Invoke(new Action(delegate { buffer.Text = $"Буферизация {buf_int}%"; }));
                                Invoke(new Action(delegate { tor_speed.Text = AppendFormat(sb, $"{engine.TotalDownloadSpeed / 1024.0:0.00}kB/sec ↓ / {engine.TotalUploadSpeed / 1024.0:0.00}kB/sec ↑"); }));
                            }
                        }
                        catch { }
                    });
                    await Task.WhenAll(task);
                }
            }
        }

        private void viewport_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

using System;
using System.IO;
using Vlc.DotNet.Core;

namespace uVideo_Player
{
    public class VPlayer
    {
        VlcMediaPlayer Player { get; set; }
        public IntPtr handle { get; set; }
        public bool IsPlay { get; set; }
        public string TimeChange { get; set; }
        public string TimeLenght { get; set; }

        public VPlayer(IntPtr handle)
        {
            DirectoryInfo vlcLibDirectory = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            Player = new VlcMediaPlayer(vlcLibDirectory);

            Player.VideoHostControlHandle = handle;
            Player.TimeChanged += Player_TimeChanged;
            Player.Playing += Player_Playing;
            Player.LengthChanged += Player_LengthChanged;
            //Player.Play(stream);
        }

        private void Player_LengthChanged(object sender, VlcMediaPlayerLengthChangedEventArgs e)
        {
            TimeLenght = TimeSpan.FromMilliseconds(Player.Length).ToString(@"hh\:mm\:ss");
        }

        private void Player_Playing(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            IsPlay = true;
        }

        public void Player_TimeChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            TimeChange = TimeSpan.FromMilliseconds(Player.Time).ToString(@"hh\:mm\:ss");
        }

        public void Stop()
        {
            Player.Stop();
        }

        public void Play(Stream stream)
        {
            Player.Play(stream);
        }

        public void Pause()
        {
            Player.Pause();
        }

        public float GetLenght(Stream stream)
        {
            return Player.Length;
        }

        public float GetPosition(Stream stream)
        {
            return Player.Position;
        }

    }
}

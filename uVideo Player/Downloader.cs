using MonoTorrent.Client;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace uVideo_Player
{
    public class Downloader
    {
        ClientEngine Engine { get; }
        public string peersConnected;
        public string connectionFailed;
        public string picesHashed;
        public string torrentState;
        public string announceComplete;
        public Downloader(ClientEngine engine)
        {
            Engine = engine;
        }

        public async Task DownloadAsync(CancellationToken token)
        {
            var downloadsPath = Path.Combine(Environment.CurrentDirectory, "Downloads");
            var torrentsPath = Path.Combine(Environment.CurrentDirectory, "Torrents");

            if (!Directory.Exists(torrentsPath))
                Directory.CreateDirectory(torrentsPath);
            string file = "";
            var settingsBuilder = new TorrentSettingsBuilder
            {
                MaximumConnections = 60,
            };
            var manager = await Engine.AddAsync(file, downloadsPath, settingsBuilder.ToSettings());
            manager.PeersFound += Manager_PeersFound;

            manager.PeerConnected += (o, e) =>
            {
                lock (peersConnected)
                    peersConnected = $"Connection succeeded: {e.Peer.Uri}";
            };

            manager.ConnectionAttemptFailed += (o, e) =>
            {
                lock (connectionFailed)
                    connectionFailed = $"Connection failed: {e.Peer.ConnectionUri} - {e.Reason}";
            };

            manager.PieceHashed += delegate (object o, PieceHashedEventArgs e)
            {
                lock (picesHashed)
                    picesHashed = $"Piece Hashed: {e.PieceIndex} - {(e.HashPassed ? "Pass" : "Fail")}";
            };

            manager.TorrentStateChanged += delegate (object o, TorrentStateChangedEventArgs e)
            {
                lock (torrentState)
                    torrentState = $"OldState: {e.OldState} NewState: {e.NewState}";
            };

            manager.TrackerManager.AnnounceComplete += (sender, e) =>
            {
                announceComplete = $"{e.Successful}: {e.Tracker}";
            };

            await manager.StartAsync();

            await Task.Delay(5000, token);
        }

        private void Manager_PeersFound(object sender, PeersAddedEventArgs e)
        {
            var str = $"Found {e.NewPeers} new peers and {e.ExistingPeers} existing peers";
        }
    }
}

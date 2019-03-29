using System;
using System.Threading;
using System.Threading.Tasks;
using Catalyst.Node.Common.Interfaces;
using Catalyst.Node.Common.Interfaces.Modules.Dfs;
using Ipfs;
using Ipfs.CoreApi;
using Ipfs.Engine;
using PeerTalk;

namespace Catalyst.Node.Core.Modules.Dfs
{
    public class IpfsDfs : IIpfsDfs
    {

        private readonly IpfsEngine _ipfsDfs;

        public IpfsDfs(IPasswordReader passwordReader)
        {
            var password = passwordReader.ReadSecurePasswordAsChars("Please provide your IPFS password");
            //TODO handle secure strings in IPFS
            _ipfsDfs = new IpfsEngine(password);
        }

        Task IService.StartAsync() { return this.StartAsync(); }

        Task IDfs.StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => _ipfsDfs.StartAsync(), cancellationToken);
        }

        public Task<IFileSystemNode> AddFileAsync(string filename, CancellationToken cancellationToken = default)
        {
            return _ipfsDfs.FileSystem.AddFileAsync(filename, cancel: cancellationToken);
        }

        public Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default)
        {
            return _ipfsDfs.FileSystem.ReadAllTextAsync(path, cancellationToken);
        }

        public IBitswapApi Bitswap => _ipfsDfs.Bitswap;

        public IBlockApi Block => _ipfsDfs.Block;

        public IBootstrapApi Bootstrap => _ipfsDfs.Bootstrap;

        public IConfigApi Config => _ipfsDfs.Config;

        public IDagApi Dag => _ipfsDfs.Dag;

        public IDhtApi Dht => _ipfsDfs.Dht;

        public IDnsApi Dns => _ipfsDfs.Dns;

        public IFileSystemApi FileSystem => _ipfsDfs.FileSystem;

        public IGenericApi Generic => _ipfsDfs.Generic;

        public IKeyApi Key => _ipfsDfs.Key;

        public INameApi Name => _ipfsDfs.Name;

        public IObjectApi Object => _ipfsDfs.Object;

        public IPinApi Pin => _ipfsDfs.Pin;

        public IPubSubApi PubSub => _ipfsDfs.PubSub;

        public IStatsApi Stats => _ipfsDfs.Stats;

        public ISwarmApi Swarm => _ipfsDfs.Swarm;

        public Task StartAsync() { return _ipfsDfs.StartAsync(); }
        public Task StopAsync() { return _ipfsDfs.StopAsync(); }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ipfsDfs.Dispose();
            }
        }
    }
}
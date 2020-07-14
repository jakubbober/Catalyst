#region LICENSE

/**
* Copyright (c) 2019 Catalyst Network
*
* This file is part of Catalyst.Node <https://github.com/catalyst-network/Catalyst.Node>
*
* Catalyst.Node is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
* (at your option) any later version.
*
* Catalyst.Node is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with Catalyst.Node. If not, see <https://www.gnu.org/licenses/>.
*/

#endregion

using System.Threading.Tasks;
using Catalyst.Modules.Network.Dotnetty.IO.EventLoop;
using Catalyst.Modules.Network.Dotnetty.IO.Transport.Channels;
using Catalyst.TestUtils;
using FluentAssertions;
using NUnit.Framework;

namespace Catalyst.Core.Lib.Tests.UnitTests.IO.Transport.Channels
{
    public sealed class TcpClientChannelFactoryTests
    {
        [Test]
        public async Task TcpClientChannelFactory_BuildChannel_Should_Return_IObservableChannel()
        {
            var eventLoopGroupFactoryConfiguration = new EventLoopGroupFactoryConfiguration
            {
                TcpClientHandlerWorkerThreads = 2
            };

            var eventLoopGroupFactory = new TcpClientEventLoopGroupFactory(eventLoopGroupFactoryConfiguration);
            var address = "/ip4/127.0.0.1/tcp/9000";

            var testTcpClientChannelFactory = new TestTcpClientChannelFactory();
            var channel = await testTcpClientChannelFactory.BuildChannelAsync(eventLoopGroupFactory, address).ConfigureAwait(false);

            channel.Should().BeOfType<ObservableChannel>();
        }
    }
}

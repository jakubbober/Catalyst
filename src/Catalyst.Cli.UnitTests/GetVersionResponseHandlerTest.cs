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

using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Catalyst.Cli.Handlers;
using Catalyst.Node.Common.Helpers.Extensions;
using Catalyst.Node.Common.Helpers.IO.Inbound;
using Catalyst.Node.Common.Interfaces;
using Catalyst.Node.Common.UnitTests.TestUtils;
using Catalyst.Protocol.Common;
using Catalyst.Protocol.Rpc.Node;
using DotNetty.Transport.Channels;
using NSubstitute;
using Serilog;
using Xunit;

namespace Catalyst.Cli.UnitTests 
{
    public sealed class GetVersionResponseHandlerTest : IDisposable
    {
        private readonly IUserOutput _output;
        public static readonly List<object[]> QueryContents;
        private readonly IChannelHandlerContext _fakeContext;
        
        private readonly ILogger _logger;
        private GetVersionResponseHandler _handler;

        static GetVersionResponseHandlerTest()
        {
            QueryContents = new List<object[]>()
            {
                new object[] {"0.0.0.0"},
                new object[] {""},
            };
        }
        
        public GetVersionResponseHandlerTest()
        {
            _logger = Substitute.For<ILogger>();
            _fakeContext = Substitute.For<IChannelHandlerContext>();
            _output = Substitute.For<IUserOutput>();
        }
        
        private IObservable<ChanneledAnySigned> CreateStreamWithMessage(AnySigned response)
        {
            var channeledAny = new ChanneledAnySigned(_fakeContext, response);
            var messageStream = new[] {channeledAny}.ToObservable();
            return messageStream;
        }
        
        [Theory]
        [MemberData(nameof(QueryContents))]  
        public void RpcClient_Can_Handle_GetVersionResponse(string version)
        {
            var response = new VersionResponse()
            {
                Version = version
            }.ToAnySigned(PeerIdHelper.GetPeerId("sender"), Guid.NewGuid());

            var messageStream = CreateStreamWithMessage(response);

            _handler = new GetVersionResponseHandler(_output, _logger);
            _handler.StartObserving(messageStream);
            
            _output.Received(1).WriteLine($"Node Version: {version}");
        }
        
        public void Dispose()
        {
            _handler?.Dispose();
        }
    }
}
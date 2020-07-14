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

using System.Linq;
using Catalyst.Abstractions.Cryptography;
using Catalyst.Abstractions.KeySigner;
using Catalyst.Core.Lib.Extensions;
using Catalyst.Core.Lib.Util;
using Catalyst.Core.Modules.Cryptography.BulletProofs;
using Catalyst.Core.Modules.Rpc.Server.IO.Observers;
using Catalyst.Protocol.Cryptography;
using Catalyst.Protocol.Wire;
using Catalyst.Protocol.Rpc.Node;
using Catalyst.TestUtils;
using Catalyst.TestUtils.Fakes;
using FluentAssertions;
using Microsoft.Reactive.Testing;
using NSubstitute;
using Serilog;
using NUnit.Framework;
using Google.Protobuf;
using Catalyst.Abstractions.P2P;

namespace Catalyst.Core.Lib.Tests.UnitTests.Rpc.IO.Observers
{
    public sealed class SignMessageRequestObserverTests
    {
        private ILogger _logger;
        private IKeySigner _keySigner;
        private IPeerClient _peerClient;
        private ISignature _signature;

        [SetUp]
        public void Init()
        {
            _keySigner = Substitute.For<FakeKeySigner>();
            _signature = Substitute.For<ISignature>();
            _signature.SignatureBytes.Returns(ByteUtil.GenerateRandomByteArray(new FfiWrapper().SignatureLength));
            _signature.PublicKeyBytes.Returns(ByteUtil.GenerateRandomByteArray(new FfiWrapper().PublicKeyLength));
            _logger = Substitute.For<ILogger>();
            _peerClient = Substitute.For<IPeerClient>();

            _keySigner.Sign(default, default).ReturnsForAnyArgs(_signature);
        }

        [TestCase("Hello Catalyst")]
        [TestCase("")]
        [TestCase("Hello&?!1253Catalyst")]
        public void SignMessageRequestObserver_Can_Return_SignMessageResponse(string message)
        {
            var testScheduler = new TestScheduler();

            var signMessageRequest = new SignMessageRequest
            {
                Message = message.ToUtf8ByteString(),
                SigningContext = new SigningContext()
            };

            var protocolMessage =
                signMessageRequest.ToProtocolMessage(MultiAddressHelper.GetAddress("sender"));

            var messageStream = MessageStreamHelper.CreateStreamWithMessage(testScheduler, protocolMessage);

            var peerSettings = MultiAddressHelper.GetAddress("sender").ToSubstitutedPeerSettings();
            var handler =
                new SignMessageRequestObserver(peerSettings, _peerClient, _logger, _keySigner);

            handler.StartObserving(messageStream);

            testScheduler.Start();

            var receivedCalls = _peerClient.ReceivedCalls().ToList();
            receivedCalls.Count.Should().Be(1);

            var sentResponse = (ProtocolMessage) receivedCalls.Single().GetArguments().First();
            var signResponseMessage = sentResponse.FromProtocolMessage<SignMessageResponse>();

            signResponseMessage.OriginalMessage.Should().Equal(ByteString.CopyFromUtf8(message));
            signResponseMessage.Signature.ToByteArray().Should().Equal(_signature.SignatureBytes);
            signResponseMessage.PublicKey.ToByteArray().Should().Equal(_signature.PublicKeyBytes);
        }
    }
}

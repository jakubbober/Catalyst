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
using Catalyst.Common.Interfaces.IO.Inbound;
using Catalyst.Common.Interfaces.IO.Messaging;
using Catalyst.Common.Interfaces.P2P.Messaging;
using Catalyst.Protocol.Common;
using Google.Protobuf;
using Serilog;

namespace Catalyst.Common.IO.Messaging.Handlers
{
    /// <summary>
    ///     Message handler for Ask message where you want to manipulate reputation of the recipient depending if they respond.
    /// </summary>
    /// <typeparam name="TProto"></typeparam>
    /// <typeparam name="TReputableCache"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class ReputableTellResponseHandlerBase<TProto, TReputableCache, TRequest, TResponse>
        : CorrelatableMessageHandlerBase<TProto, TReputableCache>,
            IReputationAskHandler<TReputableCache>
        where TProto : class, IMessage
        where TReputableCache : IMessageCorrelationCache
        where TRequest : class, IMessage<TRequest>
        where TResponse : class, IMessage<TResponse>
    {
        public TReputableCache ReputableCache { get; }

        protected ReputableTellResponseHandlerBase(TReputableCache reputableCache,
            ILogger logger)
            : base(reputableCache, logger)
        {
            ReputableCache = reputableCache;
        }
        
        /// <summary>
        ///     Adds a new message to the correlation cache before we flush it away down the socket.
        /// </summary>
        /// <param name="message"></param>
        protected override void Handler(IChanneledMessage<AnySigned> message)
        {
            ReputableCache.TryMatchResponse<TRequest, TResponse>(message.Payload);            
        }
    }
}
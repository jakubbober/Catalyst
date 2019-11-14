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
using System.Linq;
using Catalyst.Abstractions.IO.Events;
using Catalyst.Abstractions.Mempool.Repositories;
using Catalyst.Core.Lib.DAO;
using Catalyst.Core.Lib.Extensions;
using Catalyst.Core.Lib.Util;
using Catalyst.Core.Modules.Mempool.Repositories;
using Catalyst.Modules.Repository.CosmosDb;
using Catalyst.Protocol.Wire;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BaseController = Microsoft.AspNetCore.Mvc.Controller;

namespace Catalyst.Core.Modules.Web3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public sealed class MempoolController : BaseController
    {
        private readonly MempoolRepository _mempoolRepository;
        private readonly ITransactionReceivedEvent _transactionReceivedEvent;
        private readonly IMapperProvider _mapperProvider;

        public MempoolController(IMempoolRepository<TransactionBroadcastDao> mempoolRepository, ITransactionReceivedEvent transactionReceivedEvent, IMapperProvider mapperProvider)
        {
            _mempoolRepository = (MempoolRepository)mempoolRepository;
            _transactionReceivedEvent = transactionReceivedEvent;
            _mapperProvider = mapperProvider;
        }

        [HttpGet("{id}")]
        public TransactionBroadcastDao Get(string id)
        {
            id = id.ToLowerInvariant();
            return _mempoolRepository.ReadItem(id);
        }

        [HttpGet]
        public JsonResult GetMempool()
        {
            return Json(_mempoolRepository.GetAll(), new JsonSerializerSettings
            {
                Converters = JsonConverterProviders.Converters.ToList()
            });
        }

        [HttpGet("{publicKey}")]
        public JsonResult GetTransactionsByPublickey(string publicKey)
        {
            var contractEntries = _mempoolRepository.AsQueryable().Select(item=>item).SelectMany(item => item.ContractEntries.Where(contractEntry => contractEntry.Base.ReceiverPublicKey == publicKey.ToLowerInvariant()).Select(contractEntry => item))
                .ToList();

            return Json(contractEntries, new JsonSerializerSettings
            {
                Converters = JsonConverterProviders.Converters.ToList()
            });
        }

        [HttpPost]
        public JsonResult AddTransaction(string transactionBroadcastProtocolBase64)
        {
            try
            {
                var transactionBroadcastProtocolMessageBytes =
                    Convert.FromBase64String(transactionBroadcastProtocolBase64);
                var transactionBroadcastProtocolMessage =
                    ProtocolMessage.Parser.ParseFrom((transactionBroadcastProtocolMessageBytes));
                _transactionReceivedEvent.OnTransactionReceived(transactionBroadcastProtocolMessage);
                return Json(new { Success = true });
            }
            catch (Exception exc)
            {
                return Json(new { Success = false, exc.Message });
            }
        }
    }
}

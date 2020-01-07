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
using Catalyst.Abstractions.Kvm;
using Catalyst.Abstractions.Ledger;
using Catalyst.Core.Modules.Ledger.Repository;
using LibP2P;

namespace Catalyst.Core.Modules.Ledger
{
    public class DeltaResolver : IDeltaResolver
    {
        readonly IDeltaByNumberRepository _deltaByNumber;
        readonly ILedger _ledger;

        public DeltaResolver(IDeltaByNumberRepository deltaByNumber, ILedger ledger)
        {
            _deltaByNumber = deltaByNumber;
            _ledger = ledger;
        }

        public Cid Resolve(long deltaNumber)
        {
            return _deltaByNumber.TryFind(deltaNumber, out var deltaHash)
                ? deltaHash
                : throw new Exception($"Delta not found, delta number:'{deltaNumber}'");
        }

        public long LatestDeltaNumber => _ledger.LatestKnownDeltaNumber;

        public Cid LatestDelta => _ledger.LatestKnownDelta;
    }
}
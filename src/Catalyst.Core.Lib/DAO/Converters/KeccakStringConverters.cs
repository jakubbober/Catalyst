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

using AutoMapper;
using Nethermind.Core.Crypto;

namespace Catalyst.Core.Lib.DAO.Converters
{
    public class StringToKeccakConverter : IValueConverter<string, Keccak>
    {
        public Keccak Convert(string sourceMember, ResolutionContext context)
        {
            var sourceValue = new Keccak(sourceMember);
            return sourceValue;
        }
    }

    public class KeccakToStringConverter : IValueConverter<Keccak, string>
    {
        public string Convert(Keccak sourceMember, ResolutionContext context)
        {
            var sourceValue = sourceMember.ToString();
            return sourceValue; 
        }
    }
}

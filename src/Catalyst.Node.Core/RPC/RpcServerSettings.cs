/*
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

using Catalyst.Node.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using Dawn;

namespace Catalyst.Node.Core.RPC
{
    /// <summary>
    ///     This class provides the settings for the RpcServer class.
    /// </summary>
    public class RpcServerSettings : IRpcServerSettings
    {
        /// <summary>
        ///     Sets RpcServerSetting Attributes
        /// </summary>
        /// <param name="rootSection"></param>
        public RpcServerSettings(IConfigurationRoot rootSection)
        {
            Guard.Argument(rootSection, nameof(rootSection)).NotNull();
            var section = rootSection.GetSection("CatalystNodeConfiguration").GetSection("Rpc");
            Port = int.Parse(section.GetSection("Port").Value);
            AcceptInvalidCerts = bool.Parse(section.GetSection("AcceptInvalidCerts").Value);
            MutualAuthentication = bool.Parse(section.GetSection("MutualAuthentication").Value);
            PfxFileName = section.GetSection("PfxFileName").Value;
            BindAddress = IPAddress.Parse(section.GetSection("BindAddress").Value);
        }

        public int Port { get; set;}
        public IPAddress BindAddress { get; set;}
        public string PfxFileName { get; set; }
        public bool MutualAuthentication { get; set; }
        public bool AcceptInvalidCerts { get; set; }
    }
}
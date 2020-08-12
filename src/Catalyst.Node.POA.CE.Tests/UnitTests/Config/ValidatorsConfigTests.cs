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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Catalyst.Node.POA.CE.Tests.UnitTests.Config
{
    [TestFixture]
    public class ValidatorsConfigTests
    {
        [Test]
        public void Can_Parse_Validator_Json_File()
        {
            var json = File.ReadAllText("Config/validators.json");

            var jObj = JObject.Parse(json);
            var a = (JObject)jObj.GetValue("multi");

            var validatorSetStore = new ValidatorSetStore();
            var validator = new Validators(validatorSetStore, new List<IValidatorReader> { new ListValidatorReader(validatorSetStore), new ContractValidatorReader(validatorSetStore) });
            validator.ReadValidatorSets(a);

            var listSet = validator.GetValidators(0);
            var contractSet = validator.GetValidators(900);

            //var validators = JsonConvert.DeserializeObject<Validators>(json);
            var c = 0;
        }
    }
}

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

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Catalyst.Node.POA.CE
{
    public interface IValidatorSetStore
    {
        void Add(IValidatorSet validatorSet);
        IValidatorSet Get(int startBlock);
    }

    public class ValidatorSetStore : IValidatorSetStore
    {
        private IList<IValidatorSet> _validatorSets;

        public ValidatorSetStore()
        {
            _validatorSets = new List<IValidatorSet>();
        }

        public void Add(IValidatorSet validatorSet)
        {
            _validatorSets.Add(validatorSet);
        }

        public IValidatorSet Get(int startBlock)
        {
            return _validatorSets.First(x => x.StartBlock >= startBlock);
        }
    }

    public interface IValidatorSet
    {
        int StartBlock { get; }
        IEnumerable<string> GetValidators();
    }

    public class ListValidatorSet : IValidatorSet
    {
        private IEnumerable<string> _validators;
        public int StartBlock { get; }

        public ListValidatorSet(int startBlock, IEnumerable<string> validators)
        {
            StartBlock = startBlock;
            _validators = validators;
        }

        public IEnumerable<string> GetValidators()
        {
            return _validators;
        }
    }

    public class ContractValidatorSet : IValidatorSet
    {
        private string _contractAddress;

        public int StartBlock { get; }

        public ContractValidatorSet(int startBlock, string contractAddress)
        {
            StartBlock = startBlock;
            _contractAddress = contractAddress;
        }

        public IEnumerable<string> GetValidators()
        {
            return new List<string>();
        }
    }

    public interface IValidatorReader
    {
        void SetValidatorSetAtBlock(string startBlock, JProperty jProp);
    }

    public interface IContractValidatorReader : IValidatorReader
    {

    }

    public class ContractValidatorReader : IContractValidatorReader
    {
        private IValidatorSetStore _validatorSetStore;
        public ContractValidatorReader(IValidatorSetStore validatorSetStore)
        {
            _validatorSetStore = validatorSetStore;
        }

        public void SetValidatorSetAtBlock(string startBlock, JProperty jProp)
        {
            if (jProp.Name.ToLower() == "contract")
            {
                _validatorSetStore.Add(new ContractValidatorSet(int.Parse(startBlock), (string) jProp.Value));
            }
        }
    }

    public interface IListValidatorReader : IValidatorReader
    {

    }

    public class ListValidatorReader : IListValidatorReader
    {
        private IValidatorSetStore _validatorSetStore;
        public ListValidatorReader(IValidatorSetStore validatorSetStore)
        {
            _validatorSetStore = validatorSetStore;
        }

        public void SetValidatorSetAtBlock(string startBlock, JProperty jProp)
        {
            if (jProp.Name.ToLower() == "list")
            {
                _validatorSetStore.Add(new ListValidatorSet(int.Parse(startBlock), jProp.Value.ToObject<IList<string>>()));
            }
        }
    }

    public class Validators
    {
        private IValidatorSetStore _validatorSetStore;
        private IList<IValidatorReader> _validatorReaders;

        public Validators(IValidatorSetStore validatorSetStore, IList<IValidatorReader> validatorReaders)
        {
            _validatorSetStore = validatorSetStore;
            _validatorReaders = validatorReaders;
        }

        public void ReadValidatorSets(JObject validatorSets)
        {
            foreach (var validatorSet in validatorSets)
            {
                foreach (var validatorReader in _validatorReaders)
                {
                    validatorReader.SetValidatorSetAtBlock(validatorSet.Key, (JProperty)validatorSet.Value.First);
                }
            }
        }

        public IEnumerable<string> GetValidators(int blockHeight)
        {
            var validatorSet = _validatorSetStore.Get(blockHeight);
            return validatorSet.GetValidators();
        }
    }
}

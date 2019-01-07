﻿using System;
using System.Numerics;
using System.Threading.Tasks;
using ADL.Hex.HexConverters.Extensions;
using ADL.RLP;

namespace ADL.KeySigner
{
    public class TransactionChainId : TransactionBase
    {  
        //The R and S Hashing values
        private static readonly byte[] RHASH_DEFAULT = 0.ToBytesForRlpEncoding();
        private static readonly byte[] SHASH_DEFAULT = 0.ToBytesForRlpEncoding();

        public TransactionChainId(byte[] rawData, BigInteger chainId)
        {
            //Instantiate and decode
            SimpleRlpSigner = new RLPSigner(rawData, NUMBER_ENCODING_ELEMENTS);
            ValidateValidV(SimpleRlpSigner);
            AppendDataForHashRecovery(chainId);
        }

        public TransactionChainId(RLPSigner rlpSigner)
        {
            SimpleRlpSigner = rlpSigner;
            ValidateValidV(SimpleRlpSigner);
            GetChainIdFromVAndAppendDataForHashRecovery();
        }

        private static void ValidateValidV(RLPSigner rlpSigner)
        {
            if (!rlpSigner.IsVSignatureForChain())
                throw new Exception("Transaction should be used instead of TransactionChainId, invalid V");
        }
        private void GetChainIdFromVAndAppendDataForHashRecovery()
        {
            var chainId = GetChainFromVChain();
            AppendDataForHashRecovery(chainId);
        }

        private void AppendDataForHashRecovery(BigInteger chainId)
        {
            //append the chainId, r and s so it can be recovered using the raw hash
            //the encoding has only the default 6 values
            SimpleRlpSigner.AppendData(chainId.ToBytesForRlpEncoding(), RHASH_DEFAULT,
                SHASH_DEFAULT);
        }

        public TransactionChainId(byte[] rawData)
        {
            //Instantiate and decode
            SimpleRlpSigner = new RLPSigner(rawData, NUMBER_ENCODING_ELEMENTS);
            ValidateValidV(SimpleRlpSigner);
            GetChainIdFromVAndAppendDataForHashRecovery();
        }

        private BigInteger GetChainFromVChain()
        {
            return AtlasECKey.GetChainFromVChain(Signature.V.ToBigIntegerFromRlpDecoded());
        }

        public TransactionChainId(byte[] nonce, byte[] gasPrice, byte[] gasLimit, byte[] receiveAddress, byte[] value,
            byte[] data, byte[] chainId)
        {
            SimpleRlpSigner =
                new RLPSigner(GetElementsInOrder(nonce, gasPrice, gasLimit, receiveAddress, value, data, chainId),
                    NUMBER_ENCODING_ELEMENTS);
        }

        public TransactionChainId(byte[] nonce, byte[] gasPrice, byte[] gasLimit, byte[] receiveAddress, byte[] value,
            byte[] data, byte[] chainId, byte[] r, byte[] s, byte[] v)
        {
            SimpleRlpSigner = new RLPSigner(
                GetElementsInOrder(nonce, gasPrice, gasLimit, receiveAddress, value, data, chainId),
                r, s, v, NUMBER_ENCODING_ELEMENTS);
        }

        public TransactionChainId(string to, BigInteger amount, BigInteger nonce, BigInteger chainId)
            : this(to, amount, nonce, DEFAULT_GAS_PRICE, DEFAULT_GAS_LIMIT, chainId)
        {
        }

        public TransactionChainId(string to, BigInteger amount, BigInteger nonce, string data, BigInteger chainId)
            : this(to, amount, nonce, DEFAULT_GAS_PRICE, DEFAULT_GAS_LIMIT, data, chainId)
        {
        }

        public TransactionChainId(string to, BigInteger amount, BigInteger nonce, BigInteger gasPrice,
            BigInteger gasLimit, BigInteger chainId)
            : this(to, amount, nonce, gasPrice, gasLimit, "", chainId)
        {
        }

        public TransactionChainId(string to, BigInteger amount, BigInteger nonce, BigInteger gasPrice,
            BigInteger gasLimit, string data, BigInteger chainId) : this(nonce.ToBytesForRlpEncoding(),
            gasPrice.ToBytesForRlpEncoding(),
            gasLimit.ToBytesForRlpEncoding(), to.HexToByteArray(), amount.ToBytesForRlpEncoding(),
            data.HexToByteArray(), chainId.ToBytesForRlpEncoding()
        )
        {
        }

        public BigInteger GetChainIdAsBigInteger()
        {
            return ChainId.ToBigIntegerFromRlpDecoded();
        }

        public byte[] ChainId => SimpleRlpSigner.Data[6];

        public byte[] RHash => SimpleRlpSigner.Data[7];

        public byte[] SHash => SimpleRlpSigner.Data[8];

        /// <summary>
        /// Recovered Key from Signature
        /// </summary>
        public override AtlasECKey Key => AtlasECKey.RecoverFromSignature(SimpleRlpSigner.Signature,
            SimpleRlpSigner.RawHash,
            ChainId.ToBigIntegerFromRlpDecoded());

        public string ToJsonHex()
        {
            var data =
                $"['{Nonce.ToHex()}','{GasPrice.ToHex()}','{GasLimit.ToHex()}','{ReceiveAddress.ToHex()}','{Value.ToHex()}','{ToHex(Data)}','{ChainId.ToHex()}','{RHash.ToHex()}','{SHash.ToHex()}'";

            if (Signature != null)
                data = data + $", '{Signature.V.ToHex()}', '{Signature.R.ToHex()}', '{Signature.S.ToHex()}'";
            return data + "]";
        }

        public override void Sign(AtlasECKey key)
        {
            SimpleRlpSigner.Sign(key, GetChainIdAsBigInteger());
        }

        private byte[][] GetElementsInOrder(byte[] nonce, byte[] gasPrice, byte[] gasLimit, byte[] receiveAddress,
            byte[] value,
            byte[] data, byte[] chainId)
        {
            if (receiveAddress == null)
                receiveAddress = EMPTY_BYTE_ARRAY;
            //order  nonce, gasPrice, gasLimit, receiveAddress, value, data, chainId, r = 0, s =0
            return new[]
            {
                nonce, gasPrice, gasLimit, receiveAddress, value, data, chainId, RHASH_DEFAULT,
                SHASH_DEFAULT
            };
        }

#if !DOTNET35
        public override async Task SignExternallyAsync(IAtlasExternalSigner externalSigner)
        {
           await externalSigner.SignAsync(this).ConfigureAwait(false);
        }
#endif

    }

}
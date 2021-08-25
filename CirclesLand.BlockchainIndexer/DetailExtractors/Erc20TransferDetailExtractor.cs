using System;
using System.Collections.Generic;
using System.Linq;
using CirclesLand.BlockchainIndexer.TransactionDetailModels;
using Nethereum.RPC.Eth.DTOs;

namespace CirclesLand.BlockchainIndexer.DetailExtractors
{
    public static class Erc20TransferDetailExtractor
    {
        public static IEnumerable<IDetail> Extract(Transaction transactionData, TransactionReceipt receipt)
        {
            var erc20Logs = receipt.Logs
                .Where(o => o.SelectToken("topics").Values<string>().Contains(TransactionClassifier.TransferEventTopic))
                .ToArray();
            
            if (!erc20Logs.Any())
            {
                throw new Exception("The supplied transaction is not a valid CRC 'transfer' " +
                                    "transaction because it misses a log entry with " +
                                    $"topic {TransactionClassifier.TransferEventTopic}.");
            }
            
            foreach (var erc20Log in erc20Logs)
            {
                var isErc20Transfer = TransactionClassifier.IsErc20Transfer(
                    erc20Log,
                    out var tokenAddress,
                    out var from,
                    out var to,
                    out var value);

                if (!isErc20Transfer || value == null)
                {
                    throw new Exception("The supplied transaction and receipt is not a Erc20Transfer.");
                }

                yield return new Erc20Transfer
                {
                    From = from,
                    To = to,
                    Token = tokenAddress,
                    Value = value.ToString()
                };
            };
        }
    }
}
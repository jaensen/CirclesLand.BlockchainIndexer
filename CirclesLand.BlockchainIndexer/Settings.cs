namespace CirclesLand.BlockchainIndexer
{
    public class Settings
    {
        public static string ConnectionString;
        public static string RpcEndpointUrl;

        public static int UseBulkSourceThreshold = 10;
        public static int BulkFlushInterval = 25;
        public static int SerialFlushInterval = 1;

        public static int ErrorRestartPenaltyInMs = 1000 * 5;
        public static int MaxErrorRestartPenaltyInMs = 1000 * 60 * 2;
        public static int PollingIntervalInMs = 500;

        public static int MaxParallelBlockDownloads = 24;
        public static int MaxDownloadedBlockBufferSize = 24 * 25;

        public static int MaxParallelReceiptDownloads = 96;
        public static int MaxDownloadedTransactionsBufferSize = 96 * 25;
        public static int MaxDownloadedReceiptsBufferSize = 96 * 25;

        public static int WriteToStagingBatchSize = 2000;
        public static int WriteToStagingBatchMaxIntervalInSeconds = 5;
        public static int MaxWriteToStagingBatchBufferSize = 25;
    }
}
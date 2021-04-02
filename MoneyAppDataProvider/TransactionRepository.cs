namespace MoneyAppDataProvider
{
    public class TransactionRepository:ITransactionRepository
    {
        private string connectionString;

        public TransactionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
namespace System.Threading
{
    public class CancellationTokenSource
    {
        private CancellationToken token = new CancellationToken();

        public CancellationToken Token
        {
            get { return token; }
        }

        public void Cancel()
        {
            token.Cancel();
        }
    }
}
namespace HalloSingelton
{
    internal sealed class Logger
    {
        private static Logger _instance;
        private static readonly Object _lockObj = new();
        public static Logger Instance
        {
            get
            {
                lock (_lockObj)
                {
                    _instance ??= new Logger();
                }

                return _instance;
            }
        }

        private Logger()
        {
            Console.WriteLine("NEUER LOGGER");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INF] {DateTime.Now:G} {msg}");
        }
    }
}

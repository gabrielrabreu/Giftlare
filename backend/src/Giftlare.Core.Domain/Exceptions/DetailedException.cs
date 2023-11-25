namespace Giftlare.Core.Domain.Exceptions
{
    public abstract class DetailedException : Exception
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        protected DetailedException(string type,
                                    string error,
                                    string detail)
            : base(GetMessage(type, error, detail))
        {
            Type = type;
            Error = error;
            Detail = detail;
        }

        private static string GetMessage(string type,
                                        string error,
                                        string detail)
            => $"{type} | {error} | {detail}";
    }
}

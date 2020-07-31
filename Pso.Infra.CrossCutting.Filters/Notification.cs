namespace Pso.Infra.CrossCutting.Filters
{
    public class Notification
    {
        public string PropertyName { get; }
        public string Key { get; }
        public string Message { get; }

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public Notification(string propertyName, string key, string message)
        {
            PropertyName = propertyName;
            Key = key;
            Message = message;
        }
    }
}

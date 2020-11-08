using System;

namespace OnlineStore.Data
{
    public interface IDataWrapper<out T> { };
    public class DataWrapper<T> : IDataWrapper<T>
    {
        public T Data { get; set; }
        public bool IsOk => ExceptionMessage == null;
        public string ExceptionMessage { get; set; }
    }
}

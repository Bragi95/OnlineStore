using System;

namespace OnlineStore.Data
{
    public class DataWrapper<T>
    {
        public T Data { get; set; }
        public bool IsOk => ExceptionMessage == null;
        public string ExceptionMessage { get; set; }
    }
}

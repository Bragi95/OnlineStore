namespace OnlineStore.API.Serveces
{
    public  class ResponseMessage
    {
        public const string YearOfManufactureFieldMissing = "Please enter the YearOfManufacture";
        public const string WeightFieldMissing = "Please enter the Weight 00.00 kg format";
        public const string BrandFieldMissing = "Please enter the Brand";
        public const string InvalidDateFormat = "Please change date to dd.MM.yyyy format";
        public const string Canceled = "Заказ уже отменен";
        public const string OrderCollected = "Заказ уже собран";
        public const string StorageNotFound = "Такого магазина нету";
        public const string CustomerNotFound = "Такого пользователя нету";
        public const string CustomerFieldMissing = "Пользователь не введен";
        public const string StorageFieldMissing = "Пожалуйста введите данные магазина";
        public const string GoodsFieldMissing = "Выберите товар для покупки";
        public const string PaymentTypeFieldMissing = "Выберите тип оплаты";
        public const string StatusFieldMissing = "Выберите статус заказа";

    }
}
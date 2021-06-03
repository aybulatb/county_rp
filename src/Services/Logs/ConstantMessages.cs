namespace CountyRP.Services.Logs
{
    public static class ConstantMessages
    {
        // Общие сообщения

        public static string InvalidCountItemPerPage = "Количество записей на странице должно быть от 1 до 100";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

        public static string InvalidIP = "IP должен соответствовать примеру: 127.0.0.1";

        // Логи

        public static string LogUnitNotFoundById = "Лог с ID {0} не найден";

        public static string LogUnitInvalidLoginLength = "Длина логина пользователя должна быть до 32 символов";

        public static string LogUnitInvalidTextLength = "Длина текста должна быть от 1 до 128 символов";
    }
}

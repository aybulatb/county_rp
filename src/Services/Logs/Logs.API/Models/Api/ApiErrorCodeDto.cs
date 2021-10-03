namespace CountyRP.Services.Logs.API.Models.Api
{
    public enum ApiErrorCodeDto
    {
        /// <summary>
        /// Неизвестная.
        /// </summary>
        Unknown = 0,

        // Общие сообщения

        /// <summary>
        /// Количество записей на странице должно быть от 1 до 100.
        /// </summary>
        CountItemPerPageMoreThan100 = 1000,

        /// <summary>
        /// Номер страницы должен быть 1 и выше.
        /// </summary>
        InvalidPageNumber = 1001,

        /// <summary>
        /// IP должен соответствовать примеру: 127.0.0.1.
        /// </summary>
        InvalidIP = 1002,

        // Логи

        /// <summary>
        /// Лог с ID {0} не найден.
        /// </summary>
        LogUnitNotFoundById = 2000,

        /// <summary>
        /// Длина логина пользователя должна быть до 32 символов.
        /// </summary>
        LogUnitInvalidLoginLength = 2001,

        /// <summary>
        /// Длина текста должна быть от 1 до 128 символов.
        /// </summary>
        LogUnitInvalidTextLength = 2002,
    }
}

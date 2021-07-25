namespace CountyRP.Services.Game.API.Models.Api
{
    public enum ApiErrorCodeDto
    {
        /// <summary>
        /// Неизвестный код.
        /// </summary>
        Unknown = 0,

        // Общие ошибки

        /// <summary>
        /// Количество записей на странице должно быть от 1 до 100.
        /// </summary>
        CountItemPerPageMoreThan100 = 1000,

        /// <summary>
        /// Количество записей на странице должно быть 1 и больше.
        /// </summary>
        InvalidCountItemPerPage = 1001,

        /// <summary>
        /// Номер страницы должен быть 1 и выше.
        /// </summary>
        InvalidPageNumber = 1002,

        /// <summary>
        /// Количество координат позиции должно быть равно 3.
        /// </summary>
        InvalidPositionCoordinatesCount = 1003,

        // Игроки

        /// <summary>
        /// Игрок с ID {0} не найден.
        /// </summary>
        PlayerNotFoundById = 2000,

        /// <summary>
        /// Длина логина игрока должна быть от 3 до 32 символов.
        /// </summary>
        PlayerInvalidLoginLength = 2001,

        /// <summary>
        /// Логин игрока должен состоять из цифр, символов латинского алфавита и специальных символов.
        /// </summary>
        PlayerInvalidLogin = 2002,

        /// <summary>
        /// Длина пароля должна быть от 8 до 64 символов.
        /// </summary>
        PlayerInvalidPasswordLength = 2003,

        /// <summary>
        /// Пароль должен состоять из символов латинского алфавита и специальных символов.
        /// </summary>
        PlayerInvalidPassword = 2004,

        /// <summary>
        /// Игрок с таким логином уже существует.
        /// </summary>
        PlayerAlreadyExistedWithLogin = 2005,

        // Персонажи

        /// <summary>
        /// Персонаж с ID {0} не найден.
        /// </summary>
        PersonNotFoundById = 3000,

        /// <summary>
        /// Длина имени персонажа должна быть от 3 до 32 символов.
        /// </summary>
        PersonInvalidNameLength = 3001,

        /// <summary>
        /// Имя персонажа должно состоять из цифр, символов латинского алфавита и специальных символов.
        /// </summary>
        PersonInvalidName = 3002,

        /// <summary>
        /// Игрок с таким именем уже существует.
        /// </summary>
        PersonAlreadyExistedWithName = 3003,

        // Админские уровни

        /// <summary>
        /// Админский уровень с ID {0} не найден.
        /// </summary>
        AdminLevelNotFoundById = 4000,

        // Внешности

        /// <summary>
        /// Внешность с ID {0} не найдена.
        /// </summary>
        AppearanceNotFoundById = 5000,

        // Банкоматы

        /// <summary>
        /// Банкомат с ID {0} не найден.
        /// </summary>
        AtmNotFoundById = 6000,

        // Бизнесы

        /// <summary>
        /// Бизнес с ID {0} не найден.
        /// </summary>
        BusinessNotFoundById = 7000,

        // Фракции

        /// <summary>
        /// Фракция с ID {0} не найдена.
        /// </summary>
        FactionNotFoundById = 8000,

        // Группировки

        /// <summary>
        /// Группировка с ID {0} не найдена.
        /// </summary>
        GangNotFoundById = 9000,

        // Гаражи

        /// <summary>
        /// Гараж с ID {0} не найден.
        /// </summary>
        GarageNotFoundById = 10000,

        // Дома

        /// <summary>
        /// Дом с ID {0} не найден.
        /// </summary>
        HouseNotFoundById = 11000,

        // Раздевалки

        /// <summary>
        /// Раздевалка с ID {0} не найдена.
        /// </summary>
        LockerRoomNotFoundById = 12000,

        // Помещения

        /// <summary>
        /// Помещение с ID {0} не найдено.
        /// </summary>
        RoomNotFoundById = 13000,

        // Телепорты

        /// <summary>
        /// Телепорт с ID {0} не найден.
        /// </summary>
        TeleportNotFoundById = 14000,

        // Транспортные средства

        /// <summary>
        /// Транспортное средство с ID {0} не найдено.
        /// </summary>
        VehicleNotFoundById = 15000,

        /// <summary>
        /// Для привязки транспортного средства не найден персонаж с ID {0}.
        /// </summary>
        VehicleOwnerNotFoundById = 15001,

        /// <summary>
        /// Для привязки транспортного средства не найдена фракция с ID {0}.
        /// </summary>
        VehicleFactionNotFoundById = 15002,

        /// <summary>
        /// Номер транспортного средства должен соответствовать формату 1AAA111
        /// </summary>
        VehicleInvalidLicensePlate = 15003,
    }
}

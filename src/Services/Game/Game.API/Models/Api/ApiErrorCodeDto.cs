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

        /// <summary>
        /// Количество цветов маркера должно быть равно 3.
        /// </summary>
        InvalidMarkerColorsCount = 1004,

        /// <summary>
        /// ID должен быть от 3 до 16 символов и содержать цифр, символы латинского алфавита и знак нижнего подчёркивания.
        /// </summary>
        InvalidId = 1005,

        /// <summary>
        /// Цвет должен соответствовать формату: FFFFFF.
        /// </summary>
        InvalidColor = 1006,

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

        /// <summary>
        /// ID админского уровня должен соответствовать формату zZ_ и длина должна быть от 3 до 16 символов.
        /// </summary>
        AdminLevelInvalidId = 4001,

        /// <summary>
        /// Длина названия админского уровня должна быть от 1 до 16 символов.
        /// </summary>
        AdminLevelInvalidNameLength = 4002,

        /// <summary>
        /// Название админского уровня должно состоять из цифр, символов латинского и кириллического алфавита и пробелов.
        /// </summary>
        AdminLevelInvalidName = 4003,

        /// <summary>
        /// Админский уровень с таким названием уже существует.
        /// </summary>
        AdminLevelAlreadyExistsWithName = 4004,

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

        /// <summary>
        /// Для привязки банкомата бизнес с ID {0} не найден.
        /// </summary>
        AtmBusinessNotFoundById = 6001,

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

        /// <summary>
        /// Длина названия фракции должна быть от 1 до 64 символов.
        /// </summary>
        FactionInvalidNameLength = 8001,

        /// <summary>
        /// Название фракции должно состоять из цифр, символов латинского и кириллического алфавитов, специальных символов и пробелов.
        /// </summary>
        FactionInvalidName = 8002,

        /// <summary>
        /// Фракция с ID {0} уже существует.
        /// </summary>
        FactionAlreadyExistsWithId = 8003,

        /// <summary>
        /// Количество рангов фракции должно быть ровно 15.
        /// </summary>
        FactionInvalidRanksCount = 8004,

        /// <summary>
        /// Названия рангов фракции должно быть от 1 до 32 символов.
        /// </summary>
        FactionInvalidRanksNameLength = 8005,

        /// <summary>
        /// Названия рангов фракции должны состоять из цифр, символов латинского и кириллического алфавитов, специальных символов и пробелов.
        /// </summary>
        FactionInvalidRanksName = 8006,

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

        /// <summary>
        /// Для привязки помещения не найдена группировка с ID {0}.
        /// </summary>
        RoomGangNotFoundById = 13001,

        // Телепорты

        /// <summary>
        /// Телепорт с ID {0} не найден.
        /// </summary>
        TeleportNotFoundById = 14000,

        /// <summary>
        /// Для привязки телепорта не найдена фракция с ID {0}.
        /// </summary>
        TeleportFactionNotFoundById = 14001,

        /// <summary>
        /// Для привязки телепорта не найдена группировка с ID {0}.
        /// </summary>
        TeleportGangNotFoundById = 14002,

        /// <summary>
        /// Для привязки телепорта не найдено помещение с ID {0}.
        /// </summary>
        TeleportRoomNotFoundById = 14003,

        /// <summary>
        /// Для привязки телепорта не найден бизнес с ID {0}.
        /// </summary>
        TeleportBusinessNotFoundById = 14004,

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

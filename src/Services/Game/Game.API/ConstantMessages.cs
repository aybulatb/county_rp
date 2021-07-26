namespace CountyRP.Services.Game.API
{
    public static class ConstantMessages
    {
        // Общие сообщения

        public static string CountItemPerPageMoreThan100 = "Количество записей на странице должно быть от 1 до 100";

        public static string InvalidCountItemPerPage = "Количество записей на странице должно быть 1 и больше";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

        public static string InvalidPositionCoordinatesCount = "Количество координат позиции должно быть равно 3";

        public static string InvalidMarkerColorsCount = "Количество цветов маркера должно быть равно 3";

        // Игроки

        public static string PlayerNotFoundById = "Игрок с ID {0} не найден";

        public static string PlayerInvalidLoginLength = "Длина логина игрока должна быть от 3 до 32 символов";

        public static string PlayerInvalidLogin = "Логин игрока должен состоять из цифр, символов латинского алфавита и специальных символов";

        public static string PlayerInvalidPasswordLength = "Длина пароля должна быть от 8 до 64 символов";

        public static string PlayerInvalidPassword = "Пароль должен состоять из символов латинского алфавита и специальных символов";

        public static string PlayerAlreadyExistedWithLogin = "Игрок с таким логином уже существует";

        // Персонажи

        public static string PersonNotFoundById = "Персонаж с ID {0} не найден";

        public static string PersonInvalidNameLength = "Длина имени персонажа должна быть от 3 до 32 символов";

        public static string PersonInvalidName = "Имя персонажа должно состоять из цифр, символов латинского алфавита и специальных символов";

        public static string PersonAlreadyExistedWithName = "Игрок с таким именем уже существует";

        // Админские уровни

        public static string AdminLevelNotFoundById = "Админский уровень с ID {0} не найден";

        // Внешности

        public static string AppearanceNotFoundById = "Внешность с ID {0} не найдена";

        // Банкоматы

        public static string AtmNotFoundById = "Банкомат с ID {0} не найден";

        // Бизнесы

        public static string BusinessNotFoundById = "Бизнес с ID {0} не найден";

        // Фракции

        public static string FactionNotFoundById = "Фракция с ID {0} не найдена";

        // Группировки

        public static string GangNotFoundById = "Группировка с ID {0} не найдена";

        // Гаражи

        public static string GarageNotFoundById = "Гараж с ID {0} не найден";

        // Дома

        public static string HouseNotFoundById = "Дом с ID {0} не найден";

        // Раздевалки

        public static string LockerRoomNotFoundById = "Раздевалка с ID {0} не найдена";

        // Помещения

        public static string RoomNotFoundById = "Помещение с ID {0} не найдено";

        public static string RoomGangNotFoundById = "Для привязки помещения не найдена группировка с ID {0}";

        // Телепорты

        public static string TeleportNotFoundById = "Телепорт с ID {0} не найден";

        public static string TeleportFactionNotFoundById = "Для привязки телепорта не найдена фракция с ID {0}";

        public static string TeleportGangNotFoundById = "Для привязки телепорта не найдена группировка с ID {0}";

        public static string TeleportRoomNotFoundById = "Для привязки телепорта не найдено помещение с ID {0}";

        public static string TeleportBusinessNotFoundById = "Для привязки телепорта не найден бизнес с ID {0}";

        // Транспортные средства

        public static string VehicleNotFoundById = "Транспортное средство с ID {0} не найдено";

        public static string VehicleOwnerNotFoundById = "Для привязки транспортного средства не найден персонаж с ID {0}";

        public static string VehicleFactionNotFoundById = "Для привязки транспортного средства не найдена фракция с ID {0}";

        public static string VehicleInvalidLicensePlate = "Номер транспортного средства должен соответствовать формату 1AAA111";
    }
}

namespace CountyRP.Services.Game.API
{
    public static class ConstantMessages
    {
        // Общие сообщения

        public static string CountItemPerPageMoreThan100 = "Количество записей на странице должно быть от 1 до 100";

        public static string InvalidCountItemPerPage = "Количество записей на странице должно быть 1 и больше";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

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

        // Транспортные средства

        public static string VehicleNotFoundById = "Транспортное средство с ID {0} не найден";
    }
}

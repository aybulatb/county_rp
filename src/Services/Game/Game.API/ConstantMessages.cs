namespace CountyRP.Services.Game.API
{
    public static class ConstantMessages
    {
        // Игроки

        public static string PlayerNotFoundById = "Игрок с ID {0} не найден";

        public static string PlayerInvalidLoginLength = "Длина логина игрока должна быть от 3 до 32 символов";

        public static string PlayerInvalidLogin = "Логин игрока должен состоять из цифр, символов латинского алфавита и специальных символов";

        public static string PlayerInvalidPasswordLength = "Длина пароля должна быть от 8 до 64 символов";

        public static string PlayerInvalidPassword = "Пароль должен состоять из символов латинского алфавита и специальных символов";

        public static string PlayerAlreadyExistedWithLogin = "Игрок с таким логином уже существует";
    }
}

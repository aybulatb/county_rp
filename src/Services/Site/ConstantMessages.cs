namespace CountyRP.Services.Site
{
    internal static class ConstantMessages
    {
        public static string UserNotFoundById = "Пользователь с ID {0} не найден";

        public static string UserNotFoundByLogin = "Пользователь с логином {0} не найден";

        public static string UserInvalidLoginLength = "Длина логина пользователя должна быть от 3 до 32 символов";

        public static string UserInvalidLogin = "Логин пользователя должен состоять из символов латинского алфавита и специальных символов";

        public static string UserInvalidPasswordLength = "Длина пароля должна быть от 8 до 64 символов";

        public static string UserInvalidPassword = "Пароль должен содержать символы латинского алфавита и специальные символы";

        public static string UserAlreadyExistedWithLogin = "Пользователь с таким логином уже существует";
    }
}

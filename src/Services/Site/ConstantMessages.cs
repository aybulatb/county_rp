namespace CountyRP.Services.Site
{
    internal static class ConstantMessages
    {
        public static string InvalidCountItemPerPage = "Количество страниц должно быть от 1 до 100";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

        public static string UserNotFoundById = "Пользователь с ID {0} не найден";

        public static string UserNotFoundByLogin = "Пользователь с логином {0} не найден";

        public static string UserInvalidLoginLength = "Длина логина пользователя должна быть от 3 до 32 символов";

        public static string UserInvalidLogin = "Логин пользователя должен состоять из символов латинского алфавита и специальных символов";

        public static string UserInvalidPasswordLength = "Длина пароля должна быть от 8 до 64 символов";

        public static string UserInvalidPassword = "Пароль должен содержать символы латинского алфавита и специальные символы";

        public static string UserAlreadyExistedWithLogin = "Пользователь с таким логином уже существует";

        public static string UserInvalidAuthentication = "Пользователь с таким логином и паролем не найден";
    }
}

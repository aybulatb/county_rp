namespace CountyRP.Services.Forum
{
    internal static class ConstantMessages
    {
        public static string InvalidCountItemPerPage = "Количество страниц должно быть от 1 до 100";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

        public static string UserNotFoundById = "Пользователь с ID {0} не найден";

        public static string UserNotFoundByLogin = "Пользователь с логином {0} не найден";

        public static string UserInvalidLoginLength = "Длина логина пользователя должна быть от 3 до 32 символов";

        public static string UserInvalidLogin = "Логин пользователя должен состоять из символов латинского алфавита и специальных символов";

        public static string UserInvalidGroupIdLength = "Длина id группы должна быть от 3 до 16 символов";

        public static string UserAlreadyExistedWithLogin = "Пользователь с таким логином уже существует";
    }
}

namespace CountyRP.Services.Forum.API
{
    internal static class ConstantMessages
    {
        public static string CountItemPerPageMoreThan100 = "Количество страниц должно быть от 1 до 100";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

        public static string UserNotFoundById = "Пользователь с ID {0} не найден";

        public static string UserNotFoundByLogin = "Пользователь с логином {0} не найден";

        public static string UserInvalidLoginLength = "Длина логина пользователя должна быть от 3 до 32 символов";

        public static string UserInvalidLogin = "Логин пользователя должен состоять из символов латинского алфавита и специальных символов";

        public static string UserAlreadyExistedWithLogin = "Пользователь с таким логином уже существует";

        public static string ForumInvalidNameLength = "Длина названия форума должна быть от 1 до 96 символов";

        public static string ForumNotFoundById = "Форум с ID {0} не найден";

        public static string TopicInvalidCaptionLength = "Длина заголовка темы должна быть от 1 до 128 символов";

        public static string TopicNotFoundById = "Тема с ID {0} не найдена";

        public static string PostNotFoundById = "Сообщение с ID {0} не найдено";

        public static string ModeratorNotFoundById = "Модератор с ID {0} не найден";

        public static string InvalidTextLength = "Длина должна быть от 1 до 128 символов";
    }
}

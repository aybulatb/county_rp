namespace CountyRP.Services.Site
{
    internal static class ConstantMessages
    {
        // Общие сообщения

        public static string InvalidCountItemPerPage = "Количество записей на странице должно быть от 1 до 100";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

        // Пользователи

        public static string UserNotFoundById = "Пользователь с ID {0} не найден";

        public static string UserNotFoundByLogin = "Пользователь с логином {0} не найден";

        public static string UserInvalidLoginLength = "Длина логина пользователя должна быть от 3 до 32 символов";

        public static string UserInvalidLogin = "Логин пользователя должен состоять из цифр, символов латинского алфавита и специальных символов";

        public static string UserInvalidPasswordLength = "Длина пароля должна быть от 8 до 64 символов";

        public static string UserInvalidPassword = "Пароль должен содержать символы латинского алфавита и специальные символы";

        public static string UserAlreadyExistedWithLogin = "Пользователь с таким логином уже существует";

        public static string UserInvalidAuthentication = "Пользователь с таким логином и паролем не найден";

        // Группы пользователей

        public static string GroupNotFoundById = "Группа пользователей с ID {0} не найдена";

        public static string GroupInvalidIdLength = "Длина ID группы пользователей должна быть от 3 до 16 символов";

        public static string GroupInvalidId = "ID группы пользователей должно состоять из цифр, символов кириллицы, латинского алфавита и специальных символов";

        public static string GroupInvalidNameLength = "Длина названия группы пользователей должна быть от 3 до 32 символов";

        public static string GroupInvalidName = "Название группы пользователей должно состоять из цифр, символов кириллицы, латинского алфавита и специальных символов";

        public static string GroupInvalidColor = "Цвет группы пользователей должен соотвествовать HEX-формату";

        public static string GroupAlreadyExistedWithId = "Группа пользователей с таким ID уже существует";

        public static string GroupInvalidMaxBan = "Максимальное количество часов бана у группы пользователей должно быть от {0} до {1}";

        public static string GroupNotFoundWithBanGroupId = "Группа пользователей с ID {0}, указанное в списке групп, которые можно банить, не найдена";
    }
}

namespace shop_final_project
{
    internal class Auth
    {
        static ConsoleKeyInfo key;
        public static int action;
        public static int startPosition = (int)Vars.startPosition;
        public static int position = startPosition;
        static int linesQTY;
        public static int endPosition = startPosition;
        public static int leftPosition = (int)Vars.leftPosition;
        public static int authRole = (int)Vars.authRole;
        public static bool isAuth = false;
        public static string uLogin = string.Empty;
        public static int? uID = null;

        public static void View()
        {
            if (isAuth == false && authRole == (int)Vars.authRole)
            {
                Console.WriteLine("\n   Логин: ");
                Console.WriteLine("  Пароль: ");
                Console.WriteLine("  Аутентификация");
                linesQTY = 2;
                endPosition = startPosition + linesQTY;
                Auth_Cursor();
            }
            else if (isAuth == true && authRole != (int)Vars.authRole)
            {
                for (int i = Auth.startPosition - 1; i < 15; i++)
                {
                    Console.SetCursorPosition(90, i);
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(92, startPosition);
                Console.WriteLine("F1 - Добавить запись");
                Console.SetCursorPosition(92, startPosition + 1);
                Console.WriteLine("F10 - Найти запись");
                Console.SetCursorPosition(92, startPosition + 3);
                Console.WriteLine("Escape - Выйти");
                switch (authRole)
                {
                    case (int)Roles.Administrator:
                        Admin.View(); 
                        break;
                    case (int)Roles.Cashier: 
                        break;
                    case (int)Roles.HR:
                        HR.View();
                        break;
                    case (int)Roles.Manager: 
                        break;
                    case (int)Roles.Accountant: 
                        break;
                }
                Cursor.View_Cursor();
            }
        }

        public static void Auth_Cursor() 
        {
            string login = "";
            string password = "";

            Console.SetCursorPosition(0, startPosition);
            Console.WriteLine("->");
            while (true)
            {
                key = Console.ReadKey();
                int action = Actions();
                if (action == (int)Keys.DownArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("  ");
                    position = Fix(position + 1);
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                }
                else if (action == (int)Keys.UpArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("  ");
                    position = Fix(position - 1);
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                }
                else if (action == (int)Keys.Enter)
                {
                    if (position == 4)
                    {
                        Console.SetCursorPosition(leftPosition, position);
                        login = Console.ReadLine();
                    }
                    else if (position == 5)
                    {
                        Console.SetCursorPosition(leftPosition, position);
                        List<char> passwordCharList = new();
                        ConsoleKeyInfo symbol = Console.ReadKey(true);
                        while (symbol.Key != ConsoleKey.Enter)
                        {
                            if (symbol.Key == ConsoleKey.Backspace)
                            {
                                if (leftPosition - 11 >= 0)
                                {
                                    Console.SetCursorPosition(leftPosition - 1, position);
                                    passwordCharList.RemoveAt(leftPosition - 11);
                                    Console.Write(" ");
                                    leftPosition--;
                                    symbol = Console.ReadKey(true);
                                }
                            }
                            else if (symbol.Key != ConsoleKey.Backspace)
                            {
                                passwordCharList.Add(symbol.KeyChar);
                                Console.SetCursorPosition(leftPosition, position);
                                Console.WriteLine("*");
                                leftPosition++;
                                symbol = Console.ReadKey(true);
                            }
                        }
                        foreach (char s in passwordCharList)
                        {
                            password += Convert.ToString(s);
                        }
                    }
                    else if (position == 6)
                    {
                        authRole = Users.CheckUser(login, password);
                        if (authRole != (int)Vars.authRole)
                        {
                            foreach (Users user in Users.usersList)
                            {
                                if (user.login == login)
                                {
                                    uID = user.ID;
                                    break;
                                }
                            }
                            uLogin = login;
                            isAuth = true;
                            Console.Clear();
                            View();
                        }
                        else
                        {
                            Console.SetCursorPosition(0, startPosition + 3);
                            Console.WriteLine("\nНеверное имя пользователя или пароль. Попробуйте еще раз.");
                            leftPosition = (int)Vars.leftPosition;
                            Console.SetCursorPosition(leftPosition, startPosition);
                            Console.WriteLine("                    ");
                            login = "";
                            Console.SetCursorPosition(leftPosition, startPosition + 1);
                            Console.WriteLine("                    ");
                            password = "";
                            Console.SetCursorPosition(0, position);
                            Console.WriteLine("  ");
                            position = startPosition;
                            Console.SetCursorPosition(0, position);
                            Console.WriteLine("->");
                        }
                    }
                }
            }
        }
        
        static int Actions()
        {
            while (true)
            {
                if (key.Key == ConsoleKey.DownArrow)
                {
                    action = (int)Keys.DownArrow;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    action = (int)Keys.UpArrow;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    action = (int)Keys.Enter;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    action = (int)Keys.Escape;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    action = (int)Keys.F1;
                }
                else if (key.Key == ConsoleKey.F10)
                {
                    action = (int)Keys.F10;
                }
                return action;
            }
        }

        static int Fix(int position)
        {
            if (position < startPosition)
            {
                position = endPosition;
            }
            else if (position > endPosition)
            {
                position = startPosition;
            }
            return position;
        }
    }
}

namespace shop_final_project
{
    internal class Cursor
    {
        static ConsoleKeyInfo key;
        static int action;
        static int index;

        private static void DownUpArrow()
        {
            key = Console.ReadKey();
            int action = Actions();
            if (action == (int)Keys.DownArrow)
            {
                Console.SetCursorPosition(0, Auth.position);
                Console.WriteLine("  ");
                Auth.position = Fix(Auth.position + 1);
                Console.SetCursorPosition(0, Auth.position);
                Console.WriteLine("->");
            }
            else if (action == (int)Keys.UpArrow)
            {
                Console.SetCursorPosition(0, Auth.position);
                Console.WriteLine("  ");
                Auth.position = Fix(Auth.position - 1);
                Console.SetCursorPosition(0, Auth.position);
                Console.WriteLine("->");
            }
        }

        public static void View_Cursor()
        {
            Auth.position = Auth.startPosition;
            Console.SetCursorPosition(0, Auth.startPosition);
            Console.WriteLine("->");
            while (true)
            {
                DownUpArrow();
                if (action == (int)Keys.Enter)
                {
                    Console.Clear();
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            index = Auth.position - Auth.startPosition; 
                            Admin a = new();
                            a.Read(index);
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            index = Auth.position - Auth.startPosition;
                            HR h = new();
                            h.Read(index);
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
                else if (action == (int)Keys.Escape)
                {
                    Auth.isAuth = false;
                    Auth.authRole = (int)Vars.authRole;
                    Auth.position = Auth.startPosition;
                    Auth.leftPosition = (int)Vars.leftPosition;
                    Auth.endPosition = Auth.startPosition;
                    Console.Clear();
                    Auth.View();
                }
                if (action == (int)Keys.F1)
                {
                    Console.Clear();
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            Admin a = new();
                            a.Create();
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            HR h = new();
                            h.Create();
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
                else if (action == (int)Keys.F10)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            Console.Clear();
                            Admin a = new();
                            a.Search();
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            Console.Clear();
                            HR h = new();
                            h.Search();
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
            }
        }
        public static void Create_Cursor()
        {
            Auth.position = Auth.startPosition;
            Console.SetCursorPosition(0, Auth.startPosition);
            Console.WriteLine("->");
            int id = Users.usersList.Count;
            string login_input = "";
            string password_input = "";
            int? role_input = null;
            int id_hr = Employees.employeesList.Count;
            string? lastname = "";
            string? firstname = "";
            string patronymic = string.Empty;
            DateTime? birthday = null;
            string? passport = "";
            string? post = "";
            int? salary = null;
            int? userID = null;
            while (true)
            {
                DownUpArrow();
                if (action == (int)Keys.Enter)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            if (Auth.position == 5)
                            {
                                Console.SetCursorPosition(9, Auth.position);
                                login_input = Console.ReadLine();
                            }
                            else if (Auth.position == 6)
                            {
                                Console.SetCursorPosition(12, Auth.position);
                                password_input = Console.ReadLine();
                            }
                            else if (Auth.position == 7)
                            {
                                Console.SetCursorPosition(8, Auth.position);
                                role_input = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            if (Auth.position == 5)
                            {
                                Console.SetCursorPosition(11, Auth.position);
                                lastname = Console.ReadLine();
                            }
                            else if (Auth.position == 6)
                            {
                                Console.SetCursorPosition(7, Auth.position);
                                firstname = Console.ReadLine();
                            }
                            else if (Auth.position == 7)
                            {
                                Console.SetCursorPosition(12, Auth.position);
                                patronymic = Console.ReadLine();
                            }
                            else if (Auth.position == 8)
                            {
                                Console.SetCursorPosition(17, Auth.position);
                                birthday = Convert.ToDateTime(Console.ReadLine());
                            }
                            else if (Auth.position == 9)
                            {
                                Console.SetCursorPosition(26, Auth.position);
                                passport = Console.ReadLine();
                            }
                            else if (Auth.position == 10)
                            {
                                Console.SetCursorPosition(13, Auth.position);
                                post = Console.ReadLine();
                            }
                            else if (Auth.position == 11)
                            {
                                Console.SetCursorPosition(12, Auth.position);
                                salary = Convert.ToInt32(Console.ReadLine());
                            }
                            else if (Auth.position == 12)
                            {
                                Console.SetCursorPosition(22, Auth.position);
                                userID = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
                else if (action == (int)Keys.Escape)
                {
                    Auth.position = Auth.startPosition;
                    Auth.leftPosition = (int)Vars.leftPosition;
                    Auth.endPosition = Auth.startPosition;
                    Console.Clear();
                    Auth.View();
                }
                else if (action == (int)Keys.S)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            Users.AddNewUser(id, login_input, password_input, (int)role_input);
                            Console.Clear();
                            Auth.View();
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            Employees.AddNewEmployee(id_hr, lastname, firstname, patronymic, (DateTime)birthday, passport, post, (int)salary, (int)userID);
                            Console.Clear();
                            Auth.View();
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
            }
        }

        public static void Read_Cursor()
        {
            Auth.position = Auth.startPosition;
            Console.SetCursorPosition(0, Auth.startPosition);
            Console.WriteLine("->");
            while (true)
            {
                DownUpArrow();
                if (action == (int)Keys.Escape)
                {
                    Auth.position = Auth.startPosition;
                    Auth.leftPosition = (int)Vars.leftPosition;
                    Auth.endPosition = Auth.startPosition;
                    Console.Clear();
                    Auth.View();
                }
                if (action == (int)Keys.F2)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            Console.Clear();
                            Admin a = new();
                            a.Update(index);
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
                else if (action == (int)Keys.Delete)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            Console.Clear();
                            Users.DeleteUser(index);
                            Auth.View();
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
            }
        }

        public static void Update_Cursor()
        {
            string login_input = "";
            string password_input = "";
            int role_input = 0;
            Auth.position = Auth.startPosition;
            Console.SetCursorPosition(0, Auth.startPosition);
            Console.WriteLine("->");
            while (true)
            {
                DownUpArrow();
                if (action == (int)Keys.Enter)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            if (Auth.position == 5)
                            {
                                Console.SetCursorPosition(9, Auth.startPosition + 1);
                                Console.WriteLine("                    ");
                                Console.SetCursorPosition(9, Auth.startPosition + 1);
                                login_input = Console.ReadLine();
                            }
                            if (Auth.position == 6)
                            {
                                Console.SetCursorPosition(12, Auth.startPosition + 2);
                                Console.WriteLine("                    ");
                                Console.SetCursorPosition(12, Auth.startPosition + 2);
                                password_input = Console.ReadLine();
                            }
                            if (Auth.position == 7)
                            {
                                Console.SetCursorPosition(8, Auth.startPosition + 3);
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(8, Auth.startPosition + 3);
                                role_input = Convert.ToInt32(Console.ReadLine());
                                if (role_input == null)
                                {
                                    role_input = Users.usersList[index].role;
                                }
                            }
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
                else if (action == (int)Keys.S)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            Users.UpdateUser(index, login_input, password_input, (int)role_input);
                            Console.Clear();
                            Admin a = new();
                            a.Read(index);
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
                else if (action == (int)Keys.Escape)
                {
                    Auth.position = Auth.startPosition;
                    Auth.leftPosition = (int)Vars.leftPosition;
                    Auth.endPosition = Auth.startPosition;
                    Console.Clear();
                    Auth.View();
                }
            }
        }

        public static void Search_Cursor()
        {
            var search_string = "";
            List<Users> userSearch = new();
            Auth.position = Auth.startPosition;
            Console.SetCursorPosition(0, Auth.startPosition);
            Console.WriteLine("->");
            while (true)
            {
                DownUpArrow();
                if (action == (int)Keys.Enter)
                {
                    switch (Auth.authRole)
                    {
                        case (int)Roles.Administrator:
                            Admin.Fields();
                            Console.SetCursorPosition(0, Auth.startPosition + 4);
                            Console.WriteLine("\nВведите значение для поиска:");
                            search_string = Console.ReadLine();
                            if (Auth.position == 4)
                            {
                                userSearch = Users.usersList.FindAll(user => user.ID == Convert.ToInt32(search_string));
                            }
                            if (Auth.position == 5)
                            {
                                userSearch = Users.usersList.FindAll(user => user.login == search_string);
                            }
                            if (Auth.position == 6)
                            {
                                userSearch = Users.usersList.FindAll(user => user.password == search_string);
                            }
                            if (Auth.position == 7)
                            {
                                userSearch = Users.usersList.FindAll(user => user.role == Convert.ToInt32(search_string));
                            }
                            break;
                        case (int)Roles.Cashier:
                            break;
                        case (int)Roles.HR:
                            break;
                        case (int)Roles.Manager:
                            break;
                        case (int)Roles.Accountant:
                            break;
                    }
                }
                else if (action == (int)Keys.F)
                {
                    Console.Clear();
                    Admin a = new();
                    a.SearchList();
                    int k = Auth.startPosition;
                    foreach (Users user in userSearch)
                    {
                        Console.SetCursorPosition(10, k);
                        Console.WriteLine(user.ID);
                        Console.SetCursorPosition(30, k);
                        Console.WriteLine(user.login);
                        Console.SetCursorPosition(50, k);
                        Console.WriteLine(user.password);
                        Console.SetCursorPosition(75, k);
                        Console.WriteLine(user.role);
                        k++;
                    }
                    Auth.endPosition = userSearch.Count + Auth.startPosition - 1;
                    Auth.position = Auth.startPosition;
                    Console.SetCursorPosition(0, Auth.position);
                    Console.WriteLine("->");
                }
                else if (action == (int)Keys.Escape)
                {
                    Auth.position = Auth.startPosition;
                    Auth.leftPosition = (int)Vars.leftPosition;
                    Auth.endPosition = Auth.startPosition;
                    Console.Clear();
                    Auth.View();
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
                else if (key.Key == ConsoleKey.F2)
                {
                    action = (int)Keys.F2;
                }
                else if (key.Key == ConsoleKey.F10)
                {
                    action = (int)Keys.F10;
                }
                else if (key.Key == ConsoleKey.Delete)
                {
                    action = (int)Keys.Delete;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    action = (int)Keys.S;
                }
                else if (key.Key == ConsoleKey.F)
                {
                    action = (int)Keys.F;
                }
                return action;
            }
        }

        static int Fix(int position)
        {
            if (position < Auth.startPosition)
            {
                position = Auth.endPosition;
            }
            else if (position > Auth.endPosition)
            {
                position = Auth.startPosition;
            }
            return position;
        }
    }
}

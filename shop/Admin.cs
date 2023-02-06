namespace shop_final_project
{
    public class Admin : Crud, ICrud
    {
        private static void Header()
        {
            Console.SetCursorPosition(92, 1);
            Console.WriteLine("Администратор");
            string name = "";
            foreach (Employees em in Employees.employeesList)
            {
                foreach (Users user in Users.usersList) 
                {
                    if (em.userID == Auth.uID)
                    {
                        name = em.firstname + " " + em.lastname;
                        break;
                    }
                    else
                    {
                        name = Auth.uLogin;
                    }
                }
                Console.SetCursorPosition(38, 1);
                Console.WriteLine(name + "!");
            }
        }

        public static void Fields()
        {
            Console.SetCursorPosition(0, Auth.startPosition);
            Console.WriteLine("  ID: ");
            Console.SetCursorPosition(0, Auth.startPosition + 1);
            Console.WriteLine("  login: ");
            Console.SetCursorPosition(0, Auth.startPosition + 2);
            Console.WriteLine("  password: ");
            Console.SetCursorPosition(0, Auth.startPosition + 3);
            Console.WriteLine("  role: ");
            Auth.endPosition = Auth.startPosition + 3;
        }

        public static void View()
        {
            Header();
            int i = Auth.startPosition - 1;
            Console.SetCursorPosition(10, i);
            Console.WriteLine("ID");
            Console.SetCursorPosition(30, i);
            Console.WriteLine("Логин");
            Console.SetCursorPosition(50, i);
            Console.WriteLine("Пароль");
            Console.SetCursorPosition(75, i);
            Console.WriteLine("Роль");
            int k = Auth.startPosition;
            foreach (Users user in Users.usersList)
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
            Auth.endPosition = Auth.startPosition + Users.usersList.Count - 1;
        }

        public override void Create()
        {
            base.Create();
            Header();
            Fields();
            Console.SetCursorPosition(6, Auth.startPosition);
            Console.WriteLine(Users.usersList.Count);
            Cursor.Create_Cursor();
        }

        public override void Read(int index)
        {
            base.Read(index);
            Header();
            Fields();
            Console.SetCursorPosition(7, Auth.startPosition);
            Console.WriteLine(Users.usersList[index].ID);
            Console.SetCursorPosition(9, Auth.startPosition + 1);
            Console.WriteLine(Users.usersList[index].login);
            Console.SetCursorPosition(12, Auth.startPosition + 2);
            Console.WriteLine(Users.usersList[index].password);
            Console.SetCursorPosition(8, Auth.startPosition + 3);
            Console.WriteLine(Users.usersList[index].role);
            Cursor.Read_Cursor();
        }

        public override void Update(int index)
        {
            base.Update(index);
            Header();
            Fields();
            Console.SetCursorPosition(7, Auth.startPosition);
            Console.WriteLine(Users.usersList[index].ID);
            Console.SetCursorPosition(9, Auth.startPosition + 1);
            Console.WriteLine(Users.usersList[index].login);
            Console.SetCursorPosition(12, Auth.startPosition + 2);
            Console.WriteLine(Users.usersList[index].password);
            Console.SetCursorPosition(8, Auth.startPosition + 3);
            Console.WriteLine(Users.usersList[index].role);
            Cursor.Update_Cursor();
        }

        public override void Delete()
        {
            base.Delete();
        }

        public override void Search()
        {
            base.Search();
            Header();
            Fields();
            Cursor.Search_Cursor();
        }

        public override void SearchList()
        {
            base.SearchList();
            Header();
            int i = Auth.startPosition - 1;
            Console.SetCursorPosition(10, i);
            Console.WriteLine("ID");
            Console.SetCursorPosition(30, i);
            Console.WriteLine("Логин");
            Console.SetCursorPosition(50, i);
            Console.WriteLine("Пароль");
            Console.SetCursorPosition(75, i);
            Console.WriteLine("Роль");
        }
        public static void DeserializeJson()
        {
            Users.usersList = Converter.Deserialize<List<Users>>("Users.json");
        }
    }
}

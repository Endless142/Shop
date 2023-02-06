namespace shop_final_project
{
    internal class HR : Crud, ICrud
    {
        private static void Header()
        {
            Console.SetCursorPosition(92, 1);
            Console.WriteLine("Кадровик");
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
            Console.WriteLine("  Фамилия: ");
            Console.SetCursorPosition(0, Auth.startPosition + 2);
            Console.WriteLine("  Имя: ");
            Console.SetCursorPosition(0, Auth.startPosition + 3);
            Console.WriteLine("  Отчество: ");
            Console.SetCursorPosition(0, Auth.startPosition + 4);
            Console.WriteLine("  Дата рождения: ");
            Console.SetCursorPosition(0, Auth.startPosition + 5);
            Console.WriteLine("  Серия и номер паспорта: ");
            Console.SetCursorPosition(0, Auth.startPosition + 6);
            Console.WriteLine("  Должность: ");
            Console.SetCursorPosition(0, Auth.startPosition + 7);
            Console.WriteLine("  Зарплата: ");
            Console.SetCursorPosition(0, Auth.startPosition + 8);
            Console.WriteLine("  Аккаунт сотрудника: ");
            Auth.endPosition = Auth.startPosition + 8;
        }

        public static void View()
        {
            Header();
            int i = Auth.startPosition - 1;
            Console.SetCursorPosition(2, i);
            Console.WriteLine("  ID: ");
            Console.SetCursorPosition(12, i);
            Console.WriteLine("  Фамилия: ");
            Console.SetCursorPosition(28, i);
            Console.WriteLine("  Имя: ");
            Console.SetCursorPosition(48, i);
            Console.WriteLine("  Отчество: ");
            Console.SetCursorPosition(68, i);
            Console.WriteLine("  Должность: ");
            int k = Auth.startPosition;
            foreach (Employees employee in Employees.employeesList)
            {
                Console.SetCursorPosition(5, k);
                Console.WriteLine(employee.ID);
                Console.SetCursorPosition(15, k);
                Console.WriteLine(employee.lastname);
                Console.SetCursorPosition(30, k);
                Console.WriteLine(employee.firstname);
                Console.SetCursorPosition(50, k);
                Console.WriteLine(employee.patronymic);
                Console.SetCursorPosition(70, k);
                Console.WriteLine(employee.post);
                k++;
            }
            Auth.endPosition = Auth.startPosition + Employees.employeesList.Count - 1;
        }

        public override void Create()
        {
            base.Create();
            Header();
            Header();
            Fields();
            Console.SetCursorPosition(6, Auth.startPosition);
            Console.WriteLine(Employees.employeesList.Count);
            Cursor.Create_Cursor();
        }

        public override void Read(int index)
        {
            base.Read(index);
            Header();
            Fields();
            Cursor.Read_Cursor();
        }

        public override void Update(int index)
        {
            base.Update(index);
            Header();
            Fields();
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
    }
}

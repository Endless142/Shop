namespace shop_final_project
{
    public class Crud
    {
        private void Header()
        {
            for (int i = Auth.startPosition - 1; i < 15; i++)
            {
                Console.SetCursorPosition(90, i);
                Console.WriteLine("|");
            }
        }

        private void Roles()
        {
            Console.SetCursorPosition(92, Auth.startPosition);
            Console.WriteLine("0 - Администратор");
            Console.SetCursorPosition(92, Auth.startPosition + 1);
            Console.WriteLine("1 - Кассир");
            Console.SetCursorPosition(92, Auth.startPosition + 2);
            Console.WriteLine("2 - Кадровик");
            Console.SetCursorPosition(92, Auth.startPosition + 3);
            Console.WriteLine("3 - Склад-менеджер");
            Console.SetCursorPosition(92, Auth.startPosition + 4);
            Console.WriteLine("4 - Бухгалтер");
        }
        public virtual void Create()
        {
            Header();
            Roles();
            Console.SetCursorPosition(92, Auth.startPosition + 6);
            Console.WriteLine("S - Добавить запись");
            Console.SetCursorPosition(92, Auth.startPosition + 7);
            Console.WriteLine("Escape - Вернуться в меню");
        }

        public virtual void Read(int index)
        {
            Header();
            Console.SetCursorPosition(92, Auth.startPosition);
            Console.WriteLine("F2 - Изменить запись");
            Console.SetCursorPosition(92, Auth.startPosition + 1);
            Console.WriteLine("Del - Удалить запись");
            Console.SetCursorPosition(92, Auth.startPosition + 2);
            Console.WriteLine("Escape - Назад");
        }

        public virtual void Update(int index)
        {
            Header();
            Roles();
            Console.SetCursorPosition(92, Auth.startPosition + 6);
            Console.WriteLine("S - Добавить запись");
            Console.SetCursorPosition(92, Auth.startPosition + 7);
            Console.WriteLine("Escape - Вернуться в меню");
        }

        public virtual void Delete()
        {

        }

        public virtual void Search()
        {
            Header();
            Roles();
            Console.SetCursorPosition(92, Auth.startPosition + 6);
            Console.WriteLine("F - Найти");
            Console.SetCursorPosition(92, Auth.startPosition + 7);
            Console.WriteLine("Escape - Вернуться в меню");
        }

        public virtual void SearchList()
        {
            Header();
            Roles();
            Console.SetCursorPosition(92, Auth.startPosition + 6);
            Console.WriteLine("Escape - Вернуться в меню");
        }
    }
}

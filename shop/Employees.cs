namespace shop_final_project
{
    internal class Employees
    {
        public int ID;
        public string? lastname;
        public string? firstname;
        public string patronymic = string.Empty;
        public DateTime birthday;
        public string? passport;
        public string? post;
        public int salary;
        public int userID;

        public static List<Employees> employeesList = new();

        public static void AddEmployee()
        {
            Employees AddEmployee = new()
            {
                ID = 0,
                lastname = "Иванов",
                firstname = "Иван",
                patronymic = "Иванович",
                birthday = new DateTime(2000,08,03),
                passport = "1234 123456",
                post = "Администратор",
                salary = 40000,
                userID = 0,
            };

            employeesList.Add(AddEmployee);
        }

        public static void AddNewEmployee(int id_hr, string lastname, string firstname, string patronymic, DateTime birthday, string passport, string post, int salary, int userID)
        {
            Employees addNewEmployee = new()
            {
                ID = id_hr,
                lastname = lastname,
                firstname = firstname,
                patronymic = patronymic,
                birthday = birthday,
                passport = passport,
                post = post,
                salary = salary,
                userID = userID,
            };

            employeesList.Add(addNewEmployee);
        }
    }
}

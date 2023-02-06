namespace shop_final_project
{
    internal class Users
    {
        public int ID;
        public string? login;
        public string? password;
        public int role;

        public static List<Users> usersList = new();
        static int authRole;

        public static void AddAdmin()
        {
            Users addAdmin = new()
            {
                ID = 0,
                login = "admin",
                password = "admin",
                role = 0,
            };

            usersList.Add(addAdmin);
            Converter.Serialize(new List<Users>(usersList), "Users.Json");
        }
        public static int CheckUser(string login, string password)
        {
            foreach (Users user in usersList)
            {
                if (user.login == login && user.password == password)
                {
                    authRole = (int)user.role;
                    break;
                }
                else
                {
                    authRole = 100;
                }
            }
            return authRole;
        }

        public static void AddNewUser(int id, string login_input, string password_input, int role_input)
        {
            Users addNewUser = new()
            {
                ID = id,
                login = login_input,
                password = password_input,
                role = role_input
            };

            usersList.Add(addNewUser);
            Converter.Serialize(new List<Users>(usersList), "Users.Json");
        }

        public static void UpdateUser(int index, string login_input, string password_input, int role_input)
        {
            if (login_input != string.Empty)
            {
                usersList[index].login = login_input;
            }
            else if (password_input != string.Empty)
            {
                usersList[index].password = password_input;
            }
            else if (role_input != null)
            {
                usersList[index].role = (int)role_input;
            }

            Converter.Serialize(new List<Users>(usersList), "Users.Json");
        }

        public static void DeleteUser(int index)
        {
            usersList.Remove(usersList[index]);
            Converter.Serialize(new List<Users>(usersList), "Users.Json");
        }
    }
}

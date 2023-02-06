namespace shop_final_project
{
    internal class Program
    {
        static void Main()
        {
            Admin.DeserializeJson();
            Employees.AddEmployee();
            Auth.View();
        }
    }
}
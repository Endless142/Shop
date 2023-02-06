namespace shop_final_project
{
    public interface ICrud
    {
        void Create();
        void Read(int index);
        void Update(int index);
        void Delete();
        void Search();
    }
}

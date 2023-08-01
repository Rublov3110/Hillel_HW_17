namespace Hillel_HW_12
{
    public interface IMyFamiliarRegister
    {
        bool AddMyFamiliar(MyFamiliar myFamiliar);
        public MyFamiliar? PutMyFamiliar(string name, string surname, UpdateMyFamiliarRequest vyFamiliar);
        public List<MyFamiliar?> GetMyFamiliar();
        public MyFamiliar? GetMyFamiliarName(string name, string surname);
        public bool DeletMyFamiliar(string name, string surname);


    }
}

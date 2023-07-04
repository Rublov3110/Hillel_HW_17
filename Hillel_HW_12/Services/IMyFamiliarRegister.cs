namespace Hillel_HW_12
{
    public interface IMyFamiliarRegister
    {
        bool AddMyFamiliar(CreateMyFamiliarRequest request);
        public IMyFamiliar? PutMyFamiliar(string name, string surname, UpdateMyFamiliarRequest updatedMyFamiliar);
        public List<IMyFamiliar?> GetMyFamiliar();
        public IMyFamiliar? GetMyFamiliarName(string name, string surname);
        public bool DeletMyFamiliar(string name, string surname);


    }
}

namespace Hillel_HW_12
{
    public interface IMyFamiliarRegister
    {
        bool AddMyFamiliar(CreateMyFamiliarRequest request);
        public IMyFamiliar? PutMyFamiliar(int id/*string name, string surname*/, UpdateMyFamiliarRequest updatedMyFamiliar);
        public List<IMyFamiliar?> GetMyFamiliar();
        public IMyFamiliar? GetMyFamiliarName(int id/*string name, string surname*/);
        public bool DeletMyFamiliar(int id/*string name, string surname*/);


    }
}

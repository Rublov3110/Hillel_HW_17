namespace Hillel_HW_12
{
    public interface IMyFamiliarRegister
    {
        void AddMyFamiliar(IMyFamiliar myFamiliar);

        IMyFamiliar GetMyFamiliar(string name);
 
    }
}

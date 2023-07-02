namespace Hillel_HW_12
{
    public class MyFamiliarRegister: IMyFamiliarRegister
    {
        private readonly List<IMyFamiliar> MyFamiliar = new List<IMyFamiliar>();

        public void AddMyFamiliar(IMyFamiliar myFamiliar)
        {
            MyFamiliar.Add(myFamiliar);
        }

        public IMyFamiliar GetMyFamiliar(string name) 
        {
            return MyFamiliar.FirstOrDefault(x=>x.Name == name);
        }
    }
}

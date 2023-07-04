using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Hillel_HW_12
{
    public class MyFamiliarRegister: IMyFamiliarRegister
    {
        private List<IMyFamiliar> MyFamiliar { get; set; }  = new List<IMyFamiliar>();

        public bool AddMyFamiliar(CreateMyFamiliarRequest request)
        {
            var myFamiliar = new MyFamiliar
            {
                ID = MyFamiliar.Count,
                Avatarka = request.Avatarka,
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age,
                Number = request.Number,
                Sity = request.Sity,
                Description = request.Description,
            };
            MyFamiliar.Add(myFamiliar);
            return true;
        }

        public IMyFamiliar? PutMyFamiliar(string name, string surname, UpdateMyFamiliarRequest updatedMyFamiliar)
        {
            var person = MyFamiliar.Find(x => x.Name == name && x.Surname == surname);
            if (person == null)
            {
                return person;
            }
            else
            {
                person.Avatarka = updatedMyFamiliar.Avatarka;
                person.Age = updatedMyFamiliar.Age;
                person.Number = updatedMyFamiliar.Number;
                person.Sity = updatedMyFamiliar.Sity;
                person.Description = updatedMyFamiliar.Description;
                return person;
            }
        }
        public List<IMyFamiliar?> GetMyFamiliar()
        {
            return MyFamiliar;
        }

        public IMyFamiliar? GetMyFamiliarName(string name, string surname) 
        {  
            return MyFamiliar.FirstOrDefault(x => x.Name == name && x.Surname == surname);    
        }

        public bool DeletMyFamiliar(string name, string surname)
        {
            var a = MyFamiliar.FirstOrDefault(x => x.Name == name && x.Surname == surname);
             return MyFamiliar.Remove(a);

        }
    }
}

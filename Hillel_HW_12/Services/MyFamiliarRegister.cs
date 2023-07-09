using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Hillel_HW_12
{
    public class MyFamiliarRegister: IMyFamiliarRegister
    {
        public ApplicationContext DbContext { get; }
        public MyFamiliarRegister(ApplicationContext dbContext)
        {
            DbContext = dbContext;
        }
        public bool AddMyFamiliar(IMyFamiliar myFamiliar)
        {

            DbContext.MyFamiliars.Add((MyFamiliar)myFamiliar);
            DbContext.SaveChanges();
            return true;
        }

        public IMyFamiliar? PutMyFamiliar(string name, string surname, UpdateMyFamiliarRequest myFamiliar)
        {
            var person = DbContext.MyFamiliars.FirstOrDefault(x => x.Name == name && x.Surname == surname);
            if (person == null)
            {
                return person;
            }
            else
            {
                person.Avatarka = myFamiliar.Avatarka;
                person.Age = myFamiliar.Age;
                person.Number = myFamiliar.Number;
                person.Sity = myFamiliar.Sity;
                person.Description = myFamiliar.Description;
                DbContext.MyFamiliars.Update(person);
                DbContext.SaveChanges();
                return person;
            }
        }
        public List<IMyFamiliar?> GetMyFamiliar()
        {
            var all = DbContext.MyFamiliars.ToList();
            var convertedAll = all.Cast<IMyFamiliar?>().ToList();
            return convertedAll;
        }

        public IMyFamiliar? GetMyFamiliarName(string name, string surname) 
        {  
            return DbContext.MyFamiliars.FirstOrDefault(x => x.Name == name && x.Surname == surname);    
        }

        public bool DeletMyFamiliar(string name, string surname)
        {
            var a = DbContext.MyFamiliars.FirstOrDefault(x => x.Name == name && x.Surname == surname);
            if (a != null)
            {
                DbContext.MyFamiliars.Remove(a);
                DbContext.SaveChanges();
                return true;
            }
             return false;

        }
    }
}

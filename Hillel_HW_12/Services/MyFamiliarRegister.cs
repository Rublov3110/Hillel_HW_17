using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public bool AddMyFamiliar(MyFamiliar myFamiliar)
        {

            DbContext.MyFamiliars.Add((MyFamiliar)myFamiliar);
            DbContext.SaveChanges();
            return true;
        }

        public MyFamiliar? PutMyFamiliar(string name, string surname, UpdateMyFamiliarRequest myFamiliar)
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
        public List<MyFamiliar?> GetMyFamiliar()
        {
            var all = DbContext.MyFamiliars.Include(x => x.Status).ToList();
            var convertedAll = all.Cast<MyFamiliar?>().ToList();
            return convertedAll;
        }

        public MyFamiliar? GetMyFamiliarName(string name, string surname) 
        {
            return DbContext.MyFamiliars
                .Include(x => x.Status)
                .FirstOrDefault(x => x.Name == name && x.Surname == surname);
                   
        }

        public bool DeletMyFamiliar(string name, string surname)
        {
            var a = DbContext.MyFamiliars.FirstOrDefault(x => x.Name == name && x.Surname == surname);
            
            if (a != null)
            {
                var b = DbContext.Status.FirstOrDefault(x => x.MyFamiliarId == a.ID);
                DbContext.Status.Remove(b);
                DbContext.MyFamiliars.Remove(a);
                DbContext.SaveChanges();
                return true;
            }
             return false;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceSoap
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<People> GetPeople()
        {
            using (TestowaContext db = new TestowaContext())
            {
                return db.People.ToList();
            }
        }

        [WebMethod]
        public People GetPerson(int id)
        {
            using (TestowaContext db = new TestowaContext())
            {
                return db.People.Single(g => g.Id == id);
            }
        }

        [WebMethod]
        public void AddPerson(string firstName, string lastName, int phonNumber)
        {
            using (TestowaContext db = new TestowaContext())
            {
                db.People.Add(new People() { FirstName = firstName, LastName = lastName, PhoneNumber = phonNumber});
                db.SaveChanges();
            }
        }

        [WebMethod]
        public void ModifyPerson(int id, string firstName, string lastName, int phonNumber)
        {
            using (TestowaContext db = new TestowaContext())
            {
                People person = new People() { Id = id, FirstName = firstName, LastName = lastName, PhoneNumber = phonNumber };
                db.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        [WebMethod]
        public void DeletePerson(int id)
        {
            using (TestowaContext db = new TestowaContext())
            {
                db.People.Remove(db.People.Single(g=>g.Id == id));
                db.SaveChanges();
            }
        }
    }
}

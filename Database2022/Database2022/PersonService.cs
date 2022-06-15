using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database2022
{
    public class PersonService
    {
        private readonly AppDbContext _context;

        public PersonService() => _context = App.GetContext();


        public bool Create(Person item)
        {
            try
            {
                //EntityFrameworkCore
                _context.People.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Person> Get()
        {
            return _context.People.ToList();
        }





    }
}

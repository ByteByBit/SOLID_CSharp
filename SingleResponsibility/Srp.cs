using System;
using System.IO;

namespace Solid.SingleResponsibility
{
    class Srp : IPrinciple
    {
        public string Principle() =>
        "Single Responsibility Principle:";
        
        public string Definition() =>
        "A class has to have one responsibility. If it has more, it becomes coupled. A single change to one responsibility might lead to change the other responsibility.";
    }

    // VIOLATION.
    // It is violating the single responsibility principle, as it is performint two tasks or 
    // responsibilities: user database management and user property management.
    class User
    {
        public string Name {get; set;}

        public int Age {get; set;}

        public void Save(Database db)
        {
            try
            {
                db.Add();
            }
            catch (Exception ex)
            {
                File.WriteAllText(@".\error.log", ex.ToString());
            }
        }
    }
    
    // SOLUTION.
    // This way the related features are groupped together and it is not violating
    // the single responsibility principle anymore.
    class UserImproved
    {
        public string Name {get; set;}

        public int Age {get; set;}

        private Wrapper wrapper = new Wrapper();

        public void Save()
        {
            wrapper.HandleAdd(this);
        }

    }

    class Wrapper
    {
        private Database db = new Database();

        private ErrorLogger el = new ErrorLogger();
        public void HandleAdd(UserImproved usr)
        {
            try
            {
                db.Add();
            }
            catch (Exception error)
            {
                el.Handle(error.ToString());
            }
        }
    }
    
}

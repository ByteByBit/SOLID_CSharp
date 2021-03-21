namespace Solid.OpenClosed
{
    class Ocp : IPrinciple
    {
        public string Principle() =>
        "Open-Closed Principle:";

        public string Definition() =>
        "Software entities(Classes, modules, functions) should be open for extension, not for modification.";
    }

    // VIOLATION.
    // The SetBonus function seems ok when we have two different stages of the user to consider,
    // but even with just ten different stage, it becomes long and a headache to manage.
    class User
    {
        public string Name {get; set;}

        public string Stage {get; set;}

        public void SetBonus(Database db)
        {
            if (this.Stage == "starter" )
            {
                db.Add();
            }
            else
            {
                db.AddExistingCustomer();
            }   
        }
    }

    // SOLUTION.
    // This way it is easier to extend, and harder to modify. Which what we want to conform the Open Closed Principle.
    class UserImproved
    {
        public string Name {get; set;}

        public string Stage {get; set;}

        public virtual void SetBonus(Database db)
        {
            db.Add();
        }
    }

    internal class MidUser : UserImproved
    {

        public override void SetBonus(Database db)
        {
            db.AddExistingCustomer();
        }
    }

    internal class AdvancedUser : UserImproved
    {

        public override void SetBonus(Database db)
        {
            db.AnotherExtension();
        }
    }
}

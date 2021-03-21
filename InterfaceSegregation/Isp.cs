namespace Solid.InterfaceSegregation
{
    class Isp : IPrinciple
    {
        public string Principle() =>
        "Interface Segregation Principle.";
        
        public string Definition() =>
        "This principle is used for large interfaces, and the point is that the interface should implement only generic methods, which are used by all clients.";

    }

    // VIOLATION.
    // The IAnimalMove interface defines the different movement types by the classified animals. The
    // violation comes when we consider that the Fish class has to implement the fly method for example.

    public interface IAnimalMove
    {
        void Walk();

        void Swim();

        void Fly(); 
    }

    public class Fish : IAnimalMove
    {

        public void Walk()
        {
            throw new System.Exception("Fish can't walk, only swim!");
        }
        public void Swim()
        {
            // This is the only one we need here.
        }
        public void Fly()
        {
            throw new System.Exception("Fish can't fly, only swim!");
        }
    }

    // SOLUTION.
    // By having a way more general interface, our animal classes do not have to implement 
    // useless methods.

    public interface IWaterMovement
    {
        void Swim();
    }

    public interface IGroundMovement
    {
        void Walk();
    }

    public interface IAirMovement
    {
        void Fly();
    }

    public class Bird: IGroundMovement, IAirMovement
    {
        public void Walk() {}

        public void Fly() {}

    }

    public class Mammal: IGroundMovement, IWaterMovement
    {
        public void Walk() {}

        public void Swim() {}

    }       
}

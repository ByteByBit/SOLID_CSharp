using System;
using System.IO;
using Solid.SingleResponsibility;

namespace Solid.DependencyInversion
{
    class Dip : IPrinciple
    {
        public string Principle() =>
        "Dependency Inversion Principle.";
        
        public string Definition() =>
        "High-level modules should not depend on low-level modules. Both low and high level classes should depend on the same abstractions. Abstractions should not depend on details. Details should depend upon abstractions.";
        

        // VIOLATION.
        // In the example above, the High-level module depends on the Low-level modules. This violates the 
        // Dependency Inversion Principle.

        public class BackendDeveloper
        {

            public void WriteCSharp() {}
        }

        public class FrontendDeveloper
        {

            public void WriteJavascript() {}
        }

        public class Project
        {
            BackendDeveloper backendDev = new BackendDeveloper();
            FrontendDeveloper frontendDev = new FrontendDeveloper();

            public void develop()
            {
                backendDev.WriteCSharp();
                frontendDev.WriteJavascript();
            }
        }

        // SOLUTION.
        // This way, the High-level module is not depending on the Low-level module(s), but on abstraction,
        // therefore it conforms the Dependency Inversion Principle.

        class BackendDev
        {
            public void develop() {}

        }

        class FrontendDev
        {
            public void develop() {}

        }

        class DevTeam
        {
            BackendDev backendDev = new BackendDev();
            FrontendDev frontendDev = new FrontendDev();
            public void develop() 
            {
                backendDev.develop();
                frontendDev.develop();
            }
        }

        class ProjectWork : DevTeam
        {
            public void Work()
            {
                develop();
            }
        }
    }
}
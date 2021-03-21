using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Solid
{
    public class ErrorLogger
    {
        public void Handle(string error)
        {
            File.WriteAllText(@".\error.log", error);
        }
    }

    public class Database : IDatabase
    {
        public void Add() { }

        public void AddExistingCustomer() { }

        public void AnotherExtension() { }
    }

    public interface IDatabase
    {
        void Add();
    }

}

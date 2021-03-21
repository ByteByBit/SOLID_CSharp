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
    public class Customer
    {
        public int BaseDiscount = 10;

        public virtual int Discount(int sales)
        {
            return BaseDiscount - sales;
        }

        public virtual void Add(Database db)
        {
            db.Add();
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

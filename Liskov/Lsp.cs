using System;
using System.Collections.Generic;
using Solid.OpenClosed;

namespace Solid.Liskov
{
    class Lsp : IPrinciple
    {
        public string Principle() =>
        "Liskov Substitution Principle";
        
        public string Definition() =>
        "The aim of this principle is to ascertain that a sub-class can assume the place of its super-class without errors.  If the code finds itself checking the type of class then, it must have violated this principle.";
        
        // VIOLATION.
        // Usually bicycles have no engine, therefore it is a bit hard to start it. This is the reason
        // why this example violates the Liskov Substitution Principle.
        public class LogFileHandler
        {

            public string LogFilePath {get; set;}

            public virtual void Read()
            {
                Console.WriteLine($"Custom log file reader, path: {LogFilePath}.");
            }
            public virtual void Write(string logEntry)
            {
                Console.WriteLine($"Custom log file writer, path: {LogFilePath}.");
            }
        }

        public class CustomLogFileHandler : LogFileHandler
        {

            public override void Read()
            {
                Console.WriteLine($"Custom log file reader, path: {LogFilePath}.");
            }
            public override void Write(string logEntry)
            {
                Console.WriteLine($"Custom log file writer, path: {LogFilePath}.");
            }
        }

        public class ProtectedLogFileHandler : LogFileHandler
        {

            public override void Read()
            {
                Console.WriteLine($"Custom log file reader, path: {LogFilePath}.");
            }
            public override void Write(string logEntry)
            {
                throw new Exception("Protected logfiles cannot be written!");
            }
        }

        // SOLUTION.
        // This way, the start_engine method is implemented only in classes referring to objects
        // with engine. Objects or vehicles without engine has a start_movin method instead.

        public interface ILogFileReader
        {
            void Read(string filePath);
        }

        public interface ILogFileWriter
        {
            void Write(string filePath, string logEntry);
        }

        public class CustomLogFileHandler2 : ILogFileReader, ILogFileWriter
        {

            public void Read(string filePath)
            {
                Console.WriteLine($"Custom log file reader, path: {filePath}.");
            }
            public void Write(string filePath, string logEntry)
            {
                Console.WriteLine($"Custom log file writer, path: {filePath}.");
            }
        }

        public class ProtectedLogFileHandler2 : ILogFileReader
        {

            public void Read(string filePath)
            {
                Console.WriteLine($"Custom log file reader, path: {filePath}.");
            }

        }
    }
}

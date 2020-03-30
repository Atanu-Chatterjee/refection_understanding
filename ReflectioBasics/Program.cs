using System;

namespace ReflectioBasics
{
    class Program
    {
        static void Main(string[] args)
        {
             LearnRefelction_IsAssignableFrom(typeof(IDataObject));
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
        private static void LearnRefelction_IsAssignableFrom(Type InterfaceName)
        {
            //Type dataObjectType = typeof(IDataObject);
            //Type dataObjectType = InterfaceName;

            System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            //ExportedTypes will return all the colection of all public instances such as Interface, Classes
            //syntax:  assembly.ExportedTypes
            var type = thisAssembly.ExportedTypes;
            Type[] types = thisAssembly.GetTypes();

            foreach (Type t in type)
            {
                //IsAssignableFrom will tell us is any type (class) can be assigned in form of some other type(Interface)
                // syntax: (typeof(Interface).IsAssignableFrom(type(class))
                //if class implemented Interface then it will return true else false
                bool isAssignable = InterfaceName.IsAssignableFrom(t);
                Console.WriteLine("An object of {0} CAN {1}be assigned to an object of IDataObject"
                    , t.Name, isAssignable ? "" : "NOT ");
                if (isAssignable && !t.IsInterface)
                {
                    var ob = Activator.CreateInstance(t);
                }
            }
        }
    }

    public interface IDataObject
    {
        void Load();
        void Save();
    }

    public interface IIdBasedDataObject : IDataObject
    {
        int Id { get; set; }
    }

    public interface INamedDataObject : IDataObject
    {
        string Name { get; set; }
    }

    public interface IStandardDataObject : IIdBasedDataObject, INamedDataObject
    {
    }

    public interface IUnrelated
    {
    }

    public class Employee : IStandardDataObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Load()
        {
            // Code here
        }

        public void Save()
        {
            // Code here
        }
    }

    class Manager : Employee
    {
    }
}

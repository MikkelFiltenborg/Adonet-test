using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet_test
{
    public interface IMyInterface
    {
        //Properties
        int Id { get; set; }
        string Name { get; set; }
        public void MyMethod();
    }

    public interface ISecondInterface
    {
        int number { get; set; }
    }

    public class MyClass : IMyInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void MyMethod()
        {
            Console.WriteLine("Implemented interface");
        }
    }

    public class SecondClass : IMyInterface , ISecondInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int number { get; set; }

        public void MyMethod()
        {
            Console.WriteLine("Hello");
        }
    }

    public class MainClass
    {
        MyClass myClass = new MyClass();
        SecondClass secondClass = new SecondClass();

        public void MainMethod()
        {
            //Udskriver "Implemented interface"
            myClass.MyMethod();
            //Udskriver "Hello"
            secondClass.MyMethod();

            List<IMyInterface> list = new();
            list.Add(myClass);
            list.Add(secondClass);

            foreach (var item in list)
            {
                item.MyMethod();
            }
        }
    }
}

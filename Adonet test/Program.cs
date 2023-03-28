
using Adonet_test;

internal class Program
{
    private static void Main(string[] args)
    {
        ado();
        MainClass main = new();
        main.MainMethod();
    } 

    public async static void ado()
    {
        //Tager AdoFramework klassen of instantiere den som et object med navn ado.
        AdoFramework ado = new();

        //Laver en ny liste og lægger alt indhold fra ado.getEmployees i.
        List<AdoModel> list = await ado.getEmployees();

        //foreach køre 1 gang for hver variabel "item" der findes i listen "list"
        foreach (var item in list)
        {
            //string interpolation med "Id: Name"
            Console.WriteLine($"{item.Id}: {item.Name}");
        }
    }
}
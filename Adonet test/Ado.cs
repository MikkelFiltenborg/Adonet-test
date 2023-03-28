using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet_test
{
    public class AdoFramework
    {
        //stig til SQL databasen.
        string connectionString = "Data Source=.; Initial Catalog=Ado; Integrated Security=True";

        //Laver en ny liste fra AdoModel.
        List<AdoModel> list;
        public async Task<List<AdoModel>> getEmployees()
        {
            //Instatiere list.
            list = new();

            //SqlConnection fortæller den hvor den skal hen.
            using (SqlConnection connect = new(connectionString))
            {
                connect.Open();

                //Laver en SQL command som hedder cmd og lægger en SQL kommando i den. connect fortæller vhor den skal udføre kommandoen
                SqlCommand cmd = new("GetEmployee", connect);
                //cmd er en CommandType som skal finde en StoredProecdure
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.ExecuteReader lægges ned i reader.
                using (var reader = cmd.ExecuteReader())
                {
                    //loop while der er ulæste ting i tabellen.
                    while(await reader.ReadAsync())
                    {
                        //laver ny AdoModel og lægger Id værdig og Name værdi ned i listen.
                        list.Add(new AdoModel()
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Ado_Name"),
                        });
                    }
                }
            }
            return list;
        }
    }
}

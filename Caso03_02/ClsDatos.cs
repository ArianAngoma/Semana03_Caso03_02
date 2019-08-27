using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso03_02
{
    public class ClsDatos
    {

        public SqlConnection LeerCadena()
        {
            SqlConnection cn =
                new SqlConnection("Data Source=DESKTOP-DEMIG29;Initial Catalog=neptuno;Integrated Security=True");
            return cn;
        }

        public List<Empleado> ListarEmpleado()
        {
            SqlConnection cn = LeerCadena();
            cn.Open();

            List<Empleado> Lista = new List<Empleado>();
            Empleado E;
            SqlDataReader lector;

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_Empleado");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    E = new Empleado();
                    E.IdEmpleado = (int)(lector[0]);
                    E.Apellido = (string)(lector[1]);
                    E.Nombre = (string)(lector[2]);
                    E.Nacimiento = (string)(lector[3]);
                    E.Direccion = (string)(lector[4]);
                    Lista.Add(E);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }

            cn.Close();
            return Lista;
        }
    }
}

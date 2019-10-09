using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasMarvinPocasangre.Clases
{
    public class SQLPROCESS
    {
        public string CadConexion = "Data Source=WS2012crm;Initial Catalog=PruebaMarvinPocasangre;User ID=sa;password=Creativa74$";


        public DataSet ListarClientes()
        {
            DataSet dsData = new DataSet();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_ListClientes", new SqlConnection(CadConexion)))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dsData, "Data");
                }
                if (dsData.Tables.Count > 0)
                {
                    if (dsData.Tables["Data"].Rows.Count > 0)
                    {
                        return dsData;
                    }
                }

            }
            catch (Exception e)
            {
                return new DataSet("Data");
            }
            return new DataSet("Data");
        }


        public string SaveClientes(string NombresCliente, String ApellidosCliente, string CorreoElectronico)
        {

            DataSet dsData = new DataSet();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_SaveClientes", new SqlConnection(CadConexion)))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", NombresCliente);
                    da.SelectCommand.Parameters.AddWithValue("@Apellido", ApellidosCliente );
                    da.SelectCommand.Parameters.AddWithValue("@Correo", CorreoElectronico );
                    da.Fill(dsData, "Data");
                }
               return  ComprobarDatos(dsData);

            }
            catch (Exception e)
            {
                return "Error";
            }
        }


        public string UpdateClientes(int IdCliente, string NombresCliente, String ApellidosCliente, string CorreoElectronico)
        {

            DataSet dsData = new DataSet();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_UpdateClientes", new SqlConnection(CadConexion)))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Id_Cliente", IdCliente);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", NombresCliente);
                    da.SelectCommand.Parameters.AddWithValue("@Apellido", ApellidosCliente);
                    da.SelectCommand.Parameters.AddWithValue("@Correo", CorreoElectronico);
                    da.Fill(dsData, "Data");
                }
                return ComprobarDatos(dsData);

            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        public string DeleteClientes(int IdCliente)
        {

            DataSet dsData = new DataSet();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_DeleteClientes", new SqlConnection(CadConexion)))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Id_Cliente", IdCliente);
                    da.Fill(dsData, "Data");
                }
                return ComprobarDatos(dsData);

            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        public string ComprobarDatos(DataSet DsDatos)
        {
            if (DsDatos.Tables.Count > 0)
            {
                if (DsDatos.Tables["Data"].Rows.Count > 0)
                {
                    return "OK";
                }
            }
            return "SD";
        }

    }
}

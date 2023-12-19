using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EXAMEN3_RobertoChavesBrenes.Class
{
    public class Encuestas
    {
        

        public static int EncuestaID { get; set; }

        public static string NombreParticipante { get; set; }

        public static string Edad { get; set; }

        public static string CorreoElectronico { get; set; }

        public static int PartidoID { get; set; }




        public Encuestas(int encuestaID, string nombreparticipante, string edad, string correoelectronico, int partidoID)
        {
            EncuestaID = encuestaID;
            NombreParticipante = nombreparticipante;
            Edad = edad;
            CorreoElectronico = correoelectronico;
            PartidoID = partidoID;
        }


        public Encuestas(string nombreparticipante, string edad, string correoelectronico, int partidoID)
        {
            NombreParticipante = nombreparticipante;
            Edad = edad;
            CorreoElectronico = correoelectronico;
            PartidoID = partidoID;
        }


        public Encuestas( string edad, string correoelectronico, int partidoID)
        {
            Edad = edad;
            CorreoElectronico = correoelectronico;
            PartidoID = partidoID;
        }


        public Encuestas(string correoelectronico, int partidoID)
        {
            CorreoElectronico = correoelectronico;
            PartidoID = partidoID;
        }

        public Encuestas(int partidoID)
        {
            
            PartidoID = partidoID;
        }

        public static int AgregarEncuesta(string nombreparticipante, string edad, string correoelectronico, int partidoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarEncuesta", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombreParticipante", nombreparticipante));
                    cmd.Parameters.Add(new SqlParameter("@Edad", edad));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correoelectronico));
                    cmd.Parameters.Add(new SqlParameter("@PartidoID", partidoID));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        
    }
}
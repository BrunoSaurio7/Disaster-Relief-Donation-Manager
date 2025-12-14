using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Proyecto1._1
{
    public class conexionBD
    {
        // Declarar objeto conexión
        public OdbcConnection conexion { get; set; }
        public conexionBD()
        {
            // Traer los datos de conexión del web.config

            // Declarar objetos para comunicarnos con el web.config
            System.Configuration.Configuration webconfig;

            // Abrir el web.config
            webconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/p1.1");

            // Declarar objeto para guardar el connectionString
            System.Configuration.ConnectionStringSettings stringDeConexion;

            // Extraaer el string de conexion del objeto de configuracion ligado al web.config 
            stringDeConexion = webconfig.ConnectionStrings.ConnectionStrings["BDP1"];

            // Instanciar la conexion con el string de conexion
            conexion = new OdbcConnection(stringDeConexion.ToString());

            // Abrir la conexion
            conexion.Open();
        }
    }
}
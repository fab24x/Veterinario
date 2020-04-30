using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace Veterinario
{
    class Conexion
    {
        public MySqlConnection conexion;
        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = veterinario; Uid = root; Pwd=; Port=3306");
        }
        public Boolean logear(string DNI, string pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM usario where DNI = @DNI ", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    string passConHash = resultado.GetString("pass");
                    if (BCrypt.Net.BCrypt.Verify(pass, passConHash))
                   {
                        return true;
                    }
                    
                    return true;
                }
                conexion.Close();
                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        public String chavalitoNuevo(string DNI, string Nombre, string pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO usario (id, DNI, Nombre, pass) VALUES(NULL, @DNI, @Nombre, @pass)", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@pass", pass);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "Bienvenido a la familia";
            }
            catch (MySqlException e)
            {
                return "F";
            }
        }
        public String clientNuevo(string DNI, string Nombre, string Telefono, string Email)//el codigo esta bien solo que no funciona
            //por errores en la base de datos
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO client (id, DNI, Nombre, Telefono, Email) VALUES(NULL, @DNI, @Nombre, @Telefono, @Email)", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Telefono", Telefono);
                consulta.Parameters.AddWithValue("@Email", Email);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "Añadido correctamente";
            }
            catch (MySqlException e)
            {
                return "F";
            }
        }
        public String mascotaNuevo(string Dueño, string Raza, string Nombre, string Edad)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO mascota (DNI, Raza, Nombre, Edad) VALUES( @DNI, @Raza, @Nombre, @Edad)", conexion);
                consulta.Parameters.AddWithValue("@DNI", Dueño);
                consulta.Parameters.AddWithValue("@Raza", Raza);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Edad", Edad);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "Añadido correctamente";
            }
            catch (MySqlException e)
            {
                return "F";
            }
        }
        public DataTable getDNI(String DNI)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM client where DNI = '" + DNI + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable cliente = new DataTable();
                cliente.Load(resultado);
                conexion.Close();
                return cliente;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public DataTable getMas()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM mascota ", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable mascota = new DataTable();
                mascota.Load(resultado);
                conexion.Close();
                return mascota;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }
}


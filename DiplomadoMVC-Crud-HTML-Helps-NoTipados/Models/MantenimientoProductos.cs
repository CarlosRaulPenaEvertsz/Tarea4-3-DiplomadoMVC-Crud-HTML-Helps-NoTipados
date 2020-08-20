using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiplomadoMVC_Crud_HTML_Helps_NoTipados.Models
{
    
    public class MantenimientoProductos
    {
        private SqlConnection con;
        
        // Conexion a la DB
        private void Conectar() {
            string constr = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            con = new SqlConnection(constr);
        }

        // Agregar
        public int Agregar(Productos prod)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Productos(Descripcion,Precio) values (@Descripcion,@Precio)", con);
            comando.Parameters.Add("@Descripcion",SqlDbType.VarChar);
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters["@Descripcion"].Value = prod.Descripcion;
            comando.Parameters["@Precio"].Value = prod.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        //Recuperar Todos (ReadAll)
        public List<Productos> RecuperarTodos()
        {
            Conectar();
            List<Productos> productos = new List<Productos>();
            SqlCommand com = new SqlCommand("select Codigo,Descripcion,Precio from Productos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Productos prod = new Productos
                {
                    Codigo = int.Parse(registros["Codigo"].ToString()),
                    Descripcion = registros["Descripcion"].ToString(),
                    Precio = float.Parse(registros["Precio"].ToString())
                };
                productos.Add(prod);
            }
            con.Close();
            return productos;
        }

        // Recuperar (Leer)
        public Productos Recuperar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select codigo,descripcion, precio from Productos where Codigo = @Codigo",con);
            comando.Parameters.Add("@Codigo", SqlDbType.Int);
            comando.Parameters["@Codigo"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Productos producto = new Productos();
            if (registros.Read())
            {
                producto.Codigo = int.Parse(registros["Codigo"].ToString());
                producto.Descripcion = registros["Descripcion"].ToString();
                producto.Precio = float.Parse(registros["Precio"].ToString());
            }
            else
                producto = null;
            con.Close();
            return producto;
        }

        //Modificar
        public int Modificar(Productos prod)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Productos set Descripcion=@Descripcion, Precio=@Precio where Codigo=@Codigo ", con);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters["@Descripcion"].Value = prod.Descripcion;
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters["@Precio"].Value = prod.Precio;
            comando.Parameters.Add("@Codigo", SqlDbType.Int);
            comando.Parameters["@Codigo"].Value = prod.Codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        //Borrar
        public int Borrar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Productos where Codigo = @Codigo",con);
            comando.Parameters.Add("@Codigo", SqlDbType.Int);
            comando.Parameters["@Codigo"].Value = codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}
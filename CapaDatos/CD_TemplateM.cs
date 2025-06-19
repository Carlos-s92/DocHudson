using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public abstract class CD_TemplateM<T>
    {
        protected SqlConnection conexion;

        public CD_TemplateM()
        {
            conexion = new SqlConnection(Conexion.cadena);
        }
        //Metodo abstracto para registrar
        public virtual int Registrar(T obj, out string Mensaje)
        {
            using (var cmd = new SqlCommand(NombreSPRegistrar(), conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AgregarParametrosRegistrar(cmd, obj);
                conexion.Open();
                int result = cmd.ExecuteNonQuery();
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                conexion.Close();
                return result;
            }
        }
        //Metodo abstracto para editar
        public virtual int Editar(T obj, out string Mensaje)
        {
            using (var cmd = new SqlCommand(NombreSPEditar(), conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AgregarParametrosEditar(cmd, obj);
                conexion.Open();
                int result = cmd.ExecuteNonQuery();
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                conexion.Close();
                return result;
            }
        }
        //Metodo abstracto para eliminar
        public virtual int Eliminar(T obj, out string Mensaje)
        {
            using (var cmd = new SqlCommand(NombreSPEliminar(), conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AgregarParametrosEliminar(cmd, obj);
                conexion.Open();
                int result = cmd.ExecuteNonQuery();
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                conexion.Close();
                return result;
            }
        }
        //Metodo abstracto para listar
        public virtual List<T> Listar()
        {
            var lista = new List<T>();
            using (var cmd = new SqlCommand(NombreSPListar(), conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(Mapear(reader));
                    }
                }
                conexion.Close();
            }
            return lista;
        }

        //Metodo abstracto para buscar
        public virtual List<T> Buscar(string obj)
        {
            var lista = new List<T>();
            using (var cmd = new SqlCommand(NombreSPBuscar(), conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AgregarParametrosBuscar(cmd, obj);
                conexion.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(Mapear(reader));
                    }
                }
                conexion.Close();
            }
            return lista;
        }


        // Métodos abstractos que cada clase concreta debe implementar
        protected abstract string NombreSPRegistrar();
        protected abstract string NombreSPEditar();
        protected abstract string NombreSPEliminar();
        protected abstract string NombreSPListar();
        protected abstract string NombreSPBuscar();
        protected abstract void AgregarParametrosRegistrar(SqlCommand cmd, T obj);
        protected abstract void AgregarParametrosEditar(SqlCommand cmd, T obj);
        protected abstract void AgregarParametrosEliminar(SqlCommand cmd, T obj);
        protected abstract void AgregarParametrosBuscar(SqlCommand cmd, string obj);
        protected abstract T Mapear(SqlDataReader reader);

    }
}

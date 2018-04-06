using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BelExamen.BE;

namespace BelExamen.DA
{
    public class ProductoDA
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["BelExamen_SQLServer"].ConnectionString;

        public List<ProductoBE> ListarProductosxNombre(string nombre)
        {
            List<ProductoBE> productos = null;

            try
            {
                productos = new List<ProductoBE>();

                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.USP_ListarProductosxNombre", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    cmd.Parameters.AddWithValue("@Nombre", nombre);

                    cnx.Open();
                    IDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ProductoBE producto = new ProductoBE();

                        producto.AnioCampania = dr.GetInt32(dr.GetOrdinal("AnioCampania"));
                        producto.Cuv = dr.GetString(dr.GetOrdinal("Cuv"));
                        producto.MarcaId = dr.GetInt32(dr.GetOrdinal("MarcaID"));
                        producto.Precio = dr.GetInt32(dr.GetOrdinal("Precio"));
                        producto.Descripcion = dr.GetString(dr.GetOrdinal("Precio"));
                        producto.CodigoTipoOferta = dr.GetString(dr.GetOrdinal("CodigoTipoOferta"));
                        producto.CodigoSAP = dr.GetString(dr.GetOrdinal("CodigoSAP"));
                        producto.EstadoActivo = dr.GetBoolean(dr.GetOrdinal("EstadoActivo"));

                        productos.Add(producto);
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productos;
        }
    }
}

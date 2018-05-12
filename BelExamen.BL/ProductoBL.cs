using BelExamen.BE;
using BelExamen.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelExamen.BL
{
    public class ProductoBL
    {
        public List<ProductoBE> ListarProductosxNombre(string nombre)
        {
            List<ProductoBE> productos = null;

            try
            {
                ProductoDA productoDA = new ProductoDA();
                productos = productoDA.ListarProductosxNombre(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productos;
        }
    }
}

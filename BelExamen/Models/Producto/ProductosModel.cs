using BelExamen.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelExamen.Models
{
    public class ProductosModel
    {
        public List<ProductoBE> Productos { get; set; }
        public String NombreProducto { get; set; }
    }
}
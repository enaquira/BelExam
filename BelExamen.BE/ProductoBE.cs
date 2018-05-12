using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelExamen.BE
{
    [Serializable]
    public class ProductoBE
    {
        public int AnioCampania { get; set; }
        public String Cuv { get; set; }
        public int MarcaId { get; set; }
        public Decimal Precio { get; set; }
        public String Descripcion { get; set; }
        public String CodigoTipoOferta { get; set; }
        public String CodigoSAP { get; set; }
        public bool EstadoActivo { get; set; }
    }
}

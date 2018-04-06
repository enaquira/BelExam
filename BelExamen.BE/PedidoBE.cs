using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelExamen.BE
{
    [Serializable]
    public class PedidoBE
    {
        public int PedidoID { get; set; }
        public string Usuario { get; set; }
        public int AnioCampania { get; set; }
        public String Cuv { get; set; }
        public int Cantidad { get; set; }
    }
}

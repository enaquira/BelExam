using BelExamen.BE;
using BelExamen.BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BelExamen.UI.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductosWS" in both code and config file together.
    public class ProductosWS : IProductosWS
    {
        public Stream ListarProductosxNombre(string nombre)
        {
            MemoryStream memoryStream = new MemoryStream();
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            Object result = null;

            try
            {
                string urlAddress = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias";
                string HTML = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    HTML = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();
                }

                List<ProductoBE> productos = new List<ProductoBE>();
                productos = new ProductoBL().ListarProductosxNombre(nombre);

                Byte[] json = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result));
                memoryStream = new MemoryStream(json);
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                return memoryStream;
            }
            catch (Exception ex)
            {
                result = new { result = "error", title = "Error", message = "Lo sentimos, hubo un problema no esperado. Vuelva a intentar por favor.", url = "" };
                Byte[] json = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result));
                memoryStream = new MemoryStream(json);
                return memoryStream;
            }
        }
    }
}

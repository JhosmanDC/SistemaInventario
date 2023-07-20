using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SistemaInventario.ApiRest
{
    public class LoginApi
    {
        
        public dynamic Post(string url, string json, string autorizacion = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest("/cliente/usuario.php", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                request.AddParameter("cuenta", "ander");
                request.AddParameter("clave", "12345");
                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);

                }
                RestResponse response = client.Execute(request);

                dynamic datos = JsonConvert.DeserializeObject(response.Content);

                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }
        }
        
    }
}

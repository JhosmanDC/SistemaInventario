using SistemaInventario.ApiRest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class Login : Form
    {
        LoginApi dBApi = new LoginApi();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            Persona persona = new Persona
            {
                cuenta = txtCuenta.Text,
                clave = txtClave.Text
            };

            string json = JsonConvert.SerializeObject(persona);

            dynamic respuesta = dBApi.Post("http://localhost:8081/cliente/usuario.php", json);

            MessageBox.Show(respuesta.ToString());
            
        }
    }

    public class Persona
    {
        public string cuenta { get; set; }

        public string clave { get; set; }
    }
}

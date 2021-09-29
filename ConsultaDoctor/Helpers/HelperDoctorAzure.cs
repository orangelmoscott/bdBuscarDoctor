using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConsultaDoctor.Models;
using Newtonsoft.Json;

namespace ConsultaDoctor.Helpers
{
    public class HelperDoctorAzure
    {
        private const string DireccionApi = "https://apicruddoctores.azurewebsites.net/";

        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }

        public async Task <Doctor> GetDoctor(int DoctId)
        {
            Doctor datos = null;
            //CREAMOS LA PETICION 
            String peticion = DireccionApi + "api/doctores/" + DoctId;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                datos = JsonConvert.DeserializeObject<Doctor>(contenido);
            }
            return datos;
        }
    }
}

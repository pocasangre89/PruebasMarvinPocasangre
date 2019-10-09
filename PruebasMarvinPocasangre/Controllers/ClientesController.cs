using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PruebasMarvinPocasangre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/Clientes
        [HttpGet]
        public string GetList()
        {
            Clases.SQLPROCESS obj = new Clases.SQLPROCESS();
            return JsonConvert.SerializeObject(obj.ListarClientes(), Formatting.Indented ); 
        }

        // GET: api/Clientes/5
        [HttpGet("{Nombre}/{Apellido}/{Correo}", Name = "SaveData")]
        public string SaveData(string Nombre, string Apellido, string Correo)
        {
            Clases.SQLPROCESS obj = new Clases.SQLPROCESS();
            return obj.SaveClientes(Nombre, Apellido, Correo);
        }

        [HttpGet("{id}/{Nombre}/{Apellido}/{Correo}", Name = "UpdateData")]
        
        public string UpdateData(int id, string Nombre, string Apellido, string Correo)
        {
            Clases.SQLPROCESS obj = new Clases.SQLPROCESS();
            return obj.UpdateClientes (id, Nombre, Apellido, Correo);
        }

        [HttpGet("{id}", Name = "DeleteData")]
        public string DeleteData(int id)
        {
            Clases.SQLPROCESS obj = new Clases.SQLPROCESS();
            return obj.DeleteClientes (id);
        }
    }
}

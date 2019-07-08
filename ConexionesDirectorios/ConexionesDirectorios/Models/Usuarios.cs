using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConexionesDirectorios.Models
{
    public class Usuarios
    {
        [JsonProperty(PropertyName = "class")]
        public string className { get; set; }
        public List<NodeDataArray> nodeDataArray { get; set; }
    }


   public class NodeDataArray
    {
        public int key { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int? parent { get; set; }
    }
}
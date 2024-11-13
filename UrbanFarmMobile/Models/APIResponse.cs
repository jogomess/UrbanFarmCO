using System;
using System.Collections.Generic;

namespace UrbanFarmMobile.Models
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; } // Código de status HTTP
        public List<string> Errors { get; set; } // Lista de erros, se houver
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Momento da resposta
    }
}

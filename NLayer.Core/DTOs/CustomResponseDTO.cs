using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; } // JSON ignore ile dönüş mesajında bu gorünmeyecek

        public List<String> Errors { get; set; }

        public static CustomResponseDTO<T> Success(int statusCode,T data)
        {
            return new CustomResponseDTO<T> { Data = data,StatusCode=statusCode};    
        }

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Fail(int statusCode,List<string> errors)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode,Errors=errors };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, String error)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = new List<string> { error} };
        }



    }
}

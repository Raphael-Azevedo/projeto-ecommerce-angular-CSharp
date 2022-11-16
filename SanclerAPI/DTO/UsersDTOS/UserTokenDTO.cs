using System;

namespace SanclerAPI.DTO
{
    public class UserTokenDTO
    {
  
        public bool Authenticated { get; set; }

        public DateTime Expiration { get; set; }    

        public string Token { get; set; }

        public string Message { get; set; }

    
    }
}
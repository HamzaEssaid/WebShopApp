using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopUppg.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [JsonProperty("f_name")]
        public string Firstname { get; set; }
        [JsonProperty("l_name")]
        public string Lastname { get; set; }
        //public CartDTO Cart { get; set; }

        public string receipt { get; set; }

        //public CustomerDTO(int id, string fname, string lname)
        //{
        //    Id = id;
        //    Firstname = fname;
        //    Lastname = lname;
        //    if(Cart == null)
        //    {
        //        Cart = new CartDTO();
        //    }
        //}
    }
}

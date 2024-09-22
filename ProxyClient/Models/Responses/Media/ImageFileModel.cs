using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyClient.Models.Responses.Media
{
    public class ImageFileModel
    { 
        public long Id { get; set; }
      
        public Guid Uuid { get; set; }
       
        public string Name { get; set; }
       
        public string Path { get; set; }
      
        public string Extension { get; set; }
        
        public string Encode { get; set; }
    }
}

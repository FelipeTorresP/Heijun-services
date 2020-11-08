using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeijunServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDocumentController : ControllerBase
    {
       
        // PUT: api/AdminDocument/5
        [HttpPut("{id}")]
        public void UploadDocument(string id)
        {
            
        }

    }
}

using HeijunDomain.DocumentTemplate;
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
            StructureDocumentSave structureDocument = new StructureDocumentSave();
            structureDocument.SaveStructureDocument(id);
        }

    }
}

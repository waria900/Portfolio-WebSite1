using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationsController : ControllerBase
    {
        IInformations oClsInformations;
        public InformationsController(IInformations _oClsInformations) 
        {
            oClsInformations = _oClsInformations;
        }

        // GET: api/<InformationsController>
        [HttpGet]
        public TbInformation Get()
        {
            var info = oClsInformations.GetAll();
            return info;
        }


    }
}

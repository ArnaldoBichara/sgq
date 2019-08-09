using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SGQ.Problemas.API.Infrastructure.Services;
using SGQ.Problemas.API.Model;

namespace SGQ.Problemas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class ProblemasController : ControllerBase
    {
        private readonly IProblemasService _problemasService;
        private readonly IIdentityService _identityService;

        public ProblemasController(IProblemasService problemasService, IIdentityService identityService)
        {
            _problemasService = problemasService ?? throw new ArgumentNullException(nameof(problemasService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        //GET api/v1/[controller]/CadProblema/1
        [Route("CadProblema/{Codigo}")]
        [HttpGet]
        [ProducesResponseType(typeof(Problemas.API.Model.CadProblema), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Problemas.API.Model.CadProblema>> GetCadProblemaAsync(string Codigo)
        {
            return await _problemasService.GetCadProblemaAsync(Codigo);
        }
        //GET api/v1/[controller]/CadProblema
        [Route("CadProblema")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Problemas.API.Model.CadProblema>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Problemas.API.Model.CadProblema>>> GetAllProblemasAsync()
        {
            return await _problemasService.GetAllCadProblemasAsync();
        }
        //GET api/v1/[controller]/RegProblema/1
        [Route("RegProblema/{IdProblema}")]
        [HttpGet]
        [ProducesResponseType(typeof(Problemas.API.Model.RegProblema), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Problemas.API.Model.RegProblema>> GetRegProblemaAsync(int IdProblema)
        {
            return await _problemasService.GetRegProblemaAsync(IdProblema.ToString());
        }
         
        //POST api/v1/[controller]/CadProblema
        [Route("CadProblema")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateOrUpdateCadProblemaAsync([FromBody]CadProblema NovoProblema)
        {
            var result = await _problemasService.AddOrUpdateCadProblemaAsync(NovoProblema);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        //POST api/v1/[controller]/RegProblema
        [Route("RegProblema")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateOrUpdateRegProblemaAsync([FromBody]RegProblema NovoProblema)
        {
            // var userId = _identityService.GetUserIdentity();
            // var result = await _locationsService.AddOrUpdateProblemaAsync(userId, problema);
            var result = await _problemasService.AddOrUpdateRegProblemaAsync(NovoProblema);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

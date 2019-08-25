using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SGQ.Workflow.API.Infrastructure.Services;
using SGQ.Workflow.API.Model;

namespace SGQ.Workflow.API.Controllers
{
    [Route("api/v1/[controller]")]
/*    [Authorize] */
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _WorkflowService;
        private readonly IIdentityService _identityService;

        public WorkflowController(IWorkflowService WorkflowService, IIdentityService identityService)
        {
            _WorkflowService = WorkflowService ?? throw new ArgumentNullException(nameof(WorkflowService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        //GET api/v1/[controller]/CadAtiv
        [Route("CadAtiv")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Workflow.API.Model.CadAtividade>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Workflow.API.Model.CadAtividade>>> GetListaCadAtividadesAsync()
        {
            return await _WorkflowService.GetListaCadAtividadesAsync();
        }
        //GET api/v1/[controller]/CadAtiv/1
        [Route("CadAtiv/{Codigo}")]
        [HttpGet]
        [ProducesResponseType(typeof(Workflow.API.Model.CadAtividade), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Workflow.API.Model.CadAtividade>> GetCadAtividadeAsync(string Codigo)
        {
            return await _WorkflowService.GetCadAtividadeAsync(Codigo);
        }
        //POST api/v1/[controller]/CadAtiv
        [Route("CadAtiv")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateOrUpdateCadAtivAsync([FromBody]CadAtividade NovaAtividade)
        {
            var result = await _WorkflowService.AddOrUpdateCadAtividadeAsync(NovaAtividade);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        //GET api/v1/[controller]/RegAtiv/waiting
        [Route("RegAtiv/waiting")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Workflow.API.Model.RegAtividade>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Workflow.API.Model.RegAtividade>>> GetListaRegAtividadesWaitingAsync()
        {
            return await _WorkflowService.GetListaRegAtividadesWaitingAsync();
        }
        //GET api/v1/[controller]/RegAtiv/atrib/user
        [Route("RegAtiv/atrib/{User}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Workflow.API.Model.RegAtividade>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Workflow.API.Model.RegAtividade>>> GetListaRegAtividadesAtribAsync(string User)
        {
            return await _WorkflowService.GetListaRegAtividadesAtribAsync(User);
        }
        //GET api/v1/[controller]/RegAtiv/1
        [Route("RegAtiv/{Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Workflow.API.Model.RegAtividade), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Workflow.API.Model.RegAtividade>> GetRegAtividadeAsync(string Id)
        {
            return await _WorkflowService.GetRegAtividadeAsync(Id);
        }
        //POST api/v1/[controller]/RegAtividade
        [Route("RegAtiv")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateOrUpdateRegAtivAsync([FromBody]RegAtividade NovaAtividade)
        {
            // var userId = _identityService.GetUserIdentity();
            // var result = await _locationsService.AddOrUpdateProblemaAsync(userId, atividade);
            var result = await _WorkflowService.AddOrUpdateRegAtividadeAsync(NovaAtividade);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }        
        [HttpGet]
        // api/commands
        public ActionResult <IEnumerable<CommandReadDtos>> GetAllCommnads()
        {
            var commandItems = _repo.GetAllCommands();
            var commandReadDtos = _mapper.Map<IEnumerable<CommandReadDtos>>(commandItems);
            return Ok(commandReadDtos);
        }
        [HttpGet("{id}" , Name = "GetCommandById")]
        // api/commands/3
        public ActionResult <CommandReadDtos> GetCommandById(int id)
        {
            var commandItem = _repo.GetCommandById(id);
            if(commandItem==null)
                return NotFound();
            
            return Ok(_mapper.Map<CommandReadDtos>(commandItem));
            
        }

        // Post api/commands
        [HttpPost]
        public ActionResult <CommandReadDtos> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var CommandModel = _mapper.Map<Command>(commandCreateDto);
            _repo.CreateCommand(CommandModel);
            _repo.SaveChanges();
             var commandReadDtos= _mapper.Map<CommandReadDtos>(CommandModel);
            return CreatedAtRoute(nameof(GetCommandById),new {id = commandReadDtos.Id},commandReadDtos);
            //return Ok(commandReadDtos);
            
        }
        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommnad(int id,CommandUpdateDto commandUpdateDtos)
        {
            var commandItemFromRepo = _repo.GetCommandById(id);
            if(commandItemFromRepo==null)
                return NotFound();

            _mapper.Map(commandUpdateDtos,commandItemFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }
         //DELETE api/commands/{id}
        [HttpDelete("{id}")]
         public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}
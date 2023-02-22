using AwesomeDevEvents.Api.Entities;
using AwesomeDevEvents.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEvents.Api.Controllers
{
    [Route("api/devEventInicial)")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Buscar todos os eventos.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvent = _context.DevEvents.Where(x => !x.IsDelete).ToList();

            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvent);
        }

        /// <summary>
        /// Consultar  evento por id.
        /// </summary>
        [HttpGet("(id)")]
        public IActionResult GeById(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(id);

        }

        /// <summary>
        /// Cadastrar um evento.
        /// </summary>
        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);

            return CreatedAtAction(nameof(GeById), new { id = devEvent.Id }, devEvent);
        }

        /// <summary>
        /// Cadastrar estudante por id.
        /// </summary>
        [HttpPost("(id)/students)")]
        public IActionResult PostStudents(Guid id, DevEvent student)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(x => x.Id == id);

            if (devEvents == null)
            {
                return NotFound();
            }
            _context.DevEvents.Add(student);

            return CreatedAtAction(nameof(GeById), new { id = devEvents.Id }, devEvents);
        }

        /// <summary>
        /// Atualiza um evento por id.
        /// </summary>
        [HttpPut("(id)")]
        public IActionResult Upadate(Guid id, DevEvent input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.UpDate(input.Title!, input.Description!, input.StartDate, input.EndDate);

            return NoContent();
        }

        /// <summary>
        /// Remove um evento por id.
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();

            return NoContent();
        }
    }
}

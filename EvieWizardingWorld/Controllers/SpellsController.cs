using EvieWizardingWorld.Models;
using EvieWizardingWorld.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvieWizardingWorld.Controllers
{
    [Route("api/spells")]
    [ApiController]
    public class SpellsController : ControllerBase
    {
        private readonly SpellsService _spellsService;

        public SpellsController(SpellsService spellsService)
        {
            _spellsService = spellsService;
        }

        [HttpGet]
        public IActionResult GetAllSpells()
        {
            var spells = _spellsService.GetAllSpells();
            return Ok(spells);
        }
    }
}
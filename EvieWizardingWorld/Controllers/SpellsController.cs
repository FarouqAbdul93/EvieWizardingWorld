using EvieWizardingWorld.Models;
using EvieWizardingWorld.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

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

        [HttpGet("random")]
        [EnableRateLimiting("fixed")]
        public IActionResult GetRandomSpell()
        {
            var spell = _spellsService.GetRandomSpell();
            return Ok(spell);
        }
    }
}
using EvieWizardingWorld.Models;

namespace EvieWizardingWorld.Services
{
    public class SpellsService
    {
        private readonly SpellsModel _spellsModel;

        public SpellsService(SpellsModel spellsModel)
        {
            _spellsModel = spellsModel;
        }

        public List<Spell> GetAllSpells()
        {
            return _spellsModel.FetchAllSpells();
        }

        public Spell GetRandomSpell()
        {
            return _spellsModel.FetchRandomSpell();
        }
    }
}

using System.Text.Json;
using EvieWizardingWorld.Models;

namespace EvieWizardingWorld.Models
{
    public class SpellsModel
    {
        public List<Spell> FetchAllSpells()
        {
            string filePath = "Resources/Spells.json";
            string jsonText = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Spell> spells = JsonSerializer.Deserialize<List<Spell>>(jsonText, options);
            return spells;
        }

        public Spell FetchRandomSpell()
        {
            List<Spell> spells = FetchAllSpells();
            Random random = new Random();
            int index = random.Next(0, spells.Count);
            return spells[index];
        }
    }
}
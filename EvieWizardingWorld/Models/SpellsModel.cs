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
    }
}
namespace EvieWizardingWorld.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Personality { get; set; }
        public int Rating { get; set; }
        public List<string> Teaches { get; set; }
    }
}

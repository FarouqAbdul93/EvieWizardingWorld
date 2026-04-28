using System.Text.Json;

namespace EvieWizardingWorld.Models
{
    public class TeachersModel
    {
        public List<Teacher> FetchAllTeachers()
        {
            string filePath = "Resources/Teachers.json";
            string jsonText = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(jsonText, options);
            return teachers;
        }

        public Teacher AddTeacher(Teacher newTeacher)
        {
            List<Teacher> teachers = FetchAllTeachers();
            int newId = teachers.Max(t => t.Id) + 1;
            newTeacher.Id = newId;
            teachers.Add(newTeacher);
            return newTeacher;
        }

        public Teacher FetchTeacherById(int id)
        {
            List<Teacher> teachers = FetchAllTeachers();
            Teacher teacher = teachers.FirstOrDefault(t => t.Id == id);
            return teacher;
        }

        public bool DeleteTeacher(int id)
        {
            List<Teacher> teachers = FetchAllTeachers();
            Teacher teacher = teachers.FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return false;
            }

            teachers.Remove(teacher);
            return true;
        }
    }
}

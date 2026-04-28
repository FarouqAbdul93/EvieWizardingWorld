using EvieWizardingWorld.Models;

namespace EvieWizardingWorld.Services
{
    public class TeachersService
    {
        private readonly TeachersModel _teachersModel;

        public TeachersService(TeachersModel teachersModel)
        {
            _teachersModel = teachersModel;
        }

        public Teacher GetTeacherById(int id)
        {
            return _teachersModel.FetchTeacherById(id);
        }

        public Teacher AddTeacher(Teacher newTeacher)
        {
            return _teachersModel.AddTeacher(newTeacher);
        }
    }
}
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    class ExerciseController: ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private readonly User user;
        public List<Exercise> Exercises;

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Имя продукта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbonhydrates { get; }

        /// <summary>
        /// Калории на 100 грамм продукта
        /// </summary>
        public double Calories { get; }

        
        public Food(string name): this(name, 0, 0, 0, 0)
        {
            Name = name;
        }

        public Food(string name, double proteins, double fats, double carbonhydrates, double calories)
        {
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbonhydrates = carbonhydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

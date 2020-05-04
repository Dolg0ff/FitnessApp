using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Флаг для новго пользователя
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользоватекля не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(s => s.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

            //var gender = new Gender(genderName);
            //Users = new User(userName, gender, birthDate, weight, height);
            //string genderName, DateTime birthDate, double weight, double height
        }

        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if ((File.Exists("users.dat")) && (!(fs.Length == 0)))
                {
                    if (formatter.Deserialize(fs) is List<User> users)
                    {
                        return users;
                    }
                }
                return new List<User>();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}

using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Пользователь.
        /// </summary>
       
        

            /// <summary>
            /// Имя.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Пол
            /// </summary>
            public Gender Gender { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime Birthday { get; set; }

            /// <summary>
            /// Вес.
            /// </summary>
            public DateTime BirthDate { get; set; }

            /// <summary>
            /// Рост.
            /// </summary>

            public double Weight { get; set; }

            public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
            #endregion
            /// <summary>
            /// Создать нового пользователя.
            /// </summary>
            /// <param name="name">Имя. </param>
            /// <param name="gender">Пол. </param>
            /// <param name="birthDate">Дата рождения. </param>
            /// <param name="weight">Вес. </param>
            /// <param name="height">Рост. </param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="ArgumentException"></exception>

            public User(string name,
                        Gender gender,
                        DateTime birthDate,
                        double weight,
                        double height)
            {
                #region Проверка условий
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("Имя пользователся не может быть пустым или null", nameof(name));
                }

                if (gender == null)
                {
                    throw new ArgumentNullException("Про не может быть null", nameof(gender));
                }

                if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
                {
                    throw new ArgumentException("Невозможноя Дата рождения", nameof(birthDate));
                }
                if (weight <= 0)
                {
                    throw new ArgumentException("Вес не может быть меньше либо равен нулю", nameof(weight));
                }
                if (height <= 0)
                {
                    throw new ArgumentException("Рост не можен быть меньше нуля", nameof(height));
                }
                #endregion

                Name = name;
                Gender = gender;
                Birthday = birthDate;
                Weight = weight;
                Height = height;
            }

        public User(string name) 
        {
            if(string.IsNullOrWhiteSpace(name)) 
            { 
                throw new ArgumentException("Имя не должно быть пустым",nameof(name));
            }

            Name = name;
        }

        public override string ToString()
            {
                return Name + " " + Age;
            }
        }
    
}
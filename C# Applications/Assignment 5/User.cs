using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Assignment_5
{
    /// <summary>
    /// Represents the user playing the game. includes name and age
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets and Sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets and sets age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Initializes the instance of the User with name and age
        /// </summary>
        /// <param name="name">name of user</param>
        /// <param name="age">age of user</param>
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
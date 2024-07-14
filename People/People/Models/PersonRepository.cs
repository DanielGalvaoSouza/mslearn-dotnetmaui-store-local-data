using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace People.Models
{
    public class PersonRepository
    {
        private SQLiteConnection _connection;
        private string _dbPath { get;set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public string StatusMessage { get; set; }

        private void Init()
        {
            if (_connection != null)
                return;

            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Person>();

        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                //enter this line
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Invalid name required");

                // enter this line
                result = _connection.Insert(new Person { Name = name});

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieved data. {0}", ex.Message);
            }

        }

        public List<Person> GetAllPeople()
        {
            try
            {
                Init();
                return _connection.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieved data. {0}", ex.Message);
            }

            return new List<Person>();

        }



    }
}

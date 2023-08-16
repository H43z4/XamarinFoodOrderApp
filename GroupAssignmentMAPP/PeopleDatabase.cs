using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupAssignmentMAPP
{
	public class PeopleDatabase
	{
		static SQLiteConnection Database;
		public string CurrentStatus;

		public PeopleDatabase()
		{
			try
			{
				Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);

				//Creating a table Person
				Database.CreateTable<Person>();

				CurrentStatus = "Database Created Successfully!!!";
			}
			catch (SQLiteException ex)
			{
				CurrentStatus = ex.Message;
			}
		}

		public int SavePerson(Person person)
		{
			return Database.Insert(person);
		}

		public List<Person> GetPeople()
		{
			return Database.Table<Person>().ToList();
		}

		public List<Person> CheckLogin(string email, string password) //Function to check login
		{
			// Checking if a record exists with the user input email and password
			return Database.Query<Person>("SELECT * FROM Person WHERE Email = ? AND Password = ?", email, password);
		}
	}
}

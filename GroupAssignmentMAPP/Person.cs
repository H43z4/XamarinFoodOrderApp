using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GroupAssignmentMAPP
{
	public class Person : INotifyPropertyChanged //Creating Person class for database
	{
		[PrimaryKey, AutoIncrement]
		public int PersonID { get; set; }

		private string firstname, surname, address, contactnumber, email, password;

		public string Firstname
		{
			get
			{
				return firstname;
			}
			set
			{
				if (firstname != value)
				{
					firstname = value;
					OnpropertyChanged("Surname");
				}
			}
		}

		public string Surname
		{
			get
			{
				return surname;
			}
			set
			{
				if (surname != value)
				{
					surname = value;
					OnpropertyChanged("Firstname");
				}
			}
		}

		public string Address
		{
			get
			{
				return address;
			}
			set
			{
				if (address != value)
				{
					address = value;
					OnpropertyChanged("Address");
				}
			}
		}

		public string ContactNumber
		{
			get
			{
				return contactnumber;
			}
			set
			{
				if (contactnumber != value)
				{
					contactnumber = value;
					OnpropertyChanged("ContactNumber");
				}
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				if (password != value)
				{
					password = value;
					OnpropertyChanged("Password");
				}
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				if (email != value)
				{
					email = value;
					OnpropertyChanged("Email");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnpropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}

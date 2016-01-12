using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMLightTest.Model
{
    public class Person : ObservableObject
    {
        private int _id;
        private string _name;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                Set<int>(()=> this.ID, ref _id, value);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set<string>(() => this.Name, ref _name, value);
            }
        }

        public static ObservableCollection<Person> GetSamplePersons()
        {
            ObservableCollection<Person> persons = new ObservableCollection<Person>();

            for (int i = 0; i < 10; i++)
            {
                persons.Add(new Person { ID = i + 1, Name = "Person " + i.ToString() });

            }

            return persons;
        }
    }
}

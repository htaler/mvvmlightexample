using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvMLightTest.Model;
using System.Windows.Input;

namespace MvvMLightTest.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        private ObservableCollection<Person> persons;
        private Person currentPerson;

        public PersonViewModel()
        {

        }

        public ICommand LoadPersonsCommand { get; set; }
        public ICommand SavePersonsCommand { get; set; }

        public ObservableCollection<Person> PersonList
        {
            get
            {
                return persons;
            }
        }

        public Person CurrentPerson
        {
            get
            {
                return currentPerson;
            }
            set
            {
                currentPerson = value;
                RaisePropertyChanged("CurrentPerson");
            }
        }


    }
}

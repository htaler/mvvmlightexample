using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvMLightTest.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

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

        public void SavePersonMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Person saved"));
        }

        public void LoadPersonsMethod()
        {
            persons = Person.GetSamplePersons();
            this.RaisePropertyChanged(() => this.PersonList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Persons loaded"));
        }


    }
}

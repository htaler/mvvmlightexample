using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MvvMLightTest.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PersonViewModel>();
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }

        private void NotifyUserMethod(NotificationMessage message)
        {
            XmlDocument toastXML = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            ToastNotification toast = new ToastNotification(toastXML);

            XmlNodeList stringElements = toastXML.GetElementsByTagName("text");
            for (int i = 0; i < stringElements.Length; i++)
            {
                stringElements[i].AppendChild(toastXML.CreateTextNode("Message received: " + message.Notification));
            }

            ToastNotificationManager.CreateToastNotifier().Show(toast);

            Debug.WriteLine("Message received: " + message.Notification);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public PersonViewModel PersonViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO
        }
    }
}

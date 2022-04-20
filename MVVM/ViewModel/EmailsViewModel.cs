using RugbyManagementSystem.Core;
using RugbyManagementSystem.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManagementSystem.MVVM.ViewModel
{
    class EmailsViewModel : ObservableObject
    {
        public ObservableCollection<EmailModel> Emails { get; set; }

        public EmailsViewModel()
        {
            Emails = new ObservableCollection<EmailModel>();

            Emails.Add(new EmailModel
            {
                ID = "1",
                MemberName = "Irek Chylewski",
                Email = "irekchylewski@gmail.com"
            });
            Emails.Add(new EmailModel
            {
                ID = "2",
                MemberName = "Erika Silvanovic",
                Email = "erikasilvanovic@gmail.com"
            });
            Emails.Add(new EmailModel
            {
                ID = "3",
                MemberName = "Adrian Szramka",
                Email = "adrianszramka@gmail.com"
            });
        }
    }
}

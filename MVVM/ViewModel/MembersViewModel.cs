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
    class MembersViewModel : ObservableObject
    {
        
        public ObservableCollection<MemberModel> Members { get; set; }
        public MembersViewModel()
        {
            Members = new ObservableCollection<MemberModel>();

            Members.Add(new MemberModel
            {
                ID = "1",
                MemberName = "Irek Chylewski",
                Type = "Coach"
            });
            Members.Add(new MemberModel
            {
                ID = "2",
                MemberName = "Erika Silvanovic",
                Type = "Coach"

            });
            Members.Add(new MemberModel
            {
                ID = "3",
                MemberName = "Adrian Szramka",
                Type = "Coach"
            });
        }
    }
}

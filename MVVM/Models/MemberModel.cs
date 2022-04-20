using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RugbyManagementSystem.MVVM.Models
{
    class MemberModel
    {
        public string ID { get; set; }
        public string MemberName { get; set; }
        public string Type { get; set; }
        public Brush RandomColor { get; set; }

        public MemberModel (string memberName = "abc")
        {
            Random r = new Random();
            RandomColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
        }
    }
}

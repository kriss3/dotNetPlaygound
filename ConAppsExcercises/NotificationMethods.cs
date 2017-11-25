using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppsExcercises
{
    public class NotificationMethods
    {
        public delegate void MyEventHandler(object sender, EventArgs args);
        public event MyEventHandler _shaw;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOnCall();
                }
            }
        }

        protected virtual void NotifyOnCall()
        {
            if (_shaw != null)
                _shaw(this, EventArgs.Empty);
        }
    }
}

using System;

namespace ConAppsExercises;

public class NotificationMethods
{
    public delegate void MyEventHandler(object sender, EventArgs args);
    public event MyEventHandler Show;
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
        Show?.Invoke(this, EventArgs.Empty);
    }
}

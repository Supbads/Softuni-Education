using System;

namespace Problem_4.Student_Class
{
    public class PropertyChangedEventArgs<T> : EventArgs
    {
        public PropertyChangedEventArgs(string name, T oldValue, T newValue)
        {
            this.PropertyName = name;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string PropertyName { get; set; }

        public T OldValue { get; set; }

        public T NewValue { get; set; }
    }
}

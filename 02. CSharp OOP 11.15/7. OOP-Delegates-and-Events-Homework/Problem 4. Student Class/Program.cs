using System;

namespace Problem_4.Student_Class
{
    class Program
    {
        public delegate void _OnPropertyChange(object sender, PropertyChangedEventArgs<string> eventArgs);
        static void Main()
        {
            PropertyChangedEventHandler handler = delegate(object sender,PropertyChangedEventArgs<string> eventArgs)
            {
                Console.WriteLine(
                    "Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName,
                    eventArgs.OldValue,
                    eventArgs.NewValue);
            };

            //Action<object, PropertyChangedEventArgs<string>> fire = OnPropertyChange;

            Student customStudent = new Student("Pesho",20);
            customStudent.PropertyChanged += OnPropertyChange;

            customStudent.Name = "Maria";
            customStudent.Age = 19;

            //unsub
            customStudent.PropertyChanged -= OnPropertyChange;

            
            customStudent.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine(
                    "Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName,
                    eventArgs.OldValue,
                    eventArgs.NewValue);
            };// cannot unsubscribe lambdas

            customStudent.Name = "Pencho";
            customStudent.Age = 30;
        }

        private static void OnPropertyChange(object sender, PropertyChangedEventArgs<string> eventArgs)
        {
            Console.WriteLine("Property changed: {0} (from {1} to {2})",
                eventArgs.PropertyName,
                eventArgs.OldValue,
                eventArgs.NewValue);
        }
    }
}

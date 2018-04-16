using System;

namespace Problem_4.Student_Class
{
    public class Student
    {
        //public event EventHandler<PropertyChangedEventArgs<string>> PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string name;
        private int age;

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
               if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student's name can not be null or empty");
                }

                this.OnPropertyChanged(new PropertyChangedEventArgs<string>("Name", this.name, value));
                this.name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs<string>("Age", this.Age.ToString(), value.ToString()));
                this.age = value;
            }
        }

        //protected virtual
        private void OnPropertyChanged(PropertyChangedEventArgs<string> eventArgs)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, eventArgs); //fire
            }
        }
    }
}

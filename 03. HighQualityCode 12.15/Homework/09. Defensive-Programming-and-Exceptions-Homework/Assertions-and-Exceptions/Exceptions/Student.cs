using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;

    private string lastName;

    private IList<Exam> exams; 
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        //this.Exams = exams ?? new List<Exam>();
        if (exams == null)
        {
            this.Exams = new List<Exam>();
        }
        else
        {
            this.Exams = exams;
        }
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentException("first name cannot be null");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentException("last name cannot be null");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("student exams cannot be null");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            //maybe a custom exception for missing exams
            throw new ArgumentNullException("student exams cannot be null");
        }

        IList<ExamResult> results = new List<ExamResult>();

        if (this.Exams.Count == 0)
        {
            return results;
        }

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("exams","Student's exams cannot be null when calculating the average");
        }

        if (this.Exams.Count == 0)
        {
            // No exams --> return -1;
            return -1;
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}

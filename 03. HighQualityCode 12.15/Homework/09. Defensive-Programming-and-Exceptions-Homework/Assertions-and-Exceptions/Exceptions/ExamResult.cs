using System;

public class ExamResult
{
    private int grade;

    private int minGrade;

    private int maxGrade;

    private string comments;
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;

        if (minGrade < 0)
        {
            throw new Exception();
        }

        if (maxGrade <= minGrade)
        {
            throw new Exception();
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new Exception();
        }
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            if (value < minGrade || value > maxGrade)
            {
                throw new ArgumentOutOfRangeException("grade", "grade is bigger than the max exam grade or smaller than the min exam grade");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", "Minimum grade cannot be negative");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        set
        {
            if (value <= MinGrade)
            {
                throw new ArgumentOutOfRangeException("maxGrade", "Maximum grade cannot be less than or equal to the minimum grade");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("exam comment cannot be null or empty");
            }

            this.comments = value;
        }
    }
}

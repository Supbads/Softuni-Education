using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }
        private set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 10)
            {
                value = 10;
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved) // to be honest this program makes no sense 2 is the worse grade 6 is the max and 6 was being treated as average
        {                            // while the grades are based on number of problems solved so the max grade can't be 6 and min grade cannot be 2
            case 0:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1:
                return new ExamResult(4, 2, 6, "Average result: half the problems were solved.");
            case 2:
                return new ExamResult(6, 2, 6, "Excelent result: all problems were done done.");
            default:
                throw new ArgumentException("Invalid number of problems solved");
        }
    }
}

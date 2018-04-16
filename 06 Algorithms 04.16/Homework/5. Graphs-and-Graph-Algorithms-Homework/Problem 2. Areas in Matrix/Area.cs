namespace Problem_2.Areas_in_Matrix
{
    using System.Collections.Generic;

    public class Area
    {
        public Area()
        {
            this.Cells = new List<Cell>();
        }

        public char Letter { get; set; }

        public int Number { get; set; }

        public int StartX { get; set; }

        public int StartY { get; set; }

        public int Length { get; set; }

        public List<Cell> Cells { get; set; }
    }
}

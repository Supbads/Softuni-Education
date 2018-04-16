namespace Problem_7.Connected_Areas_in_a_Matrix
{
    using System.Collections.Generic;

    public class Area
    {
        public Area()
        {
            Cells = new List<Cell>();
        }

        public int Number { get; set; }

        public int StartX { get; set; }

        public int StartY { get; set; }
        
        public int Length { get; set; }

        public List<Cell> Cells { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnC.Model
{
    public class Test
    {
        public int Id { get; set; }

        public Dictionary<string, string[]> Quastions { get; set; }

        public bool[][] Answers { get; set; }
    }
}

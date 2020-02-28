namespace Common
{  
    public class Route
    {
        /// <summary>
        /// Resulting Path connecting all nodes
        /// Example of ResultingPath, if nodes are from N1 to N5 to N3, ResultingPath value should be N1 -> N5 -> N3
        /// </summary>
        public string ResultingPath { get; set; }

        /// <summary>
        /// Resulting cumulative weight connecting all nodes
        /// Example: Combined weights for travelling nodes from N1 to N5 to N3
        /// </summary>
        public double CumulativeWeight { get; set; }
    }
}
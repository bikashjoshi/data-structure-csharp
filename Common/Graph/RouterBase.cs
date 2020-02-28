using System.Collections.Generic;

namespace Common
{
    public abstract class RouterBase
    {
        protected readonly Dictionary<string, Dictionary<string, double>> _routes = new Dictionary<string, Dictionary<string, double>>();

        /// <summary>
        /// Adds Route between two nodes
        /// </summary>
        /// <param name="source">Source node</param>
        /// <param name="destination">Destination node</param>
        /// <param name="weight">Cost associate travelling from source node to destination node.</param>
        public void AddRoute(string source, string destination, double weight = 1)
        {
            Dictionary<string, double> destinations = null;
            if (!_routes.TryGetValue(source, out destinations))
            {
                destinations = new Dictionary<string, double>();
                _routes.Add(source, destinations);
            }

            destinations.Add(destination, weight);
        }

        /// <summary>
        /// Gets all the available routes between two nodes 
        /// </summary>
        /// <param name="source">Source node</param>
        /// <param name="destination">Destination node</param>
        /// <returns><see cref="Route"/>All available Routes and their cumulative costs.</returns>
        public abstract IEnumerable<Route> GetAllRoutes(string source, string destination);
    }
}

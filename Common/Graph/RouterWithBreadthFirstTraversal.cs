using System;
using System.Collections.Generic;

namespace Common
{
    public class RouterWithBreadthFirstTraversal : RouterBase
    {
        public override IEnumerable<Route> GetAllRoutes(string source, string destination)
        {
            return GetRouteUsingBreadthFirst(source, destination);
        }

        public IList<Route> GetRouteUsingBreadthFirst(string source, string finalDestination)
        {
            var queue = new Queue<Tuple<string, Route>>();
            var visited = new List<string>();
            var routes = new List<Route>();

            queue.Enqueue(Tuple.Create(source, new Route { ResultingPath = source }));
            visited.Add(finalDestination); // no need to traverse the final destination

            while (queue.Count != 0)
            {
                var next = queue.Dequeue();
                var destinationAddress = next.Item1;
                var route = next.Item2;
             
                if (string.Compare(finalDestination, destinationAddress) == 0)
                {
                    routes.Add(route);
                }

                if (visited.Contains(destinationAddress))
                {
                    continue;
                }

                visited.Add(destinationAddress);

                if (_routes.ContainsKey(destinationAddress))
                {
                    foreach (var destinations in _routes[destinationAddress])
                    {
                        if (string.Compare(source, destinations.Key) == 0)
                            continue; // avoid looping back to origin

                        queue.Enqueue(Tuple.Create(destinations.Key, route.Append(destinations.Key, destinations.Value)));
                    }
                }
            }

            return routes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class RouterWithDepthFirstTraversal : RouterBase
    {
        public override IEnumerable<Route> GetAllRoutes(string source, string destination)
        {
            return RouteUsingDepthFirstInStack(source, destination);
        }

        private IEnumerable<Route> RouteUsingDepthFirstInStack(string source, string finalDestination)
        {
            if (!_routes.ContainsKey(source))
                return Enumerable.Empty<Route>();

            var routes = new List<Route>();
            var stack = new Stack<Tuple<string, Route>>();
            var visited = new List<string>();

            stack.Push(Tuple.Create(source, new Route { ResultingPath = source }));
            visited.Add(source);
           
            while (stack.Count != 0)
            {
                var next = stack.Pop();
                var destinationAddress = next.Item1;
                var route = next.Item2;

                if (string.Compare(destinationAddress, finalDestination) == 0)
                {
                    routes.Add(route);
                }
                else if (_routes.ContainsKey(destinationAddress))
                {                   
                    var destinations = _routes[destinationAddress].ToList();
                    for (var index = destinations.Count - 1; index >= 0; index--)
                    {
                        var destination = destinations[index];
                        var nodeAddress = destination.Key;
                        var edgeWeight = destination.Value;
                        var isNodeAddressFinalDestination = string.Compare(nodeAddress, finalDestination) == 0;
                        if (!visited.Contains(nodeAddress) || isNodeAddressFinalDestination)
                        {
                            if (!isNodeAddressFinalDestination)
                                visited.Add(nodeAddress);

                            stack.Push(Tuple.Create(nodeAddress, route.Append(nodeAddress, edgeWeight)));
                        }
                    }
                }             
            }

            return routes;
        }
    }
}

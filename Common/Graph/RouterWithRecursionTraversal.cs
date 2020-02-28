using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class RouterWithRecursionTraversal : RouterBase
    {
        public override IEnumerable<Route> GetAllRoutes(string source, string destination)
        {
            return GetRoutesInternal(source, destination, new List<string> { source }); // initialzing visted with source
        }

        private IList<Route> GetRoutesInternal(string source, string finalDestination, IList<string> visited)
        {
            var routes = new List<Route>();

            if (!_routes.ContainsKey(source))
            {
                return routes;
            }

            var destinations = _routes[source];
            foreach(var destinationAndWeight in destinations)
            {
                var destinationAddress = destinationAndWeight.Key;
                var weight = destinationAndWeight.Value;

                if (string.Compare(source, destinationAddress) == 0)
                {
                    continue; // avoid looping back to origin
                }

                if (string.Compare(finalDestination, destinationAddress) == 0)
                {
                    routes.Add(RouteHelper.Create(source, destinationAddress, weight));
                }
                else if (!visited.Contains(destinationAddress))
                {
                    visited.Add(destinationAddress);
                    var r = GetRoutesInternal(destinationAddress, finalDestination, visited);
                    if (r.Count > 0)
                    {
                        routes.AddRange(r.Select(x => x.Prepend(source, weight)));
                    }
                }
            }

            return routes;
        }
    }
}

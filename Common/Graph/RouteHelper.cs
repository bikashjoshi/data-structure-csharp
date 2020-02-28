namespace Common
{
    public static class RouteHelper
    {
        public static Route Append(this Route route, string endNode, double weight)
        {
            return new Route
            {
                ResultingPath = string.Concat(route.ResultingPath, "->", endNode),
                CumulativeWeight = route.CumulativeWeight + weight
            };
        }

        public static Route Prepend(this Route route, string startNode, double weight)
        {
            return new Route
            {
                ResultingPath = string.Concat(startNode, "->", route.ResultingPath),
                CumulativeWeight = route.CumulativeWeight + weight
            };
        }

        public static Route Create(string startNode, string endNode, double weight)
        {
            return new Route
            {
                ResultingPath = string.Concat(startNode, "->", endNode),
                CumulativeWeight = weight
            };
        }
    }
}

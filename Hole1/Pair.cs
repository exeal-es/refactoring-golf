namespace Hole1
{
    public class Pair<A, B>
    {
        public readonly A first;
        public readonly B second;

        public Pair(A first, B second)
        {
            this.first = first;
            this.second = second;
        }
    }
}
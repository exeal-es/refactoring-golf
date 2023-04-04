namespace Hole2
{
    public class Pair<A, B>
    {
        public readonly A first;
        public readonly B second;

        public Pair(int first, string second)
        {
            this.first = first;
            this.second = second;
        }
    }
}
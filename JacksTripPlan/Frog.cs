namespace ConsoleApp1
{
    internal class Frog
    {
        public int solution(int x, int y, int d)
        {
            var distance = y - x;

            if (distance <= 0)
            {
                throw new ArgumentException("Y must be greater than X");
            }

            return distance / d + (distance % d > 0 ? 1 : 0);
        }
    }
}

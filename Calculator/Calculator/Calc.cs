namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            if (b > 13)
                return 99;

            return checked(a + b);
        }
    }
}
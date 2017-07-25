using System;

namespace Bowling
{
    public class Frame
    {
        public int FirstBall { get; private set; }
        public int SecondBall { get; private set; }

        public Frame(int firstBall, int secondBall)
        {
            if (firstBall >= 0 && secondBall >= 0 && firstBall + secondBall <= 10)
            {
                FirstBall = firstBall;
                SecondBall = secondBall;
            }
            else
            {
                throw new ArgumentOutOfRangeException();                
            }
        }

        public bool IsSpare
        {
            get { return !IsStrike && FirstBall + SecondBall == 10; }
        }

        public bool IsStrike
        {
            get { return FirstBall == 10; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingGame
    {
        public List<Frame> Frames { get; private set; } 

        public BowlingGame(IEnumerable<Frame> frames)
        {
            if (frames == null)
            {
                throw new ArgumentNullException();
            }

            var validFrames = frames.Where(f => f != null).ToList();

            if (validFrames.Count < 10 || validFrames.Count > 12)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (validFrames.Count == 10 && (validFrames[9].IsStrike || validFrames[9].IsSpare))
            {
                throw new ArgumentException();
            }

            if (validFrames.Count > 10 && !validFrames[9].IsSpare && !validFrames[9].IsStrike)
            {
                throw new ArgumentException();
            }

            if (validFrames.Count == 11 && validFrames[10].IsStrike)
            {
                throw new ArgumentException();                
            }

            Frames = validFrames;
        }

        public int Score
        {
            get
            {
                var score = 0;
                for (var i = 0; i < 10; i++)
                {
                    if (Frames[i].IsStrike)
                    {
                        if (Frames[i + 1].IsStrike)
                        {
                            score += Frames[i].FirstBall + Frames[i + 1].FirstBall + Frames[i + 2].FirstBall;
                        }
                        else
                        {
                            score += Frames[i].FirstBall + Frames[i + 1].FirstBall + Frames[i + 1].SecondBall;
                        }
                    }
                    else if (Frames[i].IsSpare)
                    {
                        score += Frames[i].FirstBall + Frames[i].SecondBall + Frames[i + 1].FirstBall;
                    }
                    else
                    {
                        score += Frames[i].FirstBall + Frames[i].SecondBall;
                    }
                }
                return score;
            }
        }
    }
}
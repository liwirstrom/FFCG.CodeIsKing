using System.Collections.Generic;

namespace FFCG.BowlingGame.Logic
{
	public class BowlingGameRound
	{
		private List<Frame> Frames { get; set; }
		private int Frame { get; set; }

		public BowlingGameRound()
		{
			Frame = 1;
			Frames = new List<Frame>();
		}

		public void Roll(int pins)
		{
			if (Frames.Count < Frame && Frame <= 10)
			{
				Frame newFrame;
				if (Frame == 10)
				{
					newFrame = new TenthFrame();

				}
				else
				{
					newFrame = new Frame();
				}

				if (Frames.Count != 0)
				{
					Frames[Frames.Count - 1].NextFrame = newFrame;
				}
				newFrame.NewRoll(pins);
				if (pins == 10 && Frame != 10)
				{
					newFrame.NewRoll(0);
					Frame++;
				}
				Frames.Add(newFrame);
			}
			else
			{
				Frames[Frames.Count - 1].NewRoll(pins);
				if (Frame != 10)
				{
					Frame++;
				}

				if (Frames.Count == 10)
				{
					var totalPoints = Frames[Frames.Count - 1].FirstRoll + Frames[Frames.Count - 1].SecondRoll;
					if ( totalPoints < 10)
					{
						Frames[Frames.Count - 1].NewRoll(0);
					}
					
				}
			}

		}

		public int CalculateTotalScore()
		{
			var score = 0;
			foreach (var frame in Frames)
			{
				score += frame.GetTotalPoints();

			}

			return score;
		}

	}
}

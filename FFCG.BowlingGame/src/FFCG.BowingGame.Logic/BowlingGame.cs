using System.Collections.Generic;

namespace FFCG.BowlingGame
{
    public class BowlingGame
    {
	    private List<int> _rollHistory;
	    //private List<Frame> Frames { get; set; }
		//private int Frame { get; set; }

		public BowlingGame()
		{
			//Frame = 1;
			//Frames = new List<Frame>();
			_rollHistory = new List<int>();
		}

		public void Roll(int pins)
		{
			_rollHistory.Add(pins);


		}

		public int CalculateTotalScore()
		{
			var score = 0;
			var frames = new List<Frame>();
			var framesCreated = 0;

			for (int roll = 0; roll < _rollHistory.Count; roll++)
			{
				if (framesCreated == 9)
				{
					var frame = new TenthFrame
					{
						FirstRoll = _rollHistory[roll],
						SecondRoll = _rollHistory[roll + 1]
					};
					if (roll != _rollHistory.Count - 2)
					{
						frame.ThirdRoll = _rollHistory[roll + 2];
					}
					frames.Add(frame);
				}
				else
				{


					if (_rollHistory[roll] == 10)
					{
						var frame = new Frame {FirstRoll = 10};
						frames.Add(frame);
					}
					else
					{
						var frame = new Frame
						{
							FirstRoll = _rollHistory[roll],
							SecondRoll = _rollHistory[roll + 1]
						};
						frames.Add(frame);
						roll++;
					}
				}
				framesCreated++;
			}

			for (int frameIndex = 0; frameIndex < 10; frameIndex++)
			{
				if (frameIndex != 9)
				{
					frames[frameIndex].NextFrame = frames[frameIndex + 1];
				}
			}
			foreach (var frame in frames)
			{
				score += frame.GetTotalPoints();

			}

			return score;
		}
	}
}

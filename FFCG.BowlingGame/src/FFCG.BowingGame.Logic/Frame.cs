namespace FFCG.BowlingGame
{
    public class Frame
    {
		public int FirstRoll { get; protected set; }
		public int SecondRoll { get; protected set; }
		public Frame NextFrame { get; set; }

		public Frame()
		{
			FirstRoll = -1;
			SecondRoll = -1;
		}

		public virtual void NewRoll(int points)
		{
			if (FirstRoll == -1)
			{
				FirstRoll = points;
			}
			else
			{
				SecondRoll = points;
			}
		}

		public virtual int GetTotalPoints()
		{
			var totalPoints = FirstRoll + SecondRoll;
			if (FirstRoll == 10)
			{
				totalPoints += CalculateBonusStrikePoints();
			}
			else if (totalPoints == 10)
			{
				totalPoints += NextFrame.FirstRoll;
			}

			return totalPoints;
		}

		public int CalculateBonusStrikePoints()
		{
			int bonusPoints;
			if (NextFrame.NextFrame != null)
			{
				bonusPoints = NextFrame.FirstRoll == 10
					? NextFrame.FirstRoll + NextFrame.NextFrame.FirstRoll
					: NextFrame.GetTotalPoints();
			}
			else
			{
				bonusPoints = NextFrame.FirstRoll == 10
					? NextFrame.FirstRoll + NextFrame.SecondRoll
					: NextFrame.GetTotalPoints();
			}


			return bonusPoints;
		}
	}
}

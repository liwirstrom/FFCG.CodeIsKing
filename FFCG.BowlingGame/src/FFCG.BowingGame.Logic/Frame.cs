namespace FFCG.BowlingGame
{
    public class Frame
    {
		public int FirstRoll { get;  set; }
		public int SecondRoll { get; set; }
		public Frame NextFrame { get; set; }

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

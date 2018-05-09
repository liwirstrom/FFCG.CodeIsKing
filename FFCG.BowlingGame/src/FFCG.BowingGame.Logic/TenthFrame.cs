namespace FFCG.BowlingGame
{
    public class TenthFrame: Frame
    {
		public int ThirdRoll { get; protected set; }

		public override void NewRoll(int points)
		{
			if (FirstRoll == -1)
			{
				FirstRoll = points;
			}
			else if (SecondRoll == -1)
			{
				SecondRoll = points;
			}
			else
			{
				ThirdRoll = points;
			}
		}

		public override int GetTotalPoints()
		{
			var totalPoints = FirstRoll + SecondRoll + ThirdRoll;

			return totalPoints;
		}

	}
}

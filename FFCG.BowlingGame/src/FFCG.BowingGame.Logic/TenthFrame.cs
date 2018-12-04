namespace FFCG.BowlingGame
{
    public class TenthFrame: Frame
    {
		public int ThirdRoll { get; set; }
		

		public override int GetTotalPoints()
		{
			var totalPoints = FirstRoll + SecondRoll + ThirdRoll;

			return totalPoints;
		}

	}
}

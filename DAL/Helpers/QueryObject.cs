namespace DAL.Helpers
{
	public class QueryObject
	{
		public string? Name { get; set; }
		public string? ExerciseName { get; set; }
		public string? SortBy { get; set; }
		public bool IsDecsending { get; set; } = false;
	}
}

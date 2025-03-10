namespace TrophyLibrary
{
    namespace TrophyLibrary
    {
        public class Trophy
        {
            private string competition;

            private int year;

            public int Id { get; set; }
            public string Competition
            {
                get => competition;
                set
                {
                    if (string.IsNullOrEmpty(value) || value.Length < 3)
                    {
                        throw new ArgumentException("Competition must be at least 3 characters long and cannot be null.");
                    }
                    competition = value;
                }
            }

            
            public int Year
            {
                get => year;
                set
                {
                    if (value < 1970 || value > 2025)
                    {
                        throw new ArgumentOutOfRangeException("Year must be between 1970 and 2025.");
                    }
                    year = value;
                }
            }

            public override string ToString()
            {
                return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
            }
        }
    }

}

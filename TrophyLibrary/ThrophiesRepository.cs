using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrophyLibrary.TrophyLibrary;

namespace TrophyLibrary
{
    public class TrophiesRepository
    {
        private List<Trophy> trophies;

        public TrophiesRepository()
        {
            trophies = new List<Trophy>
            {
                new Trophy { Id = 1, Competition = "Bowling", Year = 2021 },
                new Trophy { Id = 2, Competition = "Badminton", Year = 2011 },
                new Trophy { Id = 3, Competition = "Curling", Year = 2007 },
                new Trophy { Id = 4, Competition = "Tennis", Year = 1999 },
                new Trophy { Id = 5, Competition = "Swimming", Year = 1989 }
            };
        }

        public List<Trophy> Get(int? filterYear = null, string? sortBy = null)
        {
            var result = trophies.Select(t => new Trophy
            {
                Id = t.Id,
                Competition = t.Competition,
                Year = t.Year
            }).ToList();

            if (filterYear.HasValue)
            {
                result = result.Where(t => t.Year == filterYear.Value).ToList();
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.Equals("Competition", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderBy(t => t.Competition).ToList();
                }
                else if (sortBy.Equals("Year", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderBy(t => t.Year).ToList();
                }
            }
            return result;
        }

        public Trophy? GetById(int id)
        {
            return trophies.FirstOrDefault(t => t.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Id = trophies.Max(t => t.Id) + 1;
            trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                trophies.Remove(trophy);
            }
            return trophy;
        }

        public Trophy? Update(int id, Trophy values)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                trophy.Competition = values.Competition;
                trophy.Year = values.Year;
            }
            return trophy;
        }
    }
}


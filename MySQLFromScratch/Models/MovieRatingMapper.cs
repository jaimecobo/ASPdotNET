using System.Data;

namespace MySqlFromScratch.Models
{
    public class MovieRatingMapper
    {
        // offset fields
        int _IDOffset = 0;
        int _RatingOffset = 1;
        int _DescriptionOffset = 2;
        int _MinAgeOffset = 3;
        int _LongerDescriptionOffset = 4;
        // IDataReader Ctor
        public MovieRatingMapper(IDataReader reader)
        {
            if (reader.GetOrdinal("ID") != _IDOffset)
            {
                throw new Exception($"The offset of ID is not 0 as expected.  it was {reader.GetOrdinal("ID")}");
            }
            if (reader.GetOrdinal("Rating") != _RatingOffset)
            {
                throw new Exception($"The offset of ID is not 1 as expected.  it was {reader.GetOrdinal("Rating")}");
            }
            if (reader.GetOrdinal("Description") != _DescriptionOffset)
            {
                throw new Exception($"The offset of ID is not 2 as expected.  it was {reader.GetOrdinal("Description")}");
            }
            if (reader.GetOrdinal("MinAge") != _MinAgeOffset)
            {
                throw new Exception($"The offset of ID is not 3 as expected.  it was {reader.GetOrdinal("MinAge")}");
            }
            if (reader.GetOrdinal("LongerDescription") != _LongerDescriptionOffset)
            {
                throw new Exception($"The offset of ID is not 4 as expected.  it was {reader.GetOrdinal("LongerDescription")}");
            }
        }
        // ToRating

        public MovieRating ToMovieRating(IDataReader reader)
        {
            MovieRating rating = new MovieRating();
            // not nullable in the database, so no null check is required
            rating.ID = reader.GetInt32(_IDOffset);
            // The rating is nullable, so nee a null check
            if (reader.IsDBNull(_RatingOffset))
            {
                // it is rating indeed null
                rating.Rating = null;
            }
            else
            {
                // the rating is NOT null
                rating.Rating = reader.GetString(_RatingOffset);
            }

            // The description is nullable, so nee a null check
            if (reader.IsDBNull(_DescriptionOffset))
            {
                // it is rating indeed null
                rating.Description = null;
            }
            else
            {
                // the rating is NOT null
                 rating.Description = reader.GetString(_DescriptionOffset);
            }

            // The minage is nullable, so nee a null check
            if (reader.IsDBNull(_MinAgeOffset))
            {
                // it is rating indeed null
                rating.MinAge = null;
            }
            else
            {
                // the rating is NOT null
                rating.MinAge = reader.GetInt32(_MinAgeOffset);
            }

            // The minage is nullable, so nee a null check
            if (reader.IsDBNull(_LongerDescriptionOffset))
            {
                // it is rating indeed null
                rating.LongerDescription = null;
            }
            else
            {
                // the rating is NOT null
                rating.LongerDescription = reader.GetString(_LongerDescriptionOffset);
            }

            return rating;
        }
    }
}

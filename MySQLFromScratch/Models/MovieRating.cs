namespace MySqlFromScratch.Models
{
    public class MovieRating
    {
        public int ID { get; set; }

        public string? Rating { get; set; }

        public string? Description { get; set; }

        public int? MinAge { get; set; }

        public string? LongerDescription { get; set; }

        //public MovieRating()
        //{
        //    LongerDescription = "";
        //}


    }
}

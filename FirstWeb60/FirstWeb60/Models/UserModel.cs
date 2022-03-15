namespace FirstWeb60.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Display(Name="FirstName", Description="Your First given name", Prompt="")]     //This is an annotation
        public string? Name { get; set; }               // then ? indicates that this item is allowed to have a null value
        public DateTime BirthDate { get; set; }         // value types are not allowed to have a null value, for that reason it is not marked with the green squiggly line
        public string FavoriteThings { get; set; }
        public override string ToString()
        {
            //return base.ToString();
            return $"id:{Id} Name: {Name} Birth: {BirthDate} Favorites: {FavoriteThings}";
        }

    }
}

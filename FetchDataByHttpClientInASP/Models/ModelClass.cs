namespace FetchDataByHttpClientInASP.Models
{
    public class ModelClass
    {
    }
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Completed { get; set; }
    }
    public class Geo
    {
        public string? Lat { get; set; }
        public string? Lng { get; set; }
    }

    public class Address
    {
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public Geo? Geo { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
    }

}

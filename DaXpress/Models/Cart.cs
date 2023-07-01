namespace DaXpress.Models
{
    public class Cart
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public List<string> ProductNames = new List<string>();
        public List<int> counts = new List<int>();
        
        
        public Cart() 
        { 

        }
    }
}

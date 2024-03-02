namespace Commander.Dtos 
{
    public class CommandCreateDto
    {
        public required string HowTo { get; set; }
        public required string Line { get; set; }    
        public required string Platform { get; set; }
    }
}
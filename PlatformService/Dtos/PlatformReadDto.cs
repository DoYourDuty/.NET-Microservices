//DTO - Data Transfer Objects 
// DTO For Data Privacy and Contract coupling 

namespace PlatformService.Dtos
{
    public class PlatformReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Publisher { get; set; } = "";
        public string Cost { get; set; } = "";
    }
}
namespace SoftServeTestTask.BLL.Dto.Authentication
{
    public record JwtResponseDto(
        string Token, 
        string RefreshToken, 
        DateTime Expiration);
}

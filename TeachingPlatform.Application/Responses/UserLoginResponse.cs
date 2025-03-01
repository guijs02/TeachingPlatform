namespace TeachingPlatform.Application.Responses
{
    public record UserLoginResponse(string token, bool result)
    {
        public string Reponse => result ? token : "Usuário ou senha invalidos";
    }
}

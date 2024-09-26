namespace gP2os.Participants.Helpers;

public static class StringContentConvert
{
    public static StringContent GetStringContentLoginRequest(UserLoginRequest loginRequest)
    {
        return new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
    }
}

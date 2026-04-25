namespace Rallyhub.Common.Utils;

public class OtpGenerate
{
    public static string Generate6DigitOtp() => Random.Shared.Next(100000, 999999).ToString();
}
using System.Globalization;
using System.Text;

namespace Rallyhub.Service.Validation;

public class Service: IService
{
    public string RemoveDiacritics(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        
        var normalized = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var c in normalized)
        {
            if(CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }
        
        return sb.ToString()
            .Normalize(NormalizationForm.FormC)
            .Replace('đ', 'd')
            .Replace('Đ', 'D');
        
    }   
}
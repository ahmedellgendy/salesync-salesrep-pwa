using System.Text;
using System.Text.Json;

namespace Salesync.SalesRep.Pwa.Auth;

public static class JwtClaimReader
{
    public static string? GetClaimValue(
        string token,
        string claimName)
    {
        if (string.IsNullOrWhiteSpace(token) ||
            string.IsNullOrWhiteSpace(claimName))
        {
            return null;
        }

        var tokenParts = token.Split('.');

        if (tokenParts.Length < 2)
        {
            return null;
        }

        try
        {
            var payload = tokenParts[1]
                .Replace('-', '+')
                .Replace('_', '/');

            payload = AddBase64Padding(payload);

            var payloadBytes =
                Convert.FromBase64String(payload);

            var payloadJson =
                Encoding.UTF8.GetString(payloadBytes);

            using var jsonDocument =
                JsonDocument.Parse(payloadJson);

            foreach (var property in
                     jsonDocument.RootElement.EnumerateObject())
            {
                if (!string.Equals(
                        property.Name,
                        claimName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                return property.Value.ValueKind switch
                {
                    JsonValueKind.String =>
                        property.Value.GetString(),

                    JsonValueKind.Number =>
                        property.Value.GetRawText(),

                    _ => null
                };
            }

            return null;
        }
        catch (
            FormatException)
        {
            return null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private static string AddBase64Padding(string value)
    {
        return (value.Length % 4) switch
        {
            2 => value + "==",
            3 => value + "=",
            0 => value,
            _ => throw new FormatException(
                "The JWT payload isn't valid Base64Url.")
        };
    }
}
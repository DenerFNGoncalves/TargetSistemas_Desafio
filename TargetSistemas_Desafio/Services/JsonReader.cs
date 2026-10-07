using System.Text.Json;

namespace TargetSistemas_Desafio
{
    public class JsonReader
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static T Read<T>(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Arquivo não encontrado: {path}");

            try
            {
                var json = File.ReadAllText(path);

                return JsonSerializer.Deserialize<T>(json, _options)
                    ?? throw new InvalidDataException(
                        "O arquivo JSON não contém dados válidos.");
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException(
                    $"O arquivo '{path}' contém um JSON inválido.",
                    ex);
            }
        }
    }
}
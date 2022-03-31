using System.Linq;
public static class Program {
    public static void Main(string[] args) {
        WriteArray(GetPossibleMessages("111")); 
        WriteArray(GetPossibleMessages("31416")); 
        WriteArray(GetPossibleMessages("112524")); 
        WriteArray(GetPossibleMessages("")); 
    }

    public static string[] GetPossibleMessages(string encoded) {
        var letters = Enumerable.Range(1, 26).Select(value => new {Char = (char)(value + 96), Value = value});

        List<KeyValuePair<string, string>> possibleMessages = new List<KeyValuePair<string, string>>() {new("", encoded)};

        var finalMessages = new List<string>();

        do {
            // Get all the letters that can fit the start of the message along with the message
            var possibleLetters = possibleMessages.SelectMany(pair => letters.Where(letter => pair.Value.StartsWith(letter.Value.ToString()))
                                                                             .Select(letter => new { Letter = letter, Message = pair }));
            
            // Update possibleMessages with all the possibilities
            possibleMessages = possibleLetters.Select(possibleLetter => 
                                                        new KeyValuePair<string, string>(
                                                            possibleLetter.Message.Key + possibleLetter.Letter.Char, 
                                                            possibleLetter.Message.Value.Substring(possibleLetter.Letter.Value.ToString().Length)
                                                            )
                                                        ).ToList();

            // Add all the decrypted message to the final array
            finalMessages.AddRange(possibleMessages.Where(possibleMessage => possibleMessage.Value == "").Select(possibleMessage => possibleMessage.Key));
            
            // Do while there's at least one message that isn't decrypted
        } while (possibleMessages.Any(pair => pair.Value != ""));

        return finalMessages.OrderBy(message => message).ToArray();
    }

    public static void WriteArray<T> (T[] values) {
        Console.WriteLine("[" + string.Join(",", values.Select(value => value?.ToString())) + "]");
    }
}
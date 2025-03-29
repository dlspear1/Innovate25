namespace Innovate25
{
    class ROT13
    {
        // Function to encode a string using ROT13
        static string EncodeRot13(string text)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsLower(c) ? 'a' : 'A';
                    result[i] = (char)(((c - baseChar + 13) % 26) + baseChar);
                }
                else
                {
                    result[i] = c;
                }
            }
            return new string(result);
        }

        // Function to decode a string using ROT13 (since ROT13 is symmetric)
        static string DecodeRot13(string text)
        {
            return EncodeRot13(text);
        }

        static void EncodeFile()
        {
            Console.Write("Enter the file name to encode: ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"The file {fileName} does not exist.");
                return;
            }

            string content = File.ReadAllText(fileName);
            string encodedContent = EncodeRot13(content);

            Console.Write("Enter the file name to store the encoded content: ");
            string encodedFileName = Console.ReadLine();

            File.WriteAllText(encodedFileName, encodedContent);

            Console.WriteLine($"The content has been encoded and saved to {encodedFileName}");
        }

        static void DecodeFile()
        {
            Console.Write("Enter the file name to decode: ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"The file {fileName} does not exist.");
                return;
            }

            string content = File.ReadAllText(fileName);
            string decodedContent = DecodeRot13(content);

            Console.Write("Enter the file name to store the decoded content: ");
            string decodedFileName = Console.ReadLine();

            File.WriteAllText(decodedFileName, decodedContent);

            Console.WriteLine($"The content has been decoded and saved to {decodedFileName}");
        }

        static void WordCount()
    {
        Console.Write("Enter the file name for word count: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"The file {fileName} does not exist.");
            return;
        }

        string content = File.ReadAllText(fileName);
        string[] words = content.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int wordCount = words.Length;

        Console.WriteLine($"Total number of words in {fileName}: {wordCount}");
    }

    }
}


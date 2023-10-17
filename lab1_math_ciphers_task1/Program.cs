using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Український алфавіт
        string alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя0123456789";

        //стовпцевий та рядковий ключі
        //string columnKey = "324150"; 
        //string rowKey = "231450";

        string columnKey = "абвгдєжзи";
        string rowKey = "іїйклмноп";

        Console.WriteLine("Введіть текст для шифрування:");
        string plaintext = Console.ReadLine();

        string encryptedText = Encrypt(plaintext, alphabet, columnKey, rowKey);
        Console.WriteLine("Зашифрований текст: " + encryptedText);

        string decryptedText = Decrypt(encryptedText, alphabet, columnKey, rowKey);
        Console.WriteLine("Розшифрований текст: " + decryptedText);
    }

    static string Encrypt(string plaintext, string alphabet, string columnKey, string rowKey)
    {
        string encryptedText = "";

        foreach (char character in plaintext)
        {
            if (character == ' ')
            {
                encryptedText += ' '; // Додаємо символ пробілу в зашифрований текст
                continue;
            }

            int alphabetIndex = alphabet.IndexOf(character);

            if (alphabetIndex == -1)
            {
                encryptedText += character;
            }
            else
            {
                int columnIndex = alphabetIndex / rowKey.Length;
                int rowIndex = alphabetIndex % rowKey.Length;

                if (columnIndex < columnKey.Length && rowIndex < rowKey.Length)
                {
                    encryptedText += columnKey[columnIndex].ToString() + rowKey[rowIndex].ToString();
                }
                else
                {
                    encryptedText += character;
                }
            }
        }

        return encryptedText;
    }

    static string Decrypt(string encryptedText, string alphabet, string columnKey, string rowKey)
    {
        string decryptedText = "";

        for (int i = 0; i < encryptedText.Length; i++)
        {
            char currentChar = encryptedText[i];

            if (currentChar == ' ')
            {
                decryptedText += ' '; // Відновлюємо символ пробілу
            }
            else if (i < encryptedText.Length - 1)
            {
                char nextChar = encryptedText[i + 1];
                string pair = currentChar.ToString() + nextChar.ToString();

                int columnIndex = columnKey.IndexOf(pair[0]);
                int rowIndex = rowKey.IndexOf(pair[1]);

                if (columnIndex != -1 && rowIndex != -1)
                {
                    int alphabetIndex = columnIndex * rowKey.Length + rowIndex;

                    if (alphabetIndex < alphabet.Length)
                    {
                        decryptedText += alphabet[alphabetIndex];
                    }
                    else
                    {
                        decryptedText += pair;
                    }
                    i++; // Перескочуємо на наступну пару символів
                }
                else
                {
                    decryptedText += pair;
                }
            }
            else
            {
                decryptedText += currentChar;
            }
        }

        return decryptedText;
    }

}

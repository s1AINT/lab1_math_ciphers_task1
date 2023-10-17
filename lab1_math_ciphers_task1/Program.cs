using System;

class Program
{
    static void Main()
    {
        // Український алфавіт
        string alphabet = "абвгдеєжзиіїйклмнопрстуфхцчшщьюя";

        //стовпцевий та рядковий ключі
        string columnKey = "3241"; // Приклад
        string rowKey = "2314";    // Приклад

        Console.WriteLine("Введіть текст для шифрування:");
        string plaintext = Console.ReadLine().ToLower();

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
            if (character == ' ') // Пропускаємо пробіли
            {
                encryptedText += ' ';
                continue;
            }

            int columnIndex = columnKey.IndexOf(character);
            int rowIndex = rowKey.IndexOf(character);

            if (columnIndex == -1 || rowIndex == -1)
            {
                // Символ не знайдено у ключах, додаємо його без змін
                encryptedText += character;
            }
            else
            {
                encryptedText += alphabet[columnIndex * rowKey.Length + rowIndex];
            }
        }

        return encryptedText;
    }

    static string Decrypt(string encryptedText, string alphabet, string columnKey, string rowKey)
    {
        string decryptedText = "";

        foreach (char character in encryptedText)
        {
            if (character == ' ') // Пропускаємо пробіли
            {
                decryptedText += ' ';
                continue;
            }

            int indexInAlphabet = alphabet.IndexOf(character);

            if (indexInAlphabet == -1)
            {
                // Символ не входить в алфавіт, додаємо його без змін
                decryptedText += character;
            }
            else
            {
                int columnIndex = indexInAlphabet / rowKey.Length;
                int rowIndex = indexInAlphabet % rowKey.Length;
                decryptedText += columnKey[columnIndex] + rowKey[rowIndex];
            }
        }

        return decryptedText;
    }
}

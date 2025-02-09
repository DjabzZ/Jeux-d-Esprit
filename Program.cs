using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenue ! Cliquez sur une touche pour jouer au jeu.");
        Console.ReadKey(); // Attend que l'utilisateur appuie sur une touche

        do
        {
            Console.Clear(); // Efface la console pour une nouvelle présentation

            Console.WriteLine("Bienvenue dans le jeu de chiffrement de Vigenère !\n");
            Console.WriteLine("Dans ce jeu, vous pouvez crypter et décrypter des messages en utilisant le chiffre de Vigenère.");
            Console.WriteLine("Ce chiffre utilise une clé pour transformer chaque lettre du texte original.");
            Console.WriteLine("Le cryptage se fait en déplaçant chaque lettre du texte original selon une séquence définie par la clé.");
            Console.WriteLine("Vous pouvez jouer en choisissant l'option de cryptage ou de décryptage dans le menu.");
            Console.WriteLine("Amusez-vous bien !");

            Console.WriteLine("\nMenu principal\n");
            Console.WriteLine("1- Crypter un message");
            Console.WriteLine("2- Décrypter un message");

            int choix;
            do
            {
                Console.Write("\nMerci de rentrer votre choix [1,2] :");
            } while (!int.TryParse(Console.ReadLine(), out choix) || (choix != 1 && choix != 2));

            if (choix == 1)
            {
                Console.WriteLine("Vous avez choisi de crypter un message.");
                Console.Write("Entrez le texte à crypter : ");
                string inputText = Console.ReadLine().ToUpper(); // Convertir en majuscules pour la simplicité
                Console.Write("Entrez la clé : ");
                string key = Console.ReadLine().ToUpper();

                string encryptedText = EncryptVigenere(inputText, key);
                Console.WriteLine($"Texte chiffré : {encryptedText}");
            }
            else
            {
                Console.WriteLine("Vous avez choisi de décrypter un message.");
                Console.Write("Entrez le texte à décrypter : ");
                string inputText = Console.ReadLine().ToUpper(); // Convertir en majuscules pour la simplicité
                Console.Write("Entrez la clé : ");
                string key = Console.ReadLine().ToUpper();

                string decryptedText = DecryptVigenere(inputText, key);
                Console.WriteLine($"Texte déchiffré : {decryptedText}");
            }

            Console.WriteLine("\nVoulez-vous recommencer ? (Oui/Non)");
        } while (Console.ReadLine().Trim().ToUpper() == "OUI");
    }

    static string EncryptVigenere(string text, string key)
    {
        char[] encryptedText = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                int shift = key[i % key.Length] - 'A';
                encryptedText[i] = (char)(((text[i] - 'A' + shift) % 26) + 'A');
            }
            else
            {
                encryptedText[i] = text[i]; // Conserver les caractères non alphabétiques inchangés
            }
        }

        return new string(encryptedText);
    }

    static string DecryptVigenere(string text, string key)
    {
        char[] decryptedText = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                int shift = key[i % key.Length] - 'A';
                decryptedText[i] = (char)(((text[i] - 'A' - shift + 26) % 26) + 'A');
            }
            else
            {
                decryptedText[i] = text[i];
            }
        }

        return new string(decryptedText);
    }
}

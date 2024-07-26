using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Adam Asmaca Oyununa Hoşgeldiniz");


        /* Can bitene kadar harf yazabilecek
         * Can bitince eğer kelimeyi bilemezse kaybedecek
         * Can bitmeden kelimeyi bilirse oyunu kazanacak
         * Harf tahmini yaparken tahmin edilen harf kelimede nerede varsa artık görünür olacak.
         * Son harfi de tahmin edene kadar oyun devam edecek. (Can bitince oyun bitme kontrolünü de unutmayalım)
         */
        // Şimdi oyunu biraz daha kendi istediğimiz hale getirelim '1' oyuna devam '0' oyundan çık

        while (true) // Oyun döngüsü
        {
            Console.WriteLine("Oyuna başlamak için 1 ");
            Console.WriteLine("Oyundan çıkmak için 0 ve enter'a basınız.");
            int gameStart = int.Parse(Console.ReadLine());

            if (gameStart == 0)
            {
                Console.WriteLine("Oyundan çıkış yaptınız...");
                break; // oyun döngüsünden çıkış yapıyoruz.
            }

            if (gameStart == 1)
            {
                Console.Write("Saklamak istediğiniz kelimeyi yazınız: ");
                string word = Console.ReadLine().ToUpper();
                string hiddenWord = new string('_', word.Length);  // kelimemizin uzunluğu kadar '_' işareti ile kelimemizi gizledik.

                Console.WriteLine();

                Console.Write("Kaç can olsun: ");
                int healthScore = int.Parse(Console.ReadLine());

                Console.WriteLine("Yazılar siliniyor...");
                Console.Clear();
                Console.WriteLine("Yazılar silindi, oyuna başlayabilirsiniz...");
                Console.WriteLine();


                while (healthScore > 0)
                {
                    Console.WriteLine($"Kelimemiz: {hiddenWord}");
                    Console.Write("Harf Yazınız: ");

                    char guessedLetter = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    if (word.Contains(guessedLetter))
                    {
                        char[] hiddenWordArray = hiddenWord.ToCharArray(); // gizlediğimiz kelimeyi harf dizisine çeviriyoruz

                        for (int i = 0; i < word.Length; i++)
                        {
                            if (word[i] == guessedLetter) // tahmin edilen harf, kelimemizin içerisinde var mı?
                            {
                                hiddenWordArray[i] = guessedLetter; // tahmin edilen harf kelimemizin içerisinde varsa, gizlenmiş kelimemizin içindeki harfi değiştiriyoruz.
                            }
                        }

                        hiddenWord = new string(hiddenWordArray); // şimdi char dizisini tekrar 'string'e çeviriyoruz.

                    }
                    else
                    {
                        healthScore--;
                        Console.WriteLine();
                        Console.WriteLine($"--- Yanlış tahmin. Mevcut Can: {healthScore} ---");
                        Console.WriteLine();
                    }

                    if (hiddenWord == word)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"*** Tebrikler kelimeyi bildiniz. Kelime: {hiddenWord} ***");
                        Console.WriteLine();
                        break; // oyun bittiği için döngüden çıkartalım.
                    }
                }

                if (healthScore <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Canınız bitti maalesef kaybettiniz, şu ana kadar bildiğiniz kısım: {hiddenWord}");
                    Console.WriteLine();
                    break; // yenildiği için döngüden çıkaralım.
                }
            }
        }
    }
}

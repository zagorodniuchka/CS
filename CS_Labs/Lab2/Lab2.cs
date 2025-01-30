namespace CS_Labs.Lab2;

public class Lab2
{
    static string message = "ZNOVIG RVPWVIG hifuwnsnjf vzvijvo oxivhwsf cinz wqv csnrvixgj ncznovig oxusnzthf. Wqv\ntzatpptonip' ivuniwp rviv pnzvwxzvp nuvgvotgo ivto, tgo, xc gvhvpptif, hifuw-tgtsfmvo. Af wqv vgo\nnc wqv hvgwdif,hifuwnsnjf qto avhnzv xzuniwtgw vgndjq cni znpw pwtwvp wn lvvu cdss-wxzv\nhxuqvi pvhivwtixvp nhhduxvo xg ztlxgj du gvr lvfp, vghxuqvixgj tgoovhxuqvixgj zvpptjvp, tgo\npnskxgj xgwvihvuwvo oxputwhqvp. Pnzvwxzvpwqv hifuwtgtsfpwp rviv pvutitwv cinz wqv hxuqvi\npvhivwtixvp tgo rvivhtssvo xg ngsf rqvg gvvovo. Uviqtup wqv znpw vstanitwv nijtgxmtwxng\nrtpKvgxhv'p. Xw cvss dgovi wqv xzzvoxtwv hngwins nc wqv Hndghxs nc Wvg, wqvunrvicds tgo\nzfpwvixndp anof wqtw idsvo wqv ivudasxh stijvsf wqindjq xwpvccxhxvgw pvhivw unsxhv. Kvgxhv\nnrvo qvi uivvzxgvghv stijvsf wn JxnktggxPnin, rqn rtp uviqtup wqv Rvpw'p cxipw jivtw \nhifuwtgtsfpw. Pnin,tuunxgwvo hxuqvi pvhivwtif xg 1506, vgenfvo ivztiltasv pdhhvpp xgpnskxgj wqv\nhxuqvip nc gdzvindp uixghxutsxwxvp. Qxp pnsdwxng nc t oxputwhqnc Ztil Tgwqngf Hnsntgt, hqxvc\nnc wqv tizf nc wqv Qnsf Inztg VzuviniZtyxzxsxtg X, ivbdvpwxgj 20,000 odhtwp ni wqv uivpvghv\nnc wqv vzuvinirxwq wqv tizf, jtkv tg xgpxjqw xgwn Hnsnggt'p uinasvzp. Pn jivtw rtpPnin'p ctzv\nwqtw nwqvi hndiwp pqtiuvgvo wqvxi hxuqvip, tgo tp vtisf tp1510 wqv ututs hdixt rtp pvgoxgj qxz\nhxuqvip wqtw gn ngv xg Inzv hndsopnskv. Adw Kvgxhv qto gn zngnunsf. Xg 1589, Qvgif nc Gtktiiv,\nrqn rtp ovpwxgvo wn avhnzv wqv znpwunudsti lxgj xg wqv qxpwnif nc Citghv (qv hnxgvo wqv\npsnjtg \"T hqxhlvg xgvkvif uvtptgw'p unw vkvif Pdgotf\"), tphvgovo wn wqv wqingv tp Qvgif XKtgo\ncndgo qxzpvsc vzainxsvo pwxss zniv cxvihvsf xg qxp axwwvi hngwvpwrxwq wqv Qnsf Svtjdv, t\nHtwqnsxh cthwxng wqtw ivcdpvo wn hnghvov wqtw tUinwvpwtgw hndso rvti wqv hinrg. Wqv\nSvtjdv, qvtovo af wqv Odlv ncZtfvggv, qvso Utixp tgo tss wqv nwqvi stijv hxwxvp nc Citghv, tgo\nrtpivhvxkxgj stijv witgpcdpxngp nc zvg tgo zngvf cinz Uqxsxu nc Putxg.Qvgif rtp wxjqwsf qvzzvo\nxg, tgo xw rtp tw wqxp edghwdiv wqtw pnzvhniivpungovghv avwrvvg Uqxsxu tgo wrn nc qxp\nsxtxpng nccxhvip,Hnzztgovi Edtg ov Znivn tgo Tzatpptoni Ztgnppv, cvss xgwn Qvgif'pqtgop.Xw rtp\nxg hxuqvi, adw qv qto xg qxp jnkvigzvgw tw wqv wxzv ngvCitghnxp Kxvwv, wqv pvxjgvdi ov st\nAxjnwxviv, t 49-fvti-nso strfvi cinzUnxwnd rqn qto ixpvg wn avhnzv hndgpvsni nc wqv utisvzvgw,\nni hndiw ncedpwxhv, nc Wndip tgo t uixkf hndgpvsni wn Qvgif. Kxvwv qto cni fvtiptzdpvo qxzpvsc\nrxwq ztwqvztwxhp tp t qnaaf-\"Gvkvi rtp t ztg znivanig cni ztwqvztwxhp,\" ptxo Wtssvzvgw ovp Ivtdy.\nTp wqv ztg rqn cxipwdpvo svwwvip cni bdtgwxwxvp xg tsjvait, jxkxgj wqtw pwdof xwp\nhqtithwvixpwxhsnnl, Kxvwv xp wnotf ivzvzavivo tp wqv Ctwqvi nc Tsjvait. T fvti avcniv,qv qto\npnskvo t Putgxpq oxputwhq tooivppvo wn Tsvpptgoin Ctigvpv, wqvOdlv nc Utizt, rqn qvtovo wqv\nPutgxpq cnihvp nc wqv Svtjdv. Qvgifwdigvo wqv gvr xgwvihvuwp nkvi wn qxz wn pvv xc Kxvwv\nhndso ivuvtw qxppdhhvpp.";
    static List<string> lowercasedLetters = new List<string>(); // Track letters made lowercase
    static List<string> replacedLetters = new List<string>();   // Track replaced letters
    static string decryptedMessage;

    public static void Run()
    {
        var letterFrequencies = LetterFrequencyAnalysis(message);
        ShowFrequency(letterFrequencies); // Show frequencies before decryption

        var dynamicLetterMapping = BuildFrequencyMapping(letterFrequencies);

        decryptedMessage = Decryption(message, dynamicLetterMapping);

        Console.WriteLine("\nDecrypted message:");
        Console.WriteLine(decryptedMessage);

        ShowMenu();
    }

    static Dictionary<char, int> LetterFrequencyAnalysis(string text)
    {
        var frequency = new Dictionary<char, int>();
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        foreach (char letter in alphabet)
            frequency[letter] = 0;

        text = new string(text.Where(char.IsLetter).ToArray()).ToUpper();

        foreach (char letter in text)
            frequency[letter]++;

        return frequency.OrderByDescending(f => f.Value).ToDictionary(f => f.Key, f => f.Value);
    }

    static string englishLetterFrequency = "ETAOINSHRDLCUMWFGYPBVKJXQZ";

    // Function to build dynamic frequency mappings for letters
    static Dictionary<char, char> BuildFrequencyMapping(Dictionary<char, int> sortedMessageFreq)
    {
        var mapping = new Dictionary<char, char>();
        int i = 0;

        foreach (var pair in sortedMessageFreq)
        {
            if (i < englishLetterFrequency.Length)
                mapping[pair.Key] = englishLetterFrequency[i];
            i++;
        }

        return mapping;
    }

    // Function to decrypt message based on letter frequency mappings
    static string Decryption(string message, Dictionary<char, char> letterMapping)
    {
        string decryptedText = "";

        for (int i = 0; i < message.Length; i++)
        {
            char letter = char.ToUpper(message[i]);
            decryptedText += letterMapping.ContainsKey(letter) ? letterMapping[letter] : letter;
        }

        return decryptedText;
    }

    static void ShowFrequency(Dictionary<char, int> frequency)
    {
        Console.WriteLine("\nLetter Frequencies:");
        foreach (var kvp in frequency)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
    
    static void ShowMenu()
    {
        Console.WriteLine("\nChoose an action:");
        Console.WriteLine("1. Change letters to lowercase");
        Console.WriteLine("2. Replace letter");
        Console.WriteLine("3. Change letters to uppercase");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ChangeToLowerCase();
                break;
            case "2":
                ReplaceLetter();
                break;
            case "3":
                ChangeToUpperCase();
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                ShowMenu();
                break;
        }
    }
    static void ReplaceLetter()
    {
        Console.WriteLine("Enter the letter to replace (format: A->B):");
        string input = Console.ReadLine().ToUpper();
        var parts = input.Split("->");

        if (parts.Length == 2)
        {
            string oldLetter = parts[0];
            string newLetter = parts[1];

            if (lowercasedLetters.Contains(oldLetter) || lowercasedLetters.Contains(newLetter))
            {
                Console.WriteLine($"One of the letters ('{oldLetter}' or '{newLetter}') has been made lowercase and cannot be replaced.");
            }
            else
            {
                string placeholder = "©"; // Placeholder character

                // Replace oldLetter with placeholder
                decryptedMessage = decryptedMessage.Replace(oldLetter, placeholder);

                // Replace newLetter with oldLetter
                decryptedMessage = decryptedMessage.Replace(newLetter, oldLetter);

                // Replace placeholder with newLetter
                decryptedMessage = decryptedMessage.Replace(placeholder, newLetter);

                Console.WriteLine("Modified message:");
                Console.WriteLine(decryptedMessage);
            }
        }
        else
        {
            Console.WriteLine("Invalid input format.");
        }

        ShowMenu();
    }

    static void ChangeToLowerCase()
    {
        Console.WriteLine("Enter the letters you want to make lowercase (separate with spaces):");
        string letters = Console.ReadLine().ToUpper();
        var lettersArray = letters.Split(' ');

        foreach (var letter in lettersArray)
        {
            decryptedMessage = decryptedMessage.Replace(letter, letter.ToLower());
            lowercasedLetters.Add(letter);
        }

        Console.WriteLine("Modified message:");
        Console.WriteLine(decryptedMessage);
        ShowMenu();
    }

    static void ChangeToUpperCase()
    {
        Console.WriteLine("Enter the letters you want to make uppercase (separate with spaces):");
        string letters = Console.ReadLine().ToLower();
        var lettersArray = letters.Split(' ');

        foreach (var letter in lettersArray)
        {
            decryptedMessage = decryptedMessage.Replace(letter.ToLower(), letter.ToUpper());
            lowercasedLetters.Remove(letter.ToUpper());
        }

        Console.WriteLine("Modified message:");
        Console.WriteLine(decryptedMessage);
        ShowMenu();
    }
}
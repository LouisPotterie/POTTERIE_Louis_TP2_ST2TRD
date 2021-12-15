using System;
using System.Text;
using static System.Windows.MessageBox;


namespace Lab2
{
    public class Vigenere
    {
        public static string Code(string inputText, bool toDecrypt)
        {
            var keyword = "ZOE";
            var key = GenerateKey(inputText, keyword);
            // Ternary operator - Google it
            return toDecrypt ? Decrypt(inputText, key) : Encrypt(inputText, key);
        }
        
        

        static String GenerateKey(string inputText, string key)
        {
            if (inputText.Length <= key.Length)
            {
                return key;
            }
            else
            {
                for (int i = 0; i<inputText.Length; i++)
                {
                    key+=(key[i]);
                }
            }
            
            Show($"Vigenere Key used :{key}");
            return key;
        }
        
        public static string CleaningAccent(string inputText)
        {
            string inputTextClean;
            
            StringBuilder inputTextBuilder = new StringBuilder(inputText);
            
            for (int i = 0; i < inputTextBuilder.Length; i++)
            {
                switch (inputTextBuilder[i])
                {
                    case 'é':
                        inputTextBuilder[i] = 'e';
                        break;
                    case 'è':
                        inputTextBuilder[i] = 'e';
                        break;
                    case 'ê':
                        inputTextBuilder[i] = 'e';
                        break;
                    case 'à':
                        inputTextBuilder[i] = 'a';
                        break;
                    case 'â':
                        inputTextBuilder[i] = 'a';
                        break;
                    case 'ù':
                        inputTextBuilder[i] = 'u';
                        break;
                    case 'û':
                        inputTextBuilder[i] = 'u';
                        break;
                    case 'î':
                        inputTextBuilder[i] = 'i';
                        break;
                    case 'ë':
                        inputTextBuilder[i] = 'e';
                        break;
                    case 'ç':
                        inputTextBuilder[i] = 'c';
                        break;
                    case 'ô':
                        inputTextBuilder[i] = 'o';
                        break;
                    case '%':
                        inputTextBuilder[i] = '%';
                        break;
                    case '’' : 
                        inputTextBuilder[i] = ' ';
                        break;

                }
                
                
                
            }
            
            inputTextClean = inputTextBuilder.ToString();

            return inputTextClean;
        }
            
        

        private static string Encrypt(string inputText, string key)
        {
            try
            {
                var output = string.Empty;

                var inputTextClean = CleaningAccent(inputText);
                
                var inputTextUpper = inputTextClean.ToUpper();

                for (int i = 0; i < inputTextUpper.Length; i++)
                {
                    switch (inputTextUpper[i])
                    {
                        case ' ':
                            output += ' ';
                            break;
                        case ',':
                            output += ',';
                            break;
                        case '.':
                            output += '.';
                            break;
                        case ';':
                            output += ';';
                            break;
                        case ':':
                            output += ':';
                            break;
                        case '/':
                            output += '/';
                            break;
                        case '?':
                            output += '?';
                            break;
                        case '%':
                            output += '%';
                            break;
                        case '!':
                            output += '!';
                            break;
                        case (char)48 : 
                            output+= (char)48;
                            break;
                        case (char)49 : 
                            output+= (char)49;
                            break;
                        case (char)50 : 
                            output += (char)50;
                            break;
                        case (char)51 : 
                            output += (char)51;
                            break;
                        case (char)52 : 
                            output += (char)52;
                            break;
                        case (char)53 : 
                            output += (char)53;
                            break;
                        case (char)54 : 
                            output += (char)54;
                            break;
                        case (char)55 : 
                            output += (char)55;
                            break;
                        case (char)56 : 
                            output += (char)56;
                            break;
                        case (char)57 : 
                            output += (char)57;
                            break;
                        
                        default:
                            // converting in range 0-25
                            int x = (inputTextUpper[i] + key[i]) %26;
                    
                            // convert into alphabets(ASCII)
                            x += 'A';

                            output+=(char)(x);
                            break;
                       
                        
                    }

                }
            
                return output;

            }
            catch (Exception e)
            {
                Show($"Is not relevant to apply Vigenere:{e.Message}");
               
            }

            return null;
        }

        private static string Decrypt(string inputText, string key)
        {
            try
            {
                var decryptedText = string.Empty;
            
                var inputTextUpper = inputText.ToUpper();
     
                for (int i = 0 ; i < inputTextUpper.Length &&
                                 i < key.Length; i++)
                {
                    switch (inputTextUpper[i])
                    {
                        case ' ':
                            decryptedText += ' ';
                            break;
                        case ',':
                            decryptedText += ',';
                            break;
                        case '.':
                            decryptedText += '.';
                            break;
                        case ';':
                            decryptedText += ';';
                            break;
                        case ':':
                            decryptedText += ':';
                            break;
                        case '/':
                            decryptedText += '/';
                            break;
                        case '%':
                            decryptedText += '%';
                            break;
                        case '?':
                            decryptedText += '?';
                            break;
                        case '!':
                            decryptedText += '!';
                            break;
                        case (char)48 : 
                            decryptedText += (char)48;
                            break;
                        case (char)49 : 
                            decryptedText += (char)49;
                            break;
                        case (char)50 : 
                            decryptedText += (char)50;
                            break;
                        case (char)51 : 
                            decryptedText += (char)51;
                            break;
                        case (char)52 : 
                            decryptedText += (char)52;
                            break;
                        case (char)53 : 
                            decryptedText += (char)53;
                            break;
                        case (char)54 : 
                            decryptedText += (char)54;
                            break;
                        case (char)55 : 
                            decryptedText += (char)55;
                            break;
                        case (char)56 : 
                            decryptedText += (char)56;
                            break;
                        case (char)57 : 
                            decryptedText += (char)57;
                            break;
                        default:
                            // converting in range 0-25
                            int x = (inputTextUpper[i] -
                                key[i] + 26) %26;
     
                            // convert into alphabets(ASCII)
                            x += 'A';
                            decryptedText+=(char)(x);
                            break;
                       
                        
                    }

                }
            
                return decryptedText;

            }
            catch (Exception e)
            {
                Show($"Is not relevant to apply Vigenere:{e.Message}");
                
            }

            return null;
        }
    }
}
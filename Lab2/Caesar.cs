using System;
using System.Text;
using static System.Windows.MessageBox;

namespace Lab2
{
    public class Caesar
    {
        
        public static string Code(string inputText, bool toDecrypt)
        {
            int key = 5;
            // Ternary operator - Google it
            return toDecrypt ? Decrypt(inputText, key) : Encrypt(inputText, key);
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
        

        private static char Cipher(char carac, int key)
        {
            
                if (!char.IsLetter(carac))
                {
                    return carac;
                }

                var d = char.IsUpper(carac) ? 'A' : 'a';

                var caracEncrypted = (char) ((((carac + key) - d) % 26) + d);

                return caracEncrypted;
        }
            
        

        private static string Encrypt(string inputText, int key)
        {
            try
            {
                var output = string.Empty;

                inputText = CleaningAccent(inputText);

                foreach (var carac in inputText)
                {
                    output += Cipher(carac, key);
                }
            
                return output;

            }
            catch (Exception e)
            {
                Show($"Is not relevant to apply Caesar:{e.Message}");
               
            }

            return null;
        }

        private static string Decrypt(string inputText, int key)
        {
            try
            {
                var decryptedText = Encrypt(inputText, 26 - key);
                return decryptedText;

            }
            catch (Exception e)
            {
                Show($"Is not relevant to apply Caesar:{e.Message}");
                
            }

            return null;
        }
    }
}
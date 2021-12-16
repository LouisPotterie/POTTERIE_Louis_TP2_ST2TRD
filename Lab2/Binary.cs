using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.MessageBox;


namespace Lab2
{
    public class Binary
    {
        
        public static ASCIIEncoding Ascii = new ASCIIEncoding();
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
        
        public static string Code(string inputText, bool toDecrypt)
        {
            
            // Ternary operator - Google it
            var inputTextClean = CleaningAccent(inputText);
            return toDecrypt ? Decrypt(inputTextClean) : Encrypt(inputTextClean);
        }
        private static string Encrypt(string inputText)
        {
            try
            {
                StringBuilder output = new StringBuilder();
      
                foreach (char c in inputText.ToCharArray())
                {
                    output.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
                }
                
                
                for (var i = 2; i < output.Length; i += 3)
                {
                    output.Insert(i, " ");
                }
                
                return output.ToString();

            }
            catch(Exception ex)
            {
                Show($"Is not relevant to apply Binary:{ex.Message}");
            }

            return null;
        }

        private static string Decrypt(string inputText)
        {
            try
            {
                List<Byte> byteList = new List<Byte>();

               

                inputText = inputText.Replace(" ", "");
     
                for (int i = 0; i < inputText.Length; i += 8)
                {
                    
                        byteList.Add(Convert.ToByte(inputText.Substring(i, 8), 2));
                }
                return Encoding.ASCII.GetString(byteList.ToArray());

            }
            catch (Exception ex)
            {
                Show($"Is not relevant to decrypt Binary:{ex.Message}");
            }
            
            return null;
        }
    }
}
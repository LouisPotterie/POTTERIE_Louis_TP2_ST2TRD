using System.Windows;

namespace Lab2
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Infos(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("French accent are removed during the encryption process");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // the "??" operator checks for nullability and value all at once.
            // because ConvertCheckBox.IsChecked is of type __bool ?__ which
            // is a nullable boolean, so it can either be true, false or null
            var toDecrypt = ConvertCheckBox.IsChecked ?? false;
            var inputText = InputTextBox.Text;
            var encryptionmethod = EncryptionComboBox.Text;

            if (encryptionmethod == "Caesar")
            {
                OutputTextBox.Text = Caesar.Code(inputText, toDecrypt);
            }
            
            if (encryptionmethod == "Binary")
            {
                OutputTextBox.Text =Binary.Code(inputText, toDecrypt);
            }
            
            if (encryptionmethod == "Vigenere")
            {
                OutputTextBox.Text = Vigenere.Code(inputText, toDecrypt);
            }
            
            
            
        }
    }
    
}
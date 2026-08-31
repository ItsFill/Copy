using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace WpfApp2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string fromFile = @"C:\";
    private string toFolder = @"C:\";
    
    public MainWindow()
    {
        InitializeComponent();
    }

    public void chooseFromFile(object sender, RoutedEventArgs e)
    {
        var chooseFile = new OpenFileDialog 
        { 
            Title = "Choose File", 
            Filter = "All Files (*.*)|*.*", 
            InitialDirectory = fromFile,
            Multiselect = false
        };

        if (chooseFile.ShowDialog() == true)
        {
            fromFile = chooseFile.FileName;
            FromPath.Text = $"From:\n{fromFile}";
            FromPath.FontSize = 15;
        }
    }
    
    public void chooseToFolder(object sender, RoutedEventArgs e)
    {
        var chooseFolder = new OpenFolderDialog() 
        { 
            Title = "Choose Folder",
            InitialDirectory = toFolder,
            Multiselect = false
        };

        if (chooseFolder.ShowDialog() == true)
        {
            toFolder = chooseFolder.FolderName;
            ToPath.Text = $"To:\n{toFolder}";
            ToPath.FontSize = 15;
        }
    }

    public void copyButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(fromFile) || string.IsNullOrWhiteSpace(toFolder))
        {
            return;
        }
        string fileName = System.IO.Path.GetFileName(fromFile);
        string copyTo = System.IO.Path.Combine(toFolder, fileName);
        File.Copy(fromFile, copyTo, true);
    }
}
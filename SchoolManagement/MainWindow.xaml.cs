using SchoolManagement.ViewModels;
using System.Windows;

namespace SchoolManagement
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = new MainViewModel();
    }
  }
}

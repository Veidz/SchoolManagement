using System.Windows;

namespace SchoolManagement.View
{
  public partial class StudentWindow : Window
  {
    public StudentWindow()
    {
      InitializeComponent();
    }

    public void AddStudentClick(object sender, RoutedEventArgs routedEventArgs)
    {
      DialogResult = true;
    }
  }
}

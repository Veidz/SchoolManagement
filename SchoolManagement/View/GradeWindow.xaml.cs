using System.Windows;

namespace SchoolManagement.View
{
  public partial class GradeWindow : Window
  {
    public GradeWindow()
    {
      InitializeComponent();
    }
    public void AddGradeClick(object sender, RoutedEventArgs routedEventArgs)
    {
      DialogResult = true;
    }
  }
}

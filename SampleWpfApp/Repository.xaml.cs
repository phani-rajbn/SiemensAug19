using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SampleDll;
namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for Repository.xaml
    /// </summary>
    public partial class Repository : Window
    {
        static EntitesComponent component = new EntitesComponent();
        public EmpTable newEmployee { get; set; }
        public Repository()
        {
            InitializeComponent();
            newEmployee = new EmpTable();
            grdNew.DataContext = newEmployee;
        }
        public ObservableCollection<EmpTable> Employees { get; set; }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            List<EmpTable> list = component.GetAllEmployees();
            Employees = new ObservableCollection<EmpTable>(list);
            lstNames.ItemsSource = Employees;
            lstNames.DisplayMemberPath = "Empname";
        }
        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var emp = stkSelected.DataContext as EmpTable;
            component.UpdateEmployee(emp);
            MessageBox.Show("Employee updated Successfully");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            component.AddEmployee(newEmployee);
            MessageBox.Show("Employee added successfully");
        }
    }
}

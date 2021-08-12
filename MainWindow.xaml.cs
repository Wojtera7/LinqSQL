using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace LinqSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        LinqSQLDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["LinqSQL.Properties.Settings.FirstDBConnectionString"].ConnectionString;

            dataContext = new LinqSQLDataClassesDataContext(connectionString);

            //InsertUniversities();

            //InsertStudent();
            //MainDataGrid.ItemsSource = dataContext.Universities;

            //MainDataGrid.ItemsSource = dataContext.Students;

            //UpdateTony();

            DeleteCJ();

        }




        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("delete from University");


            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);
            
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;

        }


        public void InsertStudent()
        {

            University yale = dataContext.Universities.First(work1 => work1.Name.Equals("Yale"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "CJ", Gender = "F", UniversityId = yale.Id });

            students.Add(new Student { Name = "Tony", Gender = "M", University = yale });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;


        }


        public void UpdateTony()
        {

            Student tony = dataContext.Students.FirstOrDefault(work1 => work1.Name == "Tony");

            tony.Name = "Antony";

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;



        }


        public void DeleteCJ()
        {

            Student cj = dataContext.Students.FirstOrDefault(work1 => work1.Name == "CJ");

            dataContext.Students.DeleteOnSubmit(cj);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;



        }




    }
}

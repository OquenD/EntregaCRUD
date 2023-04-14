using CRUDSqlite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace EntregaCRUD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FillData();
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                Student studen = new Student
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    Age = int.Parse(txtAge.Text),
                    Email = txtEmail.Text,
                };
                await App.SQLiteDB.SaveStudentAysnc(studen);
                await DisplayAlert("!", "Information Sent Succesfully", "OK");
                CleanControls();
                FillData();



            }
            else
            {
                await DisplayAlert("!", "Fill all informacion", "OK");
            }
        }

        public async void FillData()
        {
            var studentList = await App.SQLiteDB.GetStudentAysync();
            if (studentList != null)
            {
                lstStudents.ItemsSource = studentList;

            }

        }

        public bool Validate()
        {
            bool answer;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                answer = false;

            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                answer = false;
            }

            else if (string.IsNullOrEmpty(txtAge.Text))
            {
                answer = false;
            }

            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                answer = false;
            }
            else
            {
                answer = true;
            }
            return answer;
        }
        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdStudent.Text))
            {
                Student student = new Student()
                {
                    IdStudent = Convert.ToInt32(txtIdStudent.Text),
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Age = Convert.ToInt32(txtAge.Text),
                };
                await App.SQLiteDB.SaveStudentAysnc(student);
                await DisplayAlert("!", "Information Updated Succesfully", "OK");

                CleanControls();
                txtIdStudent.IsVisible = false;
                btnUpdate.IsVisible = false;
                btnRegister.IsVisible = true;
                FillData();

            }

        }

        private async void lstStudents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Student)lstStudents.SelectedItem;
            btnRegister.IsVisible = false;
            txtIdStudent.IsVisible = true;
            btnUpdate.IsVisible = true;
            btnDelete.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdStudent.ToString()))
            {
                var student = await App.SQLiteDB.GetStudentByIdAsync(obj.IdStudent);
                if (student != null)
                {
                    txtIdStudent.Text = student.IdStudent.ToString();
                    txtName.Text = student.Name.ToString();
                    txtLastName.Text = student.LastName.ToString();
                    txtEmail.Text = student.Email.ToString();
                    txtAge.Text = student.Age.ToString();

                }

            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var student = await App.SQLiteDB.GetStudentByIdAsync(Convert.ToInt32(txtIdStudent.Text));
            if (student != null)
            {
                await App.SQLiteDB.DeleteStudentAsync(student);
                await DisplayAlert("!", "Student Deleted Succesfully", "OK");
                CleanControls();
                FillData();
                txtIdStudent.IsVisible = false;
                btnUpdate.IsVisible = false;
                btnDelete.IsVisible = false;
                btnRegister.IsVisible = true;

            }
        }

        public void CleanControls()
        {
            txtIdStudent.Text = " ";
            txtName.Text = " ";
            txtLastName.Text = " ";
            txtAge.Text = " ";
            txtEmail.Text = " ";
        }

        private async void btnGetAPI_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new GET());
        }

        private async void btnPostAPI_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PushAsync(new POST());
        }


    }

}

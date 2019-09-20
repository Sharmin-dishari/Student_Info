using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo
{
    public partial class StudentInfo : Form
    {
        List<string> id = new List<string> { };
        List<string> name = new List<string> { };
        List<string> mobile = new List<string> { };
        List<int> age = new List<int> { };
        List<string> address = new List<string> { };
        List<float> gpa = new List<float> { };
        int i = 0;
        public StudentInfo()
        {
            InitializeComponent();
        }

        private void ValueAssign()
        {
            //id[i] = idTextBox.Text;
            //name[i] = nameTextBox.Text;
            //mobile[i] = mobileTextBox.Text;
            //age[i] = Convert.ToInt32(ageTextBox.Text);
            //address[i] = addressTextBox.Text;
            //gpa[i] = float.Parse(gpaTextBox.Text);

            if (!String.IsNullOrEmpty(idTextBox.Text) && idTextBox.Text.Length == 4)
            {
                id.Add(idTextBox.Text);
            }
            else
            {
                MessageBox.Show("ID Should be 4 Character");
            }
            if (!String.IsNullOrEmpty(nameTextBox.Text) && nameTextBox.MaxLength >= 30)
            {
                name.Add(nameTextBox.Text);
            }
            else
            {
                MessageBox.Show("Name Invalid");
            }
            if (!String.IsNullOrEmpty(mobileTextBox.Text) && mobileTextBox.Text.Length == 11)
            {
                mobile.Add(mobileTextBox.Text);
            }
            else
            {
                MessageBox.Show("Mobile Number Invalid");
                
            }
            if (!String.IsNullOrEmpty(ageTextBox.Text) )
            {
                age.Add(Convert.ToInt32(ageTextBox.Text));
            }
            else
            {
                MessageBox.Show("Fild Must be Required");
            }
            if (!String.IsNullOrEmpty(addressTextBox.Text) )
            {
                address.Add(addressTextBox.Text);
            }
            else
            {
                MessageBox.Show("Address must be required");
            }
            if (!String.IsNullOrEmpty(gpaTextBox.Text) && float.Parse(gpaTextBox.Text)<= 4 ||float.Parse(gpaTextBox.Text) >= 0)
            {
                gpa.Add(float.Parse(gpaTextBox.Text));
            }
            else
            {
                MessageBox.Show("GPA Invalid");
                
            }
          
        }
        private void addvalue()
        {
 

                showRichTextBox.Text += "\n\n" + "ID:" + id[i] + "\n" + "Name:" + name[i] + "\n" + "Mobile:" + mobile[i] + "\n" + "Age:" + age[i] + "\n" + "Address:" + address[i] + "\n" + "GPA:" + gpa[i] + "\n";
           
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ValueAssign();
            addvalue();
            Reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void Allstudent()
        {
            for(i=0;i<id.Count();i++)
            {
                showRichTextBox.Text += "\n\n" + "ID:" + id[i] + "\n" + "Name:" + name[i] + "\n" + "Mobile:" + mobile[i] + "\n" + "Age:" + age[i] + "\n" + "Address:" + address[i] + "\n" + "GPA:" + gpa[i] + "\n";
            }
        }
        private void Search()
        {
            try
            {
                if (idRadioButton.Checked == true)
                {
                    for (i = 0; i < id.Count(); i++)
                    {
                        if (id[i].Equals(idTextBox.Text))
                        {
                            showRichTextBox.Text += "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
                            + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
                        }

                    }
                 
                }
                else if (nameRadioButton.Checked == true)
                {
                    for (i = 0; i < id.Count(); i++)
                    {
                        if (name[i].Equals(nameTextBox.Text))
                        {
                            showRichTextBox.Text += "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
                            + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
                        }

                    }
                   
                }
                else if (mobileRadioButton.Checked == true)
                {
                    for (i = 0; i < id.Count(); i++)
                    {
                        if (mobile[i].Equals(mobileTextBox.Text))
                        {
                            showRichTextBox.Text += "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
                            + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
                        }

                    }
                    
                }
                else
                    MessageBox.Show("Search Item is not Match the Input");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            
            Allstudent();
            MaxMin();

        }
        private void MaxMin()
        {
            float totalGPA = 0;
            float maxGPA = gpa.Max();
            maxGPATextBox.Text = maxGPA.ToString();
            float minGPA = gpa.Min();
            minGPATextBox.Text = minGPA.ToString();
            float avgGPA = gpa.Average();
            avgGPATextBox.Text = avgGPA.ToString();
            maxGpaStudentNameTextBox.Text = name[gpa.IndexOf(maxGPA)];
            minGpaStudentNameTextBox.Text = name[gpa.IndexOf(minGPA)];
            for (i = 0; i < gpa.Count(); i++)
            {
                totalGPA += gpa[i];
            }
            totalGPATextBox.Text = totalGPA.ToString();
        }

        //Student_Information_Reset
        private void Reset()
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            mobileTextBox.Clear();
            ageTextBox.Clear();
            addressTextBox.Clear();
            gpaTextBox.Clear();
            maxGpaStudentNameTextBox.Clear();
            minGpaStudentNameTextBox.Clear();
            avgGPATextBox.Clear();
            totalGPATextBox.Clear();
            maxGPATextBox.Clear();
            minGPATextBox.Clear();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
            Reset();
        }
    }
          
}

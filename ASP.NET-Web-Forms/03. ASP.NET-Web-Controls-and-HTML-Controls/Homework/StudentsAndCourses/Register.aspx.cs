using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentsAndCourses
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var nameHeader = new HtmlGenericControl("h1");
            nameHeader.InnerText = string.Format("Name: {0} {1}", this.TextBoxFirstName.Text, this.TextBoxLastName.Text);

            var facultyNumberHeader = new HtmlGenericControl("h1");
            facultyNumberHeader.InnerText = string.Format("Faculty number: {0}", this.TextBoxFacultyNumber.Text);

            var universityHeader = new HtmlGenericControl("h1");
            universityHeader.InnerText = string.Format("University: {0}", this.DropDownListUniversity.SelectedValue);

            var specialtyHeader = new HtmlGenericControl("h1");
            specialtyHeader.InnerText = string.Format("Specialty: {0}", this.DropDownListSpecialty.SelectedValue);

            var coursesHeader = new HtmlGenericControl("h1");
            coursesHeader.InnerText = "Courses: ";

            var courses = new BulletedList();

            foreach (ListItem course in this.ListBoxCourses.Items)
            {
                if (course.Selected)
                {
                    courses.Items.Add(course);
                }
            }

            this.registerInfo.Controls.Add(nameHeader);
            this.registerInfo.Controls.Add(facultyNumberHeader);
            this.registerInfo.Controls.Add(universityHeader);
            this.registerInfo.Controls.Add(coursesHeader);
            this.registerInfo.Controls.Add(courses);
        }
    }
}
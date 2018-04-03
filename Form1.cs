using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

using Newtonsoft.Json.Linq;

namespace Client3
{
    public partial class Form1 : Form
    {
        Grad grade;
        about abt;
        ug UG;
        minors Ugmin;
        academic emp;
        facultyresearch yil;
        facimages fimg;
        socialpresence social;
        StudentRes resourcess;
        MinorCourse coursevi;
        maplocation maps_loc;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            minortitle.SelectAll();
            minortitle.SelectionAlignment = HorizontalAlignment.Center;
            rtg1.SelectionAlignment = HorizontalAlignment.Center;
            rtg2.SelectionAlignment = HorizontalAlignment.Center;
            rtg3.SelectionAlignment = HorizontalAlignment.Center;
            rtg4.SelectionAlignment = HorizontalAlignment.Center;
            rtg.SelectionAlignment = HorizontalAlignment.Center;
            b1.SelectionAlignment = HorizontalAlignment.Center;
            rt_1.SelectionAlignment = HorizontalAlignment.Center;
            rt_2.SelectionAlignment = HorizontalAlignment.Center;
            rt_3.SelectionAlignment = HorizontalAlignment.Center;
            rt_4.SelectionAlignment = HorizontalAlignment.Center;
            rt_5.SelectionAlignment = HorizontalAlignment.Center;
            rt_min.SelectionAlignment = HorizontalAlignment.Center;
            descriptionabout.SelectionAlignment = HorizontalAlignment.Center;
            quote.SelectionAlignment = HorizontalAlignment.Center;


            // Student Resources
            string jsonrs = getRestData("/resources/");
            resourcess = JToken.Parse(jsonrs).ToObject<StudentRes>();
            textBox4.Text = resourcess.title;
            ltitle.Text = resourcess.tutorsAndLabInformation.title;
            label2.Text = "fORMS";
            label3.Text = resourcess.coopEnrollment.title;

            // Maps
            string jsonlocation = getRestData("/location/");
            string jsonlocation1 = "{maplo:" + jsonlocation + "}";
            maps_loc = JToken.Parse(jsonlocation1).ToObject<maplocation>();

            //minor courses
            string jsonCourse = getRestData("/course/");
            string jsonCourse1 = "{courses:" + jsonCourse + "}";
            coursevi = JToken.Parse(jsonCourse1).ToObject<MinorCourse>();

            //      foreach (var t in maps_loc.maplo)
            //{

            //  Console.WriteLine(t.latitude);
            //}

            // Go get about .......
            string jsonDegree = getRestData("/degrees/graduate/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            grade = JToken.Parse(jsonDegree).ToObject<Grad>();

            rt_1.Text = grade.graduate.Find(x => x.degreeName.Equals("ist")).title;
            rt_2.Text = grade.graduate.Find(x => x.degreeName.Equals("hci")).title;
            rt_3.Text = grade.graduate.Find(x => x.degreeName.Equals("nsa")).title;
            rt_4.Text = grade.graduate.Find(x => x.degreeName.Equals("graduate advanced certificates")).degreeName;

            string jsonAbout = getRestData("/about/");

            abt = JToken.Parse(jsonAbout).ToObject<about>();
            titleabout.Text = abt.title;
            descriptionabout.Text = abt.description;
            quote.Text = abt.quote;
            quote1.Text = abt.quoteAuthor;


            string jsonUg = getRestData("/degrees/undergraduate/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            UG = JToken.Parse(jsonUg).ToObject<ug>();

            rtg1.Text = UG.undergraduate.Find(x => x.degreeName.Equals("wmc")).title;
            rtg2.Text = UG.undergraduate.Find(x => x.degreeName.Equals("hcc")).title;
            rtg3.Text = UG.undergraduate.Find(x => x.degreeName.Equals("cit")).title;



            string jsonminor = getRestData("/minors/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            Ugmin = JToken.Parse(jsonminor).ToObject<minors>();

            min1.Text = Ugmin.UgMinors.Find(x => x.name.Equals("DBDDI-MN")).title;
            min2.Text = Ugmin.UgMinors.Find(x => x.name.Equals("GIS-MN")).title;
            min3.Text = Ugmin.UgMinors.Find(x => x.name.Equals("MEDINFO-MN")).title;
            min4.Text = Ugmin.UgMinors.Find(x => x.name.Equals("MDDEV-MN")).title;
            min5.Text = Ugmin.UgMinors.Find(x => x.name.Equals("MDEV-MN")).title;
            min6.Text = Ugmin.UgMinors.Find(x => x.name.Equals("NETSYS-MN")).title;
            min7.Text = Ugmin.UgMinors.Find(x => x.name.Equals("WEBDD-MN")).title;
            min8.Text = Ugmin.UgMinors.Find(x => x.name.Equals("WEBD-MN")).title;


            string jsonacad = getRestData("/employment/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            emp = JToken.Parse(jsonacad).ToObject<academic>();

            acadtitle.Text = emp.introduction.title;
            emptitle.Text = emp.introduction.content.Find(x => x.title.Equals("Employment")).title;
            empdes.Text = emp.introduction.content.Find(x => x.title.Equals("Employment")).description;
            cartitle.Text = emp.introduction.content.Find(x => x.title.Equals("Cooperative Education")).title;
            cardes.Text = emp.introduction.content.Find(x => x.title.Equals("Cooperative Education")).description;
            card1.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("$80,000")).description;
            card2.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("36th")).description;
            card3.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("35")).description;
            card4.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("1.11 Billion GB")).description;
            val1.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("$80,000")).value;
            val2.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("36th")).value;
            val3.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("35")).value;
            val4.Text = emp.degreeStatistics.statistics.Find(x => x.value.Equals("1.11 Billion GB")).value;

            employers.Text = emp.employers.title;
            // emplist.Text = emp.employers.employerNames;

            careers.Text = emp.careers.title;
            // emplist1.Text = emp.careers.careerNames;
            foreach (string s in emp.employers.employerNames)
            {
                emplist1.AppendText(s);
                emplist1.AppendText("\n");
            }
            foreach (string s in emp.careers.careerNames)
            {
                emplist2.AppendText(s);
                emplist2.AppendText("\n");
            }

            string jsonfaculty = getRestData("/research/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            yil = JToken.Parse(jsonfaculty).ToObject<facultyresearch>();

            fac1.Text = yil.byInterestArea.Find(x => x.areaName.Equals("HCI")).areaName;
            fac2.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Education")).areaName;
            fac3.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Geo")).areaName;
            fac4.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Database")).areaName;
            fac5.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Analytics")).areaName;
            fac6.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Web")).areaName;
            fac7.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Networking")).areaName;
            fac8.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Mobile")).areaName;
            fac9.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Health Informatics")).areaName;
            fac10.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Programming")).areaName;
            fac11.Text = yil.byInterestArea.Find(x => x.areaName.Equals("System Administration")).areaName;
            fac12.Text = yil.byInterestArea.Find(x => x.areaName.Equals("Ubiquitous Computing")).areaName;

            string jsonfimg = getRestData("/people/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            fimg = JToken.Parse(jsonfimg).ToObject<facimages>();
            
            img1.ImageLocation = fimg.faculty.Find(x => x.username.Equals("bmtski")).imagePath;
            img2.ImageLocation = fimg.faculty.Find(x => x.username.Equals("emwics")).imagePath;
            img3.ImageLocation = fimg.faculty.Find(x => x.username.Equals("qyuvks")).imagePath;
            img4.ImageLocation = fimg.faculty.Find(x => x.username.Equals("sjzics")).imagePath;
            img5.ImageLocation = fimg.faculty.Find(x => x.username.Equals("ciiics")).imagePath;
            img6.ImageLocation = fimg.faculty.Find(x => x.username.Equals("dsbics")).imagePath;
            img7.ImageLocation = fimg.faculty.Find(x => x.username.Equals("bhhics")).imagePath;
            img8.ImageLocation = fimg.faculty.Find(x => x.username.Equals("spmics")).imagePath;
            img9.ImageLocation = fimg.faculty.Find(x => x.username.Equals("thoics")).imagePath;
            img10.ImageLocation = fimg.faculty.Find(x => x.username.Equals("nxsvks")).imagePath;
            img11.ImageLocation = fimg.faculty.Find(x => x.username.Equals("ephics")).imagePath;
            img12.ImageLocation = fimg.faculty.Find(x => x.username.Equals("mjfics")).imagePath;
            img13.ImageLocation = fimg.faculty.Find(x => x.username.Equals("vlhics")).imagePath;
            img14.ImageLocation = fimg.faculty.Find(x => x.username.Equals("lwhfac")).imagePath;
            img15.ImageLocation = fimg.faculty.Find(x => x.username.Equals("dmlics")).imagePath;
            img16.ImageLocation = fimg.faculty.Find(x => x.username.Equals("rpvvks")).imagePath;
            img17.ImageLocation = fimg.faculty.Find(x => x.username.Equals("mphics")).imagePath;
            img18.ImageLocation = fimg.faculty.Find(x => x.username.Equals("cbbics")).imagePath;
            img19.ImageLocation = fimg.faculty.Find(x => x.username.Equals("dlaics")).imagePath;
            img20.ImageLocation = fimg.faculty.Find(x => x.username.Equals("jwkics")).imagePath;
            img21.ImageLocation = fimg.faculty.Find(x => x.username.Equals("efgics")).imagePath;

            // fac information

            string jsonfinfo = getRestData("/people/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            fimg = JToken.Parse(jsonfinfo).ToObject<facimages>();

            f1.Text = fimg.faculty.Find(x => x.username.Equals("gpavks")).name;
            f2.Text = fimg.faculty.Find(x => x.username.Equals("dlaics")).name;
            f3.Text = fimg.faculty.Find(x => x.username.Equals("ciiics")).name;
            f4.Text = fimg.faculty.Find(x => x.username.Equals("dsbics")).name;
            f5.Text = fimg.faculty.Find(x => x.username.Equals("cbbics")).name;
            f6.Text = fimg.faculty.Find(x => x.username.Equals("mjfics")).name;
            f7.Text = fimg.faculty.Find(x => x.username.Equals("bdfvks")).name;
            f8.Text = fimg.faculty.Find(x => x.username.Equals("efgics")).name;
            f9.Text = fimg.faculty.Find(x => x.username.Equals("jrhicsa")).name;
            f10.Text = fimg.faculty.Find(x => x.username.Equals("vlhics")).name;
            f11.Text = fimg.faculty.Find(x => x.username.Equals("bhhics")).name;
            f12.Text = fimg.faculty.Find(x => x.username.Equals("amhgss")).name;
            f13.Text = fimg.faculty.Find(x => x.username.Equals("lwhfac")).name;
            f14.Text = fimg.faculty.Find(x => x.username.Equals("ephics")).name;
            f15.Text = fimg.faculty.Find(x => x.username.Equals("mphics")).name;
            f16.Text = fimg.faculty.Find(x => x.username.Equals("jwkics")).name;
            f17.Text = fimg.faculty.Find(x => x.username.Equals("drkisd")).name;
            f18.Text = fimg.faculty.Find(x => x.username.Equals("dmlics")).name;
            f19.Text = fimg.faculty.Find(x => x.username.Equals("jalics")).name;
            f20.Text = fimg.faculty.Find(x => x.username.Equals("jalvks")).name;
            f21.Text = fimg.faculty.Find(x => x.username.Equals("phlics")).name;
            f22.Text = fimg.faculty.Find(x => x.username.Equals("spmics")).name;
            f23.Text = fimg.faculty.Find(x => x.username.Equals("mjmics")).name;
            f24.Text = fimg.faculty.Find(x => x.username.Equals("thoics")).name;
            f25.Text = fimg.faculty.Find(x => x.username.Equals("sphics")).name;
            f26.Text = fimg.faculty.Find(x => x.username.Equals("djpihst")).name;
            f27.Text = fimg.faculty.Find(x => x.username.Equals("nxsvks")).name;
            f28.Text = fimg.faculty.Find(x => x.username.Equals("kssics")).name;
            f29.Text = fimg.faculty.Find(x => x.username.Equals("aesfaa")).name;
            f30.Text = fimg.faculty.Find(x => x.username.Equals("bmtski")).name;
            f31.Text = fimg.faculty.Find(x => x.username.Equals("rpvvks")).name;
            f32.Text = fimg.faculty.Find(x => x.username.Equals("emwics")).name;
            f33.Text = fimg.faculty.Find(x => x.username.Equals("qyuvks")).name;
            f34.Text = fimg.faculty.Find(x => x.username.Equals("sjzics")).name;

            // Our People_Staff
            s1.Text = fimg.staff.Find(x => x.username.Equals("rdbcst")).name;
            s2.Text = fimg.staff.Find(x => x.username.Equals("lwb2627")).name;
            s3.Text = fimg.staff.Find(x => x.username.Equals("aacics")).name;
            s4.Text = fimg.staff.Find(x => x.username.Equals("pxg5962")).name;
            s5.Text = fimg.staff.Find(x => x.username.Equals("mchics")).name;
            s6.Text = fimg.staff.Find(x => x.username.Equals("echics")).name;
            s7.Text = fimg.staff.Find(x => x.username.Equals("sxk5664")).name;
            s8.Text = fimg.staff.Find(x => x.username.Equals("tlhdsa")).name;
            s9.Text = fimg.staff.Find(x => x.username.Equals("mdl4959")).name;
            s10.Text = fimg.staff.Find(x => x.username.Equals("krmics")).name;
            s11.Text = fimg.staff.Find(x => x.username.Equals("jmpics")).name;
            s12.Text = fimg.staff.Find(x => x.username.Equals("jssics")).name;
            s13.Text = fimg.staff.Find(x => x.username.Equals("jhsics")).name;


            // COOP Table

            coopview.View = View.Details;//text
            coopview.GridLines = true;
            coopview.FullRowSelect = true;

            coopview.Width = 820;
            coopview.Columns.Add("EMPLOYER", 335);
            coopview.Columns.Add("DEGREE", 235);
            coopview.Columns.Add("CITY", 235);
            coopview.Columns.Add("TERM", 115);

            ListViewItem covi;

            for (var i = 0; i < emp.coopTable.coopInformation.Count; i++)
            {
                covi = new ListViewItem(
                    new string[]{
                      emp.coopTable.coopInformation[i].employer,
                      emp.coopTable.coopInformation[i].degree,
                      emp.coopTable.coopInformation[i].city,
                      emp.coopTable.coopInformation[i].term
                    }
                );
                //append the row
                coopview.Items.Add(covi);
            }

            // for CoOp Table

            empview.View = View.Details;//text
            empview.GridLines = true;
            empview.FullRowSelect = true;

            empview.Width = 820;
            empview.Columns.Add("DEGREE", 175);
            empview.Columns.Add("EMPLOYER", 275);
            empview.Columns.Add("LOCATION", 175);
            empview.Columns.Add("TITLE", 175);
            empview.Columns.Add("START DATE", 120);

            ListViewItem empvi;

            for (var i = 0; i < emp.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                empvi = new ListViewItem(
                    new string[]{
                      emp.employmentTable.professionalEmploymentInformation[i].employer,
                      emp.employmentTable.professionalEmploymentInformation[i].degree,
                      emp.employmentTable.professionalEmploymentInformation[i].city,
                      emp.employmentTable.professionalEmploymentInformation[i].title,
                      emp.employmentTable.professionalEmploymentInformation[i].startDate
                    }
                );
                //append the row
                empview.Items.Add(empvi);
            }

            // Social Presence

            string jsonfoot = getRestData("/footer/");

            //have to return a string jsonAbout into an object
            //ABout Object....
            social = JToken.Parse(jsonfoot).ToObject<socialpresence>();

            os1.Text = social.social.title;
            os2.Text = social.social.tweet;
            os3.Text = social.social.by;
            // Apply now 

            Apply.Text = social.quickLinks[0].title;

            //Footer

            copyright.Text = social.copyright.html;
            foot1.Text = social.quickLinks[0].title;
            foot2.Text = social.quickLinks[1].title;
            foot3.Text = social.quickLinks[2].title;
            foot4.Text = social.quickLinks[3].title;
            GMaap();
        }

        private string getRestData(string url)
        {

            string baseUri = "http://ist.rit.edu/api";

            //connect to the api
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseUri + url);

            try
            {
                WebResponse res = req.GetResponse();
                using (Stream resStream = res.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                // What to do when it all goes wrong
                WebResponse err = ex.Response;

                using (Stream resStream = err.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }
        }
        // Populating Graduate description and concentrations on click of title
        private void rt_grad(object sender, EventArgs e)
        {
            data_grad.Visible = true;
            rt_5.Visible = true;
            data_grad.Rows.Clear();
            var gconcen = (RichTextBox)sender;
            rt_5.Text = grade.graduate.Find(x => x.title.Equals(gconcen.Text)).description;
            var concen = grade.graduate.Find(x => x.title.Equals(gconcen.Text)).concentrations;
            foreach (var gcon in concen)
            {
                string[] row = new string[] { gcon };
                data_grad.Rows.Add(row);
            }        
        }
        private void certificate1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.rit.edu/programs/web-development-adv-cert");
        }

        private void certificate2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.rit.edu/programs/networking-planning-and-design-adv-cert");

        }
        // Populate Undergraduate description and concentrations on click
        private void rtug1(object sender, EventArgs e)
        {
            data_ugrad.Visible = true;
            rtg4.Visible = true;
            data_ugrad.Rows.Clear();
            var ugconcen = (RichTextBox)sender;
            rtg4.Text = UG.undergraduate.Find(x => x.title.Equals(ugconcen.Text)).description;
            var concen = UG.undergraduate.Find(x => x.title.Equals(ugconcen.Text)).concentrations;
            foreach (var con in concen)
            {
                string[] row = new string[] { con };
                data_ugrad.Rows.Add(row);
            }
        }
        // Populate Undergraduate Minors description and courses on click
        private void min_click1(object sender, EventArgs e)
        {
            courseview.Visible = false;
            minview.Items.Clear();
            minview.Visible = true;
            rt_min.Visible = true;
            
            var ugmin = (TextBox)sender;
            rt_min.Text = Ugmin.UgMinors.Find(x => x.title.Equals(ugmin.Text)).description;
            var course = Ugmin.UgMinors.Find(x => x.title.Equals(ugmin.Text)).courses;
            ListViewItem item = null;
            foreach (var con in course)
            {
                item = new ListViewItem(new string[] { con });
                minview.Items.Add(item);
            }
        }

        private void minview_Click(object sender, EventArgs e)
        {
            courseview.Visible = true;
            var cur = minview.Items[minview.FocusedItem.Index].SubItems[0].Text;
            courseview.Text = coursevi.courses.Find(x => x.courseID.Equals(cur)).title + "\r\n" + coursevi.courses.Find(x => x.courseID.Equals(cur)).description;
        }


        // Populating Citations by Interest Area on click of domain title
        private void fclick1(object sender, EventArgs e)
        {
            TextBox fs = (TextBox)sender;            
                minview3.Visible = true;
                minview3.Rows.Clear();
                var areares = (TextBox)sender;
                var concen = yil.byInterestArea.Find(x => x.areaName.Equals(areares.Text)).citations;
                foreach (var con in concen)
                {
                    string[] row = new string[] { con };                 
                    minview3.Rows.Add(row);
                }          
        }

        // Populating Faculty Info on button click
        private void finfo(object sender, EventArgs e)
        {
            fpic.Visible = true;
            z1.Visible = true;
            z2.Visible = true;
            z3.Visible = true;
            z4.Visible = true;
            z5.Visible = true;
            facbox.Visible = true;
            fname.Visible = true;
            ftitle.Visible = true;
            foffice.Visible = true;
            fphone.Visible = true;
            email.Visible = true;
            fname.Text = "Name";
            ftitle.Text = "Title";
            foffice.Text = "Office";
            fphone.Text = "Phone";
            email.Text = "Email";
            Button fs = (Button)sender;

            if (fs.Name == "f1")
            {
                fpic.ImageLocation = fimg.faculty[0].imagePath;
                z1.Text = fimg.faculty[0].name;
                z2.Text = fimg.faculty[0].title;
                z3.Text = fimg.faculty[0].office;
                z4.Text = fimg.faculty[0].phone;
                z5.Text = fimg.faculty[0].email;
            }
            else if (fs.Name == "f2")
            {
                fpic.ImageLocation = fimg.faculty[1].imagePath;
                z1.Text = fimg.faculty[1].name;
                z2.Text = fimg.faculty[1].title;
                z3.Text = fimg.faculty[1].office;
                z4.Text = fimg.faculty[1].phone;
                z5.Text = fimg.faculty[1].email;
            }
            else if (fs.Name == "f3")
            {
                fpic.ImageLocation = fimg.faculty[2].imagePath;
                z1.Text = fimg.faculty[2].name;
                z2.Text = fimg.faculty[2].title;
                z3.Text = fimg.faculty[2].office;
                z4.Text = fimg.faculty[2].phone;
                z5.Text = fimg.faculty[2].email;
            }
            else if (fs.Name == "f4")
            {
                fpic.ImageLocation = fimg.faculty[3].imagePath;
                z1.Text = fimg.faculty[3].name;
                z2.Text = fimg.faculty[3].title;
                z3.Text = fimg.faculty[3].office;
                z4.Text = fimg.faculty[3].phone;
                z5.Text = fimg.faculty[3].email;
            }
            else if (fs.Name == "f5")
            {
                fpic.ImageLocation = fimg.faculty[4].imagePath;
                z1.Text = fimg.faculty[4].name;
                z2.Text = fimg.faculty[4].title;
                z3.Text = fimg.faculty[4].office;
                z4.Text = fimg.faculty[4].phone;
                z5.Text = fimg.faculty[4].email;
            }
            else if (fs.Name == "f6")
            {
                fpic.ImageLocation = fimg.faculty[5].imagePath;
                z1.Text = fimg.faculty[5].name;
                z2.Text = fimg.faculty[5].title;
                z3.Text = fimg.faculty[5].office;
                z4.Text = fimg.faculty[5].phone;
                z5.Text = fimg.faculty[5].email;
            }
            else if (fs.Name == "f7")
            {
                fpic.ImageLocation = fimg.faculty[6].imagePath;
                z1.Text = fimg.faculty[6].name;
                z2.Text = fimg.faculty[6].title;
                z3.Text = fimg.faculty[6].office;
                z4.Text = fimg.faculty[6].phone;
                z5.Text = fimg.faculty[6].email;
            }
            else if (fs.Name == "f8")
            {
                fpic.ImageLocation = fimg.faculty[7].imagePath;
                z1.Text = fimg.faculty[7].name;
                z2.Text = fimg.faculty[7].title;
                z3.Text = fimg.faculty[7].office;
                z4.Text = fimg.faculty[7].phone;
                z5.Text = fimg.faculty[7].email;
            }
            else if (fs.Name == "f9")
            {
                fpic.ImageLocation = fimg.faculty[8].imagePath;
                z1.Text = fimg.faculty[8].name;
                z2.Text = fimg.faculty[8].title;
                z3.Text = fimg.faculty[8].office;
                z4.Text = fimg.faculty[8].phone;
                z5.Text = fimg.faculty[8].email;
            }
            else if (fs.Name == "f10")
            {
                fpic.ImageLocation = fimg.faculty[1].imagePath;
                z1.Text = fimg.faculty[9].name;
                z2.Text = fimg.faculty[9].title;
                z3.Text = fimg.faculty[9].office;
                z4.Text = fimg.faculty[9].phone;
                z5.Text = fimg.faculty[9].email;
            }
            else if (fs.Name == "f11")
            {
                fpic.ImageLocation = fimg.faculty[10].imagePath;
                z1.Text = fimg.faculty[10].name;
                z2.Text = fimg.faculty[10].title;
                z3.Text = fimg.faculty[10].office;
                z4.Text = fimg.faculty[10].phone;
                z5.Text = fimg.faculty[10].email;
            }
            else if (fs.Name == "f12")
            {
                fpic.ImageLocation = fimg.faculty[11].imagePath;
                z1.Text = fimg.faculty[11].name;
                z2.Text = fimg.faculty[11].title;
                z3.Text = fimg.faculty[11].office;
                z4.Text = fimg.faculty[11].phone;
                z5.Text = fimg.faculty[11].email;
            }
            else if (fs.Name == "f13")
            {
                fpic.ImageLocation = fimg.faculty[12].imagePath;
                z1.Text = fimg.faculty[12].name;
                z2.Text = fimg.faculty[12].title;
                z3.Text = fimg.faculty[12].office;
                z4.Text = fimg.faculty[12].phone;
                z5.Text = fimg.faculty[12].email;
            }
            else if (fs.Name == "f14")
            {
                fpic.ImageLocation = fimg.faculty[13].imagePath;
                z1.Text = fimg.faculty[13].name;
                z2.Text = fimg.faculty[13].title;
                z3.Text = fimg.faculty[13].office;
                z4.Text = fimg.faculty[13].phone;
                z5.Text = fimg.faculty[13].email;
            }
            else if (fs.Name == "f15")
            {
                fpic.ImageLocation = fimg.faculty[14].imagePath;
                z1.Text = fimg.faculty[14].name;
                z2.Text = fimg.faculty[14].title;
                z3.Text = fimg.faculty[14].office;
                z4.Text = fimg.faculty[14].phone;
                z5.Text = fimg.faculty[14].email;
            }
            else if (fs.Name == "f16")
            {
                fpic.ImageLocation = fimg.faculty[15].imagePath;
                z1.Text = fimg.faculty[15].name;
                z2.Text = fimg.faculty[15].title;
                z3.Text = fimg.faculty[15].office;
                z4.Text = fimg.faculty[15].phone;
                z5.Text = fimg.faculty[15].email;
            }
            else if (fs.Name == "f17")
            {
                fpic.ImageLocation = fimg.faculty[16].imagePath;
                z1.Text = fimg.faculty[16].name;
                z2.Text = fimg.faculty[16].title;
                z3.Text = fimg.faculty[16].office;
                z4.Text = fimg.faculty[16].phone;
                z5.Text = fimg.faculty[16].email;
            }
            else if (fs.Name == "f18")
            {
                fpic.ImageLocation = fimg.faculty[17].imagePath;
                z1.Text = fimg.faculty[17].name;
                z2.Text = fimg.faculty[17].title;
                z3.Text = fimg.faculty[17].office;
                z4.Text = fimg.faculty[17].phone;
                z5.Text = fimg.faculty[17].email;
            }
            else if (fs.Name == "f19")
            {
                fpic.ImageLocation = fimg.faculty[18].imagePath;
                z1.Text = fimg.faculty[18].name;
                z2.Text = fimg.faculty[18].title;
                z3.Text = fimg.faculty[18].office;
                z4.Text = fimg.faculty[18].phone;
                z5.Text = fimg.faculty[18].email;
            }
            else if (fs.Name == "f20")
            {
                fpic.ImageLocation = fimg.faculty[19].imagePath;
                z1.Text = fimg.faculty[19].name;
                z2.Text = fimg.faculty[19].title;
                z3.Text = fimg.faculty[19].office;
                z4.Text = fimg.faculty[19].phone;
                z5.Text = fimg.faculty[19].email;
            }
            else if (fs.Name == "f21")
            {
                fpic.ImageLocation = fimg.faculty[20].imagePath;
                z1.Text = fimg.faculty[20].name;
                z2.Text = fimg.faculty[20].title;
                z3.Text = fimg.faculty[20].office;
                z4.Text = fimg.faculty[20].phone;
                z5.Text = fimg.faculty[20].email;
            }
            else if (fs.Name == "f22")
            {
                fpic.ImageLocation = fimg.faculty[21].imagePath;
                z1.Text = fimg.faculty[21].name;
                z2.Text = fimg.faculty[21].title;
                z3.Text = fimg.faculty[21].office;
                z4.Text = fimg.faculty[21].phone;
                z5.Text = fimg.faculty[21].email;
            }
            else if (fs.Name == "f23")
            {
                fpic.ImageLocation = fimg.faculty[22].imagePath;
                z1.Text = fimg.faculty[22].name;
                z2.Text = fimg.faculty[22].title;
                z3.Text = fimg.faculty[22].office;
                z4.Text = fimg.faculty[22].phone;
                z5.Text = fimg.faculty[22].email;
            }
            else if (fs.Name == "f24")
            {
                fpic.ImageLocation = fimg.faculty[23].imagePath;
                z1.Text = fimg.faculty[23].name;
                z2.Text = fimg.faculty[23].title;
                z3.Text = fimg.faculty[23].office;
                z4.Text = fimg.faculty[23].phone;
                z5.Text = fimg.faculty[23].email;
            }
            else if (fs.Name == "f25")
            {
                fpic.ImageLocation = fimg.faculty[24].imagePath;
                z1.Text = fimg.faculty[24].name;
                z2.Text = fimg.faculty[24].title;
                z3.Text = fimg.faculty[24].office;
                z4.Text = fimg.faculty[24].phone;
                z5.Text = fimg.faculty[24].email;
            }
            else if (fs.Name == "f26")
            {
                fpic.ImageLocation = fimg.faculty[25].imagePath;
                z1.Text = fimg.faculty[25].name;
                z2.Text = fimg.faculty[25].title;
                z3.Text = fimg.faculty[25].office;
                z4.Text = fimg.faculty[25].phone;
                z5.Text = fimg.faculty[25].email;
            }
            else if (fs.Name == "f27")
            {
                fpic.ImageLocation = fimg.faculty[26].imagePath;
                z1.Text = fimg.faculty[26].name;
                z2.Text = fimg.faculty[26].title;
                z3.Text = fimg.faculty[26].office;
                z4.Text = fimg.faculty[26].phone;
                z5.Text = fimg.faculty[26].email;
            }
            else if (fs.Name == "f28")
            {
                fpic.ImageLocation = fimg.faculty[27].imagePath;
                z1.Text = fimg.faculty[27].name;
                z2.Text = fimg.faculty[27].title;
                z3.Text = fimg.faculty[27].office;
                z4.Text = fimg.faculty[27].phone;
                z5.Text = fimg.faculty[27].email;
            }
            else if (fs.Name == "f29")
            {
                fpic.ImageLocation = fimg.faculty[28].imagePath;
                z1.Text = fimg.faculty[28].name;
                z2.Text = fimg.faculty[28].title;
                z3.Text = fimg.faculty[28].office;
                z4.Text = fimg.faculty[28].phone;
                z5.Text = fimg.faculty[28].email;
            }
            else if (fs.Name == "f30")
            {
                fpic.ImageLocation = fimg.faculty[29].imagePath;
                z1.Text = fimg.faculty[29].name;
                z2.Text = fimg.faculty[29].title;
                z3.Text = fimg.faculty[29].office;
                z4.Text = fimg.faculty[29].phone;
                z5.Text = fimg.faculty[29].email;
            }
            else if (fs.Name == "f31")
            {
                fpic.ImageLocation = fimg.faculty[30].imagePath;
                z1.Text = fimg.faculty[30].name;
                z2.Text = fimg.faculty[30].title;
                z3.Text = fimg.faculty[30].office;
                z4.Text = fimg.faculty[30].phone;
                z5.Text = fimg.faculty[30].email;
            }
            else if (fs.Name == "f32")
            {
                fpic.ImageLocation = fimg.faculty[31].imagePath;
                z1.Text = fimg.faculty[31].name;
                z2.Text = fimg.faculty[31].title;
                z3.Text = fimg.faculty[31].office;
                z4.Text = fimg.faculty[31].phone;
                z5.Text = fimg.faculty[31].email;
            }
            else if (fs.Name == "f33")
            {
                fpic.ImageLocation = fimg.faculty[32].imagePath;
                z1.Text = fimg.faculty[32].name;
                z2.Text = fimg.faculty[32].title;
                z3.Text = fimg.faculty[32].office;
                z4.Text = fimg.faculty[32].phone;
                z5.Text = fimg.faculty[32].email;
            }
            else if (fs.Name == "f34")
            {
                fpic.ImageLocation = fimg.faculty[33].imagePath;
                z1.Text = fimg.faculty[33].name;
                z2.Text = fimg.faculty[33].title;
                z3.Text = fimg.faculty[33].office;
                z4.Text = fimg.faculty[33].phone;
                z5.Text = fimg.faculty[33].email;
            }
        }

        // Populating Staff  Info on button click
        private void sclick(object sender, EventArgs e)
        {
            spic.Visible = true;
            sname.Visible = true;
            stitle.Visible = true;
            soffice.Visible = true;
            sphone.Visible = true;
            semail.Visible = true;
            l1.Visible = true;
            sbox.Visible = true;
            l1.Text = "Name";
            l2.Text = "Title";
            l3.Text = "Office";
            l4.Text = "Phone";
            l5.Text = "Email";

            Button fs = (Button)sender;

            if (fs.Name == "s1")
            {
                spic.ImageLocation = fimg.staff[0].imagePath;
                sname.Text = fimg.staff[0].name;
                stitle.Text = fimg.staff[0].title;
                soffice.Text = fimg.staff[0].office;
                sphone.Text = fimg.staff[0].phone;
                semail.Text = fimg.staff[0].email;
            }
            else if (fs.Name == "s2")
            {
                spic.ImageLocation = fimg.staff[1].imagePath;
                sname.Text = fimg.staff[1].name;
                stitle.Text = fimg.staff[1].title;
                soffice.Text = fimg.staff[1].office;
                sphone.Text = fimg.staff[1].phone;
                semail.Text = fimg.staff[1].email;
            }
            else if (fs.Name == "s3")
            {
                spic.ImageLocation = fimg.staff[2].imagePath;
                sname.Text = fimg.staff[2].name;
                stitle.Text = fimg.staff[2].title;
                soffice.Text = fimg.staff[2].office;
                sphone.Text = fimg.staff[2].phone;
                semail.Text = fimg.staff[2].email;
            }
            else if (fs.Name == "s4")
            {
                spic.ImageLocation = fimg.staff[3].imagePath;
                sname.Text = fimg.staff[3].name;
                stitle.Text = fimg.staff[3].title;
                soffice.Text = fimg.staff[3].office;
                sphone.Text = fimg.staff[3].phone;
                semail.Text = fimg.staff[3].email;
            }
            else if (fs.Name == "s5")
            {
                spic.ImageLocation = fimg.staff[4].imagePath;
                sname.Text = fimg.staff[4].name;
                stitle.Text = fimg.staff[4].title;
                soffice.Text = fimg.staff[4].office;
                sphone.Text = fimg.staff[4].phone;
                semail.Text = fimg.staff[4].email;
            }
            else if (fs.Name == "s6")
            {
                spic.ImageLocation = fimg.staff[5].imagePath;
                sname.Text = fimg.staff[5].name;
                stitle.Text = fimg.staff[5].title;
                soffice.Text = fimg.staff[5].office;
                sphone.Text = fimg.staff[5].phone;
                semail.Text = fimg.staff[5].email;
            }
            else if (fs.Name == "s7")
            {
                spic.ImageLocation = fimg.staff[6].imagePath;
                sname.Text = fimg.staff[6].name;
                stitle.Text = fimg.staff[6].title;
                soffice.Text = fimg.staff[6].office;
                sphone.Text = fimg.staff[6].phone;
                semail.Text = fimg.staff[6].email;
            }
            else if (fs.Name == "s8")
            {
                spic.ImageLocation = fimg.staff[7].imagePath;
                sname.Text = fimg.staff[7].name;
                stitle.Text = fimg.staff[7].title;
                soffice.Text = fimg.staff[7].office;
                sphone.Text = fimg.staff[7].phone;
                semail.Text = fimg.staff[7].email;
            }
            else if (fs.Name == "s9")
            {
                spic.ImageLocation = fimg.staff[8].imagePath;
                sname.Text = fimg.staff[8].name;
                stitle.Text = fimg.staff[8].title;
                soffice.Text = fimg.staff[8].office;
                sphone.Text = fimg.staff[8].phone;
                semail.Text = fimg.staff[8].email;
            }
            else if (fs.Name == "s10")
            {
                spic.ImageLocation = fimg.staff[1].imagePath;
                sname.Text = fimg.staff[9].name;
                stitle.Text = fimg.staff[9].title;
                soffice.Text = fimg.staff[9].office;
                sphone.Text = fimg.staff[9].phone;
                semail.Text = fimg.staff[9].email;
            }
            else if (fs.Name == "s11")
            {
                spic.ImageLocation = fimg.staff[10].imagePath;
                sname.Text = fimg.staff[10].name;
                stitle.Text = fimg.staff[10].title;
                soffice.Text = fimg.staff[10].office;
                sphone.Text = fimg.staff[10].phone;
                semail.Text = fimg.staff[10].email;
            }
            else if (fs.Name == "s12")
            {
                spic.ImageLocation = fimg.staff[11].imagePath;
                sname.Text = fimg.staff[11].name;
                stitle.Text = fimg.staff[11].title;
                soffice.Text = fimg.staff[11].office;
                sphone.Text = fimg.staff[11].phone;
                semail.Text = fimg.staff[11].email;
            }
            else if (fs.Name == "s13")
            {
                spic.ImageLocation = fimg.staff[12].imagePath;
                sname.Text = fimg.staff[12].name;
                stitle.Text = fimg.staff[12].title;
                soffice.Text = fimg.staff[12].office;
                sphone.Text = fimg.staff[12].phone;
                semail.Text = fimg.staff[12].email;
            }
        }
        // Populating multiple links on button click_Social Presence
        private void twitter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(social.social.facebook);
        }

        private void fb(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(social.social.twitter);
        }

        private void applynow(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(social.quickLinks[0].href);
        }

        private void clickfoot(object sender, EventArgs e)
        {

            Button fs = (Button)sender;

            if (fs.Name == "foot1")
            {
                System.Diagnostics.Process.Start(social.quickLinks[0].href);
            }
            else if (fs.Name == "foot2")
            {
                System.Diagnostics.Process.Start(social.quickLinks[1].href);
            }
            else if (fs.Name == "foot3")
            {
                System.Diagnostics.Process.Start(social.quickLinks[2].href);
            }
            else if (fs.Name == "foot4")
            {
                System.Diagnostics.Process.Start(social.quickLinks[3].href);
            }
            else if (fs.Name == "foot5")
            {
                System.Diagnostics.Process.Start("https://ist.rit.edu/manage/index.php");
            }
            else if (fs.Name == "foot6")
            {
                System.Diagnostics.Process.Start(social.news);
            }

        }

        // Populating Google Maps

        public void GMaap()
        {
            maploca.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            //logitude ,latitude positioning
            maploca.Position = new GMap.NET.PointLatLng(37.972753, -95.681656);
            maploca.ShowCenter = false;
            // setting marker at a location
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (var locat in maps_loc.maplo)
            {
                GMapMarker marker = new GMarkerGoogle(
                    new PointLatLng(Convert.ToDouble(locat.latitude), Convert.ToDouble(locat.longitude)),
                    GMarkerGoogleType.green_pushpin);
                //  tooltip settings for markers
                marker.ToolTipText = locat.city + " " + locat.state;
                marker.ToolTip.Fill = Brushes.White;
                marker.ToolTip.Foreground = Brushes.Black;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(5, 4);
           // Add created markers to overlays
                markers.Markers.Add(marker);
            }
            //add overlays on the google maps
            maploca.Overlays.Add(markers);

        }

        // Populating Citations By Faculty on click 
        private void facre(object sender, EventArgs e)
        {
            PictureBox fs = (PictureBox)sender;
            if (fs.Name == "img1")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("bmtski")).citations;
                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img2")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("emwics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img3")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("qyuvks")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img4")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("sjzics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img5")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("ciiics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img6")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("dsbics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img7")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("bhhics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img8")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("spmics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img9")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("thoics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img10")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("nxsvks")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img11")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("ephics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img12")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("mjfics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img13")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("vlhics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img14")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("lwhfac")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img15")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("dmlics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img16")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("rpvvks")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img17")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("mphics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img18")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("cbbics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img19")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("dlaics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img20")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("jwkics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }
            else if (fs.Name == "img21")
            {
                var fare = yil.byFaculty.Find(x => x.username.Equals("efgics")).citations;

                minview4.Rows.Clear();
                foreach (string con in fare)
                {
                    string[] row = new string[] { con };
                    minview4.Rows.Add(row);
                }
                minview4.Visible = true;
            }


        }

        // Tutors and Lab Informmation Section
        private void tutor(object sender, EventArgs e)
        {         
            n2.Visible = false;
            n3.Visible = false;
            n4.Visible = false;
            n5.Visible = false;
            n6.Visible = false;
            n7.Visible = false;
            n8.Visible = false;
            abroad.Visible = false;
            g1.Visible = false;
            g2.Visible = false;
            g.Visible = false;
            cvi.Visible = false;
            coopen.Visible = false;
            forms.Visible = false;
            tb.Visible = true;
            lh.Visible = true;
            srtext.Visible = true;
            srview.Visible = true;
            srtext.Text = resourcess.tutorsAndLabInformation.title;
            srview.Text = resourcess.tutorsAndLabInformation.description;
        }

        private void lhview(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(resourcess.tutorsAndLabInformation.tutoringLabHoursLink);
        }

        // Populating links of Multiple Forms
        private void form(object sender, EventArgs e)
        {        
            n2.Visible = false;
            n3.Visible = false;
            n4.Visible = false;
            n5.Visible = false;
            n6.Visible = false;
            n7.Visible = false;
            n8.Visible = false;
            coopen.Visible = false;
            abroad.Visible = false;
            g1.Visible = false;
            g2.Visible = false;
            g.Visible = false;
            forms.Visible = false;
            tb.Visible = false;
            cvi.Visible = false;
            lh.Visible = false;
            srtext.Visible = false;
            srview.Visible = false;
            coopen.Visible = false;
            forms.Visible = true;
            forms.View = View.Details;//text
            forms.GridLines = true;
            forms.FullRowSelect = true;
            forms.Clear();
            forms.Columns.Add("FormName", 235);
            forms.Columns.Add("href", 235);
            ListViewItem fovi;
            for (var i = 0; i < resourcess.forms.graduateForms.Count; i++)
            {
                fovi = new ListViewItem(
                    new string[]{
                      resourcess.forms.graduateForms[i].formName,
                      resourcess.forms.graduateForms[i].href
                    }
                );
                //append the row
                forms.Items.Add(fovi);
            }
        }

        private void formclick(object sender, EventArgs e)
        {
            var fom = forms.Items[forms.FocusedItem.Index].SubItems[0].Text;
            System.Diagnostics.Process.Start("http://ist.rit.edu/" + resourcess.forms.graduateForms.Find(x => x.formName.Equals(fom)).href);
        }

        // Co op Enrollment Section
        private void coenroll(object sender, EventArgs e)
        {       
            n2.Visible = false;
            n3.Visible = false;
            n4.Visible = false;
            n5.Visible = false;
            n6.Visible = false;
            n7.Visible = false;
            n8.Visible = false;
            abroad.Visible = false;
            g1.Visible = false;
            g2.Visible = false;
            g.Visible = false;
            forms.Visible = false;
            tb.Visible = false;
            cvi.Visible = false;
            lh.Visible = false;
            srtext.Visible = false;
            srview.Visible = false;
            coopen.Visible = true;
            coopen.Clear();
            coopen.Columns.Add("title", 205);
            coopen.Columns.Add("description", 935);
            ListViewItem fovi;
            for (var i = 0; i < resourcess.coopEnrollment.enrollmentInformationContent.Count; i++)
            {
                fovi = new ListViewItem(
                    new string[]{
                      resourcess.coopEnrollment.enrollmentInformationContent[i].title,
                      resourcess.coopEnrollment.enrollmentInformationContent[i].description
                    }
                );
                //append the row
                coopen.Items.Add(fovi);
            }
        }

        // Section on Student Ambassador
        private void embass(object sender, EventArgs e)
        {
            n2.Visible = false;
            n3.Visible = false;
            n4.Visible = false;
            n5.Visible = false;
            n6.Visible = false;
            n7.Visible = false;
            n8.Visible = false;
            abroad.Visible = false;
            g1.Visible = false;
            g2.Visible = false;
            g.Visible = false;
            coopen.Visible = false;
            forms.Visible = false;
            tb.Visible = false;
            lh.Visible = false;
            srtext.Visible = false;
            srview.Visible = false;
            cvi.Visible = true;
            cvi.Clear();
            cvi.Columns.Add("title", 205);
            cvi.Columns.Add("description", 935);
            ListViewItem fovi;
            for (var i = 0; i < resourcess.studentAmbassadors.subSectionContent.Count; i++)
            {
                fovi = new ListViewItem(
                    new string[]{
                      resourcess.studentAmbassadors.subSectionContent[i].title,
                      resourcess.studentAmbassadors.subSectionContent[i].description
                    }
                );
                //append the row
                cvi.Items.Add(fovi);
            }
        }

        // Section on Study Abroad
        private void abr(object sender, EventArgs e)
        {        
            n2.Visible = false;
            n3.Visible = false;
            n4.Visible = false;
            n5.Visible = false;
            n6.Visible = false;
            n7.Visible = false;
            n8.Visible = false;
            coopen.Visible = false;
            forms.Visible = false;
            tb.Visible = false;
            lh.Visible = false;
            srtext.Visible = false;
            srview.Visible = false;
            cvi.Visible = false;
            abroad.Visible = true;
            g1.Visible = true;
            g2.Visible = true;
            g.Visible = true;
            abroad.Clear();
            abroad.Columns.Add("nameOfPlace", 205);
            abroad.Columns.Add("description", 935);
            g2.Text = resourcess.studyAbroad.description;
            g1.Text = resourcess.studyAbroad.title;
           ListViewItem fovi;
            for (var i = 0; i < resourcess.studyAbroad.places.Count; i++)
            {
                fovi = new ListViewItem(
                    new string[]{
                       resourcess.studyAbroad.places[i].nameOfPlace,
                       resourcess.studyAbroad.places[i].description
                    }
                );
                //append the row
                abroad.Items.Add(fovi);
            }
        }

        // Section on Multiple Advising
        private void services(object sender, EventArgs e)
        {
            n2.Text = resourcess.studentServices.academicAdvisors.title;
            n3.Text = resourcess.studentServices.academicAdvisors.description;
            n5.Text = resourcess.studentServices.professonalAdvisors.title;
            n7.Text = resourcess.studentServices.istMinorAdvising.title;
            coopen.Visible = false;
            forms.Visible = false;
            tb.Visible = false;
            lh.Visible = false;
            srtext.Visible = false;
            srview.Visible = false;
            cvi.Visible = false;
            abroad.Visible = false;
            g1.Visible = false;
            g2.Visible = false;
            g.Visible = false;
            n2.Visible = true;
            n3.Visible = true;
            n4.Visible = true;
            n5.Visible = true;
            n6.Visible = true;
            n7.Visible = true;
            n8.Visible = true;
            n8.Clear();
            n6.Clear();
            n6.Columns.Add("name", 105);
            n6.Columns.Add("department",155);
            n6.Columns.Add("email", 100);
            n8.Columns.Add("title", 205);
            n8.Columns.Add("advisor", 105);
            n8.Columns.Add("email", 100);
            ListViewItem fovi;
            for (var i = 0; i < resourcess.studentServices.professonalAdvisors.advisorInformation.Count; i++)
            {
                fovi = new ListViewItem(
                    new string[]{
                       resourcess.studentServices.professonalAdvisors.advisorInformation[i].name,
                       resourcess.studentServices.professonalAdvisors.advisorInformation[i].department,
                       resourcess.studentServices.professonalAdvisors.advisorInformation[i].email
                    }
                );
                //append the row
                n6.Items.Add(fovi);
                ListViewItem zovi;
                for (var j = 0; j < resourcess.studentServices.istMinorAdvising.minorAdvisorInformation.Count; j++)
                {
                    zovi = new ListViewItem(
                        new string[]{
                      resourcess.studentServices.istMinorAdvising.minorAdvisorInformation[j].title,
                      resourcess.studentServices.istMinorAdvising.minorAdvisorInformation[j].advisor,
                      resourcess.studentServices.istMinorAdvising.minorAdvisorInformation[j].email
                        }
                    );
                    //append the row
                    n8.Items.Add(zovi);
                }

            }
        }
        private void n4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(resourcess.studentServices.academicAdvisors.faq.contentHref);
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEğitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbguide.DisplayMember = "FullName";
            cmbguide.ValueMember = "GuideId";
            cmbguide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capactiy = byte.Parse(nudcapacity.Value.ToString());
            location.City = txtcity.Text;
            location.Country = txtcountry.Text;
            location.Price = decimal.Parse(txtprice.Text);
            location.DayNight = txtnightday.Text;
            location.GuideId = int.Parse(cmbguide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLokasyonID.Text);
            var deletedValues = db.Location.Find(id);
            db.Location.Remove(deletedValues);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnGetBy_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLokasyonID.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.DayNight = txtnightday.Text;
            updatedValue.Price = decimal.Parse(txtprice.Text);
            updatedValue.Capactiy=byte.Parse(nudcapacity.Value.ToString());
            updatedValue.City = txtcity.Text;
            updatedValue.Country = txtcountry.Text;
            updatedValue.GuideId = int.Parse(cmbguide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı");
        }
    }
}

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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lbllocationcount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capactiy).ToString();
            lblGuideCount.Text = db.Location.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.Capactiy).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price)?.ToString("0.00") + " ₺";

            int lastcountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastcountryId).Select(y => y.Country).FirstOrDefault();
            lblCappadocialLocationCapacity.Text = db.Location.Where(x=>x.City== "Kapadokya").Select(y=>y.Capactiy).FirstOrDefault().ToString();

            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capactiy).ToString();

            var romeGuideId = db.Location.Where(x =>x.City == "Roma Turistlik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text =db.Guide.Where(x =>x.GuideId==romeGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.Capactiy);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capactiy == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.Location.Where(x=>x.GuideId==guideIdByNameAysegulCinar).Count().ToString();
        }
    }
}
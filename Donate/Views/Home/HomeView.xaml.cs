using Donate.Domain;
using Donate.Services;
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

namespace Donate.Views.Home
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        #region Variables, Ctor

        private readonly IDonateService donateService;

        public HomeView()
        {
            InitializeComponent();
            donateService = new DonateService();
            ClearForm();
            FillDataGrid();
        }
        #endregion

        private void SaveDonorInformation()
        {
            var addDonorInfo = new DonorInfo
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                City = txtCity.Text,
                ContactNumber = Convert.ToInt32(txtContactNumber.Text),
                BloodGroup = txtBloodGroup.Text,
                DischargeDate = Convert.ToDateTime(dtDischargeDate.Text),
                DonationDetails = new List<DonationDetails>
                {
                    new DonationDetails
                    {
                    }
                }
            };

            donateService.AddDonorInfo(addDonorInfo);
            if (addDonorInfo.HasError)
                MessageBox.Show(addDonorInfo.ErrorMessage);
            else
            {
                MessageBox.Show("Donor's Information Saved");
            }
        }
        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgrDonate.SelectedItem == null) return;

            dgrDonate.CurrentItem = dgrDonate.CurrentItem.ToString() == "No" ? "Yes" : "No";
        }
        private void btnSubmitDonorDetails(object sender, RoutedEventArgs e)
        {
            SaveDonorInformation();
            ClearForm();
            FillDataGrid();
        }
        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(((Button)sender).CommandParameter);
            var donor = donateService.GetDonorInfoById(Id);
            if (Id != null)
            {
                txtId.Text = Id.ToString();
                txtName.Text = donor.Id.ToString();
                txtCity.Text = donor.City.ToString();
                txtContactNumber.Text = donor.ContactNumber.ToString();
                txtBloodGroup.Text = donor.BloodGroup.ToString();
                dtDischargeDate.Text = donor.DischargeDate.ToString();
            }
        }
        private void btnDelete(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(((Button)sender).CommandParameter);
            donateService.DeleteDonorInfo(Id);
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            var x = donateService.GetAllDonorsInfo();
            for (int i=0; i<x.Count; i++)
            {
                
            }

            dgrDonate.ItemsSource = donateService.GetAllDonorsInfo();
            //var data = donateService.GetAllDonorsInfo().ToList();
            
            //for(int i=0; i<data.Count()-1; i++)
            //{
            //    DonorInfo donor = new DonorInfo();
            //    donor.City = data.ToList()[i].City;
            //    donor.BloodGroup = data.ToList()[i].BloodGroup;
            //    donor.Name = data.ToList()[i].Name;
            //    donor.ContactNumber = data.ToList()[i].ContactNumber;
            //    donor.DonationDetails = data.ToList()[i].DonationDetails.ToList();

            //    //donation.IsAvailable = data.DonationDetails.Where(a => a.IsAvailable).Where(a => a.IsAvailable == true) ? data.ToList()[i]."Yes"; : data.ToList()[i]"NO";

            //}
        }
        private void txtSearchCity_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtSearchCity.Text == "")
            {
                FillDataGrid();
            }
            else
            {
                var filtered = donateService.GetAllDonorsInfo().Where(a => a.City == (txtSearchCity.Text)).ToList();
                dgrDonate.ItemsSource = filtered;
            }
        }
        private void ClearForm()
        {
            txtSearchCity.Text = string.Empty;
            txtName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtBloodGroup.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
        }
        private void btnAbout_OnClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("../Views/About/AboutView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}

﻿using BussinessObject.Models;
using Microsoft.IdentityModel.Tokens;
using Repositories.Repositories.CarInformationRepository;
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
using System.Windows.Shapes;

namespace CarRentingManagermentWPF.CarWPF
{
    /// <summary>
    /// Interaction logic for CarEdit.xaml
    /// </summary>
    public partial class CarEdit : Window
    {
        CarManagerment _carmanagerment;


        public CarEdit(CarManagerment carManagerment, CarInformation carInformation)
        {
            InitializeComponent();
            _carmanagerment = carManagerment;
            LoadData(carInformation);

        }

        public void LoadData(CarInformation carInformation)
        {
            try
            {
                if (carInformation != null)
                {
                    tbCarId.Text = carInformation.CarId.ToString();
                    tbCarName.Text = carInformation?.CarName.ToString();
                    tbCarDescription.Text = carInformation?.CarDescription?.ToString();
                    tbNumberOfDoors.Text = carInformation?.NumberOfDoors.ToString();
                    tbSeatingCapacity.Text = carInformation?.SeatingCapacity.ToString();
                    tbFuelType.Text = carInformation?.FuelType?.ToString();
                    tbYear.Text = carInformation?.Year.ToString();
                    tbManufacturerId.Text = carInformation?.ManufacturerId.ToString();
                    tbSupplierId.Text = carInformation?.SupplierId.ToString();
                    tbCarStatus.Text = carInformation?.CarStatus.ToString();
                    tbCarRentingPricePerDay.Text = carInformation?.CarRentingPricePerDay?.ToString();

                }


            }
            catch (Exception)
            {
                System.Diagnostics.Trace.Write("Hello via Trace!");
                return;
            }
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int carId = Int32.Parse(tbCarId.Text);
            string carName;
            if (!tbCarName.Text.IsNullOrEmpty())
            {
                carName = tbCarName.Text;
            }
            else
            {
                MessageBox.Show("Name is required");
                return;
            }

            string carDescription = "";
            if (!tbCarDescription.Text.IsNullOrEmpty()) carDescription = tbCarDescription.Text;
            int numberOfDoors = 0;
            if (!tbNumberOfDoors.Text.IsNullOrEmpty())
            {
                try
                {
                    numberOfDoors = Int32.Parse(tbNumberOfDoors.Text);
                }
                catch
                {
                    MessageBox.Show("Number Of Doors wrong format");
                    return;
                }
            }

            int seatingCapacity = 0;
            if (!tbSeatingCapacity.Text.IsNullOrEmpty())
            {
                try
                {
                    seatingCapacity = Int32.Parse(tbSeatingCapacity.Text);
                }
                catch
                {
                    MessageBox.Show("Seating Capacity wrong format");
                    return;
                }
            }

            string fuelType = "";
            if (!tbFuelType.Text.IsNullOrEmpty())
            {
                fuelType = tbFuelType.Text;
            }

            int year = 0;
            if (!tbYear.Text.IsNullOrEmpty())
            {
                try
                {
                    year = Int32.Parse(tbYear.Text);
                }
                catch
                {
                    MessageBox.Show("Year wrong format");
                    return;
                }
            }

            int manufacturerId = 0;
            if (!tbManufacturerId.Text.IsNullOrEmpty())
            {
                try
                {
                    manufacturerId = Int32.Parse(tbManufacturerId.Text);
                }
                catch
                {
                    MessageBox.Show("Manufacturer Id wrong format");
                    return;
                }
            }

            int supplierId = 0;
            if (!tbSupplierId.Text.IsNullOrEmpty())
            {
                try
                {
                    supplierId = Int32.Parse(tbSupplierId.Text);
                }
                catch
                {
                    MessageBox.Show("Supplier Id wrong format");
                    return;
                }
            }

            byte carStatus = 0;
            if (!tbCarStatus.Text.IsNullOrEmpty())
            {
                try
                {
                    carStatus = Byte.Parse(tbCarStatus.Text);
                }
                catch
                {
                    MessageBox.Show("Car Status wrong format");
                    return;
                }
            }

            decimal carRentingPricePerDay = 0;
            if (!tbCarRentingPricePerDay.Text.IsNullOrEmpty())
            {
                try
                {
                    carRentingPricePerDay = Decimal.Parse(tbCarRentingPricePerDay.Text);
                }
                catch
                {
                    MessageBox.Show("Car Renting Price Per Day wrong format");
                    return;
                }

            }

            CarInformation carInformation = new CarInformation();
            carInformation.CarId = carId;
            carInformation.CarName = carName;
            carInformation.CarDescription = carDescription;
            carInformation.NumberOfDoors = numberOfDoors;
            carInformation.SeatingCapacity = seatingCapacity;
            carInformation.FuelType = fuelType;
            carInformation.Year = year;
            carInformation.ManufacturerId = manufacturerId;
            carInformation.SupplierId = supplierId;
            carInformation.CarStatus = carStatus;
            carInformation.CarRentingPricePerDay = carRentingPricePerDay;

            ((Repositories.Repositories.IGenericRepository<CarInformation>)CarInformationRepository.Instance).Update(carInformation);
            this.Close();
            _carmanagerment.LoadData();

        }

       

       
    }
}

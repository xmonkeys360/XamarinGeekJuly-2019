using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEssentialsDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            this.GetEssentialsList();
            this.GetAppInformation();
            this.GetBatteryInformation();
            this.GetDisplayInformation();
            this.GetDeviceInformation();
        }
        private ObservableCollection<string> essentials;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name="")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<string> Essentials
        {
            get { return essentials; }
            set
            {
                this.essentials = value;
            }
        }

        public string AppName { get; set; }
        public string PackageName { get; set; }
        public string VersionString { get; set; }
        public string Version { get; set; }
        public string BuildString { get; set; }

        private double chargeLevel;
        public double ChargeLevel
        {
            get { return chargeLevel; }
            set { this.chargeLevel = value; OnPropertyChanged(); }
        }
        public string EnergySaverStatus { get; set; }
        private string state;
        public string State
        {
            get { return state; }
            set { this.state = value; OnPropertyChanged(); }
        }
        public string PowerSource { get; set; }

        public double Density { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Orientation { get; set; }

        public string DeviceType { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }

        private void GetEssentialsList()
        {
            if (this.Essentials == null)
                this.Essentials = new ObservableCollection<string>();
            this.Essentials.Add(Constants.APP_INFORMATION);
            this.Essentials.Add(Constants.BATTERY_INFORMATION);
            this.Essentials.Add(Constants.DISPLAY_INFORMATION);
            this.Essentials.Add(Constants.DEVICE_INFORMATION);
            this.Essentials.Add(Constants.SEND_EMAIL);
        }

        private void GetAppInformation()
        {
            this.AppName = AppInfo.Name;
            this.PackageName = AppInfo.PackageName;
            this.VersionString = AppInfo.VersionString;
            this.Version = AppInfo.Version.ToString();
            this.BuildString = AppInfo.BuildString;
        }

        internal void GetBatteryInformation()
        {
            this.ChargeLevel = Battery.ChargeLevel * 100;
            this.EnergySaverStatus = Battery.EnergySaverStatus.ToString();
            this.State = Battery.State.ToString();
            this.PowerSource = Battery.PowerSource.ToString();
        }

        private void GetDisplayInformation()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            this.Density = mainDisplayInfo.Density;
            this.Height = mainDisplayInfo.Height;
            this.Width = mainDisplayInfo.Width;
            this.Orientation = mainDisplayInfo.Orientation.ToString();
        }

        private void GetDeviceInformation()
        {
            this.DeviceType = DeviceInfo.DeviceType.ToString();
            this.Model = DeviceInfo.Model;
            this.Manufacturer = DeviceInfo.Manufacturer;
            this.Name = DeviceInfo.Name;
        }
    }
}

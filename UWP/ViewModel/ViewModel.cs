using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SfDataGridDemo
{
    public class CountryInfoViewModel : INotifyPropertyChanged, IDisposable
    {
        private BaseCommand printCommand;

        public BaseCommand PrintCommand
        {
            get
            {
                if (printCommand == null)
                    printCommand = new BaseCommand(OnPrintButtonClicked);
                return printCommand;
            }
        }

        private void OnPrintButtonClicked(object obj)
        {
            var dataGrid = obj as SfDataGrid;
            if (dataGrid != null)
            {
                dataGrid.PrintSettings.PrintManagerBase = new CustomPrintManager(dataGrid);
                dataGrid.PrintSettings.PrintManagerBase.Print();
            }
        }
        public CountryInfoViewModel()
        {
            CountryDetails = new Countries();
        }

        private ObservableCollection<CountriesList> countryDetails;
        public ObservableCollection<CountriesList> CountryDetails
        {
            get
            {
                return countryDetails;
            }
            set
            {
                countryDetails = value;
                OnPropertyChanged("CountryDetails");
            }
        }

        #region INotifyEventChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion

        public void Dispose()
        {
            CountryDetails.Clear();
        }
    }
}

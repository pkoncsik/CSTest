using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSTest.Shared.Model
{
    public class Trade : INotifyPropertyChanged

    {

        private double _price;

        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                NotifyPropertyChanged();

            }
        }

        public string Moniker { get; set; }

        #region Implementation of INotifyPropertyChanged 

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary> 

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        public override string ToString()
        {
            return Moniker + ":" + Price;
        }
    }
}

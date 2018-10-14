using System.ComponentModel;

namespace CSTest.Shared.Model
{
    public class Trade : INotifyPropertyChanged

    {

        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("Price");

            }
        }

        public string Moniker { get; set; }

        #region Implementation of INotifyPropertyChanged 

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary> 


        protected void OnPropertyChanged(PropertyChangedEventArgs e)

        {

            var changed = PropertyChanged;
            if (changed != null) changed(this, e);

        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <param name="propertyName">The property that has a new value. </param> 

        protected virtual void RaisePropertyChanged(string propertyName)

        {

            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        }

        public override string ToString()
        {
            return Moniker + ":" + Price;
        }
    }
}

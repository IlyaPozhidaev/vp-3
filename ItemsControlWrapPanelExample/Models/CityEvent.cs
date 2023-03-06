using DynamicData.Binding;
using System.Xml.Serialization;
using System;
using static ItemsControlWrapPanelExample.Models.CityEvent;

namespace ItemsControlWrapPanelExample.Models
{
    [Serializable]
    [XmlRoot("CityEvents", Namespace = "")]
    public class CityEvent : AbstractNotifyPropertyChanged
    {
        private string _Header = "";

        private string _Description = "Описание отсутствует";

        private string _Image = "";

        private string _Date = "";

        private string _Category = "";

        private string _Price = "";
        public string Header
        {
            get => _Header;
            set => SetAndRaise(ref _Header, value);

        }
        public string Date
        {
            get => _Date;
            set => SetAndRaise(ref _Date, value);
        }
        private string CheckStringLenght(string? str)
        {
            const int maxLength = 135;

            if (!string.IsNullOrEmpty(str) && str.Length > maxLength)
            {
                str = str[..(maxLength - 2)] + "...";
            }

            return str;
        }
        public string Description
        {
            get => _Description;
            set => SetAndRaise(ref _Description, CheckStringLenght(value));
        }
        public string Price
        {
            get => _Price;
            set => SetAndRaise(ref _Price, value);
        }
        public string Category
        {
            get => _Category;
            set => SetAndRaise(ref _Category, value);
        }
        public string Image
        {
            get => _Image;
            set => SetAndRaise(ref _Image, value);
        }
    }
}

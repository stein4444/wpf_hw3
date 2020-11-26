using System.ComponentModel;

namespace WpfCw2
{

    public class ContactBook : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get => name;

            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShortCOntact)));
                }
            }
        }
        private string surname;

        public string Surname
        {
            get => surname;
            set
            {
                if (surname != value)
                {
                    surname = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(surname)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShortCOntact)));
                }
            }
        }

        public string Number { get; set; }
        public string Coutry { get; set; }
        public string ShortCOntact => Name + " " + Surname;
        public ContactBook() { }
        public ContactBook(string n, string s, string numb, string c)
        {
            Name = n;
            Surname = s;
            Number = numb;
            Coutry = c;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Name} {Number}";
        }
    }
}

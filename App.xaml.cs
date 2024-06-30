using sSandovalS5.Utils;

namespace sSandovalS5
{
    public partial class App : Application
    {
        public static PersonRepository personrepo { get; set; }
        public App(PersonRepository person)
        {
            InitializeComponent();

            MainPage = new Vistas.vHome();
            personrepo= person;
        }
    }
}

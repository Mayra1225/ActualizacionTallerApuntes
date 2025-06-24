namespace ActualizacionTallerApuntes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.Navigated += OnNavigated;
        }
        private void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
            var ruta = e.Current.Location.OriginalString;

            if (ruta.Contains("NotesPage"))
            {
                SetTabColors("Notas");
            }
            else if (ruta.Contains("RecordatoriosPage"))
            {
                SetTabColors("Recordatorios");
            }
            else if (ruta.Contains("ClimaPage"))
            {
                SetTabColors("Clima");
            }
            else if (ruta.Contains("AboutPage"))
            {
                SetTabColors("About");
            }
        }

        private void SetTabColors(string nombre)
        {
            Color bg = Colors.White;
            Color fg = Colors.Black;

            switch (nombre)
            {
                case "Notas":
                    bg = (Color)Application.Current.Resources["NotesPrimaryColor"];
                    break;
                case "Recordatorios":
                    bg = (Color)Application.Current.Resources["RecordatoriosPrimaryColor"];
                    break;
                case "Clima":
                    bg = (Color)Application.Current.Resources["ClimaPrimaryColor"];
                    break;
                case "About":
                    bg = (Color)Application.Current.Resources["AboutPrimaryColor"];
                    break;
            }

            Shell.SetTabBarBackgroundColor(this, bg);
            Shell.SetTabBarTitleColor(this, fg);
            Shell.SetTabBarUnselectedColor(this, Colors.Gray);
            Shell.SetTabBarForegroundColor(this, fg);
        }
    }
}

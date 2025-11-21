namespace LMA25_V2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Pages.NotesPage), typeof(Pages.NotesPage));
        }
    }
}

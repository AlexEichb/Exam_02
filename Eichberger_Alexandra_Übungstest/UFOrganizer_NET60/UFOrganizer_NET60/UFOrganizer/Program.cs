using UFOrganizer.View;

namespace UFOrganizer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var form = new Form1();
            MainPresenter mainPresenter = new MainPresenter();

            mainPresenter.Run();
        }
    }
}
namespace SimpleGraphicsEditor.Views
{
    using System.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for CanvasCreationDialogView.xaml
    /// </summary>
    public partial class CanvasCreationDialogView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasCreationDialogView"/> class.
        /// Dafault constructor.
        /// </summary>
        public CanvasCreationDialogView()
        {
            this.InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasCreationDialogView"/> class.
        /// Custom constructor which accepts the data context for the window.
        /// </summary>
        /// <param name="context">Data Context which will be bound to window</param>
        public CanvasCreationDialogView(CanvasCreationDialogViewModel context)
            : this()
        {
            this.DataContext = context;
            context.CreateCanvasRequestCompleted += this.CloseWindow;
        }

        /// <summary>
        /// A dummy method which can be subscribe to event in data context in order to close window.
        /// </summary>
        /// <param name="x">x Dummy parameters.</param>
        /// <param name="y">y Dummy parameters.</param>
        private void CloseWindow(int x, int y)
        {
            this.Close();
        }
    }
}

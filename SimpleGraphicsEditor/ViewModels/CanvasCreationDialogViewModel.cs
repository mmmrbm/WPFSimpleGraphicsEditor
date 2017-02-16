namespace SimpleGraphicsEditor.ViewModels
{
    using System;
    using System.Windows.Input;
    using Core;

    /// <summary>
    /// ViewModel for CanvasCreationDialogView
    /// </summary>
    public class CanvasCreationDialogViewModel : BindableBase
    {
        public CanvasCreationDialogViewModel()
        {
            this.OkCommand = new RelayCommand(this.OkClickHandler);
            this.CancelCommand = new RelayCommand(this.CancelClickHandler);
        }

        /// <summary>
        /// Action which will be raised when canvas size is entered
        /// </summary>
        public event Action<int, int> CreateCanvasRequestCompleted = (obj, eventArgs) => { };

        /// <summary>
        /// Gets or sets CanvasHeight
        /// </summary>
        public int CanvasHeight { get; set; }

        /// <summary>
        /// Gets or sets CanvasWidth
        /// </summary>
        public int CanvasWidth { get; set; }

        /// <summary>
        /// Gets OkCommand
        /// </summary>
        public ICommand OkCommand { get; private set; }

        /// <summary>
        /// Gets CancelCommand
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        /// <summary>
        /// OK button click handler
        /// </summary>
        private void OkClickHandler()
        {
            this.CreateCanvasRequestCompleted(this.CanvasHeight, this.CanvasWidth);
        }

        /// <summary>
        /// Cancel button Click Handler
        /// </summary>
        private void CancelClickHandler()
        {
            this.CreateCanvasRequestCompleted(0, 0);
        }
    }
}

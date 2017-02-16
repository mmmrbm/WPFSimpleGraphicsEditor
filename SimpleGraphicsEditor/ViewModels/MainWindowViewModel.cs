namespace SimpleGraphicsEditor.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Core;
    using Data.Models;
    using EventManagment;
    using Microsoft.Win32;
    using Utilities.Commands;
    using Utilities.UserDataPersistance;

    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// A string constant which holds the filter criteria for file save/load dialog.
        /// </summary>
        private const string FileFilter = "Simple Graphic Editor files|*.sge";

        /// <summary>
        /// A string constant which holds the file extention for canvas metadata.
        /// </summary>
        private const string CanvasMetadataExtention = ".metadata";

        /// <summary>
        /// Variable to hold the Canvas Height entered by user via dialog box
        /// </summary>
        private int userEnteredCanvasHeight;

        /// <summary>
        /// Variable to hold the Canvas Width entered by user via dialog box
        /// </summary>
        private int userEnteredCanvasWidth;

        /// <summary>
        /// A variable to hold the default canvas background color.
        /// </summary>
        private string defaultCanvasBackground = string.Empty;

        /// <summary>
        /// Variable to hold the flag to indicate whether workspace can be enabled
        /// </summary>
        private bool isMainContentGridEnabled = false;

        /// <summary>
        /// A variable to hold the user selected shape
        /// </summary>
        private string userSelectedShape = string.Empty;

        /// <summary>
        /// A variable to hold the user selected color
        /// </summary>
        private string userSelectedColor = string.Empty;

        /// <summary>
        /// A varialble to hold the flag which will enable delete shape button
        /// </summary>
        private bool isDeleteShapeButtonEnabled = false;

        /// <summary>
        /// A reference to the object holding the collection of commands associated with MainWindow
        /// </summary>
        private MainWindowCommandHelper mainWindowCommandHelper;

        /// <summary>
        /// Reference to <see cref="CanvasCreationDialogViewModel"/>
        /// </summary>
        private CanvasCreationDialogViewModel canvasCreationDialogViewModel = new CanvasCreationDialogViewModel();

        /// <summary>
        /// A reference to hold the shapes drawn by user in the application
        /// </summary>
        private ObservableCollection<BaseShape> userDrawnShapeCollection;

        /// <summary>
        /// A reference to the main event hub to be used to subscribe cuetom events.
        /// </summary>
        private EventHub eventHub;

        /// <summary>
        /// A variable to refer the shape currently selected by user
        /// </summary>
        private BaseShape selectedShape = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.mainWindowCommandHelper = new MainWindowCommandHelper();
            this.userDrawnShapeCollection = new ObservableCollection<BaseShape>();
            this.eventHub = EventHub.GetInstance();

            this.canvasCreationDialogViewModel.CreateCanvasRequestCompleted += this.CreateCanvasRequestCompletedHandler;
            this.eventHub.DragEventCompleted += this.DragEventCompletedHandler;
            this.eventHub.ResizeEventCompleted += this.ResizeEventCompletedHandler;

            this.NewCommand = new RelayCommand(this.NewHandler);
            this.OpenCommand = new RelayCommand(this.OpenHandler);
            this.SaveCommand = new RelayCommand(this.SaveHandler);
            this.CloseCommand = new RelayCommand(this.CloseHandler);

            this.ShapeSelectedCommand = new RelayCommand<string>(this.UserSelectedShapeHandler);
            this.ColorSelectedCommand = new RelayCommand<string>(this.UserSelectedColorHandler);

            this.DeleteSelectedShapeCommand = new RelayCommand(this.DeleteSelectedShapeHandler);
        }

        /// <summary>
        /// Gets NewCommand
        /// </summary>
        public ICommand NewCommand { get; private set; }

        /// <summary>
        /// Gets OpenCommand
        /// </summary>
        public ICommand OpenCommand { get; private set; }

        /// <summary>
        /// Gets SaveCommand
        /// </summary>
        public ICommand SaveCommand { get; private set; }

        /// <summary>
        /// Gets CloseCommand
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        /// <summary>
        /// Gets ShapeSelectedCommand
        /// </summary>
        public ICommand ShapeSelectedCommand { get; private set; }

        /// <summary>
        /// Gets ColorSelectedCommand
        /// </summary>
        public ICommand ColorSelectedCommand { get; private set; }

        /// <summary>
        /// Gets DeleteSelectedShapeCommand
        /// </summary>
        public ICommand DeleteSelectedShapeCommand { get; private set; }

        /// <summary>
        /// Gets or sets Canvas Height entered by user via dialog box.
        /// </summary>
        public int UserEnteredCanvasHeight
        {
            get { return this.userEnteredCanvasHeight; }
            set { this.SetProperty(ref this.userEnteredCanvasHeight, value); }
        }

        /// <summary>
        /// Gets or sets Canvas Width entered by user via dialog box.
        /// </summary>
        public int UserEnteredCanvasWidth
        {
            get { return this.userEnteredCanvasWidth; }
            set { this.SetProperty(ref this.userEnteredCanvasWidth, value); }
        }

        /// <summary>
        /// Gets or sets Default Canvas Background.
        /// </summary>
        public string DefaultCanvasBackground
        {
            get { return this.defaultCanvasBackground; }
            set { this.SetProperty(ref this.defaultCanvasBackground, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the flag indicating if workspace can be enabled
        /// </summary>
        public bool IsMainContentGridEnabled
        {
            get { return this.isMainContentGridEnabled; }
            set { this.SetProperty(ref this.isMainContentGridEnabled, value); }
        }

        /// <summary>
        /// Gets or sets User Selected Shape.
        /// </summary>
        public string UserSelectedShape
        {
            get { return this.userSelectedShape; }
            set { this.SetProperty(ref this.userSelectedShape, value); }
        }

        /// <summary>
        /// Gets or sets User Selected Color.
        /// </summary>
        public string UserSelectedColor
        {
            get { return this.userSelectedColor; }
            set { this.SetProperty(ref this.userSelectedColor, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether delete shape button is enabled
        /// </summary>
        public bool IsDeleteShapeButtonEnabled
        {
            get { return this.isDeleteShapeButtonEnabled; }
            set { this.SetProperty(ref this.isDeleteShapeButtonEnabled, value); }
        }

        /// <summary>
        /// Gets or sets User Drawn Shape Collection.
        /// </summary>
        public ObservableCollection<BaseShape> UserDrawnShapeCollection
        {
            get { return this.userDrawnShapeCollection; }
            set { this.SetProperty(ref this.userDrawnShapeCollection, value); }
        }

        /// <summary>
        /// Gets or sets User Selected Shape
        /// </summary>
        public BaseShape SelectedShape
        {
            get
            {
                return this.selectedShape;
            }

            set
            {
                this.SetProperty(ref this.selectedShape, value);
                this.IsDeleteShapeButtonEnabled = true;
            }
        }

        /// <summary>
        /// Command handler for NewCommand
        /// </summary>
        private void NewHandler()
        {
            this.mainWindowCommandHelper.New(this.canvasCreationDialogViewModel);
        }

        /// <summary>
        /// Command handler for OpenCommand
        /// </summary>
        private void OpenHandler()
        {
            var loadWorkspaceLoadDialog = new OpenFileDialog { Filter = FileFilter, AddExtension = true };

            if (loadWorkspaceLoadDialog.ShowDialog().Value)
            {
                this.UserDrawnShapeCollection =
                    this.mainWindowCommandHelper.Open<ObservableCollection<BaseShape>>(
                    loadWorkspaceLoadDialog.FileName);

                this.UserEnteredCanvasHeight = 600;
                this.UserEnteredCanvasWidth = 1000;
                this.IsMainContentGridEnabled = true;

                BaseCanvasInfoStorage baseCanvasInfoStorage =
                    this.mainWindowCommandHelper.Open<BaseCanvasInfoStorage>(
                        loadWorkspaceLoadDialog.FileName + CanvasMetadataExtention);

                this.DefaultCanvasBackground = baseCanvasInfoStorage.CanvasBackground;
                this.UserEnteredCanvasHeight = baseCanvasInfoStorage.CanvasHeight;
                this.UserEnteredCanvasWidth = baseCanvasInfoStorage.CanvasWidth;
            }
        }

        /// <summary>
        /// Command handler for SaveCommand
        /// </summary>
        private void SaveHandler()
        {
            var saveWorkspacePathDialog = new SaveFileDialog { Filter = FileFilter, AddExtension = true };

            if (saveWorkspacePathDialog.ShowDialog().Value)
            {
                this.mainWindowCommandHelper.Save<ObservableCollection<BaseShape>>(
                    this.UserDrawnShapeCollection,
                    saveWorkspacePathDialog.FileName);

                BaseCanvasInfoStorage baseCanvasInfoStorage = new BaseCanvasInfoStorage();
                baseCanvasInfoStorage.CanvasBackground = this.DefaultCanvasBackground;
                baseCanvasInfoStorage.CanvasHeight = this.UserEnteredCanvasHeight;
                baseCanvasInfoStorage.CanvasWidth = this.UserEnteredCanvasWidth;

                this.mainWindowCommandHelper.Save<BaseCanvasInfoStorage>(
                    baseCanvasInfoStorage,
                    saveWorkspacePathDialog.FileName + CanvasMetadataExtention);
            }
        }

        /// <summary>
        /// Command handler for CloseCommand
        /// </summary>
        private void CloseHandler()
        {
            this.mainWindowCommandHelper.Close();
        }

        /// <summary>
        /// An event handler to obtain canvas height and width via dialog box.
        /// </summary>
        /// <param name="canvasHeight">Height of the canvas</param>
        /// <param name="canvasWidth">Width of the canvas</param>
        private void CreateCanvasRequestCompletedHandler(
            int canvasHeight,
            int canvasWidth)
        {
            this.UserEnteredCanvasHeight = canvasHeight;
            this.UserEnteredCanvasWidth = canvasWidth;
            this.DefaultCanvasBackground = "BlanchedAlmond";

            if (this.UserEnteredCanvasHeight > 0 && this.UserEnteredCanvasWidth > 0)
            {
                this.IsMainContentGridEnabled = true;
            }
            else
            {
                this.IsMainContentGridEnabled = false;
            }
        }

        /// <summary>
        /// Handles the UserSelectedShapeCommand.
        /// </summary>
        /// <param name="userSelectedShape">Shape selected by user.</param>
        private void UserSelectedShapeHandler(
            string userSelectedShape)
        {
            this.UserSelectedShape = userSelectedShape;
            this.UserDrawnShapeCollection.Add(this.mainWindowCommandHelper.UserSelectedShapeDrawer(userSelectedShape));
        }

        /// <summary>
        /// Handles the UserSelectedColorCommand.
        /// </summary>
        /// <param name="userSelectedColor">Color selected by user.</param>
        private void UserSelectedColorHandler(
            string userSelectedColor)
        {
            this.UserSelectedColor = userSelectedColor;

            if (this.SelectedShape != null)
            {
                this.SelectedShape.ShapeColor = userSelectedColor;
            }
        }

        /// <summary>
        /// Handler for event DragEventCompleted.
        /// </summary>
        /// <param name="shapeId">Id of the shape which needs to be updated.</param>
        /// <param name="eventArguments">Updated values from the event source passed as argument.</param>
        private void DragEventCompletedHandler(
            string shapeId,
            double[] eventArguments)
        {
            foreach (var shape in this.UserDrawnShapeCollection)
            {
                if (shape.ShapeIdentifire.ToString() == shapeId)
                {
                    shape.XPosition = eventArguments[0];
                    shape.YPosition = eventArguments[1];
                }
            }
        }

        /// <summary>
        /// Handler for event ResizeEventCompleted.
        /// </summary>
        /// <param name="shapeId">Id of the shape which needs to be updated.</param>
        /// <param name="eventArguments">Updated values from the event source passed as argument.</param>
        private void ResizeEventCompletedHandler(
            string shapeId,
            double[] eventArguments)
        {
            foreach (var shape in this.UserDrawnShapeCollection)
            {
                if (shape.ShapeIdentifire.ToString() == shapeId)
                {
                    shape.ShapeHeight = eventArguments[0];
                    shape.ShapeWidth = eventArguments[1];
                }
            }
        }

        /// <summary>
        /// Handler for Delete Selected Shape Command
        /// </summary>
        private void DeleteSelectedShapeHandler()
        {
            if (this.SelectedShape != null)
            {
                this.UserDrawnShapeCollection.Remove(this.SelectedShape);
            }
        }
    }
}

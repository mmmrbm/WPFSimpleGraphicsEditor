namespace SimpleGraphicsEditor.Utilities.Commands
{
    using System;
    using System.Windows;
    using Data.Factories;
    using Data.Models;
    using Microsoft.Win32;
    using UserDataPersistance;
    using ViewModels;

    /// <summary>
    /// A utility class which holds the commands for MainWindow
    /// </summary>
    public class MainWindowCommandHelper
    {
        /// <summary>
        /// Method which will be executed when New menu command is exectued.
        /// </summary>
        /// <param name="canvasCreationDialogViewModel">ViewModel to render associated view</param>
        public void New(
            CanvasCreationDialogViewModel canvasCreationDialogViewModel)
        {
            var canvasCreationDialog = new Views.CanvasCreationDialogView(canvasCreationDialogViewModel);
            canvasCreationDialog.ShowDialog();
        }

        /// <summary>
        /// Method which will be executed when Open menu command is exectued.
        /// </summary>
        /// <typeparam name="T">Type of object which will be loaded to application.</typeparam>
        /// <param name="filePath">Path of the file.</param>
        /// <returns>Object returned from load process.</returns>
        public T Open<T>(
            string filePath)
        {
            UserDataPersistManager userDataPersistManager = new UserDataPersistManager();
            return userDataPersistManager.Load<T>(filePath);
        }

        /// <summary>
        /// Method which will be executed when Save menu command is exectued.
        /// </summary>
        /// <typeparam name="T">Type of the object which will be persisted.</typeparam>
        /// <param name="obj">The object which will be persisted.</param>
        /// <param name="filePath">Path of the file.</param>
        public void Save<T>(
            T obj,
            string filePath)
        {
            UserDataPersistManager userDataPersistManager = new UserDataPersistManager();
            userDataPersistManager.Save<T>(obj, filePath);
        }

        /// <summary>
        /// Method which will be executed when Close menu command is exectued.
        /// </summary>
        public void Close()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Uses the ShapeFactory to get a shape as per user input
        /// and returns it to MainWindow
        /// </summary>
        /// <param name="userSelectedShape">The shape selected by user</param>
        /// <returns>The shape object fetched from ShapeFactory</returns>
        public BaseShape UserSelectedShapeDrawer(
            string userSelectedShape)
        {
            return ShapeFactory.GetInstance().GetShape(userSelectedShape);
        }
    }
}

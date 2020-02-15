using System;
using System.IO;
using System.Linq;

namespace Homework4
{
    class ConsoleExplorer
    {
        public string CurrentPath { get; private set; }

        public ConsoleExplorer()
        {
            this.CurrentPath = Environment
                .GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        /// <summary>
        /// Lists contents of directory in CurrentPath property
        /// </summary>
        /// <returns>Formatted string with files and directories.</returns>
        public string ListContents()
        {
            // Call method with current path
            return this.ListContents(this.CurrentPath);
        }

        /// <summary>
        /// Lists contents of specified directory.
        /// </summary>
        /// <param name="directoryPath">Directory path</param>
        /// <returns>Formatted string with files and directories.</returns>
        public string ListContents(string directoryPath)
        {
            try
            {
                // Full path 
                string auxPath = Path.GetFullPath(directoryPath,
                                                  this.CurrentPath);
                // All files
                string files = String.Join('\n', Directory
                    .GetFiles(auxPath).Select(Path.GetFileName));
                // All directories
                string directories = String.Join('\n', Directory
                    .GetDirectories(auxPath).Select(Path.GetFileName));
                // Formatting
                return $"FILES:\n{files}\n\nDIRECTORIES:\n{directories}";
            }
            // Access denied
            catch (UnauthorizedAccessException)
            {
                return "Access denied...";
            }
            // Path too long (more than 260 characters)
            catch (PathTooLongException)
            {
                return "Path is too long...";
            }
            // Directory does not exist
            catch (DirectoryNotFoundException)
            {
                return "Directory not found...";
            }
            // Others
            catch (IOException)
            {
                return "IOException...";
            }
        }

        /// <summary>
        /// Change CurrentPath property
        /// </summary>
        /// <param name="directoryPath">New current path</param>
        /// <returns>Error messages or null if successfull.</returns>
        public string ChangeDirectory(string directoryPath)
        {
            try
            {
                // Move 'up'
                if (directoryPath.Equals(".."))
                {
                    this.CurrentPath = Directory.GetParent(this.CurrentPath)
                        .FullName;
                }
                // Validate new path
                else
                {
                    // New path
                    string newPath = Path.GetFullPath(directoryPath,
                                                      this.CurrentPath);
                    // Does not exist...
                    if (!Directory.Exists(newPath))
                    {
                        throw new DirectoryNotFoundException();
                    }
                    // Change current path
                    this.CurrentPath = newPath;
                }
                // Success!
                return null;
            }
            // No Access
            catch (UnauthorizedAccessException)
            {
                return "Access denied...";
            }
            // Path too long (more than 260 characters)
            catch (PathTooLongException)
            {
                return "Path is too long...";
            }
            // Directory does not exist
            catch (DirectoryNotFoundException)
            {
                return "Directory not found...";
            }
            // Parent of root?!
            catch (NullReferenceException)
            {
                return "Root has no parent directory...";
            }
            // Others
            catch (IOException)
            {
                return "IOException...";
            }
        }

        /// <summary>
        /// Create file specified by path
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Error messages or null if successfull.</returns>
        public string CreateFile(string filePath)
        {
            // Full path
            string auxPath = Path.GetFullPath(filePath, this.CurrentPath);
            // File exists...
            if (File.Exists(auxPath))
            {
                return "The file already exists...";
            }
            try
            {
                // File creation
                File.Create(auxPath);
                // Success!
                return null;
            }
            // Access denied
            catch (UnauthorizedAccessException)
            {
                return "Access denied...";
            }
            // Path too long (more than 260 characters)
            catch (PathTooLongException)
            {
                return "Path is too long...";
            }
            // Directory is not valid
            catch (DirectoryNotFoundException)
            {
                return "Directory not found...";
            }
            // Others
            catch (IOException)
            {
                return "IOException...";
            }
        }

        /// <summary>
        /// Move/Rename file to another location
        /// </summary>
        /// <param name="filePath">Original file</param>
        /// <param name="directoryPath">New location/name</param>
        /// <returns>Error messages or null if successfull.</returns>
        public string MoveFile(string filePath, string directoryPath)
        {
            // Origin path
            string path1 = Path.GetFullPath(filePath, this.CurrentPath);
            // Destination path
            string path2 = Path.GetFullPath(directoryPath, this.CurrentPath);
            // File does not exist...
            if (!File.Exists(path1))
            {
                return "File not found...";
            }
            try
            {
                // Move file
                File.Move(path1, path2, true);
                // Success!
                return null;
            }
            // No access
            catch (UnauthorizedAccessException)
            {
                return "Access denied...";
            }
            // Path too long (more than 260 characters)
            catch (PathTooLongException)
            {
                return "Path is too long...";
            }
            // Invalid directory
            catch (DirectoryNotFoundException)
            {
                return "Directory not found...";
            }
            // Others
            catch (IOException)
            {
                return "IOException...";
            }
        }

    }
}

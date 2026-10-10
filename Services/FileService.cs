using System;
using System.IO;
using System.Collections.Generic;
using Assessment2Task2.Models;

namespace Assessment2Task2.Services
{
    public class FileService
    {
        private string primaryFilePath;
        private string backupFilePath;

        public FileService(string primaryFilePath, string backupFilePath)
        {
            this.primaryFilePath = primaryFilePath;
            this.backupFilePath = backupFilePath;
        }

        public void SaveAllocationsToFile(List<RoomAllocation> allocations)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(primaryFilePath, true);

                writer.WriteLine("========================================");
                writer.WriteLine($"Timestamp: {DateTime.Now:dd-MM-yyyy HH:mm:ss}");
                writer.WriteLine("========================================");

                if (allocations.Count == 0)
                {
                    writer.WriteLine("No allocations to save.");
                }
                else
                {
                    writer.WriteLine($"{"Room Number",-15} {"Customer No",-15} {"Customer Name",-20}");
                    writer.WriteLine(new string('-', 50));

                    foreach (var alloc in allocations)
                    {
                        writer.WriteLine($"{alloc.AllocatedRoomNo,-15} {alloc.AllocatedCustomer.CustomerNo,-15} {alloc.AllocatedCustomer.CustomerName,-20}");
                    }
                }

                writer.WriteLine();
                Console.WriteLine($"Allocations saved successfully to {primaryFilePath}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access Denied: You do not have permission to write to this file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                Console.WriteLine("Save operation completed.");
            }
        }

        public void ShowAllocationsFromFile()
        {
            StreamReader reader = null;
            try
            {
                if (!File.Exists(primaryFilePath))
                {
                    throw new FileNotFoundException($"File not found: {primaryFilePath}");
                }

                reader = new StreamReader(primaryFilePath);
                string content = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("The file is empty. No records to display.");
                }
                else
                {
                    Console.WriteLine("\n===== FILE CONTENTS =====");
                    Console.WriteLine(content);
                    Console.WriteLine("===== END OF FILE =====");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File Error: {ex.Message}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access Denied: You do not have permission to read this file.");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                Console.WriteLine("Show File operation completed.");
            }
        }

        public void BackupAndClear()
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                if (!File.Exists(primaryFilePath))
                {
                    throw new FileNotFoundException($"Primary file not found: {primaryFilePath}");
                }

                reader = new StreamReader(primaryFilePath);
                string content = reader.ReadToEnd();
                reader.Close();
                reader = null;

                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("Primary file is empty. Nothing to backup.");
                    return;
                }

                writer = new StreamWriter(backupFilePath, true);
                writer.WriteLine("========================================");
                writer.WriteLine($"Backup Timestamp: {DateTime.Now:dd-MM-yyyy HH:mm:ss}");
                writer.WriteLine("========================================");
                writer.Write(content);
                writer.WriteLine();
                writer.Close();
                writer = null;

                File.WriteAllText(primaryFilePath, string.Empty);

                Console.WriteLine($"Backup successful. Data saved to {backupFilePath}");
                Console.WriteLine($"Primary file {primaryFilePath} has been cleared.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File Error: {ex.Message}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access Denied: You do not have permission to perform this operation.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
            finally
            {
                if (reader != null) reader.Close();
                if (writer != null) writer.Close();
                Console.WriteLine("Backup operation completed.");
            }
        }
    }
}
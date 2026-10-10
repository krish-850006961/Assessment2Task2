/* 
 * Project Name:   Langham Hotel Management System
 * Author Name:    Krish
 * Student ID:     850006961
 * Cohort:         NZDITTS226C-E
 * Date:           2026
 * Application Purpose: Hotel Room Allocation Management Console Application
 */


using System;
using System.Collections.Generic;
using System.IO;
using Assessment2Task2.Models;
using Assessment2Task2.Services;

namespace Assessment2Task2
{
    class Program
    {
        static List<Room> rooms = new List<Room>();
        static List<RoomAllocation> allocations = new List<RoomAllocation>();

        static void Main(string[] args)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string primaryFilePath = Path.Combine(folderPath, "lhms_850006961.txt");
            string backupFilePath = Path.Combine(folderPath, "lhms_850006961_backup.txt");

            RoomService roomService = new RoomService(rooms);
            AllocationService allocationService = new AllocationService(rooms, allocations);
            FileService fileService = new FileService(primaryFilePath, backupFilePath);

            char ans;

            do
            {
                Console.Clear();
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("                    LANGHAM HOTEL MANAGEMENT SYSTEM                               ");
                Console.WriteLine("                                 MENU                                             ");
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("0. Backup Room Allocations File");
                Console.WriteLine("1. Add Rooms");
                Console.WriteLine("2. Display Rooms");
                Console.WriteLine("3. Allocate Rooms");
                Console.WriteLine("4. De-Allocate Rooms");
                Console.WriteLine("5. Display Room Allocation Details");
                Console.WriteLine("6. Billing");
                Console.WriteLine("7. Save the Room Allocations To a File");
                Console.WriteLine("8. Show the Room Allocations From a File");
                Console.WriteLine("9. Exit");
                Console.WriteLine("***********************************************************************************");
                Console.Write("Enter Your Choice Number Here: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 0:
                            fileService.BackupAndClear();
                            break;
                        case 1:
                            roomService.AddRoom();
                            break;
                        case 2:
                            roomService.DisplayRooms();
                            break;
                        case 3:
                            allocationService.AllocateRoom();
                            break;
                        case 4:
                            allocationService.DeAllocateRoom();
                            break;
                        case 5:
                            allocationService.DisplayAllocations();
                            break;
                        case 6:
                            Console.WriteLine("Billing Feature is Under Construction and will be added soon...!!!");
                            break;
                        case 7:
                            fileService.SaveAllocationsToFile(allocations);
                            break;
                        case 8:
                            fileService.ShowAllocationsFromFile();
                            break;
                        case 9:
                            Console.WriteLine("Thank you for using Langham Hotel Management System. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 0 and 9.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number for your menu choice.");
                }

                Console.Write("\nWould You Like To Continue (Y/N): ");
                ans = Convert.ToChar(Console.ReadLine());

            } while (ans == 'y' || ans == 'Y');

            Console.WriteLine("Thank you for using Langham Hotel Management System. Goodbye!");
        }
    }
}
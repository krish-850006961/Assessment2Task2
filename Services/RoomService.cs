using System;
using System.Collections.Generic;
using System.Linq;
using Assessment2Task2.Models;

namespace Assessment2Task2.Services
{
    public class RoomService
    {
        private List<Room> rooms;

        public RoomService(List<Room> rooms)
        {
            this.rooms = rooms;
        }

        public void AddRoom()
        {
            try
            {
                Console.Write("Enter Room Number: ");
                int roomNo = Convert.ToInt32(Console.ReadLine());

                if (rooms.Any(r => r.RoomNo == roomNo))
                {
                    Console.WriteLine($"Room {roomNo} already exists.");
                    return;
                }

                rooms.Add(new Room(roomNo));
                Console.WriteLine($"Room {roomNo} added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for Room Number.");
            }
            finally
            {
                Console.WriteLine("Add Room operation completed.");
            }
        }

        public void DisplayRooms()
        {
            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms available.");
                return;
            }

            Console.WriteLine("\n{0,-15} {1,-15}", "Room Number", "Status");
            Console.WriteLine(new string('-', 30));

            foreach (var room in rooms)
            {
                string status = room.IsAllocated ? "Allocated" : "Available";
                Console.WriteLine("{0,-15} {1,-15}", room.RoomNo, status);
            }
        }

        public List<Room> GetRooms()
        {
            return rooms;
        }
    }
}
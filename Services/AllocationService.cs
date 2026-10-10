using System;
using System.Collections.Generic;
using System.Linq;
using Assessment2Task2.Models;

namespace Assessment2Task2.Services
{
    public class AllocationService
    {
        private List<Room> rooms;
        private List<RoomAllocation> allocations;

        public AllocationService(List<Room> rooms, List<RoomAllocation> allocations)
        {
            this.rooms = rooms;
            this.allocations = allocations;
        }

        public void AllocateRoom()
        {
            try
            {
                Console.Write("Enter Room Number to Allocate: ");
                int roomNo = Convert.ToInt32(Console.ReadLine());

                Room room = rooms.FirstOrDefault(r => r.RoomNo == roomNo);

                if (room == null)
                {
                    throw new InvalidOperationException($"Room {roomNo} does not exist.");
                }

                if (room.IsAllocated)
                {
                    throw new InvalidOperationException($"Room {roomNo} is already allocated.");
                }

                Console.Write("Enter Customer Number: ");
                int customerNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();

                Customer customer = new Customer(customerNo, customerName);
                allocations.Add(new RoomAllocation(roomNo, customer));
                room.IsAllocated = true;

                Console.WriteLine($"Room {roomNo} successfully allocated to {customerName}.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numeric values where required.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Operation Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Allocate Room operation completed.");
            }
        }

        public void DeAllocateRoom()
        {
            try
            {
                Console.Write("Enter Room Number to De-Allocate: ");
                int roomNo = Convert.ToInt32(Console.ReadLine());

                RoomAllocation allocation = allocations.FirstOrDefault(a => a.AllocatedRoomNo == roomNo);

                if (allocation == null)
                {
                    throw new InvalidOperationException($"Room {roomNo} is not currently allocated.");
                }

                allocations.Remove(allocation);

                Room room = rooms.FirstOrDefault(r => r.RoomNo == roomNo);
                if (room != null)
                {
                    room.IsAllocated = false;
                }

                Console.WriteLine($"Room {roomNo} has been successfully de-allocated.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for Room Number.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Operation Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("De-Allocate Room operation completed.");
            }
        }

        public void DisplayAllocations()
        {
            if (allocations.Count == 0)
            {
                Console.WriteLine("No room allocations found.");
                return;
            }

            Console.WriteLine("\n{0,-15} {1,-15} {2,-20}", "Room Number", "Customer No", "Customer Name");
            Console.WriteLine(new string('-', 50));

            foreach (var alloc in allocations)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-20}",
                    alloc.AllocatedRoomNo,
                    alloc.AllocatedCustomer.CustomerNo,
                    alloc.AllocatedCustomer.CustomerName);
            }
        }

        public List<RoomAllocation> GetAllocations()
        {
            return allocations;
        }
    }
}
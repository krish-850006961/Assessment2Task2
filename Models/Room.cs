namespace Assessment2Task2.Models
{
    public class Room
    {
        public int RoomNo { get; set; }
        public bool IsAllocated { get; set; }

        public Room(int roomNo)
        {
            RoomNo = roomNo;
            IsAllocated = false;
        }
    }
}
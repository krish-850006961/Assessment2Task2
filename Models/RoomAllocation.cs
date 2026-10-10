namespace Assessment2Task2.Models
{
    public class RoomAllocation
    {
        public int AllocatedRoomNo { get; set; }
        public Customer AllocatedCustomer { get; set; }

        public RoomAllocation(int roomNo, Customer customer)
        {
            AllocatedRoomNo = roomNo;
            AllocatedCustomer = customer;
        }
    }
}
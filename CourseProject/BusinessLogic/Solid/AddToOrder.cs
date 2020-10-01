using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    public class AddToOrder : IAddToOrder
    {
        private readonly IAddToOrderDAL _addtoorderDAL;



        public AddToOrder(IAddToOrderDAL addtoorderDAL)
        {
            _addtoorderDAL = addtoorderDAL;
        }

        public AddToOrderDTO AddPosition(AddToOrderDTO addtoorder)
        {
            Console.WriteLine("ENTER ORDER ID, ITEM ID, AMOUNT TO ADD TO ORDER");

            addtoorder = new AddToOrderDTO
            {
                
                OrderIDKEY = Convert.ToInt32(Console.ReadLine()),
                ItemIDKEY = Convert.ToInt32(Console.ReadLine()),
                Amount = Convert.ToInt32(Console.ReadLine())
            };



            return _addtoorderDAL.CreateAddToOrder(addtoorder);
        }


        public void DeletePosition(int OrderIDKEY)
        {
            AddToOrderDTO addtoorder = new AddToOrderDTO();
            addtoorder.OrderIDKEY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting position OrderIDKey: {addtoorder.OrderIDKEY}");
            _addtoorderDAL.DeleteAddToOrder(addtoorder.OrderIDKEY);
        }


        public List<AddToOrderDTO>SameOrderPositions(int OrderIDKEY)
        {

            OrderIDKEY = Convert.ToInt32(Console.ReadLine());
            return _addtoorderDAL.FromSameOrder(OrderIDKEY);
        }
    }
}

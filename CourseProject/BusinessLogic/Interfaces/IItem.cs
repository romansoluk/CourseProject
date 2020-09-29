
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Interfaces
{
    public interface IItem
    {
        ItemDTO AddItem(ItemDTO item);
        ItemDTO ChangeItem(ItemDTO item);
        void ShowItemsSorted(int SortingParameter);
        void ShowItems();
        void RemoveItem(int ItemID);
        ItemDTO GetItem(int ItemID);
    }
}



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
        //ItemDTO AddItem(ItemDTO item);
        //MovieDTO AddMovie(MovieDTO movie);

        void ShowItems();
    }
}


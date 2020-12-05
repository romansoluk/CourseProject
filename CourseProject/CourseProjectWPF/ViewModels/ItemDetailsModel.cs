using BusinessLogic.Interfaces;
using CourseProjectWPF.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectWPF.ViewModels
{
   public class ItemDetailsModel : INotifyPropertyChanged
    {
        private IUser _manager;

        private ItemDTO _item;
        public ItemDTO Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        

        public string Name { get; set; }
        public double Price { get; set; }
        public int OnStock { get; set; }

        public List<SelectableOption> ITEMS { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public ItemDetailsModel(IUser manager, ItemDTO item)
        {
            _manager = manager;
            Item = item ?? new ItemDTO();
            var items = _manager.ShowItems();

            Name = items.Select(i => new SelectableOption
            {
                ID = i.ItemID,
                Text = i.Name,
                IsSelected= item.Name.Equals(i.Name)
            }).ToList().First().Text ;


            //Price = items.Select(i => new SelectableOption
            //{
            //    ID = i.ItemID,
            //    Text = i.Price.ToString(),
            //    IsSelected = item.Name.Equals(i.Name)
            //}).ToList().First().Text;
           
          
            OnStock = item.OnStock;
            
        
        }

        public void Save()
        {

            Item.Name = ITEMS.Where(d => d.IsSelected).Select(d => new ItemDTO
             {
                ItemID = d.ID
                
            }).FirstOrDefault().Name;


            Item.Price = ITEMS.Where(d => d.IsSelected).Select(d => new ItemDTO
            {
                ItemID = d.ID
            }).FirstOrDefault().Price;

            Item = _manager.ChangeItem(Item);
        }

    }
}

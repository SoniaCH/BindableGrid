using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BindableGrid
{


    public class GalleryCustomMvvm : INotifyPropertyChanged
    {
        private ImagesItems _selectedItem;
        public ImagesItems SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ImagesItems> _dummyItems;
        public ObservableCollection<ImagesItems> DummyItems
        {
            get
            {
                return _dummyItems;
            }
            set
            {               
                    _dummyItems = value;
                    OnPropertyChanged("DummyItems");
             
            }
        }
        public Page CurrentPage{get;set;}
        public INavigation nav{get;set;}

        public GalleryCustomMvvm()
        {
            // Add some data to the model
            _dummyItems = new ObservableCollection<ImagesItems>();
            this._dummyItems.Add(new ImagesItems { SmallImage = "yellow.png"});
            this._dummyItems.Add(new ImagesItems { SmallImage = "red.png"});
            this._dummyItems.Add(new ImagesItems { SmallImage = "blue.png"});
            this._dummyItems.Add(new ImagesItems { SmallImage = "greencitron.png"});
            this._dummyItems.Add(new ImagesItems { SmallImage = "rose.png"});
            this._dummyItems.Add(new ImagesItems { SmallImage = "lightblue.png"});
           // nav.PushAsync(CurrentPage);
        }

        //DeleteCommand: 

        public ICommand DeleteCommand => new Command<object>((o) =>
        {
            var img = o as ImagesItems;
            SelectedItem = img;
            _dummyItems.Remove(img);
            DummyItems = _dummyItems;          
            //  CurrentPage.FindByName<GalleryCustom>("ListTest").ItemsSource=DummyItems;
            //Itemsource=DummyItems;                    
        });

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

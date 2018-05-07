using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BindableGrid
{


    public class GalleryCustomMvvm : INotifyPropertyChanged
    {


        private ObservableCollection<ImagesItems> _dummyItems;
        public ObservableCollection<ImagesItems> DummyItems
        {
            get { return _dummyItems; }
            set
            {

                _dummyItems = value;
                NotifyPropertyChanged("DummyItems");

            }
        }
        public Page CurrentPage{get;set;}
        public INavigation nav{get;set;}

        public GalleryCustomMvvm()
        {
           
          // Add some data to the model
            this.DummyItems = new ObservableCollection<ImagesItems>();
            this.DummyItems.Add(new ImagesItems { SmallImage = "yellow.png", IsDeleted = false, TxtName = "test1" });
            this.DummyItems.Add(new ImagesItems { SmallImage = "red.png", IsDeleted = false, TxtName = "test2" });
            this.DummyItems.Add(new ImagesItems { SmallImage = "blue.png", IsDeleted = false, TxtName = "test3" });
            this.DummyItems.Add(new ImagesItems { SmallImage = "greencitron.png", IsDeleted = false, TxtName = "test4" });
            this.DummyItems.Add(new ImagesItems { SmallImage = "rose.png", IsDeleted = false, TxtName = "test5" });
            this.DummyItems.Add(new ImagesItems { SmallImage = "lightblue.png", IsDeleted = false, TxtName = "test6" });
            this.DummyItems.Add(new ImagesItems { SmallImage = "rose.png", IsDeleted = false, TxtName = "test8" });
           // nav.PushAsync(CurrentPage);
        }

        //DeleteCommand

        public ICommand DeleteCommand => new Command<object>((o) =>
        {
            var img = o as ImagesItems;
            DummyItems.Remove(img);
            CurrentPage.FindByName<GalleryCustom>("ListTest").ItemsSource= DummyItems;
            DummyItems = _dummyItems;
           
        });


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


    }
}

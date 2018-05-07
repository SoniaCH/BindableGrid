using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindableGrid
{
	public partial class MainPage : ContentPage
	{

        private ObservableCollection<ImagesItems> _dummyItems;
        public MainPage()
		{
			InitializeComponent();
           
            // Add some data to the model
            this._dummyItems = new ObservableCollection<ImagesItems>();

            this._dummyItems.Add(new ImagesItems { SmallImage = "yellow.png", IsDeleted = false, TxtName = "test1" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "red.png", IsDeleted = false, TxtName = "test2" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "blue.png", IsDeleted = false, TxtName = "test3" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "greencitron.png", IsDeleted = false, TxtName = "test4" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "rose.png", IsDeleted = false, TxtName = "test5" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "lightblue.png", IsDeleted = false, TxtName = "test6" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "yellow.png", IsDeleted = false, TxtName = "test7" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "rose.png", IsDeleted = false, TxtName = "test8" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "lightblue.png", IsDeleted = false, TxtName = "test9" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "yellow.png", IsDeleted = false, TxtName = "test10" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "yellow.png", IsDeleted = false, TxtName = "test1" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "red.png", IsDeleted = false, TxtName = "test2" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "blue.png", IsDeleted = false, TxtName = "test3" });
            this._dummyItems.Add(new ImagesItems { SmallImage = "greencitron.png", IsDeleted = false, TxtName = "test4" });
        }

        public void OnDelete(object s, EventArgs e)
        {
            ListTest.ItemsSource = _dummyItems;
        }

	}
}

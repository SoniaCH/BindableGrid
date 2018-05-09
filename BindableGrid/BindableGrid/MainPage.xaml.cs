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

        private ObservableCollection<ImagesItems> Items;
        public MainPage()
		{
			InitializeComponent();
            
            // Add some data to the model
            this.Items = new ObservableCollection<ImagesItems>();

            this.Items.Add(new ImagesItems { SmallImage = "yellow.png"});
            this.Items.Add(new ImagesItems { SmallImage = "red.png"});
            this.Items.Add(new ImagesItems { SmallImage = "blue.png"});
            this.Items.Add(new ImagesItems { SmallImage = "greencitron.png"});
            this.Items.Add(new ImagesItems { SmallImage = "rose.png"});
            this.Items.Add(new ImagesItems { SmallImage = "lightblue.png"});
            this.Items.Add(new ImagesItems { SmallImage = "yellow.png"});
            this.Items.Add(new ImagesItems { SmallImage = "rose.png"});
            this.Items.Add(new ImagesItems { SmallImage = "lightblue.png"});
            this.Items.Add(new ImagesItems { SmallImage = "yellow.png"});
            this.Items.Add(new ImagesItems { SmallImage = "yellow.png"});
            this.Items.Add(new ImagesItems { SmallImage = "red.png"});
            this.Items.Add(new ImagesItems { SmallImage = "blue.png"});
            this.Items.Add(new ImagesItems { SmallImage = "greencitron.png"});
        }

        public void OnDelete(object s, EventArgs e)
        {
            var test = new ObservableCollection<ImagesItems>();
            foreach (var i in Items.ToList())
            {
                if(i.SmallImage== "yellow.png") { Items.Remove(i); test.Add(i); }
            }
            ListTest.ItemsSource = test;
        }

        public void OnTest(object s, EventArgs e)
        {
            var test= new ObservableCollection<ImagesItems>();
            foreach (var i in Items.ToList())
            {
                if (i.SmallImage == "rose.png")
                {
                    Items.Remove(i);
                    test.Add(i);
                }
            }
            ListTest.ItemsSource = test;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var VM = BindingContext as GalleryCustomMvvm;
            var Dummy = VM.DummyItems;
            ListTest.ItemsSource = Dummy;            
        }

    }
}

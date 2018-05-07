﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace BindableGrid
{
    public class GalleryCustom:Grid
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var children = this.Children;
            foreach (var item in children.ToList())
            {
                this.Children.Remove(item);
            }
            CreateGrid();
        }
        protected override void OnPropertyChanged(string propertyName)
        {
           
            if (propertyName== GalleryCustom.ItemsSourceProperty.PropertyName)
            {
                var children = this.Children;
                foreach (var item in children.ToList())
                {
                    this.Children.Remove(item);
                }
                CreateGrid();
            }            
        }

        //Property
      

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(GalleryCustom), null, propertyChanged: OnEventNameChanged);
        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        static void OnEventNameChanged(BindableObject bindable, object oldValue,object newValue)
        {
            // Property changed implementation 
            var control = (GalleryCustom)bindable;
            //control.ItemsSource = newValue.T;
        }


        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(GalleryCustom), null);
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty ItemSelectedProperty = BindableProperty.Create(nameof(ItemSelected), typeof(object), typeof(GalleryCustom), null);
        public object ItemSelected
        {
            get { return (object)GetValue(ItemSelectedProperty); }
            set { SetValue(ItemSelectedProperty, value); }
        }
        //methods
        double intWidth = Device.info.PixelScreenSize.Width - 100;
        private void CreateGrid()
        {
            // Check for data
            if (this.ItemsSource == null || this.ItemsSource.Count() == 0)
            {
                return;
            }

            CreateCells();
        }

        private void CreateCells()
        {
            double nbr = intWidth * 0.02;
            int _c = Convert.ToInt32(Math.Floor(nbr));
            int _count = ItemsSource.Count();

            int _row = 0;
            int _col = 0;

           
                int _index = _c * _row + _col;
                while (_col <= _c && _index < _count)
                {
                    _index = _c * _row + _col;
                    if (_col == _c)
                    {
                        _row++;
                        _col = 0;
                    }
                    if (_col < _c && _index < _count)
                    {
                    var item = ItemsSource.ElementAt(_index);
                        this.Children.Add(CreateCellView(item), _col, _row);
                        _col++;
                    }
                }
            
         
        }

        private Xamarin.Forms.View CreateCellView(object item)
        {
            var view = (View)this.ItemTemplate.CreateContent();
            var bindableObject = (BindableObject)view;

            if (bindableObject != null)
            {
                bindableObject.BindingContext = item;
            }

            return view;
        }



    }
    }
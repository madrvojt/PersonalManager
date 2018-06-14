using PersonalManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PersonalManager.Views
{
    public class FloatingActionButtonView : Button
    {

        public static readonly BindableProperty ImageNameProperty = BindableProperty.Create(nameof(ImageName), typeof(string), typeof(FloatingActionButtonView), null);

        public string ImageName
        {
            get { return (string)GetValue(ImageNameProperty); }
            set { SetValue(ImageNameProperty, value); }
        }



        public static readonly BindableProperty ButtonColorProperty = BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(FloatingActionButtonView), Color.White);

        public Color ButtonColor
        {
            get { return (Color)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }


    }
}

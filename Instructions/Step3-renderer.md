#  Personal manager workshop (Part 3)

## Creating FAB (Floating action button for Android)


### 1. Create views in multiplatformč part

* Views/FloatingActionButtonView 

```csharp

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
```

### 2. Create custom renderer

* Renderers/FloatingActionButtonViewRenderer

https://github.com/madrvojt/PersonalManager/blob/master/PersonalManager/PersonalManager.Android/Renderers/FloatingActionButtonViewRenderer.cs




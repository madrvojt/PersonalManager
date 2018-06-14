#  Personal manager workshop (Part 3)

## Creating FAB (Floating action button for Android)


### 1. Create views in multiplatform part

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

[Complete Android custom renderer](https://github.com/madrvojt/PersonalManager/blob/master/PersonalManager/PersonalManager.Android/Renderers/FloatingActionButtonViewRenderer.cs)

### 3. Update Tasks and Contact Page

*  Tasks Page
```csharp
 <AbsoluteLayout HorizontalOptions="Fill" VerticalOptions="Fill">
        <ListView x:Name="TasksListView" AbsoluteLayout.LayoutFlags="All" AbsoluteLayout.LayoutBounds="0, 0, 1, 1">
        </ListView>
        <views:FloatingActionButtonView x:Name="FloatingButton" Clicked="Button_Clicked" AbsoluteLayout.LayoutFlags="PositionProportional" AbsoluteLayout.LayoutBounds="1, 1, AutoSize, AutoSize" ButtonColor="Blue" ImageName="add"/>
    </AbsoluteLayout>
```

*  Contact Page

```csharp
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:views="clr-namespace:PersonalManager.Views"
             x:Class="PersonalManager.Pages.ContactsPage">
    <AbsoluteLayout HorizontalOptions="Fill" VerticalOptions="Fill">
        <ListView x:Name="TasksListView" AbsoluteLayout.LayoutFlags="All" AbsoluteLayout.LayoutBounds="0, 0, 1, 1"/>
        <views:FloatingActionButtonView x:Name="FloatingButton" Clicked="Button_Clicked" AbsoluteLayout.LayoutFlags="PositionProportional" AbsoluteLayout.LayoutBounds="1, 1, AutoSize, AutoSize" ButtonColor="Blue" ImageName="add"/>
    </AbsoluteLayout>
```

</ContentPage>



### 4. Add picture XML to Android Resources/Drawable

https://github.com/madrvojt/PersonalManager/blob/master/PersonalManager/PersonalManager.Android/Resources/drawable/add.xml

### 5. Add button click to codebehind (Contact page , Tasks page)

```csharp
 private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTaskPage());
        }
```







# Personal manager workshop (Part 1)


## 1. Create Project & Select Xamarin

![](../Resources/Screenshots/Screenshot_01.png)

* Visual Studio -> File -> New -> Project

## 2. Select CrossPlatforms Settings
* Prefered Xamarin Forms & .NET Standard (Version 2.0)

![](../Resources/Screenshots/Screenshot_02.png)



## 3. Create new Pages

* Create folder Pages
* Add 3 pages to folder (TasksPage, ContactsPage, AboutPage)

![](../Resources/Screenshots/Screenshot_04.png)

* Pages -> Add -> New Item -> ContentPage (Not C#!)


![](../Resources/Screenshots/Screenshot_06.png)

## 4. Update MainPage to TabbedPage

### Part 1

* Open MainPage.xaml screen

![](../Resources/Screenshots/Screenshot_03.png)

* Change ContentPage to TappedPage
* Remove ContentPage content
* Add TappedPage screens
* Add Namespace to:
```
xmlns:local="clr-namespace:PersonalManager.Pages"
```
![](../Resources/Screenshots/Screenshot_05.png)

### Part 2

* Open MainPage.xaml.cs 
* Change Content page to TappedPage

![](../Resources/Screenshots/Screenshot_07.png)


## 5. Start the app

![](../Resources/Screenshots/Screenshot_08.png)
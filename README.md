# Xamarin-SmoothBottomBar
A lightweight Xamarin.Android material bottom navigation bar library. Based on [ibrahimsn98](https://github.com/ibrahimsn98/SmoothBottomBar)'s version.

|  Package  |Latest Release|
|:----------|:------------:|
|**Xamarin-SmoothBottomBar**|[![NuGet Badge Xamarin-MaterialSearchBar](https://buildstats.info/nuget/Xamarin-SmoothBottomBar)](https://www.nuget.org/packages/Xamarin-SmoothBottomBar/)|

## GIF

<img src="https://cdn.dribbble.com/users/1015191/screenshots/6251784/snapp---animation.gif"/>

## Design Credits

All design and inspiration credits belong to [Alejandro Ausejo](https://dribbble.com/shots/6251784-Navigation-Menu-Animation).

## Usage

-   Create menu.xml under your res/menu/ folder
```xml
<?xml version="1.0" encoding="utf-8"?>
<menu xmlns:android="http://schemas.android.com/apk/res/android">

    <item
        android:id="@+id/item0"
        android:title="@string/menu_dashboard"
        android:icon="@drawable/ic_dashboard_white_24dp"/>

    <item
        android:id="@+id/item1"
        android:title="@string/menu_leaderboard"
        android:icon="@drawable/ic_multiline_chart_white_24dp"/>

    <item
        android:id="@+id/item2"
        android:title="@string/menu_store"
        android:icon="@drawable/ic_store_white_24dp"/>

    <item
        android:id="@+id/item3"
        android:title="@string/menu_profile"
        android:icon="@drawable/ic_person_outline_white_24dp"/>

</menu>
```

-   Add view into your layout file
```xml
<me.ibrahimsn.lib.SmoothBottomBar
    android:id="@+id/bottomBar"
    android:layout_width="match_parent"
    android:layout_height="70dp"
    app:backgroundColor="@color/colorPrimary"
    app:menu="@menu/menu_bottom"/>
```

## **Use SmoothBottomBar with [Navigation Components](https://developer.android.com/guide/navigation/).**

Coupled with the Navigation Component from the [Android Jetpack](https://developer.android.com/jetpack), SmoothBottomBar offers easier navigation within your application by designating navigation to the Navigation Component. This works best when using fragments, as the Navigation component helps to handle your fragment transactions.

- Setup Navigation Component i.e. Add dependenccy to your project, create a Navigation Graph etc.
- For each Fragment in your Navigation Graph, ensure that the Fragment's `id` is the same as the MenuItems in your Menu i.e res/menu/ folder
```xml
<?xml version="1.0" encoding="utf-8"?>
<menu xmlns:android="http://schemas.android.com/apk/res/android">

    <item
        android:id="@+id/first_fragment"
        android:title="@string/menu_dashboard"
        android:icon="@drawable/ic_dashboard_white_24dp"/>

    <item
        android:id="@+id/second_fragment"
        android:title="@string/menu_leaderboard"
        android:icon="@drawable/ic_multiline_chart_white_24dp"/>

    <item
        android:id="@+id/third_fragment"
        android:title="@string/menu_store"
        android:icon="@drawable/ic_store_white_24dp"/>

    <item
        android:id="@+id/fourth_fragment"
        android:title="@string/menu_profile"
        android:icon="@drawable/ic_person_outline_white_24dp"/>

</menu>
```

Navigation Graph i.e res/navigation/ folder
```xml
<?xml version="1.0" encoding="utf-8"?>
<navigation xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:id="@+id/nav_graph"
    app:startDestination="@id/first_fragment">

    <fragment
        android:id="@+id/first_fragment"
        android:name="[YOUR_NAMESPACE].FirstFragment"
        android:label="First Fragment"
        tools:layout="@layout/fragment_first" />
    <fragment
        android:id="@+id/second_fragment"
        android:name="[YOUR_NAMESPACE].SecondFragment"
        android:label="Second Fragment"
        tools:layout="@layout/fragment_second" />
    <fragment
        android:id="@+id/third_fragment"
        android:name="[YOUR_NAMESPACE].ThirdFragment"
        android:label="Third Fragment"
        tools:layout="@layout/fragment_third" />
    <fragment
        android:id="@+id/fourth_fragment"
        android:name="[YOUR_NAMESPACE].FourthFragment"
        android:label="Fourth Fragment"
        tools:layout="@layout/fragment_fourth" />
</navigation>
```

- In your activity i.e `MainActivity`, override `onCreateOptionsMenu`, get a reference to your SmoothBottomBar and call `setupWithNavController()` which takes in a `Menu` and `NavController` on the SmoothBottomBar.
```csharp
public override bool OnCreateOptionsMenu(IMenu menu)
{
	MenuInflater.Inflate(Resource.Menu.menu_bottom, menu);
	if (menu != null)
	{
		BottomBar.SetupWithNavController(menu, NavController);
	}

	return true;
}
```
- You can also setup your `ActionBar` with the Navigation Component
```csharp
private NavController NavController;
private SmoothBottomBar BottomBar;
protected override void OnCreate(Bundle savedInstanceState)
{
	try
	{
		base.OnCreate(savedInstanceState);
		Xamarin.Essentials.Platform.Init(this, savedInstanceState);
		// Set our view from the "main" layout resource
		SetContentView(Resource.Layout.activity_main);
		BottomBar = FindViewById<SmoothBottomBar>(Resource.Id.bottomBar);
		NavController = Navigation.FindNavController(this, Resource.Id.main_fragment);
	}
	catch (System.Exception ex)
	{

	}
}
```

### Result:

<p align="center"><a><img src="https://github.com/mayokunthefirst/SmoothBottomBar/blob/navigation-component-dev/GIF/smooth_bar_gif.gif?raw=true" width="300"></a></p>


## Customization

```xml
<me.ibrahimsn.lib.SmoothBottomBar
        android:id="@+id/bottomBar"
        android:layout_width="match_parent"
        android:layout_height="70dp"
        app:menu=""
        app:backgroundColor=""
        app:indicatorColor=""
        app:indicatorRadius=""
        app:sideMargins=""
        app:itemPadding=""
        app:textColor=""
        app:itemFontFamily=""
        app:textSize=""
        app:iconSize=""
        app:iconTint=""
        app:iconTintActive=""
        app:activeItem=""
        app:duration="" />
```

## License

```
MIT License

Copyright (c) 2019 İbrahim Süren and Federico Navarrete

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```


> Follow me on LinkedIn [@fanmixco](https://www.linkedin.com/in/fanmixco/)

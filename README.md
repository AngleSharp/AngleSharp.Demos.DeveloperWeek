# AngleSharp.Demos.DeveloperWeek

Demo application with samples as shown at the Developer Week conference in June 2015.

## Using the demo

The demo application consists of several projects. The main application can be found in the *AngleSharp.Demos.DeveloperWeek.App* project. This is a WPF application and can therefore only run on Windows. The sample code, however, can be executed on any platform that supports AngleSharp.

You can find the main sample code in the *AngleSharp.Demos.DeveloperWeek.Samples* project. This one is a PCL with the same target as AngleSharp. It is therefore easy to apply the code to other platforms.

The sample website, which can be found in *AngleSharp.Demos.DeveloperWeek.Website*, is an ASP.NET MVC web application. The purpose of this project is to provide a base for demoing some of AngleSharp's capabilities, such as:

* Handling document requests
* Dynamic loading of resources
* Navigating to links in a webpage
* Submitting forms
* Handling cookies (e.g., login to a webpage)

If you have anything to add to the samples, then feel free to do so. Push requests are always highly appreciated.

## Video of the Demo

The demo has been shown at a talk given at a conference in Nuremberg, Germany. The talk is freely available at [Channel 9 from Microsoft](https://channel9.msdn.com/events/community-germany/Developer-Week/Modern-DOM-manipulation-with-Csharp).

<iframe src="https://channel9.msdn.com/Events/community-germany/Developer-Week/Modern-DOM-manipulation-with-Csharp/player" width="960" height="540" allowFullScreen frameBorder="0"></iframe>

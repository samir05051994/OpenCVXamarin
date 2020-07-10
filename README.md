**integrate Opencv with Xamarin**

1) Clone the .github from "https://github.com/Kawaian/OpenCvSharp" 
2) Copy the solution file to your project
3) add "src" folder to your solution
4) add .so file 
"OpenCvSharp",
"OpenCvSharp.Android",
"OpenCvSharp.Windows",
"OpenCvSharpExtern",
"OpenCvSharpExternDroid"
5) ** Convert PCL project to .netStandard **

A) Unload your PCL project (right click -- unload), and start editing it (right -> click edit)
B) Delete Everything in the csproj and insert this:
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <!--<PackageReference Include="" Version=""/>-->
  </ItemGroup>

</Project>
C) Add back NuGets (simply open packages.config, and add the package references above, or via the NuGet package manager.
D) Delete AssemblyInfo.cs (this is now in the csproj) and packages.config (also in csproj via PackageReference)

**End Convert PCL project to .netStandard **

6) add a reference to your project
	A) To your xamarin.form project 
		-OpenCvSharp
		-OpenCvSharp.Android
	B) To your Xamarin.Android project
		-OpenCvSharp
		-OpenCvSharp.Android

7) ready to use

How to Convert image

Step 1 Grayscale
Step 2 Blur the image
Step 3 find edges (Canny and Dilate)
Step 4 Find Contour with 4 points (rectangle) with the largest area (find the doc edges)
Steps 4.1 find the max size of contour area (entire image) 
Steps 5: apply the four-point transform to obtain a top-down
Step 6: grayscale it to give it that 'black and white' paper effect

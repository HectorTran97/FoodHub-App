﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(FoodHub.Droid.FileManager))]
namespace FoodHub.Droid
{
    class FileManager : IFileManager
    {
        public void DeleteFile(string source)
        {
            File.Delete(source);
        }
    }
}
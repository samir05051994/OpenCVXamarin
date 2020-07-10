using System.IO;
using Xamarin.Forms;
using Environment1 = Android.OS.Environment;
using Environment = System.Environment;
using uri1 = Android.Net.Uri;
using supp = Android.Support;
using andApp = Android.App;
using andwebkit = Android.Webkit;
using andNet = Android.Net;
using andContent = Android.Content;
using Java.IO;
using Xamarin.Essentials;
using Android.Content;
using DocScanOpenCV.Droid.Utils;
using DocScanOpenCV.Utils;

[assembly: Dependency(typeof(SaveViewFileAndroid))]
namespace DocScanOpenCV.Droid.Utils
{
    public class SaveViewFileAndroid : ISaveViewFile
    {
        [System.Obsolete]
        public string SaveAndViewAsync(string filename, MemoryStream stream)
        {
            try
            {
                string root = null;
                if (Environment1.IsExternalStorageEmulated)
                {
                    root = Environment1.ExternalStorageDirectory.ToString();

                }
                else
                    root = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //Create directory and file 
                Java.IO.File myDir = new Java.IO.File(root + "/DocScanOpenCV");
                myDir.Mkdir();
                Java.IO.File myDir1 = new Java.IO.File(root + "/DocScanOpenCV/Docs");
                myDir1.Mkdir();

                Java.IO.File file = new Java.IO.File(myDir1, filename);

                //Remove if the file exists
                if (file.Exists()) file.Delete();

                //Write the stream into the file
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(stream.ToArray());

                outs.Flush();
                outs.Close();


                if (file.Exists())
                {
                    uri1 path = supp.V4.Content.FileProvider.GetUriForFile(andApp.Application.Context, AppInfo.PackageName + ".fileprovider", file);
                    string extension = andwebkit.MimeTypeMap.GetFileExtensionFromUrl(andNet.Uri.FromFile(file).ToString());
                    string mimeType = andwebkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);

                    Intent openFile = new Intent();
                    openFile.SetFlags(ActivityFlags.NewTask);
                    openFile.SetFlags(ActivityFlags.GrantReadUriPermission);
                    openFile.SetAction(andContent.Intent.ActionView);
                    openFile.SetDataAndType(path, mimeType);
                    Xamarin.Forms.Forms.Context.StartActivity(Intent.CreateChooser(openFile, "Choose App"));

                }
                return "Finish";
            }
            catch (System.Exception ex)
            {
                string d = ex.ToString();
                return "Error";
                //
            }
        }
    }
}
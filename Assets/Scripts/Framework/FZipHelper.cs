using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;

public static class FZipHelper
{
    /// <summary>
    /// 将文件列表压缩成zip格式
    /// </summary>
    /// <param name="outputPath">输出路径</param>
    /// <param name="fileRoot">所有文件所在的根目录</param>
    /// <param name="files">文件名(相对于根目录的相对路径)</param>
    public static void Zip (string zipPath, string fileRoot, IEnumerable<string> files)
    {
        // 'using' statements guarantee the stream is closed properly which is a big source
        // of problems otherwise.  Its exception safe as well which is great.
        using (ZipOutputStream s = new ZipOutputStream (File.Create (zipPath))) {

            s.SetLevel (9); // 0 - store only to 9 - means best compression

            byte[] buffer = new byte[4096];

            foreach (string filename in files) {

                string file = filename;
                if (file.StartsWith (fileRoot) == true) {
                    file = file.Remove (0, fileRoot.Length + 1);
                }

                // Using GetFileName makes the result compatible with XP
                // as the resulting path is not absolute.
                ZipEntry entry = new ZipEntry (file);

                // Setup the entry data as required.

                // Crc and size are handled by the library for seakable streams
                // so no need to do them here.

                // Could also use the last write time or similar for the file.
                entry.DateTime = System.DateTime.Now;
                s.PutNextEntry (entry);

                using (FileStream fs = File.OpenRead (fileRoot + "/" + file)) {

                    // Using a fixed size buffer here makes no noticeable difference for output
                    // but keeps a lid on memory usage.
                    int sourceBytes;
                    do {
                        sourceBytes = fs.Read (buffer, 0, buffer.Length);
                        s.Write (buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }
            }

            // Finish/Close arent needed strictly as the using statement does this automatically

            // Finish is important to ensure trailing information for a Zip file is appended.  Without this
            // the created file would be invalid.
            s.Finish ();

            // Close is important to wrap things up and unlock the file.
            s.Close ();
        }
    }

    public static void UnZip (string zipPath, string outputPath)
    {

        using (ZipInputStream s = new ZipInputStream (File.OpenRead (zipPath))) {

            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry ()) != null) {

                Console.WriteLine (theEntry.Name);

                string absolutePath = outputPath + "/" + theEntry.Name;
                string absoluteDir = Path.GetDirectoryName (absolutePath);

                // create directory
                if (Directory.Exists (absoluteDir) == false) {
                    Directory.CreateDirectory (absoluteDir);
                }

                //                Debug.Log ("unzip : " + absolutePath);
                using (FileStream streamWriter = File.Create (absolutePath)) {

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true) {
                        size = s.Read (data, 0, data.Length);
                        if (size > 0) {
                            streamWriter.Write (data, 0, size);
                        } else {
                            break;
                        }
                    }
                }
            }
        }
    }

}


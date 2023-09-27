using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ComptaParaules.Model
{
    internal class ComptadorParaules
    {
        public async Task carregaArxiuAsync(String arxiu)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri($"ms-appx:///Assets/{arxiu}"));
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                while (streamReader.Peek() >= 0)
                {
                    Debug.WriteLine(string.Format("the line is {0}",
                        streamReader.ReadLine()));
                }
            }
        }
    }
}

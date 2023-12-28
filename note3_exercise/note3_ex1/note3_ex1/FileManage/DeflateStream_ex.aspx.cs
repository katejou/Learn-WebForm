using System;
using System.IO;
using System.IO.Compression;

namespace note3_ex1.FileManage
{
    public partial class DeflateStream_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 107
        }

        /// <summary>
        /// 加壓時用
        /// </summary>
        /// <returns></returns>
        private byte[] ByteAry_In_Compress_Out(byte[] doc)
        {
            using (MemoryStream inmemory = new MemoryStream())
            {
                DeflateStream def = new DeflateStream(inmemory, CompressionMode.Compress);
                def.Write(doc, 0, doc.Length);
                def.Flush();
                def.Close();
                // def 將 doc 加壓寫到 inmemory , inmemory 再化為 byte[]
                return inmemory.ToArray();
            }
        }

        /// <summary>
        /// 解壓時用
        /// </summary>
        private void DecompressStream(Stream input, Stream output)
        {
            // 因為 Stream 是 Object 所以不用特注意輸出輸入的保留。
            using (MemoryStream inmemory = new MemoryStream())
            {
                DeflateStream def = new DeflateStream(input, CompressionMode.Decompress);
                Byte[] buffer = new Byte[1024];
                int readLength;
                do
                {
                    readLength = def.Read(buffer, 0, 1024);
                    inmemory.Write(buffer, 0, readLength);
                    Array.Clear(buffer, 0, 1024);
                } while (readLength == 1024);

                inmemory.Flush();
                inmemory.WriteTo(output);
            }
        }

        protected void Compress_Click(object sender, EventArgs e)
        {
            String fileName = Path.Combine(Server.MapPath("."), "OriginalFile.txt");
            if (!File.Exists(fileName))
            {
                Label1.Text = "檔案不存在";
                return;
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                int fileLength = (int)fs.Length;
                Byte[] originalData = new Byte[fileLength];
                fs.Read(originalData, 0, fileLength);
                fs.Close();
                
                // 轉化 byte Arrary
                byte[] output = ByteAry_In_Compress_Out(originalData);
                FileStream outputFile = new FileStream(fileName.Replace("txt", "def"), FileMode.Create, FileAccess.Write);
                outputFile.Write(output, 0, output.Length);
                outputFile.Close();
            }

            Label1.Text = "壓縮檔案(OriginalFile.def) 生成 OK";
        }

        protected void DeCompress_Click(object sender, EventArgs e)
        {
            String fileName = Path.Combine(Server.MapPath("."), "OriginalFile.def");
            if (!File.Exists(fileName))
            {
                Label2.Text = "檔案不存在";
                return;
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                String outputFN = fileName.Replace(Path.GetFileName(fileName), Path.GetFileNameWithoutExtension(fileName) + "2.txt");
                //if (File.Exists(outputFN))File.Delete(outputFN); // <-- 會自動覆蓋，不用刪。
                FileStream outputFS = new FileStream(outputFN, FileMode.Create, FileAccess.Write);
                
                //將這個打開的檔案 -> 解壓 -> 開及寫到 新檔
                DecompressStream(fs, outputFS);
                outputFS.Close(); 
            }

            Label2.Text = "「解」壓縮檔案(OriginalFile2.txt) 生成 OK";
        }

    }
}
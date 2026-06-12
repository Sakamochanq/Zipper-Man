using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Zipper_Man.utils
{
    internal class zip
    {
        public void Extract(string zipFolder, string extractFolder, string encodingName)
        {
            Encoding encoding = Encoding.GetEncoding(str2Code(encodingName));

            // ZIPファイルの一覧を取得
            string[] zipFiles = Directory.GetFiles(zipFolder, "*.zip");


            // 各ZIPファイルを解凍
            foreach (string zipFile in zipFiles)
            {
                // ZIPファイル名から拡張子を除いたフォルダ名を作成
                string folderName = Path.GetFileNameWithoutExtension(zipFile);

                // 解凍先のパスを作成
                string destination = Path.Combine(extractFolder, folderName);

                // 解凍先のフォルダが存在しない場合は作成
                Directory.CreateDirectory(destination);

                // ZIPファイルを解凍
                ZipFile.ExtractToDirectory(zipFile, destination, encoding);
            }
        }

        // 文字コードを数値に変換
        private int str2Code(string encodingName)
        {
            switch (encodingName.ToUpper())
            {
                case "UTF-8":
                    return 65001;

                case "Shift-JIS":
                    return 932;

                case "EUC-JP":
                    return 51932;

                default:
                    throw new ArgumentException($"Bonk!");
            }
        }
    }
}

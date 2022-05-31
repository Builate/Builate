// DataOperation.cs

using System.Text;
using System.IO;
using System.IO.Compression;

namespace KYapp.Builate
{
    /// <summary>
    /// �f�t���[�g�A���S���Y�����g�p�����f�[�^���k�E�𓀋@�\���`���܂��B
    /// </summary>
    public static class DataOperation
    {
        /// <summary>
        /// ����������k���o�C�i����Ƃ��ĕԂ��܂��B
        /// </summary>
        public static byte[] CompressFromStr(string message) => Compress(Encoding.UTF8.GetBytes(message));

        /// <summary>
        /// �o�C�i�������k���܂��B
        /// </summary>
        public static byte[] Compress(byte[] src)
        {
            using (var ms = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Compress, true/*ms��*/))
                {
                    ds.Write(src, 0, src.Length);
                }

                // ���k�������e��byte�z��ɂ��Ď��o��
                ms.Position = 0;
                byte[] comp = new byte[ms.Length];
                ms.Read(comp, 0, comp.Length);
                return comp;
            }
        }

        /// <summary>
        /// ���k�f�[�^�𕶎���Ƃ��ĕ������܂��B
        /// </summary>
        public static string DecompressToStr(byte[] src) => Encoding.UTF8.GetString(Decompress(src));

        /// <summary>
        /// ���k�ς݂̃o�C�g����𓀂��܂��B
        /// </summary>
        public static byte[] Decompress(byte[] src)
        {
            using (var ms = new MemoryStream(src))
            using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
            {
                using (var dest = new MemoryStream())
                {
                    ds.CopyTo(dest);

                    dest.Position = 0;
                    byte[] decomp = new byte[dest.Length];
                    dest.Read(decomp, 0, decomp.Length);
                    return decomp;
                }
            }
        }
    }
}
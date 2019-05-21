using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Polenter.Serialization;

namespace REvernus.Utilities
{
    public static class Serializer
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Tries to serialize an object to a file provided. If the file path does not exist, it will create it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public static bool SerializeData<T>(T data, string path)
        {
            try
            {
                // Check if the parent directory of the file exist, if not, create it.
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }

                if (data != null)
                {
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fileStream, data);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        /// <summary>
        /// Tries to deserialize data into the type given.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeserializeData<T>(string path)
        {
            try
            {
                var fileStream = new FileStream(path, FileMode.Open);
                var binaryFormatter = new BinaryFormatter();
                var result = binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                return (T) result;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return default;
            }
        }
    }
}

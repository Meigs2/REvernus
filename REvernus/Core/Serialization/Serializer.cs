using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace REvernus.Core.Serialization
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
        public static void SerializeData<T>(T data, string path)
        {
            // Check if the parent directory of the file exist, if not, create it.
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            var fileStream = new FileStream(path, FileMode.Create);

            if (data != null)
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, data);
                    fileStream.Close();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        /// <summary>
        /// Tries to deserialize data into the type given.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object DeserializeData<T>(string path)
        {
            var fileStream = new FileStream(path, FileMode.Open);
            try
            {
                var binaryFormatter = new BinaryFormatter();
                var result = (T) binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                return result;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }
    }
}

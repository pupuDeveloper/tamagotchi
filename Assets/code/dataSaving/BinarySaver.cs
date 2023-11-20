using System.IO;

{
    public class BinarySaver
    {
        private BinaryReader _reader;
        private BinaryWriter _writer;

        //called before reading the data from the save file. Opens the filestream and creates the binary reader
        public bool PrepareRead(string path)
        {
            //check if save file Exists
            if (!File.Exists(path))
            {
                return false;
            }

            try
            {
                _fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
                _reader = new BinaryReader(_fileStream);
            }
            catch(Exception e)
            {
                Debug.LogException(e);
                return false;
            }
            return true;
        }
        
        // Called after all data is read from the file to release the save file and memory
        public void FinalizeRead()
        {
            _reader.Close();
            _fileStream.Close();

            _reader = null;
            _fileStream = null;
        }

        public bool PrepareWrite(string path)
        {
            try
            {
                string directory
            }
        }
        private FileStream _fileStream;

        #region Reading
        public int ReadInt()
        {
            return _reader.ReadInt32();
        }
        public float ReadFloat()
        {
            return _reader.ReadSingle();
        }
        public bool ReadBool()
        {
            return _reader.ReadBoolean();
        }
        public string ReadString()
        {
            return _reader.ReadString();
        }
        #endregion

        #region Writing
        public void WriteInt(int value)
        {
            _writer.Write(value);
        }
        public void WriteFloat(float value)
        {
            _writer.Write(value);
        }
        public void WriteBool(bool value)
        {
            _writer.Write(value);
        }
        public void WriteString(string value)
        {
            _writer.Write(value);
        }
        #endregion
    }
}
using System.IO;

{
    public class BinarySaver
    {
        private BinaryReader _reader;
        private BinaryWriter _writer;
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
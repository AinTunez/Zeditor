﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using Crypto = System.Security.Cryptography;

namespace SoulsFormats
{
    /// <summary>
    /// An extended writer for binary data supporting big and little endianness, value reservation, and arrays.
    /// </summary>
    public class BinaryWriterEx
    {
        private static readonly Encoding ASCII = Encoding.ASCII;
        private static readonly Encoding ShiftJIS = Encoding.GetEncoding("shift-jis");
        private static readonly Encoding UTF16 = Encoding.Unicode;
        private static readonly Encoding UTF16BE = Encoding.BigEndianUnicode;
        private static readonly Crypto.MD5 MD5 = Crypto.MD5.Create();

        private BinaryWriter bw;
        private Stack<long> steps;
        private Dictionary<string, long> reservations;

        /// <summary>
        /// Interpret values as big-endian if set, or little-endian if not.
        /// </summary>
        public bool BigEndian;

        /// <summary>
        /// The underlying stream.
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// Gets the MD5 hash of the current stream's bytes from beginning to end.
        /// </summary>
        public string GetMD5HashOfStream()
        {
            StepIn(0);
            var hash = MD5.ComputeHash(Stream);
            StepOut();
            return string.Join("", hash.Select(x => x.ToString("X2")));
        }

        /// <summary>
        /// The current position of the stream.
        /// </summary>
        public long Position
        {
            get { return Stream.Position; }
            set { Stream.Position = value; }
        }

        /// <summary>
        /// Initializes a new <c>BinaryWriterEx</c> writing to an empty <c>MemoryStream</c>
        /// </summary>
        public BinaryWriterEx(bool bigEndian) : this(bigEndian, new MemoryStream()) { }

        /// <summary>
        /// Initializes a new <c>BinaryWriterEx</c> writing to the specified stream.
        /// </summary>
        public BinaryWriterEx(bool bigEndian, Stream stream)
        {
            BigEndian = bigEndian;
            steps = new Stack<long>();
            reservations = new Dictionary<string, long>();
            Stream = stream;
            bw = new BinaryWriter(stream);
        }

        private void WriteReversedBytes(byte[] bytes)
        {
            Array.Reverse(bytes);
            bw.Write(bytes);
        }

        private void Reserve(string name, string typeName, int bytes)
        {
            name += ":" + typeName;
            if (reservations.ContainsKey(name))
                throw new ArgumentException("Key already reserved: " + name);

            reservations[name] = Stream.Position;
            for (int i = 0; i < bytes; i++)
                WriteByte(0xFE);
        }

        private void Fill<T>(Action<T> writeValue, string name, string typeName, T value)
        {
            name += ":" + typeName;
            if (!reservations.ContainsKey(name))
                throw new ArgumentException("Key is not reserved: " + name);

            StepIn(reservations[name]);
            writeValue(value);
            StepOut();
            reservations.Remove(name);
        }

        /// <summary>
        /// Verify that all reservations are filled and close the stream.
        /// </summary>
        public void Finish()
        {
            if (reservations.Count > 0)
            {
                throw new InvalidOperationException("Not all reservations filled: " + string.Join(", ", reservations.Keys));
            }
            bw.Close();
        }

        /// <summary>
        /// Verify that all reservations are filled, close the stream, and return the written data as an array of bytes.
        /// </summary>
        public byte[] FinishBytes()
        {
            MemoryStream ms = (MemoryStream)Stream;
            byte[] result = ms.ToArray();
            Finish();
            return result;
        }

        /// <summary>
        /// Store the current position of the stream on a stack, then move to the specified offset.
        /// </summary>
        public void StepIn(long offset)
        {
            steps.Push(Stream.Position);
            Stream.Position = offset;
        }

        /// <summary>
        /// Restore the previous position of the stream from a stack.
        /// </summary>
        public void StepOut()
        {
            if (steps.Count == 0)
                throw new InvalidOperationException("Writer is already stepped all the way out.");

            Stream.Position = steps.Pop();
        }

        /// <summary>
        /// Writes 0x00 bytes until the stream position meets the specified alignment.
        /// </summary>
        public void Pad(int align)
        {
            while (Stream.Position % align > 0)
                WriteByte(0);
        }

        #region Boolean
        /// <summary>
        /// Writes a one-byte boolean value.
        /// </summary>
        public void WriteBoolean(bool value)
        {
            bw.Write(value);
        }

        /// <summary>
        /// Writes an array of one-byte boolean values.
        /// </summary>
        public void WriteBooleans(IList<bool> values)
        {
            foreach (bool value in values)
                WriteBoolean(value);
        }

        /// <summary>
        /// Reserves the current position and advance the stream by one byte.
        /// </summary>
        public void ReserveBoolean(string name)
        {
            Reserve(name, "Boolean", 1);
        }

        /// <summary>
        /// Writes a one-byte boolean value to a reserved position.
        /// </summary>
        public void FillBoolean(string name, bool value)
        {
            Fill(WriteBoolean, name, "Boolean", value);
        }
        #endregion

        #region SByte
        /// <summary>
        /// Writes a one-byte signed integer.
        /// </summary>
        public void WriteSByte(sbyte value)
        {
            bw.Write(value);
        }

        /// <summary>
        /// Writes an array of one-byte signed integers.
        /// </summary>
        public void WriteSBytes(IList<sbyte> values)
        {
            foreach (sbyte value in values)
                WriteSByte(value);
        }

        /// <summary>
        /// Reserves the current position and advance the stream by one byte.
        /// </summary>
        public void ReserveSByte(string name)
        {
            Reserve(name, "SByte", 1);
        }

        /// <summary>
        /// Writes a one-byte signed integer to a reserved position.
        /// </summary>
        public void FillSByte(string name, sbyte value)
        {
            Fill(WriteSByte, name, "SByte", value);
        }
        #endregion

        #region Byte
        /// <summary>
        /// Writes a one-byte unsigned integer.
        /// </summary>
        public void WriteByte(byte value)
        {
            bw.Write(value);
        }

        /// <summary>
        /// Writes an array of one-byte unsigned integers.
        /// </summary>
        public void WriteBytes(byte[] bytes)
        {
            bw.Write(bytes);
        }

        /// <summary>
        /// Writes an array of one-byte unsigned integers.
        /// </summary>
        public void WriteBytes(IList<byte> values)
        {
            foreach (byte value in values)
                WriteByte(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by one byte.
        /// </summary>
        public void ReserveByte(string name)
        {
            Reserve(name, "Byte", 1);
        }

        /// <summary>
        /// Writes a one-byte unsigned integer to a reserved position.
        /// </summary>
        public void FillByte(string name, byte value)
        {
            Fill(WriteByte, name, "Byte", value);
        }
        #endregion

        #region Int16
        /// <summary>
        /// Writes a two-byte signed integer.
        /// </summary>
        public void WriteInt16(short value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of two-byte signed integers.
        /// </summary>
        public void WriteInt16s(IList<short> values)
        {
            foreach (short value in values)
                WriteInt16(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by two bytes.
        /// </summary>
        public void ReserveInt16(string name)
        {
            Reserve(name, "Int16", 2);
        }

        /// <summary>
        /// Writes a two-byte signed integer to a reserved position.
        /// </summary>
        public void FillInt16(string name, short value)
        {
            Fill(WriteInt16, name, "Int16", value);
        }
        #endregion

        #region UInt16
        /// <summary>
        /// Writes a two-byte unsigned integer.
        /// </summary>
        public void WriteUInt16(ushort value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of two-byte unsigned integers.
        /// </summary>
        public void WriteUInt16s(IList<ushort> values)
        {
            foreach (ushort value in values)
                WriteUInt16(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by two bytes.
        /// </summary>
        public void ReserveUInt16(string name)
        {
            Reserve(name, "UInt16", 2);
        }

        /// <summary>
        /// Writes a two-byte unsigned integer to a reserved position.
        /// </summary>
        public void FillUInt16(string name, ushort value)
        {
            Fill(WriteUInt16, name, "UInt16", value);
        }
        #endregion

        #region Int32
        /// <summary>
        /// Writes a four-byte signed integer.
        /// </summary>
        public void WriteInt32(int value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of four-byte signed integers.
        /// </summary>
        public void WriteInt32s(IList<int> values)
        {
            foreach (int value in values)
                WriteInt32(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by four bytes.
        /// </summary>
        public void ReserveInt32(string name)
        {
            Reserve(name, "Int32", 4);
        }

        /// <summary>
        /// Writes a four-byte signed integer to a reserved position.
        /// </summary>
        public void FillInt32(string name, int value)
        {
            Fill(WriteInt32, name, "Int32", value);
        }
        #endregion

        #region UInt32
        /// <summary>
        /// Writes a four-byte unsigned integer.
        /// </summary>
        public void WriteUInt32(uint value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of four-byte unsigned integers.
        /// </summary>
        public void WriteUInt32s(IList<uint> values)
        {
            foreach (uint value in values)
                WriteUInt32(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by four bytes.
        /// </summary>
        public void ReserveUInt32(string name)
        {
            Reserve(name, "UInt32", 4);
        }

        /// <summary>
        /// Writes a four-byte unsigned integer to a reserved position.
        /// </summary>
        public void FillUInt32(string name, uint value)
        {
            Fill(WriteUInt32, name, "UInt32", value);
        }
        #endregion

        #region Int64
        /// <summary>
        /// Writes an eight-byte signed integer.
        /// </summary>
        public void WriteInt64(long value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of eight-byte signed integers.
        /// </summary>
        public void WriteInt64s(IList<long> values)
        {
            foreach (long value in values)
                WriteInt64(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by eight bytes.
        /// </summary>
        public void ReserveInt64(string name)
        {
            Reserve(name, "Int64", 8);
        }

        /// <summary>
        /// Writes an eight-byte signed integer to a reserved position.
        /// </summary>
        public void FillInt64(string name, long value)
        {
            Fill(WriteInt64, name, "Int64", value);
        }
        #endregion

        #region UInt64
        /// <summary>
        /// Writes an eight-byte unsigned integer.
        /// </summary>
        public void WriteUInt64(ulong value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of eight-byte unsigned integers.
        /// </summary>
        public void WriteUInt64s(IList<ulong> values)
        {
            foreach (ulong value in values)
                WriteUInt64(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by eight bytes.
        /// </summary>
        public void ReserveUInt64(string name)
        {
            Reserve(name, "UInt64", 8);
        }

        /// <summary>
        /// Writes an eight-byte unsigned integer to a reserved position.
        /// </summary>
        public void FillUInt64(string name, ulong value)
        {
            Fill(WriteUInt64, name, "UInt64", value);
        }
        #endregion

        #region Single
        /// <summary>
        /// Writes a four-byte floating point number.
        /// </summary>
        public void WriteSingle(float value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of four-byte floating point numbers.
        /// </summary>
        public void WriteSingles(IList<float> values)
        {
            foreach (float value in values)
                WriteSingle(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by four bytes.
        /// </summary>
        public void ReserveSingle(string name)
        {
            Reserve(name, "Single", 4);
        }

        /// <summary>
        /// Writes a four-byte floating point number to a reserved position.
        /// </summary>
        public void FillSingle(string name, float value)
        {
            Fill(WriteSingle, name, "Single", value);
        }
        #endregion

        #region Double
        /// <summary>
        /// Writes an eight-byte floating point number.
        /// </summary>
        public void WriteDouble(double value)
        {
            if (BigEndian)
                WriteReversedBytes(BitConverter.GetBytes(value));
            else
                bw.Write(value);
        }

        /// <summary>
        /// Writes an array of eight-byte floating point numbers.
        /// </summary>
        public void WriteDoubles(IList<double> values)
        {
            foreach (double value in values)
                WriteDouble(value);
        }

        /// <summary>
        /// Reserves the current position and advances the stream by eight bytes.
        /// </summary>
        public void ReserveDouble(string name)
        {
            Reserve(name, "Double", 8);
        }

        /// <summary>
        /// Writes a eight-byte floating point number to a reserved position.
        /// </summary>
        public void FillDouble(string name, double value)
        {
            Fill(WriteDouble, name, "Double", value);
        }
        #endregion

        #region String
        private void WriteChars(string text, Encoding encoding, bool terminate)
        {
            if (terminate)
                text += '\0';
            byte[] bytes = encoding.GetBytes(text);
            bw.Write(bytes);
        }

        /// <summary>
        /// Writes an ASCII string, with null terminator if specified.
        /// </summary>
        public void WriteASCII(string text, bool terminate = false)
        {
            WriteChars(text, ASCII, terminate);
        }

        /// <summary>
        /// Writes a Shift JIS string, with null terminator if specified.
        /// </summary>
        public void WriteShiftJIS(string text, bool terminate = false)
        {
            WriteChars(text, ShiftJIS, terminate);
        }

        /// <summary>
        /// Writes a length-prefixed Shift JIS stream with the specified terminator and aligns the stream to 0x4.
        /// </summary>
        public void WriteShiftJISLengthPrefixed(string text, byte terminator)
        {
            byte[] bytes = ShiftJIS.GetBytes(text);
            WriteInt32(bytes.Length);
            if (bytes.Length > 0)
                WriteBytes(bytes);
            WriteByte(terminator);
            Pad(4);
        }

        /// <summary>
        /// Writes a UTF-16 string, with null terminator if specified.
        /// </summary>
        public void WriteUTF16(string text, bool terminate = false)
        {
            if (BigEndian)
                WriteChars(text, UTF16BE, terminate);
            else
                WriteChars(text, UTF16, terminate);
        }

        /// <summary>
        /// Writes a null-terminated Shift JIS string in a fixed-size field.
        /// </summary>
        public void WriteFixStr(string text, int size, byte padding = 0)
        {
            byte[] fixstr = new byte[size];
            for (int i = 0; i < size; i++)
                fixstr[i] = padding;

            byte[] bytes = ShiftJIS.GetBytes(text + '\0');
            Array.Copy(bytes, fixstr, Math.Min(size, bytes.Length));
            bw.Write(fixstr);
        }

        /// <summary>
        /// Writes a null-terminated UTF-16 string in a fixed-size field.
        /// </summary>
        public void WriteFixStrW(string text, int size, byte padding = 0)
        {
            byte[] fixstr = new byte[size];
            for (int i = 0; i < size; i++)
                fixstr[i] = padding;

            byte[] bytes;
            if (BigEndian)
                bytes = UTF16BE.GetBytes(text + '\0');
            else
                bytes = UTF16.GetBytes(text + '\0');
            Array.Copy(bytes, fixstr, Math.Min(size, bytes.Length));
            bw.Write(fixstr);
        }
        #endregion

        #region Other
        /// <summary>
        /// Writes a vector of two four-byte floating point numbers.
        /// </summary>
        public void WriteVector2(Vector2 vector)
        {
            WriteSingle(vector.X);
            WriteSingle(vector.Y);
        }

        /// <summary>
        /// Writes a vector of three four-byte floating point numbers.
        /// </summary>
        public void WriteVector3(Vector3 vector)
        {
            WriteSingle(vector.X);
            WriteSingle(vector.Y);
            WriteSingle(vector.Z);
        }

        /// <summary>
        /// Writes a vector of four four-byte floating point numbers.
        /// </summary>
        public void WriteVector4(Vector4 vector)
        {
            WriteSingle(vector.X);
            WriteSingle(vector.Y);
            WriteSingle(vector.Z);
            WriteSingle(vector.W);
        }
        #endregion
    }
}

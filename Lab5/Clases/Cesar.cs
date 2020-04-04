using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab5.Clases
{
    class Cesar
    {

        //
        //------------------------------------------------------------Public Funcs------------------------------------------------------------
        //

        public void Encode(string rPath, string wPath, string key)
        {
            Dictionary<byte, byte> Dictionary = GenerateEncryptionDictionary(key);//--------------> Validate that the key doesnt contains repited values.

            using (FileStream Rfile = new FileStream(rPath, FileMode.Open))
            using (BinaryReader BR = new BinaryReader(Rfile))
            using (FileStream Wfile = new FileStream(wPath, FileMode.Create))
            using (BinaryWriter BW = new BinaryWriter(Wfile))
            {
                WriteCyphedText(Dictionary, BR, BW);
            }
        }

        public void Decode(string rPath, string wPath, string key)
        {
            Dictionary<byte, byte> Dictionary = GenerateDecryptionDictionary(key);//--------------> Validate that the key doesnt contains repited values.

            using (FileStream Rfile = new FileStream(rPath, FileMode.Open))
            using (BinaryReader BR = new BinaryReader(Rfile))
            using (FileStream Wfile = new FileStream(wPath, FileMode.Create))
            using (BinaryWriter BW = new BinaryWriter(Wfile))
            {
                WriteCyphedText(Dictionary, BR, BW);
            }
        }

        //
        //------------------------------------------------------------------------------------------------------------------------------------



        //
        //------------------------------------------------------------Private Funcs------------------------------------------------------------
        //

        private Dictionary<byte, byte> GenerateEncryptionDictionary(string key)
        {
            Dictionary<byte, byte> RtrnDict = new Dictionary<byte, byte>();
            byte[] Alphabet = new byte[]
            { 65, 97, 66, 98, 67, 99, 68, 100, 69, 101, 70, 102, 71, 103, 72, 104, 73, 105, 74, 106, 75, 107, 76, 108, 77, 109, 78, 110, 79, 111,
              80, 112, 81, 113, 82, 114, 83, 115, 84, 116, 85, 117, 86, 118, 87, 119, 88, 120, 89, 121, 90, 122};

            for (int i = 0; i < key.Length; i++) RtrnDict.Add(Alphabet[i], (byte)key[i]);

            int counter = key.Length;
            foreach (var item in Alphabet)
            {
                if (!RtrnDict.ContainsValue(item))
                {
                    RtrnDict.Add(Alphabet[counter], item);
                    counter++;
                }
            }

            return RtrnDict;
        }

        private Dictionary<byte, byte> GenerateDecryptionDictionary(string key)
        {
            Dictionary<byte, byte> RtrnDict = new Dictionary<byte, byte>();
            byte[] Alphabet = new byte[]
            {
                65, 97, 66, 98, 67, 99, 68, 100, 69, 101, 70, 102, 71, 103, 72, 104, 73, 105, 74, 106, 75, 107, 76, 108, 77, 109, 78, 110, 79, 111,
                80, 112, 81, 113, 82, 114, 83, 115, 84, 116, 85, 117, 86, 118, 87, 119, 88, 120, 89, 121, 90, 122
            };

            for (int i = 0; i < key.Length; i++) RtrnDict.Add((byte)key[i], Alphabet[i]);

            int counter = key.Length;
            foreach (var item in Alphabet)
            {
                if (!RtrnDict.ContainsKey(item))
                {
                    RtrnDict.Add(item, Alphabet[counter]);
                    counter++;
                }
            }

            return RtrnDict;
        }

        private void WriteCyphedText(Dictionary<byte, byte> Dictionary, BinaryReader br, BinaryWriter bw)
        {
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                byte NewByte = br.ReadByte();
                if (Dictionary.ContainsKey(NewByte)) bw.Write(Dictionary[NewByte]);
                else bw.Write(NewByte);
            }
        }
    }
}

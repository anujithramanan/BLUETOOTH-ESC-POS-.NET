﻿using System;
using System.IO;

namespace ESCPOS_NET
{
    public class FilePrinter : BasePrinter
    {
        private readonly FileStream _file;

        // TODO: default values to their default values in ctor.
        public FilePrinter(string filePath)
            : base()
        {
            _file = File.Open(filePath, FileMode.Open);
            Writer = new BinaryWriter(_file);
            Reader = new BinaryReader(_file);
        }

        ~FilePrinter()
        {
            Dispose(false);
        }

        protected override void OverridableDispose()
        {
            _file?.Close();
            _file?.Dispose();
        }
    }
}

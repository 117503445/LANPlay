﻿using System.Collections.Generic;

namespace LANPlay_Server
{
    public class Client
    {
        public byte ID { get; set; }
        public List<byte> Keys { get; set; } = new List<byte>();

    }
}
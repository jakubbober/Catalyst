﻿using System;
using Akka.Actor;

namespace ADL.DFS
{
    public class DFSActor : UntypedActor
    {
        public static Props Props => Props.Create(() => new DFSActor());
        
        protected override void OnReceive(object message)
        {
            if (!(message is string)) return;
            var msg = (string) message;
            Console.WriteLine($"Message received {msg}");
        }
    }
}

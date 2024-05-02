using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

class EnvCommand
{
    static void Main(string[] args)
    {
        ArgsProcessor.Handle(args);
    }
}

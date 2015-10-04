﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cosmos.Debug.Kernel;
using Cosmos.System.FileSystem.VFS;
using Cosmos.TestRunner;
using Sys = Cosmos.System;

namespace Cosmos.Kernel.Tests.Fat
{
    public class Kernel : Sys.Kernel
    {
        private VFSBase myVFS;

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully, now start testing");
            myVFS = new Sys.SentinelVFS();
            VFSManager.RegisterVFS(myVFS);
        }

        private Debugger mDebugger = new Debugger("User", "Test");

        protected override void Run()
        {
            try
            {
                mDebugger.Send("Run");
                string xContents;
                //Assert.IsTrue(Path.GetDirectoryName(@"0:\test") == @"0:\", @"Path.GetDirectoryName(@'0:\test') == @'0:\'");
                //Assert.IsTrue(Path.GetFileName(@"0:\test") == @"test", @"Path.GetFileName(@'0:\test') == @'test'");

                bool xTest;

                ////Assert.IsTrue(xTest, "Subfolder doesn't exist!");
                //mDebugger.Send("File exist check:");
                //xTest = File.Exists(@"0:\Kudzu.txt");
                //Assert.IsTrue(xTest, @"\Kudzu.txt not found!");

                mDebugger.Send("Directory exist check:");
                xTest = Directory.Exists(@"0:\test");
                Console.WriteLine("After test");
                Assert.IsTrue(xTest, "Folder does not exist!");

                //mDebugger.Send("File contents of Kudzu.txt: ");
                //xContents = File.ReadAllText(@"0:\Kudzu.txt");
                //mDebugger.Send("Contents retrieved");
                //mDebugger.Send(xContents);
                //Assert.IsTrue(xContents == "Hello Cosmos", "Contents of Kudzu.txt was read incorrectly!");

                //mDebugger.Send("Write to file now");
                //File.WriteAllText(@"0:\Kudzu.txt", "Test FAT write.");
                //mDebugger.Send("Text written");
                //xContents = File.ReadAllText(@"0:\Kudzu.txt");

                //mDebugger.Send("Contents retrieved after writing");
                //mDebugger.Send(xContents);
                //Assert.IsTrue(xContents == "Test FAT write.", "Contents of Kudzu.txt was written incorrectly!");

                TestController.Completed();
            }
            catch (Exception E)
            {
                mDebugger.Send("Exception occurred");
                mDebugger.Send(E.Message);
                TestController.Failed();
            }
        }
    }
}
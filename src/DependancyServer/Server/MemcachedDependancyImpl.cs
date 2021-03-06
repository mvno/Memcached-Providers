#region [License]
/**
 Apache License
Version 2.0, January 2004
http://www.apache.org/licenses/

TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION

1. Definitions.

"License" shall mean the terms and conditions for use, reproduction, and distribution as defined by Sections 1 through 9 of this document.

"Licensor" shall mean the copyright owner or entity authorized by the copyright owner that is granting the License.

"Legal Entity" shall mean the union of the acting entity and all other entities that control, are controlled by, or are under common control with that entity. For the purposes of this definition, "control" means (i) the power, direct or indirect, to cause the direction or management of such entity, whether by contract or otherwise, or (ii) ownership of fifty percent (50%) or more of the outstanding shares, or (iii) beneficial ownership of such entity.

"You" (or "Your") shall mean an individual or Legal Entity exercising permissions granted by this License.

"Source" form shall mean the preferred form for making modifications, including but not limited to software source code, documentation source, and configuration files.

"Object" form shall mean any form resulting from mechanical transformation or translation of a Source form, including but not limited to compiled object code, generated documentation, and conversions to other media types.

"Work" shall mean the work of authorship, whether in Source or Object form, made available under the License, as indicated by a copyright notice that is included in or attached to the work (an example is provided in the Appendix below).

"Derivative Works" shall mean any work, whether in Source or Object form, that is based on (or derived from) the Work and for which the editorial revisions, annotations, elaborations, or other modifications represent, as a whole, an original work of authorship. For the purposes of this License, Derivative Works shall not include works that remain separable from, or merely link (or bind by name) to the interfaces of, the Work and Derivative Works thereof.

"Contribution" shall mean any work of authorship, including the original version of the Work and any modifications or additions to that Work or Derivative Works thereof, that is intentionally submitted to Licensor for inclusion in the Work by the copyright owner or by an individual or Legal Entity authorized to submit on behalf of the copyright owner. For the purposes of this definition, "submitted" means any form of electronic, verbal, or written communication sent to the Licensor or its representatives, including but not limited to communication on electronic mailing lists, source code control systems, and issue tracking systems that are managed by, or on behalf of, the Licensor for the purpose of discussing and improving the Work, but excluding communication that is conspicuously marked or otherwise designated in writing by the copyright owner as "Not a Contribution."

"Contributor" shall mean Licensor and any individual or Legal Entity on behalf of whom a Contribution has been received by Licensor and subsequently incorporated within the Work.

2. Grant of Copyright License.

Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable copyright license to reproduce, prepare Derivative Works of, publicly display, publicly perform, sublicense, and distribute the Work and such Derivative Works in Source or Object form.

3. Grant of Patent License.

Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable (except as stated in this section) patent license to make, have made, use, offer to sell, sell, import, and otherwise transfer the Work, where such license applies only to those patent claims licensable by such Contributor that are necessarily infringed by their Contribution(s) alone or by combination of their Contribution(s) with the Work to which such Contribution(s) was submitted. If You institute patent litigation against any entity (including a cross-claim or counterclaim in a lawsuit) alleging that the Work or a Contribution incorporated within the Work constitutes direct or contributory patent infringement, then any patent licenses granted to You under this License for that Work shall terminate as of the date such litigation is filed.

4. Redistribution.

You may reproduce and distribute copies of the Work or Derivative Works thereof in any medium, with or without modifications, and in Source or Object form, provided that You meet the following conditions:

1. You must give any other recipients of the Work or Derivative Works a copy of this License; and

2. You must cause any modified files to carry prominent notices stating that You changed the files; and

3. You must retain, in the Source form of any Derivative Works that You distribute, all copyright, patent, trademark, and attribution notices from the Source form of the Work, excluding those notices that do not pertain to any part of the Derivative Works; and

4. If the Work includes a "NOTICE" text file as part of its distribution, then any Derivative Works that You distribute must include a readable copy of the attribution notices contained within such NOTICE file, excluding those notices that do not pertain to any part of the Derivative Works, in at least one of the following places: within a NOTICE text file distributed as part of the Derivative Works; within the Source form or documentation, if provided along with the Derivative Works; or, within a display generated by the Derivative Works, if and wherever such third-party notices normally appear. The contents of the NOTICE file are for informational purposes only and do not modify the License. You may add Your own attribution notices within Derivative Works that You distribute, alongside or as an addendum to the NOTICE text from the Work, provided that such additional attribution notices cannot be construed as modifying the License.

You may add Your own copyright statement to Your modifications and may provide additional or different license terms and conditions for use, reproduction, or distribution of Your modifications, or for any such Derivative Works as a whole, provided Your use, reproduction, and distribution of the Work otherwise complies with the conditions stated in this License.

5. Submission of Contributions.

Unless You explicitly state otherwise, any Contribution intentionally submitted for inclusion in the Work by You to the Licensor shall be under the terms and conditions of this License, without any additional terms or conditions. Notwithstanding the above, nothing herein shall supersede or modify the terms of any separate license agreement you may have executed with Licensor regarding such Contributions.

6. Trademarks.

This License does not grant permission to use the trade names, trademarks, service marks, or product names of the Licensor, except as required for reasonable and customary use in describing the origin of the Work and reproducing the content of the NOTICE file.

7. Disclaimer of Warranty.

Unless required by applicable law or agreed to in writing, Licensor provides the Work (and each Contributor provides its Contributions) on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied, including, without limitation, any warranties or conditions of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A PARTICULAR PURPOSE. You are solely responsible for determining the appropriateness of using or redistributing the Work and assume any risks associated with Your exercise of permissions under this License.

8. Limitation of Liability.

In no event and under no legal theory, whether in tort (including negligence), contract, or otherwise, unless required by applicable law (such as deliberate and grossly negligent acts) or agreed to in writing, shall any Contributor be liable to You for damages, including any direct, indirect, special, incidental, or consequential damages of any character arising as a result of this License or out of the use or inability to use the Work (including but not limited to damages for loss of goodwill, work stoppage, computer failure or malfunction, or any and all other commercial damages or losses), even if such Contributor has been advised of the possibility of such damages.

9. Accepting Warranty or Additional Liability.

While redistributing the Work or Derivative Works thereof, You may choose to offer, and charge a fee for, acceptance of support, warranty, indemnity, or other liability obligations and/or rights consistent with this License. However, in accepting such obligations, You may act only on Your own behalf and on Your sole responsibility, not on behalf of any other Contributor, and only if You agree to indemnify, defend, and hold each Contributor harmless for any liability incurred by, or claims asserted against, such Contributor by reason of your accepting any such warranty or additional liability. 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Amib.Threading;
using Enyim.Caching;

namespace DependancyServer.Server
{
    internal class MemcachedDependancyImpl : IDependancyServer
    {
        #region Class members and properties
        private TcpListener _objListener;
        private LinkedList<IMemcachedDependancy> _objDependancy;
        private object _objSocketLock = new object();
        private object _objMemDepFileLock = new object();
        private object _objMemDepKeyLock = new object();
        private FileSystemWatcher _objFileSystemWatcher;
        private SmartThreadPool _objThreadPool;
        private Queue<PooledTcpClient> _objClientQueue;
        private IDictionary<string, IMemcachedDependancy> _objMemDepFile;
        private readonly int _iCounterLimit = int.Parse(System.Configuration.ConfigurationManager.AppSettings["counterToExpire"]);
        private static readonly MemcachedClient _objMemcachedClient = new MemcachedClient();
        //private IDictionary<string, IMemcachedDependancy> _objMemDepKey;
        //private System.Timers.Timer _objTimer;        
        #endregion

        #region File events
        void _objFileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File deleted: " + e.FullPath);
        }

        void _objFileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File name changed:" + e.FullPath);
        }

        void _objFileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error File: ");
        }

        void _objFileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Changed File: " + e.FullPath + " ------- " + e.ChangeType + " ---- " + e.Name);
            this._objThreadPool.QueueWorkItem(new WorkItemCallback(ProcessFileEvent), e.Name);
        }

        #endregion

        #region Timer Events

        //void _objTimer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("Event Called: "+ e.SignalTime);

        //    lock (this._objMemDepKeyLock)
        //    {
        //        Console.WriteLine("/***---------------Size of Key Queue: {0}------------------***/", _objMemDepKey.Count);

        //        foreach (IMemcachedDependancy obj in _objMemDepKey.Values)
        //        {
        //            this._objThreadPool.QueueWorkItem(new WorkItemCallback(ProcessKeyEvent),obj.Clone(),WorkItemPriority.AboveNormal); 
        //        }
        //    }
        //}

        #endregion

        #region Constructor

        public MemcachedDependancyImpl()
        {
            this._objListener = new TcpListener(IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["ip"]),
                int.Parse(System.Configuration.ConfigurationManager.AppSettings["port"]));
            this._objDependancy = new LinkedList<IMemcachedDependancy>();
            this._objThreadPool =
                new SmartThreadPool(
                    int.Parse(System.Configuration.ConfigurationManager.AppSettings["threadIdleTime"]),
                    int.Parse(System.Configuration.ConfigurationManager.AppSettings["maxThreads"]),
                    int.Parse(System.Configuration.ConfigurationManager.AppSettings["minThreads"]));
            this._objClientQueue = new Queue<PooledTcpClient>();
            this._objMemDepFile = new Dictionary<string, IMemcachedDependancy>();
            //this._objMemDepKey = new Dictionary<string, IMemcachedDependancy>();

            #region Comments
            //this._objTimer = new System.Timers.Timer();
            //this._objTimer.Interval = int.Parse(System.Configuration.ConfigurationManager.AppSettings["keyTimeoutPoolValue"]);
            //this._objTimer.Elapsed += new ElapsedEventHandler(_objTimer_Elapsed);
            //this._objTimer.Enabled = true;
            #endregion
        }

        #endregion

        #region TCP/IP request response functions
        private void SendErrorMessage(NetworkStream objStream)
        {
            ArraySegment<byte> objResponse = GetCommandBuffer("ERROR");
            Write(objResponse.Array, objResponse.Offset, objResponse.Count, objStream);

            Console.WriteLine("Sending Error response....");
        }

        private void SendSuccessMessage(NetworkStream objStream)
        {
            ArraySegment<byte> objResponse = GetCommandBuffer("STORED");
            Write(objResponse.Array, objResponse.Offset, objResponse.Count, objStream);
            Console.WriteLine("Sending Success response....");
        }

        public static ArraySegment<byte> GetCommandBuffer(string value)
        {
            int valueLength = value.Length;
            byte[] data = new byte[valueLength + 2];

            Encoding.ASCII.GetBytes(value, 0, valueLength, data, 0);

            data[valueLength] = 13;
            data[valueLength + 1] = 10;

            return new ArraySegment<byte>(data);
        }

        public static void Write(byte[] data, int offset, int length, NetworkStream objStream)
        {
            objStream.Write(data, offset, length);
        }

        private string ReadLine(NetworkStream inputStream)
        {
            MemoryStream ms = new MemoryStream(50);

            bool gotR = false;
            byte[] buffer = new byte[1];

            int data;

            try
            {
                while (true)
                {
                    data = inputStream.ReadByte();
                    if (data == 13)
                    {
                        gotR = true;
                        continue;
                    }

                    if (gotR)
                    {
                        if (data == 10)
                            break;

                        ms.WriteByte(13);

                        gotR = false;
                    }

                    ms.WriteByte((byte)data);
                }
            }
            catch (IOException)
            {
                throw;
            }

            string retval = Encoding.ASCII.GetString(ms.GetBuffer(), 0, (int)ms.Length);

            return retval;
        }
        #endregion

        #region WorkItemCallback methods

        /// <summary>
        /// This function processes any file changes in the specified directory
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected object ProcessFileEvent(object obj)
        {
            string strFileName = (string)obj;
            IMemcachedDependancy objDependancy = null;

            // Lock the queue for processing
            lock (_objMemDepFileLock)
            {
                if (this._objMemDepFile.ContainsKey(strFileName) == true)
                {
                    objDependancy = this._objMemDepFile[strFileName];

                    this._objMemDepFile.Remove(strFileName);
                    Console.WriteLine("Item removed from Process Queue...");
                }
            }

            if (objDependancy != null)
            {
                foreach (string str in objDependancy.DependancyKeys)
                {
                    // Removing Key from memcached
                    _objMemcachedClient.Remove(str);
                    Console.WriteLine("Memcached Key {0} removed...", str);
                }
            }

            return null;
        }

        /// <summary>
        /// This functions constantly check for new requests
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected object CheckForRequest(object obj)
        {
            Console.WriteLine("Checking TCP Client...");
            Console.WriteLine();

            byte[] objData = new byte[1024];
            TcpClient objClient = null;
            PooledTcpClient objPoolClient = null;

            while (true)
            {
                if (this._objClientQueue.Count > 0)
                {
                    lock (_objSocketLock)
                    {
                        //Console.WriteLine("/--------------------Size of Socket Queue: {0}--------------------------/", this._objClientQueue.Count);
                        if (this._objClientQueue.Count > 0)
                        {
                            objPoolClient = this._objClientQueue.Dequeue();
                            objClient = objPoolClient.TCPClient;

                            if (objPoolClient.CanCloseClient() == true) // we can remove this socket
                            {
                                continue;
                            }


                            if ((objClient.Client.Connected == true))
                            {
                                if (objClient.Available > 0)
                                {
                                    this._objThreadPool.QueueWorkItem(new WorkItemCallback(ProcessDependancyRequest), objClient, WorkItemPriority.Highest);
                                }
                                else
                                {
                                    objPoolClient.Increment();
                                    this._objClientQueue.Enqueue(objPoolClient);
                                    Thread.Sleep(RandomSleep()); // get a random number
                                }
                            }
                        }
                        else
                        {
                            Thread.Sleep(RandomSleep()); // get a random number
                            continue;
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("Putting Thread to Sleep.......");
                    Thread.Sleep(RandomSleep()); // get a random number
                }
            }
        }

        /// <summary>
        /// Processes client request
        /// </summary>
        /// <param name="obj">null</param>
        /// <returns>null</returns>
        protected object ProcessDependancyRequest(object obj)
        {
            #region Processing Request
            TcpClient objClient = (TcpClient)obj;
            NetworkStream objStream = objClient.GetStream();
            string str = string.Empty;

            try
            {
                str = this.ReadLine(objStream);

                try
                {
                    bool bResult = false;

                    IMemcachedDependancy objDep = DependancyParser.ProcessCommand(str);

                    if (objDep == null)
                        throw new Exception();

                    if (objDep.Type == MemcachedDependancy.File)
                    {
                        lock (_objMemDepFileLock)
                        {
                            if (this._objMemDepFile.ContainsKey(objDep.KeyToIndex) == false)
                            {
                                this._objMemDepFile.Add(objDep.KeyToIndex, objDep);
                            }
                            else
                            {
                                this._objMemDepFile[objDep.KeyToIndex] = objDep;
                            }

                            bResult = true;
                        }
                    }

                    #region Comments
                    //else if(objDep.Type == MemcachedDependancy.OtherKey)
                    //{
                    //    lock (_objMemDepKeyLock)
                    //    {
                    //        if (this._objMemDepKey.ContainsKey(objDep.KeyToIndex) == false)
                    //        {
                    //            this._objMemDepKey.Add(objDep.KeyToIndex, objDep);
                    //        }
                    //        else
                    //        {
                    //            this._objMemDepKey[objDep.KeyToIndex] = objDep;
                    //        }

                    //        bResult = true;
                    //    } 
                    //}
                    #endregion

                    if (bResult == true)
                    {
                        SendSuccessMessage(objStream);
                    }
                    else
                    {
                        SendErrorMessage(objStream);
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    SendErrorMessage(objStream);
                    throw;
                }

                objStream.Flush();

                Console.WriteLine();
                Console.WriteLine("Putting the TCP client back in queue.....");

                lock (_objSocketLock)
                {
                    this._objClientQueue.Enqueue(new PooledTcpClient(objClient, this._iCounterLimit));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Exception occured....connection closed: " + err);
            }
            #endregion

            return null;
        }

        /// <summary>
        /// Initializes and starts the server
        /// </summary>
        /// <param name="obj">null</param>
        /// <returns>null</returns>
        protected object StartListener(object obj)
        {
            // Start the TCP/IP server
            this._objListener.Start();
            Console.WriteLine("Server Starting....port:" + System.Configuration.ConfigurationManager.AppSettings["port"]);

            #region Creating filesystem watcher
            this._objFileSystemWatcher = new FileSystemWatcher(System.Configuration.ConfigurationManager.AppSettings["directory"]);
            this._objFileSystemWatcher.Filter = System.Configuration.ConfigurationManager.AppSettings["fileTypeToMonitor"];
            this._objFileSystemWatcher.EnableRaisingEvents = true;
            this._objFileSystemWatcher.IncludeSubdirectories = false;
            this._objFileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;

            this._objFileSystemWatcher.Changed += new FileSystemEventHandler(_objFileSystemWatcher_Changed);
            this._objFileSystemWatcher.Error += new ErrorEventHandler(_objFileSystemWatcher_Error);
            this._objFileSystemWatcher.Renamed += new RenamedEventHandler(_objFileSystemWatcher_Renamed);
            this._objFileSystemWatcher.Deleted += new FileSystemEventHandler(_objFileSystemWatcher_Deleted);
            #endregion

            // Create a thread that constantly monitors the sockets if they have data
            this._objThreadPool.QueueWorkItem(new WorkItemCallback(CheckForRequest));

            while (true)
            {
                Console.WriteLine("Server is listening for client connections...");
                TcpClient objClient = this._objListener.AcceptTcpClient();

                // Locks the socket queue to add new connection
                lock (_objSocketLock)
                {
                    objClient.ReceiveTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["socketKeepAliveTime"]); //Timeout
                    this._objClientQueue.Enqueue(new PooledTcpClient(objClient, this._iCounterLimit));
                    Console.WriteLine("TCP Client count: " + this._objClientQueue.Count);
                }
            }
        }

        #region Comments
        /// <summary>
        /// This function processes Key polling WorkItemCallback
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //protected object ProcessKeyEvent(object obj)
        //{
        //    IMemcachedDependancy objKeyDep = (IMemcachedDependancy)obj;

        //    Console.WriteLine("------------------------{0}------------------------" , DateTime.Now);
        //    Console.WriteLine("Key expired: "+ objKeyDep.KeyToIndex);

        //    foreach (string str in objKeyDep.DependancyKeys)
        //    {
        //        Console.WriteLine("Dependanct Key: "+ str);
        //    }

        //    lock (this._objMemDepKey)
        //    {
        //        this._objMemDepKey.Remove(objKeyDep.KeyToIndex);
        //    }

        //    return null;
        //}
        #endregion

        /// <summary>
        /// This function gets a random number between 250 and 750
        /// </summary>
        /// <returns>int</returns>
        protected int RandomSleep()
        {
            return (new System.Random()).Next(250, 750);
        }

        #endregion

        #region IDependancyServer Members

        public void Start()
        {
            this._objThreadPool.Start();
            this._objThreadPool.QueueWorkItem(new WorkItemCallback(StartListener), null);
        }

        public void Stop()
        {
            this._objListener.Stop();
            this._objThreadPool.Shutdown();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this._objDependancy.Clear();
            this._objListener = null;
        }

        #endregion
    }
}

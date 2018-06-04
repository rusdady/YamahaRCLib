///***********************************************
/// Class implements functionality to send request 
/// to a receiver and get response back from receiver.
/// Commands are taken from "Cmd_List" node from 
/// receiver's initial response.
///***********************************************
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Xml.Linq;
using YamahaAVLib.Config;
using YamahaAVLib.ENums;
using YamahaAVLib.EveArgs;
using YamahaAVLib.Net;
using YamahaAVLib.YNC;

namespace YamahaAVLib.Classes
{
    /// <summary>
    /// Class implements functionality to send request to a receiver and get response back from receiver.
    /// Commands are taken from &lt;Cmd_List&gt; node from receiver's initial response.
    /// </summary>
    public class Communication : YNCFunctionBuilder
    {
        #region Declarations
        public delegate void HandlerResponseReceived(object sender, CommEventArgs e);
        public delegate void HandlerStatusCheck(object sender, CommEventArgs e);

        /// <summary>
        /// Fires when request completed
        /// </summary>
        public event HandlerResponseReceived OnResponseReceived;

        //private string _hostNameorAddress = "";

        public XElement UnitDescription { get; set; }

        System.Timers.Timer statusTimer = new System.Timers.Timer(Atomics.StatusCheckInterval);
        #endregion


        #region Constructor implemetation
        /// <summary>
        /// Constructor initializes connection and gets initial unit description.
        /// HandlerReponseReceived delegate is optional, if implemented it should
        /// have following signature (object sender, CommEventArgs e).
        /// Unit response stored in static YNCCommand.UnitDescription property.
        /// </summary>
        /// <param name="hostNameorAddress">Host name or IP address of the AV receiver</param>
        /// <param name="onResponseReceived">Method name with signature (object sender, CommEventArgs e)</param>
        public Communication(string hostNameorAddress, HandlerResponseReceived onResponseReceived = null) : base(hostNameorAddress)
        {
            Atomics.HostNameOrIPAddress = hostNameorAddress;
            if (onResponseReceived != null) this.OnResponseReceived += onResponseReceived;
            RequestUnitDescription(hostNameorAddress);
        }

        /// <summary>
        /// Constructor does not request unit description.It simply passes value of hostNameorAddress variable
        /// to private _hostNameorAddress variable for future requests.
        /// </summary>
        public Communication(string hostNameorAddress) : base(hostNameorAddress)
        {
            Atomics.HostNameOrIPAddress = hostNameorAddress;
        }
        public Communication() : base(Atomics.HostNameOrIPAddress)
        {

        }


        /// <summary>
        /// Pings IP address of the unit before connect to it. If receiver is on or in sleep it returns true otherwise false.
        /// </summary>
        /// <param name="ipAddress">string, IP address of the receiver</param>
        /// <returns>If receiver is on or in sleep it returns true otherwise false</returns>
        private bool PingIpAddress(string ipAddress)
        {
            Ping ping = new Ping();
            //IPAddress address = IPAddress.Parse(ipAddress);
            PingReply reply = ping.Send(ipAddress);


            if (reply.Status == IPStatus.Success) return true;
            else return false;
        }

        /// <summary>
        /// Pings IP address as many times as defined in attempts parameter
        /// </summary>
        /// <param name="attempts">how many times ping ip address</param>
        /// <param name="ipAddress">ip address of the receiver</param>
        /// <returns>true if success, otherwise false</returns>
        private bool PingIpAddress(int attempts, string ipAddress)
        {
            bool result = false;

            for(int i=0; i<attempts; i++)
            {
                Thread.Sleep(500);

                if(PingIpAddress(ipAddress))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Method implements initial request. Returned result sets to Atomics.UnitDescription property and
        /// to internal this._xmlDescription variable.
        /// </summary>
        /// <param name="hostNameorAddress">Host name or IP address of the AV receiver</param>
        public bool RequestUnitDescription(string hostNameorAddress)
        {
            Atomics.HostNameOrIPAddress = hostNameorAddress;

            bool result = false;
            try
            {
                if (PingIpAddress(3, hostNameorAddress) == true)
                {
                    string ynccmd = YNCCommand.CreateCommand(MethodType.NONE);

                    Atomics.UnitDescription = Http.Send(hostNameorAddress, Atomics.UnitDescriptionPath, HttpMethod.Get, ynccmd);
                    UnitDescription = Atomics.UnitDescription;
                    OnResponseReceived?.Invoke(this, new CommEventArgs() { Success = true, UnitDescription = Atomics.UnitDescription, YNCFunction = CommandListFunctionType.UnitDescription });

                    result = true;
                }
                else throw new Exception("Receiver is not accessible.");
            }
            catch (Exception ex)
            {
                OnResponseReceived?.Invoke(this, new CommEventArgs() { Success = false, ErrorMessage = ex.Message, YNCFunction = CommandListFunctionType.UnitDescription });
            }

            return result;
        } 
        #endregion

        /// <summary>
        /// Method creates YNC command, sends it to AV unit, and returns response
        /// </summary>
        /// <param name="cmd">YNCCommand.CommandType type</param>
        /// <param name="path">Sequential presentation of YNC function: System,Misc,Network,Network_Name</param>
        /// <returns>XElement response</returns>
        internal XElement SendYNCCommand(MethodType cmd, string path, object value = null)
        {
            string ynccmd = YNCCommand.CreateCommand(cmd, path, value);

            return Http.Send(Atomics.HostNameOrIPAddress, Atomics.RemoteControlPath, YamahaAVLib.ENums.HttpMethod.Post, ynccmd);
        }


    }
}


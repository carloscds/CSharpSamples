using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace NetworkCardInfo
{
    public class NetworkCardUtil
    {
        public string ConfiguracaoRede()
        {
            StringBuilder rede = new StringBuilder();
            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            rede.Append($" Computador: {Environment.MachineName}{Environment.NewLine}");
            rede.Append($"Endereço IP: {GetIP()}");
            rede.Append($"{Environment.NewLine}");
            foreach (NetworkInterface Interface in Interfaces)
            {
                if (Interface.OperationalStatus != OperationalStatus.Up) continue;
                if (Interface.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;
                rede.Append(Interface.Description + Environment.NewLine);
                UnicastIPAddressInformationCollection UnicastIPInfoCol = Interface.GetIPProperties().UnicastAddresses;
                var dns = Interface.GetIPProperties().DnsAddresses;
                var gateway = Interface.GetIPProperties().GatewayAddresses;
                foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol)
                {
                    rede.Append($"\tEndereço IP{(UnicatIPInfo.IPv4Mask.ToString() == "0.0.0.0" ? "v4" : "v6")}: {UnicatIPInfo.Address}{Environment.NewLine}");
                    rede.Append($"\tSubnet Mask: {UnicatIPInfo.IPv4Mask}{Environment.NewLine}");
                    foreach (var d in gateway)
                    {
                        rede.Append($"\tGateway: {d.Address.ToString()}{Environment.NewLine}");
                    }
                    foreach (var d in dns)
                    {
                        rede.Append($"\tDNS: {d.ToString()}{Environment.NewLine}");
                    }
                    rede.Append($"{Environment.NewLine}");
                }
            }
            return rede.ToString();
        }
        public string GetIP()
        {
            string IP = "0.0.0.0";

            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                foreach(var ip in ipHostInfo.AddressList)
                {
                    if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        IP = ip.ToString();
                        break;
                    }
                }
            }
            catch
            {
                IP = "0.0.0.0";
            }
            return IP;
        }

    }
}
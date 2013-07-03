using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net;
using Windows.Data.Json;

namespace com.nuclearpowered.SimpServ
{
    class JSONAPI
    {
        private string host;
        private int port;
        private string username;
        private string password;
        private string salt;

        private string urlFormat_call = "http://{0}:{1}/api/call?method={2}&args={3}&key={4}";
        private string urlFormat_callMultiple = "http:/{0}:{1}/api/call-multiple?method={2}&args={3}&key={4}";

        public JSONAPI(string par1, int par2, string par3, string par4, string par5)
        {
            this.host = par1;
            this.port = par2;
            this.username = par3;
            this.password = par4;
            this.salt = par5;
        }

        public JsonValue call(string method, Array args)
        {
            if (args != null)
            {
                string sArgs = ArrayToJSON(args);
            }
        }

        private string ArrayToJSON(Array par1)
        {
            string output = "[";
            foreach (string s in par1)
            {
                if (output != "[")
                    output += ",";
                output += '"' + s + '"';
            }
            output += "]";
            return output;
        }
    }
}

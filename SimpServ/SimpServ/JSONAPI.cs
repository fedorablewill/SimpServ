﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net;
<<<<<<< HEAD
using Windows.Data.Json;

namespace com.nuclearpowered.SimpServ
=======
using System.Net.Http;
using Windows.Data.Json;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;
using Windows.UI.Popups;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace SimpServ
>>>>>>> Created graphics, login splash, and communicator
{
    class JSONAPI
    {
        private string host;
        private int port;
        private string username;
        private string password;
        private string salt;

        private string urlFormat_call = "http://{0}:{1}/api/call?method={2}&args={3}&key={4}";
<<<<<<< HEAD
        private string urlFormat_callMultiple = "http:/{0}:{1}/api/call-multiple?method={2}&args={3}&key={4}";
=======
        //private string urlFormat_callMultiple = "http:/{0}:{1}/api/call-multiple?method={2}&args={3}&key={4}";
>>>>>>> Created graphics, login splash, and communicator

        public JSONAPI(string par1, int par2, string par3, string par4, string par5)
        {
            this.host = par1;
            this.port = par2;
            this.username = par3;
            this.password = par4;
            this.salt = par5;
        }

<<<<<<< HEAD
        public JsonValue call(string method, Array args)
        {
            if (args != null)
            {
                string sArgs = ArrayToJSON(args);
            }
=======
        public JsonValue call(string method, string[] args)
        {
            string sArgs;
            if (args != null)
                sArgs = ArrayToJSON(args);
            else
                sArgs = "[]";

            string raw = this.username + method + this.password + this.salt;
            IBuffer input = CryptographicBuffer.ConvertStringToBinary(raw, BinaryStringEncoding.Utf8);

            // hash it...
            var hasher = HashAlgorithmProvider.OpenAlgorithm("SHA256");
            IBuffer hashed = hasher.HashData(input);

            // format it...
            string key = CryptographicBuffer.EncodeToHexString(hashed);
            MessageDialog msg = new MessageDialog(key + " is key for " + raw);
            IAsyncOperation<IUICommand> x = msg.ShowAsync();

            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> resp = client.GetAsync(Uri.EscapeUriString(String.Format(urlFormat_call, host, port, Uri.EscapeUriString(method), Uri.EscapeUriString(sArgs), Uri.EscapeUriString(key))));

            JsonValue json = JsonValue.Parse(resp.Result.Content.ReadAsStringAsync().Result);

            return json;
>>>>>>> Created graphics, login splash, and communicator
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

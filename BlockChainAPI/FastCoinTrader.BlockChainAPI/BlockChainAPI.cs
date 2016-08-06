using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API.CreateWallet;
using NBitcoin;
using System.Net;
using System.IO;

namespace FastCoinTrader.BlockChainAPI
{
    public class BlockChainAPI
    {
        public static bool CreateWalletForUser(string username,string password)
        {
            //Info.Blockchain.API.CreateWallet.WalletCreator creator = new WalletCreator(string.Empty);
            Key privateKey = new Key(); //generate a private key for this user...
            string label = "Main address";
            BitcoinSecret testNetPrivateKey = privateKey.GetBitcoinSecret(Network.TestNet);
            //Create request and get response.
            WebRequest request =  WebRequest.Create(String.Format("http://localhost:3000/api/v2/create?password={0}&api_code={1}&priv={2}&label={3}&email{4}", password,string.Empty,testNetPrivateKey.ToString(),label,username));
            request.ContentType = "application/x-www-form-urlencoded";
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            WebResponse response = request.GetResponse();

            //Create stream and reader to parse response
            Stream dataStream = response.GetResponseStream();            
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();          
            Console.WriteLine(responseFromServer);    
            reader.Close();
            response.Close();

            //TODO: create wallet entry with required details...
            return true;
        }

        private static void GetNetDetails(Key privateKey)
        {
            //TODO: Get required details and return that which is necessary.
            PubKey publicKey = privateKey.PubKey; //get public key for this privateKey
            var publicKeyHash = publicKey.Hash;

            //var mainNetAddress = publicKeyHash.GetAddress(Network.Main); //TODO: make use of this network once we are live

            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet); //For now use only the test network.
        }

        private static BitcoinPubKeyAddress GetPublicScriptKey(Key privateKey,Network netw)
        {
            return privateKey.PubKey.GetAddress(netw);
        }  
    }
}

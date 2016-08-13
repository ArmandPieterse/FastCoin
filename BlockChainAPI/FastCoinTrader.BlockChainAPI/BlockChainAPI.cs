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
        public static string CreateWalletForUser(string username,string password)
        {
            Key privateKey = new Key();
            PubKey pubKey = privateKey.PubKey;
            Network networkToUse = Network.TestNet; //change to main network when system goes live...

            var pubKeyHash = pubKey.Hash;
            BitcoinAddress userBitcoinAddress = GetTestNetDetails(pubKey);
            //BitcoinSecret secret = privateKey.GetBitcoinSecret(networkToUse);
            BitcoinSecret privateWifKey = privateKey.GetWif(networkToUse);
            //BitcoinSecret testing = new BitcoinSecret(privateWifKey.ToWif());   //privateWifKey.ToWif() save dit in die table as die user se secret key om als te generate.

            return privateWifKey.ToWif();
        }      


        private static BitcoinAddress GetTestNetDetails(PubKey pubKey)
        {
            //TODO: Get required details and return that which is necessary.           
            var publicKeyHash = pubKey.Hash;
            return publicKeyHash.GetAddress(Network.TestNet); //For now use only the test network.
        }

        private static BitcoinAddress GetMainNetDetails(PubKey pubKey)
        {
            //TODO: make use of this network once we are live
            var publicKeyHash = pubKey.Hash;
            return publicKeyHash.GetAddress(Network.Main);
        }
      

        private static BitcoinPubKeyAddress GetPublicScriptKey(Key privateKey,Network netw)
        {
            return privateKey.PubKey.GetAddress(netw);
        }  
    }
}

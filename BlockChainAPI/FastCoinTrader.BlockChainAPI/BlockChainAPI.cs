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
        private static Network networkToUse = Network.TestNet;
        IBitcoinService BitcoinService = new BitcoinService();
        public static ExtKey CreateWalletForUser()
        {
            ExtKey extKey = new ExtKey();
            return extKey;
        }  
        

        private static BitcoinAddress GetUserAddress(PubKey pubKey)
        {
            BitcoinAddress userBitcoinAddress = GetTestNetDetails(pubKey);
            return userBitcoinAddress;
        }

        //use this to get the receiving address.
        private static BitcoinAddress GetLinkedAddressByOrder(uint order, ExtPubKey pubkey, Network networkToUse)
        {
            BitcoinAddress tempAddress = pubkey.Derive(order).PubKey.GetAddress(networkToUse);
            return tempAddress;
        }

        public static string DoTransaction(string wifSecretFrom,byte[] fromCode,string wifSecretTo,string password)
        {            
            NBitcoin.TransactionBuilder tb = new TransactionBuilder();
            Transaction trans = tb.BuildTransaction(true);


            ExtKey myWallet = GetWallet(wifSecretFrom,fromCode);

            return "";
        }

        private static ExtKey GetWallet(string wif,byte[] code)
        {
            return new ExtKey(new BitcoinSecret(wif).PrivateKey, code);
        }

        private static ExtKey GetExtKey(byte[] seed)
        {
            ExtKey myWallet = new ExtKey(seed);            
            return myWallet;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API.CreateWallet;
using BitcoinLib;
using System.Net;
using System.IO;
using BitcoinLib.Auxiliary;
using BitcoinLib.ExceptionHandling.Rpc;
using BitcoinLib.Responses;
using BitcoinLib.Services.Coins.Base;
using BitcoinLib.Services.Coins.Bitcoin;
using NBitcoin;

namespace FastCoinTrader.BlockChainAPI
{
    
    public class BlockChainAPI
    {
        //private static readonly ICoinService CoinService = new BitcoinService(useTestnet: true);
        private static NBitcoin.Network networkToUse = NBitcoin.Network.TestNet;
        private static readonly ICoinService CoinService = new BitcoinService(useTestnet: true);
        //private static BitcoinLib.Services.CoinService serv = new BitcoinLib.Services.CoinService();
        //private static readonly ICoinService CoinService = new BitcoinService(useTestnet:true);
        //    <add key = "Bitcoin_DaemonUrl" value="http://localhost:8332" />
        //<add key = "Bitcoin_DaemonUrl_Testnet" value="http://localhost:18332" />
        //<add key = "Bitcoin_WalletPassword" value="MyWalletPassword" />
        //<add key = "Bitcoin_RpcUsername" value="MyRpcUsername" />
        //<add key = "Bitcoin_RpcPassword" value="MyRpcPassword" />
        public static ExtKey CreateWalletForUser(string username)
        {
            // need to get bitcoinliib working and install bitcoind on pc commandline interface...
            ExtKey extKey = new ExtKey();
            //string result = CoinService.SetAccount(extKey.PrivateKey.GetBitcoinSecret(networkToUse).GetAddress().ToString(), username);
            
            //Decimal myBalance = CoinService.GetBalance();           
            return extKey;
        }  
        
        public static string GetUserAddress(string wif)
        {
            BitcoinSecret secret = new BitcoinSecret(wif,networkToUse);
            return secret.GetAddress().ToString();
        }

        private string GetAccountNameForAddress(string address)
        {
            string accountName = CoinService.GetAccount(address);
            return accountName;
        }


        private static BitcoinAddress GetUserAddress(PubKey pubKey)
        {
            BitcoinAddress userBitcoinAddress = GetTestNetDetails(pubKey);
            return userBitcoinAddress;
        }

        //use this to get the receiving address.
        private static BitcoinAddress GetLinkedAddressByOrder(uint order, ExtPubKey pubkey, NBitcoin.Network networkToUse)
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
            return publicKeyHash.GetAddress(NBitcoin.Network.TestNet); //For now use only the test network.
        }

        private static BitcoinAddress GetMainNetDetails(PubKey pubKey)
        {
            //TODO: make use of this network once we are live
            var publicKeyHash = pubKey.Hash;
            return publicKeyHash.GetAddress(NBitcoin.Network.Main);
        }
      

        private static BitcoinPubKeyAddress GetPublicScriptKey(Key privateKey, NBitcoin.Network netw)
        {
            return privateKey.PubKey.GetAddress(netw);
        }  
    }
}

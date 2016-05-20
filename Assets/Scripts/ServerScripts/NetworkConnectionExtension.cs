using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

using System.Collections.Generic;
namespace NetworkClientExtensions
{
    public static class NetworkClientExtension
    {
        private static Dictionary<NetworkClient, string> mClientTable = new Dictionary<NetworkClient, string>();
        public static void AssignUniqueID(this NetworkClient con, string ID)
        {
            if(!mClientTable.ContainsKey(con))
            {
                mClientTable.Add(con, ID);
            }
        }
        public static string GetID(NetworkClient con)
        {
            return mClientTable[con];
        }
        public static void RemoveClient(this NetworkClient con)
        {
            mClientTable.Remove(con);
        }
    }
}
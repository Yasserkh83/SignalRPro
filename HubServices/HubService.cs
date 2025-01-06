﻿using System.Collections.Concurrent;

namespace SignalRPro.HubServices
{
    public class HubService
    {
        // A theard-safe dictionary to store the groups each connection is part of:
        public readonly IEnumerable<string> ChatGroups = ["Administrators", "Managers", "Users"];
        public readonly ConcurrentDictionary<string, string> ConnectionGroups = new();
        //public List<string> GetMembers(string groupName)
        //{
        //    List<string> allConnectionIds = [.. ConnectionGroups.Keys];
        //    List<string> groupMembers = [];
        //    foreach (var connectionId in allConnectionIds)
        //    {
        //        var group = ConnectionGroups.FirstOrDefault(x=>x.Key == connectionId).Value;
        //        if (Equals(groupName, group)) 
        //         groupMembers.Add(connectionId);
        //    }
        //    return groupMembers;
        //}

        public List<string> GetMembers(string groupName)
        {
            List<string> groupMembers = new List<string>();

            foreach (var kvp in ConnectionGroups)
            {
                if (Equals(groupName, kvp.Value))
                {
                    groupMembers.Add(kvp.Key);
                }
            }

            return groupMembers;
        }

        public bool ISUserInGroup(string connectionId)
        {
            ConnectionGroups.TryGetValue(connectionId, out string? connectedGroupName);
            if (string.IsNullOrEmpty(connectedGroupName))
                return false;
            else
                return true;
        }

        public bool FindGroupName(string groupName)
        {
            var group =ChatGroups.FirstOrDefault(groupName);
            if(string.IsNullOrEmpty(group))
                return false;
            else return true;
        }
        public string GetUserGroupName(string connectionId) => ConnectionGroups[connectionId];
        public IEnumerable<string> GetAvailableGroups() => ChatGroups;



    }
}

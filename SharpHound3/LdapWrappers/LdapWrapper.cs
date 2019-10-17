﻿using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using Newtonsoft.Json;
using SharpHound3.JSON;

namespace SharpHound3.LdapWrappers
{
    internal class LdapWrapper
    {
        private string _domain;

        internal LdapWrapper(SearchResultEntry entry)
        {
            SearchResult = entry;
            Aces = new ACL[0];
        }

        public string DisplayName { get; set; }
        public string ObjectIdentifier { get; set; }
        public string DistinguishedName { get; set; }

        public Dictionary<string, object> Properties = new Dictionary<string, object>();

        public ACL[] Aces { get; set; }

        internal string Domain
        {
            get => _domain ?? (_domain = Helpers.DistinguishedNameToDomain(DistinguishedName));
            set => _domain = value.ToUpper();
        }
        [JsonIgnore]
        public SearchResultEntry SearchResult { get; }

        public override string ToString()
        {
            return $"{DisplayName}";
        }
    }
}
﻿using System.Collections.Generic;
using System.Xml;
using IceWarpObjects.Helpers;
using IceWarpObjects.Rpc.Classes;
using IceWarpRpc.Utilities;

namespace IceWarpRpc.Responses
{
    /// <summary>
    /// Informational list of rules
    /// </summary>
    public class TRulesInfoListResponse : IceWarpResponse
    {
        /// <summary>
        /// Current offset in the list.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Overall count of domains in the list.
        /// </summary>
        public int OverallCount { get; set; }
        /// <summary>
        /// List Of TRuleInfo. See <see cref="TRuleInfo"/> for more information.
        /// </summary>
        public List<TRuleInfo> Items { get; set; }

        public TRulesInfoListResponse(HttpRequestResult httpRequestResult)
            : base(httpRequestResult)
        {
        }

        public override void ProcessResultNode(XmlNode node)
        {
            Items = new List<TRuleInfo>();
            if (node != null)
            {
                Offset = Extensions.GetNodeInnerTextAsInt(node.GetSingleNode("Offset"));
                OverallCount = Extensions.GetNodeInnerTextAsInt(node.GetSingleNode("OverallCount"));
                var items = node.GetNodes("item");
                if (items != null)
                {
                    foreach (XmlNode item in items)
                    {
                        Items.Add(new TRuleInfo(item));
                    }
                }
            }
        }
    }
}

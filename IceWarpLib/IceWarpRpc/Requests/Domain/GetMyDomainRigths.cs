﻿using System.Xml;
using IceWarpObjects.Helpers;
using IceWarpObjects.Rpc.Classes;
using IceWarpRpc.Exceptions;
using IceWarpRpc.Responses;
using IceWarpRpc.Utilities;

namespace IceWarpRpc.Requests.Domain
{
    /// <summary>
    /// Gets the rights for domain properties. See <see cref="IceWarpCommand{TPropertyRightList}"/> for return type.
    /// </summary>
    public class GetMyDomainRigths : IceWarpCommand<TPropertyRightListResponse>
    {
        /// <summary>
        /// Domain name
        /// </summary>
        public string DomainStr { get; set; }
        /// <summary>
        /// Specifies the domains properties you want to get rights for
        /// </summary>
        public TDomainPropertyList DomainPropertyList { get; set; }

        protected override void BuildCommandParams(XmlDocument doc, XmlElement command)
        {
            var commandParams = XmlHelper.CreateElement(doc, "commandparams");

            XmlHelper.AppendTextElement(commandParams, "domainstr", DomainStr);
            if (DomainPropertyList != null)
            {
                commandParams.AppendChild(DomainPropertyList.BuildXmlElement(doc, "domainpropertylist"));
            }

            command.AppendChild(commandParams);
        }

        /// <summary>
        /// Generates the response from the HTTP request result.
        /// </summary>
        /// <param name="httpRequestResult">The HTTP request result.</param>
        /// <returns>The response from IceWarp. See <see cref="TPropertyRightListResponse"/> for more information.</returns>
        /// <exception cref="ProcessResponseException"> Thrown if HttpRequestResult is null, if HttpRequestResult.Response is null or empty or an exception occurs when loading the XML.</exception>
        /// <exception cref="IceWarpErrorException">Thrown if IceWarp returned and error.</exception>
        public override TPropertyRightListResponse FromHttpRequestResult(HttpRequestResult httpRequestResult)
        {
            return new TPropertyRightListResponse(httpRequestResult);
        }
    }
}

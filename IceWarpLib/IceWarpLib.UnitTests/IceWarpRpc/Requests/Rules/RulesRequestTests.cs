﻿using System;
using System.IO;
using System.Linq;
using System.Xml;
using IceWarpLib.Objects.Helpers;
using IceWarpLib.Objects.Rpc.Classes.Rule;
using IceWarpLib.Objects.Rpc.Classes.Rule.Actions;
using IceWarpLib.Objects.Rpc.Classes.Rule.Conditions;
using IceWarpLib.Objects.Rpc.Enums;
using IceWarpLib.Rpc.Requests.Rule;
using IceWarpLib.Rpc.Utilities;
using NUnit.Framework;

namespace IceWarpLib.UnitTests.IceWarpRpc.Requests.Rules
{
    [TestFixture]
    public class RulesRequestTests
    {
        private readonly string _requestsTestDataPath = @"IceWarpRpc\Requests\Rules\TestData\Requests";
        private readonly string _responsesTestDataPath = @"IceWarpRpc\Requests\Rules\TestData\Responses";

        [TestFixtureSetUp]
        public void FixtureSetup() { }

        [SetUp]
        public void TestSetup() { }

        [TearDown]
        public void TestTearDown() { }

        [TestFixtureTearDown]
        public void FixtureTearDown() { }

        [Test]
        public void GetRule()
        {
            string expected = File.ReadAllText(Path.Combine(_requestsTestDataPath, "GetRule.xml"));
            var request = new GetRule
            {
                SessionId = "sid",
                Who = "test@testing.com",
                RuleID = 1
            };
            var xml = request.ToXml().InnerXmlFormatted();
            Assert.AreEqual(expected, xml);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(Path.Combine(_responsesTestDataPath, "GetRule.xml")));
            var response = request.FromHttpRequestResult(new HttpRequestResult { Response = doc.InnerXml });

            Assert.AreEqual("result", response.Type);
            Assert.AreEqual("Test", response.Title);
            Assert.True(response.Active);
            Assert.AreEqual(1, response.RuleID);

            Assert.AreEqual(1, response.Conditions.Items.Count);
            Assert.AreEqual(typeof(TRuleSomeWordsCondition), response.Conditions.Items.First().GetType());
            Assert.AreEqual(TRuleConditionType.CustomHeader, response.Conditions.Items.First().ConditionType);
            Assert.True(response.Conditions.Items.First().OperatorAnd);
            Assert.AreEqual(TRuleSomeWordsFunctionType.Regex, ((TRuleSomeWordsCondition)response.Conditions.Items.First()).MatchFunction);
            Assert.AreEqual("X-Priority: 2", ((TRuleSomeWordsCondition)response.Conditions.Items.First()).MatchValue);

            Assert.AreEqual(2, response.Actions.Items.Count);
            Assert.AreEqual(typeof(TRuleMessageActionAction), response.Actions.Items.First().GetType());
            Assert.AreEqual(TRuleActionType.MessageAction, response.Actions.Items.First().Actiontype);

            Assert.AreEqual(typeof(TRulePriorityAction), response.Actions.Items.Last().GetType());
            Assert.AreEqual(TRuleActionType.Priority, response.Actions.Items.Last().Actiontype);
        }

        [Test]
        public void GetRulesInfoList()
        {
            string expected = File.ReadAllText(Path.Combine(_requestsTestDataPath, "GetRulesInfoList.xml"));
            var request = new GetRulesInfoList
            {
                SessionId = "sid",
                Who = "testing.com",
                Filter = new TRulesListFilter
                {
                    NameMask = "test"
                }
            };
            var xml = request.ToXml().InnerXmlFormatted();
            Assert.AreEqual(expected, xml);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(Path.Combine(_responsesTestDataPath, "GetRulesInfoList.xml")));
            var response = request.FromHttpRequestResult(new HttpRequestResult { Response = doc.InnerXml });

            Assert.AreEqual("result", response.Type);
            Assert.AreEqual(2, response.Items.Count);
            Assert.AreEqual(typeof(TRuleTrustedSessionCondition), response.Items.First().Condition.GetType());
            Assert.AreEqual(typeof(TRuleHasAttachmentCondition), response.Items.Last().Condition.GetType());
        }


    }
}

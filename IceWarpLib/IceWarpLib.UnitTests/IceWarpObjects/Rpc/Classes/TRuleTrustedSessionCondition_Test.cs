﻿using IceWarpLib.Objects.Helpers;
using IceWarpLib.Objects.Rpc.Classes;
using IceWarpLib.Objects.Rpc.Classes.Rule;
using IceWarpLib.Objects.Rpc.Enums;
using NUnit.Framework;

namespace IceWarpLib.UnitTests.IceWarpObjects.Rpc.Classes
{
    public class TRuleTrustedSessionCondition_Test : BaseTest
    {
        private string _xml = @"
<custom xmlns=""admin:iq:rpc"">
    <classname>truletrustedsessioncondition</classname>
    <conditiontype>0</conditiontype>
    <operatorand>0</operatorand>
    <logicalnot>0</logicalnot>
    <bracketsleft>0</bracketsleft>
    <bracketsright>0</bracketsright>
</custom>".TrimStart();

        [Test]
        public void TRuleTrustedSessionCondition()
        {
            var testClass = new TRuleTrustedSessionCondition();

            var testXml = ToFormattedXml(testClass);
            Assert.AreEqual(_xml, testXml);
        }

        [Test]
        public void TRuleTrustedSessionCondition_BuildXmlElement()
        {
            var testClass = new TRuleTrustedSessionCondition(GetXmlNode(_xml));

            Assert.AreEqual(TRuleConditionType.None, testClass.ConditionType);
        }
    }
}

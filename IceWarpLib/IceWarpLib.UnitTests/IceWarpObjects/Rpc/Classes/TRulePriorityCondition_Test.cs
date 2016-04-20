﻿using IceWarpObjects.Rpc.Classes;
using IceWarpObjects.Rpc.Enums;
using NUnit.Framework;

namespace IceWarpLib.UnitTests.IceWarpObjects.Rpc.Classes
{
    public class TRulePriorityCondition_Test : BaseTest
    {
        private string _xml = @"
<custom xmlns=""admin:iq:rpc"">
    <classname>truleprioritycondition</classname>
    <conditiontype>0</conditiontype>
    <operatorand>0</operatorand>
    <logicalnot>0</logicalnot>
    <bracketsleft>0</bracketsleft>
    <bracketsright>0</bracketsright>
    <priority>0</priority>
</custom>".TrimStart();

        [Test]
        public void TRulePriorityCondition()
        {
            var testClass = new TRulePriorityCondition();

            var testXml = ToFormattedXml(testClass);
            Assert.AreEqual(_xml, testXml);
        }

        [Test]
        public void TRulePriorityCondition_BuildXmlElement()
        {
            var testClass = new TRulePriorityCondition(GetXmlNode(_xml));

            Assert.AreEqual(TRuleConditionType.None, testClass.ConditionType);
        }
    }
}

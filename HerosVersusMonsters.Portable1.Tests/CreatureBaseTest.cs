using System.Reflection;
// <copyright file="CreatureBaseTest.cs">Copyright ©  2015</copyright>

using System;
using HerosVersusMonsters.Portable;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerosVersusMonsters.Portable.Tests
{
    [TestClass]
    [PexClass(typeof(CreatureBase))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CreatureBaseTest
    {

        [PexMethod]
        [PexMethodUnderTest("RecalculateBonuses()")]
        internal void RecalculateBonuses([PexAssumeNotNull]CreatureBase target)
        {
            object[] args = new object[0];
            Type[] parameterTypes = new Type[0];
            object result = ((MethodBase)(typeof(CreatureBase).GetMethod("RecalculateBonuses",
                                                                         BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                         CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                                .Invoke((object)target, args);
            // TODO: add assertions to method CreatureBaseTest.RecalculateBonuses(CreatureBase)
        }
    }
}

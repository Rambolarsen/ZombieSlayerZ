using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.NUnit3;
using System;

namespace ZombieSlayerZ.UnitTests
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoFakeItEasyDataAttribute : AutoDataAttribute
    {
        public AutoFakeItEasyDataAttribute()
            : base(() => new Fixture().Customize(new AutoFakeItEasyCustomization()))
        {
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FakerLib.Interfaces;
using FakerLib.Generators;
using PluginLongGenerator;
using FakerLib;

namespace UnitTest
{

[TestClass]
public class UserFieldsTest
{

User user;
[TestInitialize]
public void Setup()
{
FakerLib.Faker faker = new FakerLib.Faker();
user = faker.Create<User>();
}
[TestMethod]

public void MoneyFieldTest()
{
Assert.AreEqual(user.money.GetType() == typeof(double), true, typeof(double).ToString() + " " + user.money.GetType());
}
[TestMethod]
public void NameFieldTest()
{
Assert.AreEqual(user.name.GetType() == typeof(string), true, "чё");
}
[TestMethod]
public void AgeFieldTest()
{
Assert.AreEqual(user.age.GetType() == typeof(int), true, "чё");
}
[TestMethod]
public void DateFieldTest()
{
Assert.AreEqual(user.date.GetType() == typeof(DateTime), true, "чё");
}

[TestMethod]
public void ProfileFieldTest()
{
Assert.AreEqual(user.profile == null, false, "чё");
}
[TestMethod]
public void DogsListTest()
{
Assert.AreEqual(user.dogs == null, false, "чё");
}

[TestMethod]
public void DogNameTest()
{

Assert.AreEqual(user.dogs[0].name.GetType() ==typeof(string), true, "чё");

}

[TestMethod]
public void DogLongValueTest()
{
Assert.AreEqual(user.dogs[0].longValue.GetType() ==typeof(long), true, user.dogs[0].longValue.ToString());

}

[TestMethod]
public void AddressTest()
{
Assert.AreEqual(user.profile.address.GetType() == typeof(string), true, user.profile.address.ToString());
}




}


[TestClass]
public class GeneratorsTest
{

[TestMethod]
public void CharGeneratorTest()
{
IGenerator generator = new CharGenerator();
object generated = generator.Create();
Assert.AreEqual(generated.GetType(), typeof(char));
}

[TestMethod]
public void StringGeneratorTest()
{
IGenerator generator = new StringGenerator();
object generated = generator.Create();
Assert.AreEqual(generated.GetType(), typeof(string));
}

[TestMethod]
public void IntGeneratorTest()
{
IGenerator generator = new IntGenerator();
object generated = generator.Create();
Assert.AreEqual(generated.GetType(), typeof(int));
}

[TestMethod]
public void DoubleGeneratorTest()
{
IGenerator generator = new CharGenerator();
object generated = generator.Create();
Assert.AreEqual(generated.GetType(), typeof(char));
}

[TestMethod]
public void LongGeneratorTest()
{
IGenerator generator = new LongGenerator();
object generated = generator.Create();
Assert.AreEqual(generated.GetType(), typeof(long), generated.ToString());
}
}

[TestClass]
public class PluginsTest
{
[TestMethod]
public void PluginLoadTest()
{
Dictionary<Type, IGenerator> plugins = new Dictionary<Type, IGenerator>();
PluginLoader loader = new PluginLoader(plugins);
loader.LoadPluginGeneratorsFromFiles();
Assert.AreEqual(plugins.Count, 2);
}
}



[TestClass]
public class UnitTest1
{







}
}
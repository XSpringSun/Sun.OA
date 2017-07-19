using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sun.OA.EFDAL;
using System.Linq;

namespace Sun.OA.UnitTest.DAL
{
    [TestClass]
    public class UserInfoDalTest
    {
        [TestMethod]
        public void TestGetUsers()
        {
            UserInfoDal dal = new UserInfoDal();

            for (int i = 0; i < 10; i++)
            {
                dal.Add(new Model.UserInfo
                {
                    UName = i + "User"
                });
            }
            IQueryable<Model.UserInfo> temp = dal.GetEntities(u => u.UName.Contains("User"));

            Assert.AreEqual(true, temp.Count() >= 10);
        }
    }
}

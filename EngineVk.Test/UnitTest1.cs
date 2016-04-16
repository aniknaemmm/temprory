using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineVk;
using System.Net;
using System.Collections.Generic;

namespace EngineVk.Test
{
    [TestClass]
    public class UnitTest1
    {
        CoreVk vk;

        public void initMethod()
        {
            vk = new CoreVk();
            vk.Init("+375257307554", "29730511");
        }

        public void disposeMethod()
        {
            vk.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
           initMethod();
           Assert.IsTrue(vk.authorize);
            disposeMethod();
        }



        [TestMethod]
        public void Getclient()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(@"https://pp.vk.me/c630320/v630320425/2aa5d/V8GTrijVdqI.jpg", @"C:\Users\INFINITY\Desktop\опуопоулое\temprory\fdf.jpg");
            }
        }


        [TestMethod]
        public void getUser()
        {
            initMethod();
            var user = vk.getUsers(1);
            Console.WriteLine(user.ToString());
            disposeMethod();
        }

        [TestMethod]
        public void getUsers()
        {
            initMethod();
            var usersId = new long[] { 16227876, 27189113 };
            var users = vk.getUsers(usersId);
            Assert.AreEqual(users.Count, 2);

        }
        //[TestMethod]
        //public void getUsersProfileField()
        //{
        //    initMethod();
        //    var user = vk.getUsers(145820810, VkNet.Enums.Filters.ProfileFields.Counters);
        //    Console.WriteLine(user.ToString());
        //    disposeMethod();

        //}TODO see code

        //[TestMethod]
        //public void getAudio()
        //{
        //    initMethod();
        //    vk.getAudio(16227876);
        //}TODO audio

        [TestMethod]
        public void getDialog()
        {
            initMethod();
            vk.getDialog();
        }

        [TestMethod]
        public void getMessagehistory()
        {
            initMethod();
            vk.getMessage();
        }

    }
}

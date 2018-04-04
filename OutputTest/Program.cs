﻿using DevelopHelpers;
using System;
using System.Collections.Generic;
using TestModel;


namespace QueueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\Project\MyTest\MyTest\OutputTest\bin\Debug\Test.xml";
            string bnpath = @"F:\Project\MyTest\MyTest\OutputTest\bin\Debug\bnTest.txt";
            ///启动队列
            BusinessInfoHelper.Instance.start(StartThread);
            BusinessInfoHelper.Instance.AddQueue("胡大帅3", "666666676666");
            BusinessInfoHelper.Instance.AddQueue("胡大帅","6666666666");
            BusinessInfoHelper.Instance.AddQueue("胡大帅2", "66664666666");

            List<SerializationModel> modellist = new List<SerializationModel>()
            {
                new SerializationModel() { name="just fly",passWord="flyboy"},
                new SerializationModel() { name="just fly1",passWord="flyboy1"},
                new SerializationModel() { name="just fly2",passWord="flyboy2"}
            };
            List<SerializationModel> nmodellist = new List<SerializationModel>();
            foreach (var item in modellist)
            {
                nmodellist.Add(BinarySerializationHelper.DeepClone(item));
            }
            modellist[1].name = "hu";
            SerializationModel model = BinarySerializationHelper.DeepClone(new SerializationModel() { name="just fly",passWord="flyboy"});

            XmlSerializationHelper.SerializeToXml<List<SerializationModel>>(modellist,path);
            var li= XmlSerializationHelper.DeSerializeToXml<List<SerializationModel>>(path);
            var ss = XmlSerializationHelper.SerializeToXml<List<SerializationModel>>(modellist);
            var sss = XmlSerializationHelper.DeSerializeToXml<List<SerializationModel>>(ss,false);
            
            var bt = BinarySerializationHelper.SerializeToByte(modellist);
            BinarySerializationHelper.SerializeToByte(modellist,bnpath);
            Console.Read();
        }

        private static void StartThread()
        {
            //throw new NotImplementedException();
        }
    }
}

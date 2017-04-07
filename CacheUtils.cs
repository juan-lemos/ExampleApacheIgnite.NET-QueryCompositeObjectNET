using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;
using Apache.Ignite.Core.Cache.Store;
using Apache.Ignite.Core.Common;
using Apache.Ignite.Core.Communication.Tcp;
using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

namespace testIgnite
{

    
    class CacheUtils
    {


        public static void startCache()
        {

            IgniteConfiguration cfg = new IgniteConfiguration
            {
                BinaryConfiguration = new BinaryConfiguration(typeof(TestObject), typeof(TestObjectPK))
                ,CommunicationSpi = new TcpCommunicationSpi
                {
                    LocalPort = 4321   // Override local port.
                }

            };



            using (var ignite = Ignition.Start(cfg))
            {
                
                ICache<TestObjectPK, TestObject> cache = ignite.GetOrCreateCache<TestObjectPK, TestObject>(
                    new CacheConfiguration("TestObject", new QueryEntity(typeof(TestObjectPK), typeof(TestObject))));
                

                TestObjectPK testObjectPK = new TestObjectPK();
                testObjectPK.NAME = "h1";
                testObjectPK.ID = 1;
                TestObject testObject = new TestObject();
                testObject.VALUE = "value1";
                cache.Put(testObjectPK, testObject);
                Console.WriteLine("==================I'm here =====================================");
               
                

                TestObjectPK findpk = new TestObjectPK();
                findpk.NAME = "h1";
                findpk.ID = 1;
                var fieldsQuery = new SqlFieldsQuery("select _val,_key from TestObject where NAME=? and VALUE=?", "h1","value1");
                

                IQueryCursor<IList> queryCursor = cache.QueryFields(fieldsQuery);
                foreach (IList fieldList in queryCursor)
                    Console.WriteLine(((TestObject)fieldList[0]).VALUE);
                
            }

        }



    }
}

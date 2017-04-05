using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testIgnite
{

    class TestObjectPK : IBinarizable
    {
        private Int32 id;
        private String name;

        [QuerySqlField]
        public string NAME
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [QuerySqlField]
        public Int32 ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public void WriteBinary(IBinaryWriter writer)
        {
            writer.WriteInt("ID", ID);
            writer.WriteString("NAME", NAME);
        }

        public void ReadBinary(IBinaryReader reader)
        {
            ID = reader.ReadInt("ID");
            NAME = reader.ReadString("NAME");
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() + name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return id == ((TestObjectPK)obj).id && name == ((TestObjectPK)obj).NAME;
        }
    }


    class TestObject : IBinarizable
    {
        private String value2;
        [QuerySqlField]
        public String VALUE
        {
            get { return this.value2; }
            set { this.value2 = value; }
        }

        public void WriteBinary(IBinaryWriter writer)
        {
            writer.WriteString("VALUE", VALUE);
        }

        public void ReadBinary(IBinaryReader reader)
        {
            // Read order does not matter, however, reading in the same order 
            // as writing improves performance          
            VALUE = reader.ReadString("VALUE");
        }

        public override int GetHashCode()
        {
            return VALUE.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return VALUE == ((TestObject)obj).VALUE;
        }

    }
}

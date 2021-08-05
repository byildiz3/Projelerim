using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings
{
   public class MongoDbSettings
    {
        public string ConnectionString;
        public string Database;

        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(Database);
    }
}

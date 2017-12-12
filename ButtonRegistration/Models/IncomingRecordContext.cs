using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ButtonRegistration.Models
{
    public class IncomingRecordContext : DbContext
    {
        public IncomingRecordContext() : base("incomingRecord")
        {

        }
        public DbSet<IncomingRecord> IncomingRecords { get; set; }
    }
}
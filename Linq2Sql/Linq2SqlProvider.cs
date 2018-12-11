using Comparison;
using System;

namespace Linq2Sql
{
    public class Linq2SqlProvider : Provider<METERING>
    {
        public Linq2SqlProvider(Metering[] meterings):base(meterings)
            { }

        public override string Name => "Linq2Sql";

        public override void ClearSource()
        {
            using (var context = new DataClassesDataContext())
            {
                context.METERINGs.DeleteAllOnSubmit(context.METERINGs);
                context.SubmitChanges();
            }
        }

        protected override void AddMultiple(METERING[] dataItems)
        {
            using (var context = new DataClassesDataContext())
            {
                context.METERINGs.InsertAllOnSubmit(dataItems);
                context.SubmitChanges();
            }
        }

        protected override void AddSingle(METERING item)
        {
            using (var context = new DataClassesDataContext())
            {
                context.METERINGs.InsertOnSubmit(item);
                context.SubmitChanges();
            }
        }

        protected override METERING[] CreateDataItems(Metering[] meterings)
        {
            return Array.ConvertAll(meterings,
                p => new METERING()
                {
                    IDOBJECT = p.IDOBJECT,
                    IDOBJECT_AVERAGE = p.IDOBJECT_AVERAGE,
                    IDTYPE_OBJECT = p.IDTYPE_OBJECT,
                    STATUS = p.STATUS,
                    TIME_BEGIN = p.TIME_BEGIN,
                    TIME_END = p.TIME_END,
                    VALUE_METERING = p.VALUE_METERING
                });
        }
    }
}

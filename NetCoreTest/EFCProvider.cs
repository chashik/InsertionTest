using System;

namespace NetCoreTest
{
    public class EFCProvider : Provider<METERING>
    {
        public override string Name => "EFCore";

        public EFCProvider(Metering[] meterings) : base(meterings)
            { }

        protected override void AddSingle(METERING item)
        {
            using (var context = new MyContext())
            {
                context.METERINGs.Add(item);
                context.SaveChanges();
            }
        }

        protected override void AddMultiple(METERING[] dataItems)
        {
            using (var context = new MyContext())
            {
                context.METERINGs.AddRange(dataItems);
                context.SaveChanges();
            }
        }

        public override void ClearSource()
        {
            using (var context = new MyContext())
            {
                context.METERINGs.RemoveRange(context.METERINGs);
                context.SaveChanges();
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

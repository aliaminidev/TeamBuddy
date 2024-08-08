using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class BaseData : BaseDomainEntity<long>
    {
        // MaxLength : 100
        public string Name { get; set; }

        // MaxLength : 1000
        public string? Description { get; set; }

        public BaseDataType DataType { get; set; }

        public long? ParentId { get; set; }
        public BaseData Parent { get; set; }
    }

    public enum BaseDataType
    {
        // رشته های ورزشی
        Sport,
        // استان
        Province,
        // شهر
        City,
        // مکان ها
        Location,
        // تیم هایی که حریف تیم های موجود در سایت هستند
        Team,
        // معیارهای متفاوت نمره دهی به عملکرد بازیکنان
        PlayerPerformanceMatric,
        // انواع مصدومیت
        InjuryType,
    }
}

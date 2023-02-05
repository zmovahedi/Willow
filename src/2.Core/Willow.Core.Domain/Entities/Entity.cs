using Willow.Core.Domain.ValueObjects;

namespace Willow.Core.Domain.Entities
{
    public abstract class Entity<TId>
    {
        /// <summary>
        /// شناسه عددی Entityها
        /// صرفا برای ذخیره در دیتابیس و سادگی کار مورد استفاده قرار بگیرید.
        /// </summary>
        public virtual TId Id { get; protected set; }

        /// <summary>
        /// شناسه Entity
        /// شناسه اصلی Entity که در همه جا باید مورد استفاده قرار گیرد BusinessId است.
        /// تمامی ارتباطات به کمک این شناسه باید برقرار شود.
        /// </summary>
        public BusinessId BusinessId { get; protected set; } = BusinessId.FromGuid(Guid.NewGuid());

        /// <summary>
        /// سازنده پیش‌فرض به صورت Protected تعریف شده است.
        /// با توجه به اینکه این نیاز است هنگام ساخت خواص اساسی Entity ایجاد شود، هیچ شی بدون پر کردن این خواص نباید ایجاد شود.
        /// بار جلو گیری از این مورد برای همه Entityها باید سازنده‌هایی تعریف شود که مقدار ورودی دارند.
        /// برای اینکه بتوان از همین Entityها برای فرایند ذخیره سازی و بازیابی از دیتابیس به کمک ORMها استفاده کرد، ضروری است که سازنده پیش‌فرض با سطح دسترسی بالا مثل Protected یا Private ایجاد شود.
        /// </summary>
        protected Entity() { }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TId> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (IsTransient() || other.IsTransient())
                return false;

            return Id.Equals(other.Id);
        }

        private bool IsTransient()
        {
            return Id is null || Id.Equals(default(TId));
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }

    public abstract class Entity : Entity<int>
    {
        protected Entity()
        {
        }

        protected Entity(int id)
            : base(id)
        {
        }
    }
}

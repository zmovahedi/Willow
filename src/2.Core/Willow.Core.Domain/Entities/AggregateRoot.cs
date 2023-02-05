﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Willow.Core.Domain.Events;

namespace Willow.Core.Domain.Entities
{
    public abstract class AggregateRoot : Entity
    {
        /// <summary>
        /// لیست Evantهای مربوطه را نگهداری می‌کند        
        /// </summary>
        private readonly List<IDomainEvent> _events;
        protected AggregateRoot() => _events = new();

        /// <summary>
        /// سازنده Aggregate برای ایجاد Aggregate از روی Eventها
        /// </summary>
        /// <param name="events">در صورتی که Event از قبل وجود داشته باشد توسط این پارامتر به Aggregate ارسال می‌گردد</param>
        public AggregateRoot(IEnumerable<IDomainEvent> events)
        {
            if (events == null || !events.Any()) return;
            foreach (var @event in events)
            {
                Mutate(@event);
            }
        }

        protected void Apply(IDomainEvent @event)
        {
            Mutate(@event);
            AddEvent(@event);
        }

        private void Mutate(IDomainEvent @event)
        {
            var onMethod = this.GetType().GetMethod("On", BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { @event.GetType() });
            onMethod.Invoke(this, new[] { @event });
        }

        /// <summary>
        /// یک Event جدید به مجموعه Eventهای موجود در این Aggregate اضافه می‌کند.
        /// مسئولیت ساخت و ارسال Event به عهده خود Aggregateها می‌باشد.
        /// </summary>
        /// <param name="event"></param>
        protected void AddEvent(IDomainEvent @event) => _events.Add(@event);

        /// <summary>
        /// لیستی از Eventهای رخداده برای Aggregate را به صورت فقط خواندی و غیر قابل تغییر را بازگشت می‌دهد
        /// </summary>
        /// <returns>لیست Eventها</returns>
        public IEnumerable<IDomainEvent> GetEvents() => _events.AsEnumerable();

        /// <summary>
        /// Eventهای موجود در این Aggregate را پاک می‌کند
        /// </summary>
        public void ClearEvents() => _events.Clear();
    }
}

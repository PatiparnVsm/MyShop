using System;

namespace MyShop.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now;
        }
    }
}

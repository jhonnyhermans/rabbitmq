using System;
using System.Collections.Generic;
using System.Text;

namespace JH.RabbitMq.Domain
{
    public class SomeData
    {
        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }


        public bool IsValid()
        {
            return true;
        }

        public static class Factory
        {
            public static SomeData CreateNew(string content)
            {
                return new SomeData()
                {
                    Id = Guid.NewGuid(),
                    Content = content,
                    CreateDate = DateTime.Now
                };
            }
        }
    }
}

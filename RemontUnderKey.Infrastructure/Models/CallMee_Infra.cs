using System;

namespace RemontUnderKey.Infrastructure.Models
{
    public class CallMee_Infra
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime DateStamp { get; set; }
        public string Comments { get; set; }
        public bool CallIsDone { get; set; }
    }
}

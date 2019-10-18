using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberAPI.Enums
{
    [Flags]
    public enum Subscription
    {
        Delivered = 1 << 0,
        Seen = 1 << 1,
        Failed = 1 << 2,
        Subscribed = 1 << 3,
        Unsubscribed = 1 << 4,
        ConversationStarted = 1 << 5,
        All = ~(~0 << 6)
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberAPI.Enums
{
    public enum StatusCode
    {
        OK,
        InvalidUrl,
        InvalidAuthToken,
        BadData,
        MissingData,
        ReceiverNotRegistered,
        ReceiverNotSubscribed,
        PublicAccountBlocked,
        PublicAccountNotFound,
        PublicAccountSuspended,
        WebhookNotSet,
        ReceiverNoSuitableDevice,
        TooManyRequests,
        ApiVersionNotSupported,
        IncompatibleWithVersion,
        Other = 15
    }
}

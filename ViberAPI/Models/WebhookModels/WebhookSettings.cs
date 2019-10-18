using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViberAPI.Enums;
using ViberAPI.Models.DTO;

namespace ViberAPI.Models.WebhookModels
{
    public class WebhookSettings
    {
        public string Url { get; set; }
        public Subscription Subscription { get; set; }

        public static explicit operator WebhookSettingsDTO(WebhookSettings settings)
        {
            WebhookSettingsDTO dto = new WebhookSettingsDTO();
            dto.url = settings.Url;
            if (settings.Subscription == Subscription.All)
            {
                dto.event_types = eventTypes.Values.ToList();
            }
            else
            {
                List<string> events = new List<string>();
                int ops = (int)settings.Subscription;
                for (int i = 0; i < eventTypes.Count; i++)
                {
                    bool marked = (ops >> i & 1) == 1;
                    if (marked)
                    {
                        events.Add(eventTypes.ElementAt(i).Value);
                    }
                }
                dto.event_types = events;
            }
            return dto;
        }

        internal static readonly Dictionary<Subscription, string> eventTypes = new Dictionary<Subscription, string>()
        {
            { Subscription.Delivered, "delivered" },
            { Subscription.Seen, "seen" },
            { Subscription.Failed, "failed" },
            { Subscription.Subscribed, "subscribed" },
            { Subscription.Unsubscribed, "unsubscribed" },
            { Subscription.ConversationStarted, "conversation_started" }
        };
    }
}

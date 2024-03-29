﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MM.Model
{
    public enum AlertStatus
    {

        [Display(Name = "On Deck")]
        OnDeck,
        Executed,
        Closed,
        Triggered,
        Untriggered
    }
    public static class AlertStatusExtensions
    {
        public static string GetDescription(this AlertStatus value)
        {
            switch (value)
            {
                case AlertStatus.OnDeck: return "On Deck";
                case AlertStatus.Executed: return "Executed";
                case AlertStatus.Closed: return "Closed";
                case AlertStatus.Triggered: return "Triggered";
                case AlertStatus.Untriggered: return "Untriggered";
                default: throw new NotImplementedException();
            }
        }
    }
}

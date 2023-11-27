﻿using Business.Interfaces;

namespace Business.Notifications
{
    public class Notificator : INotificator
    {

        private List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
        public List<Notification> GetNotificatios()
        {
           
           return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }


}
